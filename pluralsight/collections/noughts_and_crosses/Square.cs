using System;

namespace noughts_and_crosses
{
    public enum Player { Noone = 0, Noughts, Crosses }

    public struct Square
    {
        public Player Owner { get; }
        public Square(Player owner)
        {
            this.Owner = owner;
        }

        public override string ToString()
        {
            switch (Owner)
            {
                case Player.Noone:
                    return ".";
                case Player.Crosses:
                    return "X";
                case Player.Noughts:
                    return "O";
                default:
                    throw new Exception("Invalid state");
            }
        }

    }

}