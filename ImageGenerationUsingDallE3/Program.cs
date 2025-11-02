// Note: The Azure OpenAI client library for .NET is in preview.
// Install the .NET library via NuGet: dotnet add package Azure.AI.OpenAI --prerelease
using Azure.AI.OpenAI;
using OpenAI.Images;
using System.ClientModel;
using static System.Environment;

class Program
{
    static async Task Main(string[] args)
    {
        // You will need to set these environment variables or edit the following values.
        string endpoint = GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? "https://pkaifoundry.cognitiveservices.azure.com/";
        string deployment = GetEnvironmentVariable("DEPLOYMENT_NAME") ?? "dall-e-3";
        string apiKey = "";

        AzureOpenAIClient azureClient = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey));

        ImageClient client = azureClient.GetImageClient(deployment);
        ClientResult<GeneratedImage> imageResult = await client.GenerateImageAsync("Futuristic neon city at night, cyberpunk style, floating vehicles, holographic advertisements, rain-slicked streets", new()
        {
            Quality = GeneratedImageQuality.Standard,
            Size = GeneratedImageSize.W1024xH1024,
            Style = GeneratedImageStyle.Vivid,
            ResponseFormat = GeneratedImageFormat.Uri
        });

        GeneratedImage image = imageResult.Value;
        Console.WriteLine($"Image URL: {image.ImageUri}");
    }
}