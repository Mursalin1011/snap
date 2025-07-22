using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snap.commands
{
    public class AddCommand
    {
        public static void Run(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: snap add <file>");
                return;
            }

            string filePath = args[1];
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                return;
            }

            //Get the whole file -> Generate Hash -> Prepare blob
            var fileContent = File.ReadAllTextAsync(filePath);

        }
    }
}
