#!/bin/bash

# Define the .env file path
ENV_FILE_PATH=".env"

# Clear the contents of the .env file
> $ENV_FILE_PATH
echo "AZURE_ENV_NAME=$(azd env get-value AZURE_ENV_NAME)" >> $ENV_FILE_PATH
echo "AZURE_LOCATION=$(azd env get-value AZURE_LOCATION)" >> $ENV_FILE_PATH
echo "AZURE_AI_PROJECT_ENDPOINT=$(azd env get-value AZURE_AI_PROJECT_ENDPOINT)" >> $ENV_FILE_PATH
echo "AZURE_AI_FOUNDRY_SERVICE_ENDPOINT=$(azd env get-value AZURE_AI_FOUNDRY_SERVICE_ENDPOINT)" >> $ENV_FILE_PATH
echo "AZURE_RESOURCE_GROUP=$(azd env get-value AZURE_RESOURCE_GROUP)" >> $ENV_FILE_PATH
echo "AZURE_SUBSCRIPTION_ID=$(azd env get-value AZURE_SUBSCRIPTION_ID)" >> $ENV_FILE_PATH
echo "AZURE_TENANT_ID=$(azd env get-value AZURE_TENANT_ID)" >> $ENV_FILE_PATH
echo "AZURE_TEXT_MODEL_NAME=$(azd env get-value AZURE_OPENAI_DEPLOYMENT_NAME)" >> $ENV_FILE_PATH
echo "AZURE_AI_SERVICES_ENDPOINT=$(azd env get-value AZURE_AI_SERVICES_ENDPOINT)" >> $ENV_FILE_PATH
echo "AZURE_AI_SERVICES_KEY=$(azd env get-value AZURE_AI_SERVICES_KEY)" >> $ENV_FILE_PATH

exit 0