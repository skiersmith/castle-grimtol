using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public bool Locked {get; set;}

        public Dictionary<string, Room> Exits { get; set; }
        // public List<Player> Player { get; set; }



        public void UseItem(Item item)
        {
            throw new System.NotImplementedException();
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