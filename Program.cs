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
        static void Main()
        {
            /*
             * This sample application is a simple wrapper around the RSMFGenerator class.             
             * Validation of the input directory is done by the class, but output location still
             * needs validation.
             */

            //arg removals and check / create folders
            string inputpath = @"json";
            string outputpath = @"rsmf";

            Console.Write("Checking Folders ..");
            if (!Directory.Exists(inputpath))
            {
                Console.Write("Creating .."); 
                Directory.CreateDirectory(inputpath);
            }        
            if (!Directory.Exists(outputpath))
            {
                Console.Write("Creating ..");
                Directory.CreateDirectory( outputpath);
            }
            Console.Write("Ok");
            Console.WriteLine("");


            var rsmf = new RSMFGenerator();
            try
            {
                rsmf.CustodianDisplay = "Relativity";
                rsmf.CustodianEmail = "support@relativity.com"; 
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
