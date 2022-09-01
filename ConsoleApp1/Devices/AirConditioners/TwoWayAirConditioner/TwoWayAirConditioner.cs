using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class TwoWayAirConditioner:AirConditioner
    {
        public override void Input()
        {
            airConditionerType = 2;
            base.Input();
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Co su dung cong nghe khang khuan khong (0 - khong, 1 - co) : ");
                try
                {
                    isAntibacterial = int.Parse(Console.ReadLine());
                }
                catch
                {
                    isAntibacterial = -1;
                }
            }
            while (!checkIsAntibacterial(isAntibacterial));

            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Co su dung cong nghe khu mui khong (0 - khong, 1 - co) : ");
                try
                {
                    isDeodorization = int.Parse(Console.ReadLine());
                }
                catch
                {
                    isDeodorization = -1;
                }
            }
            while (!checkIsDeodorization(isDeodorization));
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
        private bool checkIsAntibacterial(int isAntibacterialCheck)
        {
            if ((isAntibacterialCheck < 0) || (isAntibacterialCheck > 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Vui long luu y chi nhap (0 hoac 1) !!!");
                return false;
            }
            else
                return true;
        }
        private bool checkIsDeodorization(int isDeodorizationCheck)
        {
            if ((isDeodorizationCheck < 0) || (isDeodorizationCheck > 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=>  Vui long luu y chi nhap (0 hoac 1) !!!");
                return false;
            }
            else
                return true;
        }

        protected override int getValue()
        {
            int totalValue = 0;
            totalValue += (isInverter == 0) ? 2000 : 2500;
            totalValue += (isAntibacterial == 0) ? 0 : 500;
            totalValue += (isDeodorization == 0) ? 0 : 500;
            return totalValue;
        }
    }
}
