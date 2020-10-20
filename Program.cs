using System;
using System.IO;
using RSMFGenLib;

/* ----------------------------------------------------------------------------
 * <copyright file="Program.cs" company="Relativity ODA LLC">
 *  © Relativity All Rights Reserved.
 * </copyright>
 *----------------------------------------------------------------------------
*/

namespace RSMFGen
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("Validation on the Zip layer is performed if -validate is specified.  On validation error, no RSMF is created.");

                return;
            }
            /*
             * This sample application is a simple wrapper around the RSMFGenerator class.             
             * Validation of the input directory is done by the class, but output location still
             * needs validation.
             */

            //arg removals and check / create folders
            string inputpath = @"json";
            string outputpath = @"rsmf";

            Console.WriteLine("Checking json folder ..");
            if (!Directory.Exists(inputpath))
            {
                Console.WriteLine("Creating json folder"); 
                Directory.CreateDirectory(inputpath);
            }
            Console.WriteLine("json folder ok");          
            Console.WriteLine("Checking rsmf folder ..");
            if (!Directory.Exists(outputpath))
            {
                Console.WriteLine("Creating rsmf folder");
                Directory.CreateDirectory( outputpath);
            }
            Console.WriteLine("rsmf folder ok");


            var rsmf = new RSMFGenerator();
            try
            {
                /*
                 * By populating the custodian information, the "From" address field of the EML will be generated.
                 */
                rsmf.CustodianDisplay = "Relativity";
                rsmf.CustodianEmail = "support@relativity.com";
                
                if(args.Length > 2 && args[0].Equals("-validate", StringComparison.OrdinalIgnoreCase))
                {
                    /*
                     * Validating affects the peformance of creating an RSMF.  If the JSON has already been validated before
                     * running this process then further validating may not be necessary.
                     */
                    rsmf.ValidateZip = true;
                }
                rsmf.GenerateRSMF(new DirectoryInfo(inputpath), new FileInfo(outputpath));
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine("Exception caught attempting to create RSMF file.");
                Console.Error.WriteLine(ex.Message);
            }

        }
    }
}
