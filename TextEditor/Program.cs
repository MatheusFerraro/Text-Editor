using System.IO;

namespace TextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            const string BOARD = """
             |---------------------------------|
             |  1 - Open File                  |
             |  2 - Create File                |
             |  0 - Quit                       |
             |                                 |
             |                                 |
             |_________________________________|                                  
           """;
            Console.WriteLine(BOARD);
            Console.Write("Select a Option: ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: OpenFile(); break;
                case 2: CreateFile(); break;
                default: Menu(); break;
            }
        }

        static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("What is the path of file?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void CreateFile()
        {
            
            Console.Clear();
            
            ConsoleTopRightCursor();
            Console.WriteLine();
            Console.WriteLine("Type your text below");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            string text = "";
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
            Console.Write(text);
            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("What is the path to save the file?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"File {path} Saved Sucessfully");
            Console.ReadLine();
            Menu();
        }
        static void ConsoleTopRightCursor()
        {
            int consoleWidth = Console.WindowWidth;
            string text = "Esc to exit";

            //Calculate the starting column for the top-right corner
            int startColum = consoleWidth - text.Length; 

            if(startColum < 0)
            {
                startColum = 0; // align it to the left if its too long
                text = text.Substring(0, consoleWidth); //trim the text
            }
            Console.SetCursorPosition(startColum, 0);

            Console.Write(text);
          

        }
    }
}
