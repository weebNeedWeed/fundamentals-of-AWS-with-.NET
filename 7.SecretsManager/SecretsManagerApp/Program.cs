using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

var secretsManagerClient = new AmazonSecretsManagerClient();

var listSecretVersionsRequest = new ListSecretVersionIdsRequest
{
    SecretId = "ApiKey",
    IncludeDeprecated = true
};

var versionsResponse = await secretsManagerClient.ListSecretVersionIdsAsync(listSecretVersionsRequest);

var getSecretValueRequest = new GetSecretValueRequest
{   
    SecretId = "ApiKey",
    //VersionStage = "AWSPREVIOUS",
    VersionId = "81b5b852-4d25-47f9-bb9d-20d11798912b"
};

var response = await secretsManagerClient.GetSecretValueAsync(getSecretValueRequest);

Console.WriteLine(response.SecretString);




/*var describeSecretRequest = new DescribeSecretRequest
{
    SecretId = "ApiKey"
};

var describeSecretResponse = await secretsManagerClient.DescribeSecretAsync(describeSecretRequest);

Console.WriteLine();*/