using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Score { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<Item> Inventory {get; set; }
        public Player( string name){
            Name = name;
            Inventory = new List<Item>();
        }
    }

}