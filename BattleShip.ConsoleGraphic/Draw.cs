namespace BattleShip.ConsoleGraphic
{
    public class Draw
    {
        public static void Print(string you, string enemy)
        {
            Console.WriteLine(" | A | B | C | D | E | F | G | H | I | J |\t\t | A | B | C | D | E | F | G | H | I | J |");
            Console.WriteLine("------------------------------------------\t\t------------------------------------------");
            for (int i = 0; i < 10; ++i)
            {
                Console.Write($"{i}|");
                for (int j = 0; j < 10; ++j)
                {
                    Console.Write($" {you[i*10+j]} |");
                }
                Console.Write("\t\t");
                Console.Write($"{i}|");
                for (int j = 0; j < 10; ++j)
                {
                    Console.Write($" {enemy[i * 10 + j]} |");
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------\t\t------------------------------------------");


                //Console.WriteLine(you.Substring(i * 10, 10) + "\t\t" + enemy.Substring(i * 10, 10));
            }
        }
    }
}