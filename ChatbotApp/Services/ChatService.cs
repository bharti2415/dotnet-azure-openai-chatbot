using Azure.AI.OpenAI;
using Azure;
using System.Threading.Tasks;

namespace ChatbotApp.Services
{
    public class ChatService
    {
        private readonly OpenAIClient _client;
        private readonly string _deploymentName;

        public ChatService(IConfiguration config)
        {
            var endpoint = new Uri(config["AzureOpenAI:Endpoint"]);
            var key = new AzureKeyCredential(config["AzureOpenAI:ApiKey"]);
            _deploymentName = config["AzureOpenAI:DeploymentName"];

            _client = new OpenAIClient(endpoint, key);
        }

        public async Task<string> GetResponseAsync(string userMessage)
        {
            var response = await _client.GetChatCompletionsAsync(
                _deploymentName,
                new ChatCompletionsOptions
                {
                    Messages =
                    {
                        new ChatMessage(ChatRole.System, "You are a helpful assistant."),
                        new ChatMessage(ChatRole.User, userMessage)
                    },
                    MaxTokens = 500
                });

            return response.Value.Choices[0].Message.Content;
        }
    }
}
