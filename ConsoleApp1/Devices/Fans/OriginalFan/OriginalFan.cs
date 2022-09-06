using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class OriginalFan : Fan
    {
        public override void Input()
        {
            fanType = 1;
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap ma san pham (theo format QD_(ma so) vi du QD_001) : ");
                id = Console.ReadLine();
            }
            while (!checkID(id));
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

        private bool checkID(string idCheck)
        {

            var regexItem = new Regex("^[a-zA-Z0-9_]*$");
            bool check;
            check = (idCheck.IndexOf("QD_") == 0) ? true : false;
            if (regexItem.IsMatch(idCheck) && idCheck != "" && check)
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Luu y nhap ma so chi bao gom ky tu so va chu !!!");
                Console.WriteLine($"\t{c}=>  Cu phap ma so co dang (QD_(ma so) vi du QD_001)");
                return false;
            }
        }
    }
}
