# MAF Context Engineering - AI Travel Agent Workshop

This repository contains the code and resources for building an AI-powered travel agent using Microsoft Agent Framework (MAF) and Azure AI services.

## Prerequisites

- **Azure Subscription**: Sign up for a free [Azure account](https://azure.microsoft.com/free/)
- **Azure Developer CLI (azd)**: Required for provisioning Azure resources

### Verify Azure Developer CLI Installation

Run the following command in your terminal to verify the installation:

```bash
azd version
```

## Setup Azure Infrastructure

Create your Azure environment by provisioning the necessary resources:

### Authenticate with Azure

First, authenticate with your Azure account using the Azure Developer CLI:

```bash
azd auth login --use-device-code
```

Follow the prompts to complete the authentication process in your browser.

### Create and Configure Environment

Create a new environment for your Azure resources:

```bash
azd env new dev
azd env select dev
azd env set AZURE_LOCATION australiaeast
```

> **Note**: You can change `australiaeast` to any Azure region that supports AI Foundry. Common options include: `eastus`, `westus2`, `westeurope`, `southeastasia`.

### Provision and Deploy

Deploy all required Azure resources using a single command:

```bash
azd up
```

This command will:

- Provision Azure AI Foundry resources (AI Hub, AI Project)
- Deploy AI models
- Configure authentication and permissions

> **Note**: The deployment process may take 5-10 minutes to complete.

### Verify Deployment

1. Navigate to the [Azure Portal](https://portal.azure.com/)
2. Look for a resource group named `rg-aiagent-ws-dev` (or similar, based on your environment name)
3. Verify the following resources are created:
   - Azure AI Hub
   - Azure AI Project
   - AI models (e.g., GPT-4)
   - Azure Cosmos DB
   - Azure AI Search

## Running the Application Locally

To work through the labs, you need to run both the backend (.NET) and frontend (React) applications simultaneously.

### 1. Start the Backend Server

Navigate to the backend folder:

```bash
cd src/backend
```

Start the backend server by running the following command. This will start the backend API server on `http://localhost:5001`:

```bash
dotnet run
```

### 2. Start the Frontend Development Server

In a separate terminal, navigate to the frontend folder:

```bash
cd src/frontend
```

Install the required npm packages (if you haven't already):

```bash
npm install
```

Build the frontend application:

```bash
npm run build
```

Start the frontend server:

```bash
npm start
```

To access the frontend application, open your browser to `http://localhost:3000`.

### 3. Test Your Setup

- **API Testing**: Navigate to the file `src/backend/ContosoTravelAgent.http` in the code repository. This file contains HTTP requests that you can use to interact with the backend API. Click on the `Send Request` link above each request in the file.

- **Web Application Testing**: Open your web browser and navigate to `http://localhost:3000`. Click on the `New Chat` button to start a new conversation with the AI travel agent. Send a few messages to verify that the frontend and backend are communicating correctly.

## Test Your Implementation

Start the conversation with:

```
Hi! I want to plan my next vacation
```

**Expected Response**: Agent greets you and asks about your travel preferences (e.g., budget, travel style, interests).

Answer the agent's questions to build your profile.

**Expected Response**: Agent provides personalized destination recommendations and stores your profile information (travel style, budget, interests, past trips, places to visit).

### Test Profile Memory

Test that the agent remembers your preferences in a new session.

Start a new conversation by clicking on **New Chat** in the frontend UI, then ask:

```
Suggest a vacation for me
```

**Expected Response**: Agent references your stored profile and provides personalized recommendations based on your preferences.

Note that the user preferences are stored in memory and will be lost if the backend server is restarted. You can save the user profile to a persistent database (e.g., Azure Cosmos DB). 
