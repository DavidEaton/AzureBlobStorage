﻿// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureBlobStorage;
using AzureBlobStorage.Models;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");

string connectionString = "DefaultEndpointsProtocol=https;AccountName=menominee;AccountKey=7BO1y2PRVwW3Jh94qFnPHZZ87jrnqk5FEBazjRKSBIzxXjLetw88EGvP+xljbW5V0mQnBGecbz3mGOO54dLnRg==;EndpointSuffix=core.windows.net";

// Create a BlobServiceClient object which will be used to create a container client
BlobServiceClient blobServiceClient = new(connectionString);

//Create a unique name for the container
string containerName = $"moops";// -{Guid.NewGuid().ToString()}";

// Create the container and return a container client object
BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);

try
{
    containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
}
catch (RequestFailedException ex)
{
    // Container already exists. Log it.
    Console.WriteLine($"Container '{containerName}' already exists.");
}

//string blobName = "supply.json";
//var supplyFile = await Methods.GetBlob(containerClient);

//Console.WriteLine($"Getting {blobName} from uri {containerClient.Uri}\n");

//Console.WriteLine($"Got blob: {supplyFile.GetType()}");


// Create non-hard-coded filename
string fileType = "json"; 
var fileName = $"{SettingType.supply}{fileType}";


// Get a reference to a blob
BlobClient blobClient = containerClient.GetBlobClient(fileName);

Supply? supply = await Methods.CreateSupply();
string? json = JsonSerializer.Serialize(supply);

try
{
    using MemoryStream ms = new(Encoding.UTF8.GetBytes(json));
    await blobClient.UploadAsync(ms, true);
    // Upload the string; overwrite = true
    //await blobClient.UploadAsync(json, true);
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.Message);
    // Log it.
}


Console.WriteLine("Listing blobs...");

// List all blobs in the container
await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
{
    Console.WriteLine("\t" + blobItem.Name);
}

Console.ReadLine();