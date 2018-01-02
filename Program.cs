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

            game.Setup();

            while (playing)
            {
                System.Console.WriteLine("What is your name?");
                var input3 = game.handleInput();


                var player1 = new Player(input3);
                game.CurrentPlayer = player1;
                System.Console.WriteLine("Hello " + game.CurrentPlayer.Name + "! Welcome to Castle Grimtol.");


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
