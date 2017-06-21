ASP.NET Core Key Vault Configuration source sample
==================================================

This sample illustrates the usage of ASP.NET Core Key Vault Configuration source. The application uses `AddAzureKeyVault` extension method for `IConfigurationBuilder` to retreive configuration values from Azure Key Vault. Sample `IKeyVaultSecretManager` implemenation `EnvironmentSecretManager` is included to show an ability to filter which secrets should be loaded and thansform their configuration key names.


