using FightClub.Fighters;

namespace FightClub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintMenu();
        }

        private static void PrintMenu()
        {
            Console.Clear();

            Console.WriteLine("ИГРА БОЙЦОВСКИЙ КЛУБ");
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("1 - Начать игру");
            Console.WriteLine("2 - Правила");
            Console.WriteLine("3 - Выход");

            string option = Console.ReadLine()!;

            if (option == "1")
                StartGame();

            if (option == "2")
                PrintRules();

            if (option == "3")
                StopGame();

            PrintMenu();
        }

        private static void StartGame()
        {
            Game game = new Game();
            game.StartGame();
        }

        private static void PrintRules()
        {
            Console.Clear();

            Console.WriteLine(new Warrior());
            Console.WriteLine(new Dodger());
            Console.WriteLine(new Mage());

            Console.ReadLine();
        }

        private static void StopGame()
        {
            Environment.Exit(0);
        }
    }
}
