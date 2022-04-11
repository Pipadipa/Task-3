using System;

namespace Task3
{
    class Program
    {
        private static int computerMove;

        private static string playerMove;

        private static string key;
        static void Main(string[] args)
        {
            if (args.Length >= 3 && args.Length % 2 == 1)
            {
                computerMove = GameLogicClass.computerMove(args.Length);
                showMoves(args);
                key = HmacFather.GetKey();
                Console.WriteLine("Hmac is: " + HmacFather.GetHmac(args[computerMove], key));
                checkCorrect((Console.ReadLine().Trim()), args);
                Console.WriteLine("Your move is: " + args[Int32.Parse(playerMove) - 1]);
                Console.WriteLine("Computer move is: " + args[computerMove]);
                Console.WriteLine(GameLogicClass.getWinCodition(Int32.Parse(playerMove) - 1, computerMove, args));
                Console.WriteLine("Hmac key: " + key);
            }
            else
            {
                Console.WriteLine("Number of arguments isn't odd or/and it's value less than three");
                Console.WriteLine("Example: >dotnet run arg1 arg2 arg3");
            } 
        }
        private static void checkCorrect(string s, string[] arr) 
        {
            if (s.Trim().Equals("?")) 
            {
                TableFather.generateTable(arr);
                Console.Write("Enter your move: ");
                s = Console.ReadLine().Trim();
            }
            while (true) 
            {                
                if (Int32.TryParse(s, out int r))
                {
                    if (r - 1 < arr.Length)
                    {
                        if (r - 1 >= 0)
                        {
                            playerMove = s;
                            break;
                        }
                        if(r - 1 == -1) System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                }
                Console.WriteLine("Incorrect value: must be a positive number, above or equal 0 and below " + arr.Length.ToString());
                s = Console.ReadLine();
            }

        }
        private static void showMoves(string[] mov) 
        {
            for(int i = 0; i < mov.Length; i++) 
            {
                Console.WriteLine((i + 1) + " : " + mov[i]);
            }
            Console.WriteLine("? - help");
            Console.WriteLine("0 - exit");
        }
        
    }
}
