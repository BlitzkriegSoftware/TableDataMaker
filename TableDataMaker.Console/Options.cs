using CommandLine;
using CommandLine.Text;

namespace TableDataMaker.ConsoleApp
{
    public class Options
    {
        [Option('n', "Number_of_Records", Default = 50, HelpText = "Number of Records")]
        public int NumberOfRecords { get; set; }

        [Option('c', "Connection_String", HelpText ="Connection String", Required =true)]
        public string ConnectionString { get; set; }

        [Option('h', "Help", HelpText = "Help", Default = false)]
        public bool DoHelp { get; set; }

    }
}
