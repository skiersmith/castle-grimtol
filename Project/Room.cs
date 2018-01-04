using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public bool Locked { get; set; }

        public Dictionary<string, Room> Exits { get; set; }
        // public List<Player> Player { get; set; }



        public void UseItem(Item item)
        {
            if (item.Name == "lockpick")
            {
                if (item.Name == "key")
                {
                    System.Console.WriteLine("Success!");
                    Locked = false;
                }
                else
                {


                    bool valid = true;
                    while (valid == true)
                    {
                        Random rnd = new Random();
                        int odds = rnd.Next(1, 25);
                        // System.Console.WriteLine(odds);
                        System.Console.WriteLine("Picking lock...");
                        if (odds < 3)
                        {
                            System.Console.WriteLine("Success!");
                            Locked = false;
                            valid = false;
                        }
                        else
                        {

                            System.Threading.Thread.Sleep(2000);
                            System.Console.WriteLine("Your attempt has failed Click enter to try again.");
                            System.Console.ReadLine();

                            continue;
                        }


                    }
                }
                return;
            }
        }



        public Room(string name, string description, bool locked)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, Room>();
            Items = new List<Item>();
            Locked = locked;


        }

    }
}