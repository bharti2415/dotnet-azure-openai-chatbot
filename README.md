**Azure OpenAI + ASP.NET Core Blazor Chatbot**

A smart chatbot built with ASP.NET Core Blazor Server and Azure OpenAI Service.
This project demonstrates how to integrate Azure-hosted GPT models into a real-world application, complete with a Blazor UI for chat and a REST API for external consumption.

✨ Features

🔹 Blazor Server UI – Chat directly with the bot in your browser

🔹 REST API – Expose chatbot as /api/chat for Postman, Angular, React, or mobile apps

🔹 Service Layer – Clean separation of Azure OpenAI logic

🔹 Production-ready structure – UI + API + Service in one project

🔹 Configurable via appsettings.json

📂 Project Structure
ChatbotApp/
 ├── Controllers/
 │    └── ChatController.cs      # REST API
 ├── Pages/
 │    └── Chat.razor             # Blazor UI
 ├── Services/
 │    └── ChatService.cs         # Azure OpenAI integration
 ├── wwwroot/
 │    └── css/site.css
 ├── Program.cs
 ├── appsettings.json
 └── ChatbotApp.csproj

🛠️ Getting Started
1️⃣ Prerequisites

.NET 8 SDK

An Azure OpenAI resource

Deployed model (e.g., gpt-35-turbo)

2️⃣ Clone Repo
git clone https://github.com/<your-username>/ChatbotApp.git
cd ChatbotApp

3️⃣ Configure Azure OpenAI

Update appsettings.json with your Azure credentials:

"AzureOpenAI": {
  "Endpoint": "https://<your-resource-name>.openai.azure.com/",
  "ApiKey": "<your-api-key>",
  "DeploymentName": "gpt-35-turbo"
}

4️⃣ Run App
dotnet run


Navigate to 👉 https://localhost:5001/chat
 for Blazor chatbot UI

Test API 👉 POST https://localhost:5001/api/chat with JSON:

{
  "message": "Hello AI!"
}

🚀 Deployment
Deploy to Azure App Service
dotnet publish -c Release
az webapp up --name <your-app-name> --runtime "DOTNETCORE:8.0"

Run with Docker
docker build -t chatbotapp .
docker run -p 5000:80 chatbotapp
