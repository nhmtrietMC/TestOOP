using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{
    class Bill
    {
        private string _id;
        private string _date;
        private DetailBill _detailBill = new DetailBill();
        private Customer _customer = new Customer();
        private int _totalCost;
        public void Input()
        {
            do
            {
                Console.ResetColor();
                Console.Write("- Nhap ma hoa don : ");
                _id = Console.ReadLine();
            } while (!checkID(_id));

            do
            {
                Console.ResetColor();
                Console.Write("- Nhap ngay lap hoa don (dd/MM/yyyy) : ");
                _date = Console.ReadLine();
            }
            while (!checkDateTime(_date));
            Console.WriteLine("- Nhap thong tin khach hang : ");
            _customer.Input();
            _detailBill.Input();
            _totalCost = _detailBill.TotalCost;
        }

        public void Output()
        {
            Console.WriteLine("Hoa don : " + _id + " " +_date + " " +_totalCost);
            _customer.Output();
            _detailBill.Output();
        }

        public void OutputText()
        {
            StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\danh_sach_hoa_don.txt");
            sw.WriteLine();
            sw.WriteLine("        ----------------------------");
            sw.WriteLine();
            sw.WriteLine("Hoa don : " + _id + " " + _date + " " + _totalCost);
            sw.Close();
            _customer.OutputText();
            _detailBill.OutputText();
            
        }

        private bool checkDateTime(string dateCheck)
        {
            DateTime tempDate;
            if (DateTime.TryParseExact(dateCheck, "dd/MM/yyyy", null, DateTimeStyles.None, out tempDate))
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=>  Ngay lap hoa don khong hop le !!!");
                return false;
            }
        }

        private bool checkID(string idCheck)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(idCheck))
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=>  Luu y nhap ma so chi bao gom ky tu so va chu !!!");
                return false;
            }
        }
    }
}
