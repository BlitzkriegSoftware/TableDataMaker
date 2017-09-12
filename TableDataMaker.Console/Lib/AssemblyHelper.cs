using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDataMaker.ConsoleApp.Lib
{
    public static class AssemblyHelper
    {
        /// <summary>
        /// Make a version string from AssemblyInfo
        /// </summary>
        /// <returns>formatted string</returns>
        public static string GetVersion()
        {
            int mjr = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMajorPart;
            int mnr = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMinorPart;
            int bld = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileBuildPart;
            int prv = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FilePrivatePart;
            return mjr + "." + mnr + "." + bld + "." + prv;
        }

        /// <summary>
        /// Gets title from assembly info
        /// </summary>
        /// <returns>title</returns>
        public static string GetTitle()
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName;
        }

        /// <summary>
        /// Gets the name of the EXE running
        /// </summary>
        /// <returns>String of name</returns>
        public static string GetExeName()
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileName;
        }

        /// <summary>
        /// Get CopyRight
        /// </summary>
        /// <returns></returns>
        public static string GetCopyright()
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).LegalCopyright;
        }
    }

}
