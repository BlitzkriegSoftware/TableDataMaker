using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;

using TableDataMaker.ConsoleApp.Models;

namespace TableDataMaker.ConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            int exitCode = 0;

            Title();

            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (options.DoHelp)
                {
                    Usage(null, options);
                    exitCode = 1;
                }

                if (string.IsNullOrWhiteSpace(options.ConnectionString))
                {
                    Usage("/c Connection string is required", options);
                    exitCode = 2;
                }

                if(options.NumberOfRecords <= 0)
                {
                    Usage("/n The number of records must be > 0", options);
                    exitCode = 3;
                }

                if(exitCode <= 0)
                {
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(options.ConnectionString);
                    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                    CloudTable table = tableClient.GetTableReference("People");
                    // table.CreateIfNotExists();

                    for (int i=0; i< options.NumberOfRecords; i++)
                    {
                        PersonEntity item = Lib.ModelMaker.PersonMake();
                        Console.WriteLine("{0} -> {1}", i, item.ToString());
                        TableOperation insertOperation = TableOperation.Insert(item);
                        table.Execute(insertOperation);
                    }
                }
            }

            Environment.ExitCode = exitCode;
            return exitCode;
        }

        static void Title()
        {
            Console.WriteLine("{0} {1}", Lib.AssemblyHelper.GetTitle(), Lib.AssemblyHelper.GetVersion());
        }

        static void Usage(string message, Options options)
        {
            Console.WriteLine("{0}", options.GetUsage());
            if (!string.IsNullOrWhiteSpace(message)) Console.WriteLine(message);
        }
    }
}
