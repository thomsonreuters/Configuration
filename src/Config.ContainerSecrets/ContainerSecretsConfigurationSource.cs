using System;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.Extensions.Configuration.ContainerSecrets
{
    /// <summary>
    /// An <see cref="ConfigurationProvider"/> for container secrets.
    /// </summary>
    public class ContainerSecretsConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ContainerSecretsConfigurationSource()
        {
            IgnoreCondition = s => IgnorePrefix != null && s.StartsWith(IgnorePrefix);
        }

        /// <summary>
        /// The secrets directory which will be used if FileProvider is not set.
        /// </summary>
        public string SecretsDirectory { get; set; } = "/run/secrets";

        /// <summary>
        /// The FileProvider representing the secrets directory.
        /// </summary>
        public IFileProvider FileProvider { get; set; }

        /// <summary>
        /// Container secrets that start with this prefix will be excluded.
        /// </summary>
        public string IgnorePrefix { get; set; } = "ignore.";

        /// <summary>
        /// Used to determine if a file should be ignored using its name.
        /// </summary>
        public Func<string, bool> IgnoreCondition { get; set; }

        /// <summary>
        /// If false, will throw if the secrets directory doesn't exist.
        /// </summary>
        public bool Optional { get; set; }

        /// <summary>
        /// Builds the <see cref="ContainerSecretsConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="ContainerSecretsConfigurationProvider"/></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ContainerSecretsConfigurationProvider(this);
        }
    }
}
