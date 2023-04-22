using Standard.API.RESTFulSense.Infrastructure.Build.Services;

namespace Standard.REST.RESTFulSense.Infrastructure.Build
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scriptGenerationService = new ScriptGenerationService();
            scriptGenerationService.GenerateBuildScript();
        }
    }
}