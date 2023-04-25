// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

namespace Standard.REST.RESTFulSense.Infrastructure.Build.Services
{
    internal class ScriptGenerationService
    {
        private readonly ADotNetClient adotNetClient;

        public ScriptGenerationService() =>
            adotNetClient = new ADotNetClient();

        public void GenerateBuildScript()
        {
            var githubPipeline = new GithubPipeline
            {
                Name = "Standard.REST.RESTFulSense Build",

                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { "main" }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "main" }
                    }
                },

                Jobs = new Jobs
                {
                    Build = new BuildJob
                    {
                        RunsOn = BuildMachines.WindowsLatest,

                        Steps = new List<GithubTask>
                        {
                            new CheckoutTaskV2
                            {
                                Name = "Pulling Code"
                            },

                            new SetupDotNetTaskV1
                            {
                                Name = "Installing .NET",

                                TargetDotNetVersion = new TargetDotNetVersion
                                {
                                    DotNetVersion = "7.0.201",
                                    IncludePrerelease = true
                                }
                            },

                            new RestoreTask
                            {
                                Name = "Restoring Packages"
                            },

                            new DotNetBuildTask
                            {
                                Name = "Building Solution"
                            },

                            new TestTask
                            {
                                Name = "Running Tests"
                            }
                        }
                    }
                }
            };

            string yamlRelativeFilePath = "../../../../.github/workflows/build.yml";
            string yamlFullPath = Path.GetFullPath(yamlRelativeFilePath);
            FileInfo yamlDefinition = new FileInfo(yamlFullPath);

            if (!yamlDefinition.Directory.Exists)
            {
                yamlDefinition.Directory.Create();
            }

            adotNetClient.SerializeAndWriteToFile(
                adoPipeline: githubPipeline,
                path: yamlRelativeFilePath);
        }
    }
}

