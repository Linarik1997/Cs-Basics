using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SeaBattle
{
    class Map
    {
        /// <summary>
        /// Карта
        /// </summary>
        private char[,] map = new char[10, 10];
        /// <summary>
        /// Корабли на карте
        /// </summary>
        List<Ship> ships = new List<Ship>();
        Random rnd = new Random();
        /// <summary>
        /// Не доступные клетки
        /// </summary>
        List<Point> blocked = new List<Point>();
        /// <summary>
        /// Кол-во попыток для расположения кораблей
        /// </summary>
        private int attempt = 0;

        public int Attemp
        {
            get
            {
                return attempt;
            }
        }
        
        public void DrawMap(char empty, char placed) //Отрисовка карты
        {
            
            foreach(var ship in ships)
            {
                for(int i = 0; i < ship.shipPosition.Count; i++)
                {
                    map[ship.shipPosition[i].X , ship.shipPosition[i].Y] = placed;
                }
            }
            //Отладочный режим
            //for (int i = 0; i < blocked.Count; i++)
            //{
            //    if(blocked[i].X>=0 && blocked[i].X < 10 && blocked[i].Y >= 0 && blocked[i].Y<10)
            //    {
            //        if(map[blocked[i].X,blocked[i].Y]!= placed)
            //        {
            //            map[blocked[i].X, blocked[i].Y] = closed;
            //        }
            //    }
            //}

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == placed)
                        Console.Write(placed + " ");
                    //else if (map[i, j] == closed)
                    //    Console.Write(closed + " ");
                    else 
                        Console.Write(empty + " ");
                }
                Console.WriteLine("");
            }
        }
        private bool CanPlaceShip(Ship ship)//Проверка возможности расположения корабля
        {
            
            bool intersect = true;
            List<Point> check = Surround(ship); //Зона вокруг которой нельзя ставить корабль
            //Проверка каждой точки корабля 
            for (int i = 0; i < ship.shipPosition.Count ; i++)
            {
                //Если точка есть в списке не доустпных клеток, то возвращаем ложь
                if (blocked.Contains(ship.shipPosition[i])) 
                {
                    intersect = false;
                    return intersect;
                }
            }
            //Если точки нет в списке не доступных - добавляем точки в список не доступных и возвращаем истину
            for (int i = 0; i < check.Count; i++)
            {
                blocked.Add(check[i]);
            }
            return intersect;
        }
        public void PlaceShip(Ship ship)//расположение корабля на карте
        {
            bool isPlaced = false; //Успех - не успех
            switch (ship.orientation)// в зависимости от ориентации корабля строим его точки
            {
                case (ShipOrientation.vertical):
                    do
                    {
                        ship.x = rnd.Next(0, map.GetLength(0) );
                        ship.y = rnd.Next(0, (map.GetLength(0)) - ship.length);
                        for (int i = 0; i < ship.length; i++)
                        {
                            ship.shipPosition.Add(new Point(ship.x, ship.y + i));
                        }
                        if (CanPlaceShip(ship)) //Если успех - добавляем в общий список и признаку isPlaced присваиваем истину для выхода из цикла
                        {
                            ships.Add(ship);
                            isPlaced = true;
                        }
                        else
                        {
                            ship.shipPosition.Clear(); //Если не успех - обнуляем список с точками корабля
                            attempt++;
                        }
                    }
                    while (!isPlaced);
                    break;
                case (ShipOrientation.hotizontal):
                    do
                    {
                        ship.x = rnd.Next(0, (map.GetLength(0) ) - ship.length);
                        ship.y = rnd.Next(0, map.GetLength(0)  );
                        for (int i = 0; i < ship.length; i++)
                        {
                            ship.shipPosition.Add(new Point(ship.x + i, ship.y));
                        }
                        if (CanPlaceShip(ship))
                        {
                            ships.Add(ship);
                            isPlaced = true;
                        }
                        else
                        {
                            ship.shipPosition.Clear();
                            attempt++;
                        }
                    }
                    while (!isPlaced);
                    break;
            }
        }
        private List<Point> Surround(Ship ship) //метод для получения точек вокруг корабля, чтобы понять, где нельзя будет расположить корабли
        {
            Point leftUp = new Point();
            Point rightUp = new Point();
            Point leftBot = new Point();
            List<Point> rectangular = new List<Point>();
            switch (ship.orientation)
            {
                case (ShipOrientation.vertical):
                    leftUp.X = ship.shipPosition[0].X - 1;
                    leftUp.Y = ship.shipPosition[0].Y - 1;
                    rightUp.X = ship.shipPosition[0].X + 1;
                    rightUp.Y = ship.shipPosition[0].Y - 1;
                    leftBot.X = ship.shipPosition[ship.shipPosition.Count - 1].X - 1;
                    leftBot.Y = ship.shipPosition[ship.shipPosition.Count - 1].Y + 1;
                    for(int i = leftUp.X; i <= rightUp.X; i++)
                    {
                        for(int j = leftUp.Y; j <= leftBot.Y; j++)
                        {
                            rectangular.Add(new Point(i, j));
                        }
                    }
                    return rectangular;
                case (ShipOrientation.hotizontal):
                    leftUp.X = ship.shipPosition[0].X - 1;
                    leftUp.Y = ship.shipPosition[0].Y - 1;
                    rightUp.X = ship.shipPosition[ship.shipPosition.Count - 1].X + 1;
                    rightUp.Y = ship.shipPosition[ship.shipPosition.Count - 1].Y - 1;
                    leftBot.X = ship.shipPosition[0].X - 1;
                    leftBot.Y = ship.shipPosition[0].Y + 1;
                    for (int i = leftUp.X; i <= rightUp.X; i++)
                    {
                        for (int j = leftUp.Y; j <= leftBot.Y; j++)
                        {
                            rectangular.Add(new Point(i, j));
                        }
                    }
                    return rectangular;
                default:
                    return rectangular;
            }
        }
    }
}
