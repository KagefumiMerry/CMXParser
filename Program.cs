using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PSO2CMXParser
{
    class Program
    {
        public static List<string>  Log = new List<string>();
		public static List<int> endTagLocations;
		public static byte[] fileByteArray;

        static int Main(string[] args)
        {
			return Command(args);
        }

        public static int Command(string[] args)
        {
            try
            {
				if (args.Length < 1)
				{
					Console.WriteLine("Requires 1 arguments.");
					return 0;
				}
				
				//main parts
	
				string inFilename = args[0];
				CMXparser.ParseCMX(inFilename);

				
                return 0;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return 1;
            } finally
            {
                if(Log.Count > 0)
                try
                {
                    var dir     = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                    var logfile = Path.Combine(dir, "lastlog.txt");

                    File.WriteAllLines(logfile, Log);
                } catch {}
            }
        }
		
		
    }
	
}
