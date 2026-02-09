using DotNetEnv;
using ContosoTravelAgent.Host.Models;
using Microsoft.Extensions.Options;

namespace ContosoTravelAgent.Host.Extensions;

public static class ConfigurationExtensions
{
    public static ContosoTravelAppConfig LoadContosoTravelConfig(this IServiceCollection services, IConfiguration configuration)
    {
        LoadEnvironmentVariables();

        var useGitHubModels = bool.Parse(Env.GetString("USE_GITHUB_MODELS")
                                         ?? configuration["USE_GITHUB_MODELS"]
                                         ?? "false");

        // GitHub Models configuration
        var githubToken = Env.GetString("GITHUB_TOKEN")
                          ?? configuration["GITHUB_TOKEN"];
        var githubModelsBaseUrl = Env.GetString("GITHUB_MODELS_BASE_URL")
                                  ?? configuration["GITHUB_MODELS_BASE_URL"]
                                  ?? "https://models.inference.ai.azure.com";
        var githubTextModelId = Env.GetString("GITHUB_TEXT_MODEL_ID")
                                ?? configuration["GITHUB_TEXT_MODEL_ID"]
                                ?? "gpt-4o";
        var githubEmbeddingModelId = Env.GetString("GITHUB_EMBEDDING_MODEL_ID")
                                     ?? configuration["GITHUB_EMBEDDING_MODEL_ID"]
                                     ?? "openai/text-embedding-ada-002";

        // Azure AI configuration
        var azureProjectEndpoint = Env.GetString("AZURE_AI_PROJECT_ENDPOINT")
                                   ?? configuration["AZURE_AI_PROJECT_ENDPOINT"];

        var azureAiFoundryServiceEndpoint = Env.GetString("AZURE_AI_FOUNDRY_SERVICE_ENDPOINT")
                                           ?? configuration["AZURE_AI_FOUNDRY_SERVICE_ENDPOINT"];

        var azureAiServicesEndpoint = Env.GetString("AZURE_AI_SERVICES_ENDPOINT")
                                     ?? configuration["AZURE_AI_SERVICES_ENDPOINT"];

        var azureAiServicesKey = Env.GetString("AZURE_AI_SERVICES_KEY")
                                ?? configuration["AZURE_AI_SERVICES_KEY"];

        var azureProjectName = Env.GetString("AZURE_AI_PROJECT_NAME")
                               ?? configuration["AZURE_AI_PROJECT_NAME"];

        var azureLocation = Env.GetString("AZURE_LOCATION")
                            ?? configuration["AZURE_LOCATION"];

        var azureSubscriptionId = Env.GetString("AZURE_SUBSCRIPTION_ID")
                                  ?? configuration["AZURE_SUBSCRIPTION_ID"];

        var azureTenantId = Env.GetString("AZURE_TENANT_ID")
                            ?? configuration["AZURE_TENANT_ID"];

        var textModelName = Env.GetString("AZURE_AZURE_TEXT_MODEL_NAME")
                            ?? configuration["AZURE_AZURE_TEXT_MODEL_NAME"]
                            ?? "gpt-4o";

        var embeddingModelName = Env.GetString("AZURE_EMBEDDING_MODEL_NAME")
                                   ?? configuration["AZURE_EMBEDDING_MODEL_NAME"]
                                   ?? "text-embedding-ada-002";

        var azureSearchEndpoint = Env.GetString("AZURE_SEARCH_SERVICE_ENDPOINT")
                                  ?? configuration["AZURE_SEARCH_SERVICE_ENDPOINT"];

        var azureSearchAdminKey = Env.GetString("AZURE_AI_SEARCH_ADMIN_KEY")
                                  ?? configuration["AZURE_AI_SEARCH_ADMIN_KEY"];

        var otlpEndpoint = Env.GetString("OTEL_EXPORTER_OTLP_ENDPOINT")
                           ?? configuration["OTEL_EXPORTER_OTLP_ENDPOINT"];

        // Mem0 configuration
        var mem0Endpoint = Env.GetString("MEM0_ENDPOINT")
                          ?? configuration["MEM0_ENDPOINT"]
                          ?? "https://api.mem0.ai";

        var mem0ApiKey = Env.GetString("MEM0_APIKEY")
                        ?? configuration["MEM0_APIKEY"];

        // Cosmos DB configuration
        var cosmosDbEndpoint = Env.GetString("COSMOS_DB_ENDPOINT")
                              ?? configuration["COSMOS_DB_ENDPOINT"];

        var cosmosDbConnectionString = Env.GetString("COSMOS_DB_CONNECTION_STRING")
                                      ?? configuration["COSMOS_DB_CONNECTION_STRING"];

        var cosmosDbDatabaseName = Env.GetString("COSMOS_DB_DATABASE_NAME")
                                  ?? configuration["COSMOS_DB_DATABASE_NAME"];

        var cosmosDbChatHistoryContainer = Env.GetString("COSMOS_DB_CHAT_HISTORY_CONTAINER")
                                          ?? configuration["COSMOS_DB_CHAT_HISTORY_CONTAINER"];

        var cosmosDbUserProfileContainer = Env.GetString("COSMOS_DB_USER_PROFILE_CONTAINER")
                                          ?? configuration["COSMOS_DB_USER_PROFILE_CONTAINER"];

        var cosmosDbFlightsContainer = Env.GetString("COSMOS_DB_FLIGHTS_CONTAINER")
                                      ?? configuration["COSMOS_DB_FLIGHTS_CONTAINER"]
                                      ?? "Flights";

        // Validate configuration based on mode
        if (useGitHubModels && string.IsNullOrWhiteSpace(githubToken))
        {
            throw new InvalidOperationException
                ("GitHub Models token not found. Set GITHUB_TOKEN in .env file.");
        }

        if (!useGitHubModels && string.IsNullOrWhiteSpace(azureProjectEndpoint))
        {
            throw new InvalidOperationException
                ("Azure AI Project endpoint not found. Set AZURE_AI_PROJECT_ENDPOINT in .env file.");
        }

        var config = new ContosoTravelAppConfig
        {
            UseGitHubModels = useGitHubModels,
            GithubToken = githubToken,
            GithubModelsBaseUrl = githubModelsBaseUrl,
            GithubTextModelId = githubTextModelId,
            GithubEmbeddingModelId = githubEmbeddingModelId,
            AzureAIProjectEndpoint = azureProjectEndpoint,
            AzureAiFoundryServiceEndpoint = azureAiFoundryServiceEndpoint,
            AzureAIServicesEndpoint = azureAiServicesEndpoint,
            AzureAIServicesKey = azureAiServicesKey,
            AzureAIProjectName = azureProjectName,
            AzureLocation = azureLocation,
            AzureSubscriptionId = azureSubscriptionId,
            AzureTenantId = azureTenantId,
            AzureTextModelName = textModelName,
            AzureEmbeddingModelName = embeddingModelName,
            AzureAISearchEndpoint = azureSearchEndpoint,
            AzureAISearchAdminKey = azureSearchAdminKey,
            OtelExporterOtlpEndpoint = otlpEndpoint,
            Mem0Endpoint = mem0Endpoint,
            Mem0ApiKey = mem0ApiKey,
            CosmosDbEndpoint = cosmosDbEndpoint,
            CosmosDbConnectionString = cosmosDbConnectionString,
            CosmosDbDatabaseName = cosmosDbDatabaseName,
            CosmosDbChatHistoryContainer = cosmosDbChatHistoryContainer,
            CosmosDbUserProfileContainer = cosmosDbUserProfileContainer,
            CosmosDbFlightsContainer = cosmosDbFlightsContainer
        };

        services.AddSingleton<IOptions<ContosoTravelAppConfig>>(Options.Create(config));
        services.AddSingleton(config);

        return config;
    }

    /// <summary>
    /// Loads .env file from workspace root by searching up the directory tree.
    /// </summary>
    private static void LoadEnvironmentVariables()
    {
        var fileName = ".env";
        var currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (currentDir != null)
        {
            var envFile = Path.Combine(currentDir.FullName, fileName);
            if (File.Exists(envFile))
            {
                Env.Load(envFile);
                Console.WriteLine($"Loaded .env from: {envFile}");
                return;
            }
            currentDir = currentDir.Parent;
        }

        Console.WriteLine("No .env file found");
    }
}
