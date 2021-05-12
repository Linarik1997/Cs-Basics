using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SeaBattle
{
    public enum ShipOrientation
    {
        hotizontal,
        vertical
    }
    public class Ship
    {
        public int length;
        public ShipOrientation orientation;
        public int x;
        public int y;
        public List<Point> shipPosition = new List<Point>();
        
        public Ship(int length)
        {
            this.length = length;
            Random rnd = new Random();
            if(rnd.Next(0,2) == 0)
            {
                this.orientation = ShipOrientation.hotizontal;
            }
            else
            {
                this.orientation = ShipOrientation.vertical;
            }
        }
        public static List<Ship> defShips()
        {
            List<Ship> ships = new List<Ship>();
            for (int i = 0; i < 1; i++)
            {
                ships.Add(new Ship(4));
            }
            for (int i = 0; i < 2; i++)
            {
                ships.Add(new Ship(3));
            }
            for (int i = 0; i < 3; i++)
            {
                ships.Add(new Ship(2));
            }

            for (int i = 0;i < 4; i++)
            {
                ships.Add(new Ship(1));
            }
            return ships;
        }

    }
}
