class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No command provided.");
            return;
        }

        switch (args[0])
        {
            case "init":
                InitCommand.Run();
                break;
            case "add":
                AddCommand.Run(args);
                break;

            default:
                Console.WriteLine($"Unknown command: {args[0]}");
                break;
        }
    }
}
