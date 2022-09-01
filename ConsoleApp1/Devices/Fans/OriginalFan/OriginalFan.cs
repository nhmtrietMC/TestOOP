using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;

namespace ConsoleApp1
{
    class OriginalFan : Fan
    {
        public override void Input()
        {
            fanType = 1;
            base.Input();
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
