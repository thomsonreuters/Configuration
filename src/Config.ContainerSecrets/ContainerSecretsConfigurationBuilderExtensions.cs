using System;
using Microsoft.Extensions.Configuration.ContainerSecrets;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Extension methods for registering <see cref="ContainerSecretsConfigurationProvider"/> with <see cref="IConfigurationBuilder"/>.
    /// </summary>
    public static class ContainerSecretsConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from container secrets.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddContainerSecrets(this IConfigurationBuilder builder) =>
            builder.AddContainerSecrets(configureSource: null);

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from container secrets.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="secretsPath">The path to the secrets directory.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddContainerSecrets(this IConfigurationBuilder builder, string secretsPath) 
            => builder.AddContainerSecrets(source => source.SecretsDirectory = secretsPath);

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from container secrets.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="secretsPath">The path to the secrets directory.</param>
        /// <param name="optional">Whether the directory is optional.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddContainerSecrets(this IConfigurationBuilder builder, string secretsPath, bool optional)
            => builder.AddContainerSecrets(source =>
            {
                source.SecretsDirectory = secretsPath;
                source.Optional = optional;
            });

        /// <summary>
        /// Adds a container secrets configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="configureSource">Configures the source.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddContainerSecrets(this IConfigurationBuilder builder, Action<ContainerSecretsConfigurationSource> configureSource)
            => builder.Add(configureSource);
    }
}
