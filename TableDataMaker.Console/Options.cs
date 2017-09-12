using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDataMaker.ConsoleApp
{
    public class Options
    {
        [Option('n', "Number_of_Records", DefaultValue = 50, HelpText = "Number of Records")]
        public int NumberOfRecords { get; set; }

        [Option('c', "Connection_String", HelpText ="Connection String", Required =true)]
        public string ConnectionString { get; set; }

        [Option('h', "Help", HelpText = "Help", DefaultValue = false)]
        public bool DoHelp { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
