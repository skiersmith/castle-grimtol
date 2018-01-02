using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{

    public class Game : IGame
    {
        public bool Running = false;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }


        public void Run()
        {
            Running = true;
            while (Running)
            {
                Console.Clear();
                System.Console.WriteLine("PreStory.");
                System.Console.WriteLine("Current Room: " + CurrentRoom.Name + " "); //  + CurrentRoom.Exits.Values   trying to display exits of currentroom
                System.Console.WriteLine(CurrentRoom.Description);
                System.Console.WriteLine("n/s");
                var input = handleInput();





                switch (input.ToLower())
                {
                    case "q":
                        Console.WriteLine("Excellent!");
                        return;

                    case "n":
                        go("n");

                        continue;
                    case "e":
                        go("e");
                        continue;

                    case "s":
                        go("s");
                        continue;

                    case "w":
                        go("w");
                        continue;

                    default:
                        Console.WriteLine("Unrecognized Input!");
                        continue;

                }


            }
        }


        public void go(string direction)
        {
            if (direction == "n")
            {
                var newRoom = CurrentRoom.Exits["north"];
                CurrentRoom = newRoom;
                System.Console.WriteLine(CurrentRoom);
                return;
            }

            else if (direction == "s")
            {
                var newRoom = CurrentRoom.Exits["south"];
                CurrentRoom = newRoom;
                System.Console.WriteLine(CurrentRoom);
                return;
            }

            else if (direction == "e")
            {
                var newRoom = CurrentRoom.Exits["east"];
                CurrentRoom = newRoom;
                return;
            }

            else if (direction == "w")
            {
                var newRoom = CurrentRoom.Exits["west"];
                CurrentRoom = newRoom;
                return;
            }
            else
            {
                System.Console.WriteLine("bad input");
                return;
            }

        }
        public string handleInput()
        {
            System.Console.Write(":"); return System.Console.ReadLine();

        }
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void Setup()
        {

            var room1 = new Room("1", "A dim light courtyard with two doors.");
            var room2 = new Room("2", "test2yuh");
            System.Console.WriteLine("ayeee bish");
            room1.Exits.Add("north", room2);
            room2.Exits.Add("south", room1);
            CurrentRoom = room1;
            var lockpick = new Item("Lockpick", "A universal key");





        }
        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }


        public Game()
        {

        }
    }
}