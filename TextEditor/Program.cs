using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        
        static void Menu() 
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine());

            switch(option) 
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Update(); break;
                default: Menu(); break;
            }
        }

        static void Open() {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            // lendo o caminho do arquivo
            using(var file = new StreamReader(path)) 
            {   
                // lendo o arquivo até o final
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
            
        }
        static void Update() {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo. (ESC para sair)");
            Console.WriteLine("--------------------------------------");
            string text = "";

            // verificando se a tecla ESC foi pressionada
            do {    
                text += Console.ReadLine();
                text += Environment.NewLine;
            } 
            while(Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }

        // salvando um arquivo através do StreamWriter();
        static void Save(string text) 
        {
            Console.WriteLine("Qual caminho deseja salvar o arquivo? ");
            var path = Console.ReadLine();

            // escrevendo e salvando um arquivo
            using(var file = new StreamWriter(path)) 
            {   
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}
