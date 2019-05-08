using System;
using System.Threading.Tasks;

using Microsoft.Azure.Cosmos.Table;

namespace TableDataMaker.ConsoleApp.Lib
{
    public static class MsStorageUtilities
    {
        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.Error.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                throw;
            }

            return storageAccount;
        }

        public static async Task<CloudTable> CreateOrGetTableAsync(string tableName, string storageConnectionString)
        {
            // Retrieve storage account information from connection string.
            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(storageConnectionString);

            // Create a table client for interacting with the table service
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

            Console.WriteLine("Create a Table for the demo");

            // Create a table client for interacting with the table service 
            CloudTable table = tableClient.GetTableReference(tableName);
            if (await table.CreateIfNotExistsAsync())
            {
                Console.WriteLine("Created Table named: {0}", tableName);
            }
            else
            {
                Console.WriteLine("Table {0} already exists", tableName);
            }

            return table;
        }

        public static async Task<CloudTable> CreateTableAsync(CloudTableClient tableClient, string tableName)
        {
            Console.WriteLine("Create a Table for the demo");

            // Create a table client for interacting with the table service 
            CloudTable table = tableClient.GetTableReference(tableName);
            try
            {
                if (await table.CreateIfNotExistsAsync())
                {
                    Console.WriteLine("Created Table named: {0}", tableName);
                }
                else
                {
                    Console.WriteLine("Table {0} already exists", tableName);
                }
            }
            catch (StorageException ex)
            {
                Console.Error.WriteLine("Error: {0}\nHint: {1}",ex.Message,
                    "If you are running with the default configuration please make sure you have started the storage emulator.");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            return table;
        }

        public static async Task<T> InsertOrMergeEntityAsync<T>(CloudTable table, Microsoft.Azure.Cosmos.Table.ITableEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                T insertedCustomer = (T)result.Result;

                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
                }

                return insertedCustomer;
            }
            catch (StorageException e)
            {
                Console.Error.WriteLine(e.Message);
                throw;
            }
        }



    }

}

