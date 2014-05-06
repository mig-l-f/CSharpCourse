using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;

namespace SrtFixer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string srtLine;

            StreamReader file = 
                new StreamReader(@"..\..\Artifacts\Kill.Bill.Vol.2.srt");
            while ((srtLine = file.ReadLine()) != null)
            {
                Match match = Regex.Match(srtLine, @"(\d\d:\d\d:\d\d,\d\d\d) --> (\d\d:\d\d:\d\d,\d\d\d)");
                if (match.Success)
                {
                    Console.WriteLine("{0} --> {1}", incrementTime(match.Groups[1].Value, 3), incrementTime(match.Groups[2].Value, 3));
                }
                else
                {
                    Console.WriteLine(srtLine);
                }
            }

        }

        // Write your time incrementing & printing method here
        public static string incrementTime(string time, int additionalSeconds) {
            Match match = Regex.Match(time, @"(\d\d):(\d\d):(\d\d)");
            MyTime mytime = new MyTime(Int32.Parse(match.Groups[1].Value),
                                       Int32.Parse(match.Groups[2].Value),
                                       Int32.Parse(match.Groups[3].Value));
            mytime.AddSeconds(additionalSeconds);
            return mytime.ToString();
        }

    }
}
