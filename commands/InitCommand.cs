using System;
using System.IO;

public class InitCommand
{
    public static void Run()
    {
        string snapDir = Path.Combine(Directory.GetCurrentDirectory(), ".snap");

        if (!Directory.Exists(snapDir))
        {
            Directory.CreateDirectory(snapDir);
            Directory.CreateDirectory(Path.Combine(snapDir, "objects"));
            File.WriteAllText(Path.Combine(snapDir, "HEAD"), "");
            Console.WriteLine("Initialized empty snap repository in " + snapDir);
        }
        else
        {
            Console.WriteLine("Snap repository already exists.");
        }
    }
}
