using System.Text.Json;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Movies.Api;

// await new DataSeeder().ImportDataAsync();

var movie1 = new Movie1
{
    Id = Guid.NewGuid(),
    Title = "The boy and the heron",
    AgeRestriction = 18,
    ReleaseYear = 2014,
    RottenTomatoesPercentage = 90
};

var movie1AsJson = JsonSerializer.Serialize(movie1);
var movie1AsAttributes = Document.FromJson(movie1AsJson).ToAttributeMap();

var movie2 = new Movie2
{
    Id = Guid.NewGuid(),
    Title = "The boy and the heron",
    AgeRestriction = 18,
    ReleaseYear = 2014,
    RottenTomatoesPercentage = 90
};

var movie2AsJson = JsonSerializer.Serialize(movie2);
var movie2AsAttributes = Document.FromJson(movie2AsJson).ToAttributeMap();

var transactionRequest = new TransactWriteItemsRequest
{
    TransactItems = new List<TransactWriteItem>
    {
        new()
        {
            Put = new Put
            {
                TableName = "movies-year-title",
                Item = movie1AsAttributes
            }
        },
        new()
        {
            Put = new Put
            {
                TableName = "movies-title-rotten",
                Item = movie2AsAttributes
            }
        }
    }
};

var dynamoDbClient = new AmazonDynamoDBClient(RegionEndpoint.APSoutheast1);

var response = await dynamoDbClient.TransactWriteItemsAsync(transactionRequest);