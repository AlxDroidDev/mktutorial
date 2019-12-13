using System;
using System.Reflection;
using System.Runtime.Versioning;

namespace CaseConversion.Web
{
    public sealed class EnvConfig
    {

        private string HOST;

        private string PORT;

        private string VERSION;

        private EnvConfig()
        {
            Initialize();
        }

        private void Initialize()
        {
            string destHost = Environment.GetEnvironmentVariable("API_HOST");
            HOST = ((destHost == null) ? "localhost" : destHost).Trim();
                       
            string destPort = Environment.GetEnvironmentVariable("API_PORT");
            PORT = ((destPort == null) ? "81" : destPort).Trim();

            VERSION = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
            
        }

        public string host => HOST;

        public string port => PORT;

        public string hostPort => HOST + ":" + PORT;

        public string version => VERSION;

        private static Lazy<EnvConfig> lazyInstance = new Lazy<EnvConfig>(() => new EnvConfig());

        public static EnvConfig Instance => lazyInstance.Value;

    }
}
