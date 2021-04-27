using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    enum Alignment
    {
        Left,
        Right,
        Centre
    }
    public struct goods
    {
        public string goodName;
        public double pricePerItem;
        public int quantity;
        public double totalPrice;

        public goods(string goodName, double pricePerItem, int quantity)
        {
            this.goodName = goodName;
            this.pricePerItem = pricePerItem;
            this.quantity = quantity;
            this.totalPrice = pricePerItem * quantity;
        }
    }
    class Cheque
    {
        string orgName;
        string orgAdress;
        int orgINN;
        int cassID;
        DateTime dtPrint;
        public List<goods> goodsList;

        public double totalPrice
        {
            get
            {
                double totalPrice = 0;
                foreach(var good in goodsList)
                {
                    totalPrice += good.totalPrice;
                }
                return totalPrice;
            }
        }
        public Cheque(string orgName, string orgAdress, int orgINN, int cassID)
        {
            goodsList = new List<goods>();
            this.orgName = orgName;
            this.orgAdress = orgAdress;
            this.orgINN = orgINN;
            this.cassID = cassID;
            dtPrint = new DateTime(2021, 3, 2, 3, 35, 5);
        }
        public void DrawLine(int xLeft, int xRight, char sym)
        {
            for(int x=xLeft; x <= xRight; x++)
            {
                Console.SetCursorPosition(x, Console.CursorTop);
                Console.Write(sym);
            }
            Console.WriteLine("");
        }
        public void Print(Alignment alignment,string message)
        {
            switch (alignment)
            {
                case (Alignment.Left):
                    break;
                case (Alignment.Centre):
                    Console.SetCursorPosition((Console.BufferWidth / 2) - message.Length, Console.CursorTop);
                    break;
                case (Alignment.Right):
                    Console.SetCursorPosition(Console.BufferWidth - message.Length, Console.CursorTop);
                    break;
            }
            Console.Write(message);
            Console.WriteLine("");
        }

        public void Draw()
        {
            Print(Alignment.Centre, orgName);
            Print(Alignment.Centre, orgAdress);
            Print(Alignment.Left, $"ИНН: {orgINN}");
            Print(Alignment.Left, $"КАССА:{cassID}");
            Print(Alignment.Left, $"ДАТА: {dtPrint}");
            DrawLine(1, Console.BufferWidth - 1, '_');
            Print(Alignment.Left, "Кассовый чек");
            DrawLine(1, Console.BufferWidth - 1, '_');
            string[] headers = { "Наименование товара", "Цена за ед.", "Кол-во", "Итого" };
            Console.Write("Наименование товара");
            Console.SetCursorPosition(35, Console.CursorTop);
            Console.Write("Цена за ед.");
            Console.SetCursorPosition(48, Console.CursorTop);
            Console.Write("Кол-во");
            Console.SetCursorPosition(58, Console.CursorTop);
            Console.Write("Итого");
            Console.WriteLine("");
            foreach (var good in goodsList)
            {
                Console.Write(good.goodName);
                Console.SetCursorPosition(35, Console.CursorTop);
                Console.Write(good.pricePerItem);
                Console.SetCursorPosition(48, Console.CursorTop);
                Console.Write(good.quantity);
                Console.SetCursorPosition(58, Console.CursorTop);
                Console.Write(good.totalPrice);
                Console.WriteLine("");
            }
            DrawLine(1, Console.BufferWidth - 1, '_');
            Print(Alignment.Right, $"ИТОГО К ОПЛАТЕ:  {totalPrice}");
            Print(Alignment.Right, $"НАЛИЧНЫЕ:  {totalPrice + 237}");
            Print(Alignment.Right, $"СДАЧА:  {totalPrice + 237 - totalPrice}");
            DrawLine(1, Console.BufferWidth - 1, '_');
            Print(Alignment.Right, $"НДС 20%:  {totalPrice * 0.2}");
        } 
    }
}
