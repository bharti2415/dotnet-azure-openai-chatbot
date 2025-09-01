using Azure.AI.OpenAI;
using Azure;

namespace ChatbotApp.Services
{
    public class ChatService
    {
        private readonly OpenAIClient _client;
        private readonly string _deploymentName;

        public ChatService(IConfiguration configuration)
        {
            var endpoint = new Uri(configuration["AzureOpenAI:Endpoint"]);
            var apiKey = new AzureKeyCredential(configuration["AzureOpenAI:ApiKey"]);
            _deploymentName = configuration["AzureOpenAI:DeploymentName"];
            _client = new OpenAIClient(endpoint, apiKey);
        }

        public async Task<string> GetResponseAsync(string userInput)
        {
            var chatCompletionsOptions = new ChatCompletionsOptions
            {
                Messages =
                {
                    new ChatMessage(ChatRole.System, "You are a helpful chatbot."),
                    new ChatMessage(ChatRole.User, userInput)
                },
                MaxTokens = 200
            };

            var response = await _client.GetChatCompletionsAsync(_deploymentName, chatCompletionsOptions);
            return response.Value.Choices[0].Message.Content;
        }
    }
}
