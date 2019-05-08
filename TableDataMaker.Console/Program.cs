using CommandLine;
using System;

using TableDataMaker.ConsoleApp.Models;

using Microsoft.Azure.Cosmos.Table;

namespace TableDataMaker.ConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            int exitCode = 0;

            Title();

            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o =>
            {
                if (o.DoHelp)
                {
                    Usage(null, o);
                    exitCode = 1;
                }

                if (string.IsNullOrWhiteSpace(o.ConnectionString))
                {
                    Usage("/c Connection string is required", o);
                    exitCode = 2;
                }

                if (o.NumberOfRecords <= 0)
                {
                    Usage("/n The number of records must be > 0", o);
                    exitCode = 3;
                }

                if (exitCode <= 0)
                {
                    var tableName = "People";

                    // Create or reference an existing table
                    CloudTable table = Lib.MsStorageUtilities.CreateOrGetTableAsync(tableName, o.ConnectionString).Result;

                    for (int i = 0; i < o.NumberOfRecords; i++)
                    {
                        PersonEntity item = Lib.ModelMaker.PersonMake();
                        Console.WriteLine("{0} -> {1}", i, item.ToString());
                        var res = Lib.MsStorageUtilities.InsertOrMergeEntityAsync<Models.PersonEntity>(table, item).Result;
                    }
                }
            });

            Environment.ExitCode = exitCode;
            return exitCode;
        }

        static void Title()
        {
            Console.WriteLine("{0} {1}", Lib.AssemblyHelper.GetTitle(), Lib.AssemblyHelper.GetVersion());
        }

        static void Usage(string message, Options options)
        {
            Console.WriteLine("{0}", "");
            if (!string.IsNullOrWhiteSpace(message)) Console.WriteLine(message);
        }
    }
}
