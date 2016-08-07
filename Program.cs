using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

/*
 * This comment block should only be in branch: DID001-branch-test
 * 
 * This is for testing github branches, etc.
 *
 */

namespace SnoValleyConverter
{
    class Program
    {
        static string Convert(string ofxFile)
        {
            string qfxFile = ofxFile + ".qfx";
            try 
            {
                using (StreamReader reader = File.OpenText(ofxFile))
                {
                    using (StreamWriter writer = new StreamWriter(qfxFile))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.ToUpper().Equals("<FID>33333333"))
                            {
                                line = "<FID>24399";
                            }
                            else if (line.ToUpper().Equals("<INTU.BID>33333333"))
                            {
                                line = "<INTU.BID>24399";
                            }
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Unable to convert {0} to {1}, error: {2}", ofxFile, qfxFile, e.Message));
                qfxFile = null;
            }

            return qfxFile;
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: SnoValleyConverter <OFX_File.ofx>");
            }
            else
            {
                Console.WriteLine(String.Format("Converting {0}...", args[0]));
                string qfxPath = Convert(args[0]);

                if (qfxPath != null)
                {
                    Process.Start(qfxPath);
                }
            }
        }
    }
}
