using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {


        // public static bool running = true;

        public static void Main(string[] args)
        {


            bool playing = true;
            Game game = new Game();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            game.Setup();
            System.Console.WriteLine("What is your name?");
            var input3 = game.handleInput();
            while (playing)
            {

                var player1 = new Player(input3);
                game.CurrentPlayer = player1;
                System.Console.WriteLine("Hello " + game.CurrentPlayer.Name + "! Welcome to Castle Grimtol. Press enter to continue.");
                System.Console.ReadLine();

              
                System.Console.WriteLine("You have successfully infultrated the Grimtol Castle. You must find the treasure and escape!");

                System.Console.WriteLine("Type: play or q");
                var input2 = game.handleInput().ToLower();




                switch (input2)
                {

                    case "q":
                        Console.WriteLine("Excellent!");
                        return;

                    case "play":
                        Console.WriteLine("Excellent!");
                        game.Run();
                        break;


                    default:
                        Console.WriteLine("Unrecognized Input!");
                        continue;

                }


            }
        }
    }
}
