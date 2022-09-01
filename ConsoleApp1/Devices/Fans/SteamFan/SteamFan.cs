using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;

namespace ConsoleApp1
{
    class SteamFan : Fan
    {

        protected override int getValue()
        {
            return waterCapacity * 400;
        }
        public override void Input()
        {
            fanType = 2;
            base.Input();
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap dung tich nuoc : ");
                try
                {
                    waterCapacity = int.Parse(Console.ReadLine());
                }
                catch
                {
                    waterCapacity = 0;
                }
            }
            while (!checkWaterCapacity(waterCapacity));
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap so luong ban ra : ");
                try
                {
                    amountSold = int.Parse(Console.ReadLine());
                }
                catch
                {
                    amountSold = 0;
                }
            }
            while (!checkAmountSold(amountSold));
        }

        private bool checkWaterCapacity(int waterCapacityCheck)
        {
            if (waterCapacityCheck <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Dung tich nuoc phai nguyen duong !!!");
                return false;
            }
            else
                return true;
        }
        private bool checkAmountSold(int amountSoldCheck)
        {
            if (amountSold <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  So luong ban ra phai nguyen duong !!!");
                return false;
            }
            else
                return true;
        }
    }
}
