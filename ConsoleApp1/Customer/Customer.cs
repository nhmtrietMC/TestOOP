using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Customer
    {

        public string c = ((char)124).ToString();
        private string _id = "";
        private string _name = "";
        private string _address = "";
        private string _phoneNumber = "";
        public void Input()
        {
            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap ma khach hang (Vi du nhap KH001): ");
                _id = Console.ReadLine();
            }
            while (!checkID(_id));

            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap ten khach hang: ");
                _name = Console.ReadLine();
            }
            while (!checkName(_name));

            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap dia chi: ");
                _address = Console.ReadLine();
            }
            while (!checkAddress(_address));

            do
            {
                Console.ResetColor();
                Console.Write($"\t{c}  Nhap so dien thoai: ");
                _phoneNumber = Console.ReadLine();
            }
            while (!checkPhoneNumber(_phoneNumber));
        }

        private bool checkID(string idCheck)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(idCheck) && idCheck != "")
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=> Luu y nhap ma so chi bao gom ky tu so va chu !!!");
                return false;
            } 
        }

        private bool checkName(string nameCheck)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(nameCheck) && nameCheck != "")
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=> Luu y nhap ten chi bao gom ky tu so va chu !!!");
                return false;
            }
        }

        private bool checkAddress(string addressCheck)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(addressCheck) && addressCheck != "")
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=> Luu y nhap dia chi chi bao gom ky tu so va chu !!!");
                return false;
            }
        }

        private bool checkPhoneNumber(string phoneNumberCheck)
        {
            if (phoneNumberCheck.Length != 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{c}=> Luu y so dien thoai cho co 10 so !!!");
                return false;
            }
            else
            {
                if (Regex.Match(phoneNumberCheck, @"^[0-9]").Success)
                    return true;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t{c}=> Luu y nhap so dien thoai chi bao gom ki tu (0-9) !!!");
                    return false;
                }
            }
        }

        public void Output()
        {
            Console.WriteLine("\nThong tin khach hang : " + _id + " " + _name + " " + _address + " " + _phoneNumber);
        }

        public void OutputText()
        {
            StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\danh_sach_hoa_don.txt");
            sw.WriteLine("\nThong tin khach hang : " + _id + " " + _name + " " + _address + " " + _phoneNumber);
            sw.Close();
        }
    }
}
