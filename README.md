# 🤖 Azure OpenAI + ASP.NET Core Blazor Chatbot

A smart chatbot built with **ASP.NET Core Blazor Server** and **Azure OpenAI Service**.  
This project demonstrates how to integrate **Azure-hosted GPT models** into a real-world application, complete with a **Blazor UI** for chat and a **REST API** for external consumption.

---

## ✨ Features

- 🔹 **Blazor Server UI** – Chat directly with the bot in your browser  
- 🔹 **REST API** – Expose chatbot as `/api/chat` for Postman, Angular, React, or mobile apps  
- 🔹 **Service Layer** – Clean separation of Azure OpenAI logic  
- 🔹 **Production-ready structure** – UI + API + Service in one project  
- 🔹 **Configurable via `appsettings.json` or environment variables**  
- 🔹 **Docker & docker-compose support** – Run anywhere  

---

## 📂 Project Structure

ChatbotApp/
├── Controllers/
│ └── ChatController.cs # REST API
├── Pages/
│ └── Chat.razor # Blazor UI
├── Services/
│ └── ChatService.cs # Azure OpenAI integration
├── wwwroot/
│ └── css/site.css
├── Program.cs
├── appsettings.json
├── Dockerfile
├── .dockerignore
├── docker-compose.yml
└── ChatbotApp.csproj


---

## 🛠️ Getting Started

### 1️⃣ Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- An **Azure OpenAI resource**  
- A deployed model (e.g., `gpt-35-turbo`)  

### 2️⃣ Clone Repo
```bash
git clone https://github.com/<your-username>/ChatbotApp.git
cd ChatbotApp

3️⃣ Configure Azure OpenAI

Update appsettings.json:
"AzureOpenAI": {
  "Endpoint": "https://<your-resource-name>.openai.azure.com/",
  "ApiKey": "<your-api-key>",
  "DeploymentName": "gpt-35-turbo"
}

Or set environment variables (recommended for production):

export AzureOpenAI__Endpoint="https://<your-resource>.openai.azure.com/"
export AzureOpenAI__ApiKey="<your-api-key>"
export AzureOpenAI__DeploymentName="gpt-35-turbo"

4️⃣ Run App

dotnet run

Blazor UI 👉 https://localhost:5001/chat

REST API 👉 POST https://localhost:5001/api/chat with body:

{
  "message": "Hello AI!"
}
