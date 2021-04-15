using Microsoft.Extensions.Configuration;
using System.IO;

namespace Common
{
    public class Configuration : IConfiguration
    {
        private readonly string loggingFilePath;
        public string LoggingFilePath { get => loggingFilePath; }

        private readonly string errorMessage;
        public string ErrorMessage { get => errorMessage; }

        private readonly string displayObjectNotFoundErrorMessage;
        public string DisplayObjectNotFoundErrorMessage { get => displayObjectNotFoundErrorMessage; }

        public Configuration()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();

            loggingFilePath = root.GetSection("Logging").GetSection("loggingFilePath").Value;

            errorMessage = root.GetSection("Errors").GetSection("DisplayGenericUserErrorMessage").Value;
            displayObjectNotFoundErrorMessage = root.GetSection("Errors").GetSection("DisplayObjectNotFoundErrorMessage").Value;
        }
    }
}
