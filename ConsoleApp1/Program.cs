using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int choose = 0;
            Bills DataBill = null;
            bool check = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t--------Menu--------");
                Console.WriteLine("\t\t\t1. Nhap phim so 1 de nhap hoa don");
                Console.WriteLine("\t\t\t2. Nhap phim so 2 de xem hoa don");
                Console.WriteLine("\t\t\t3. Nhan phim so 3 de hoa don da tai xuong o dau");
                Console.WriteLine("\t\t\t4. Nhan phim so 4 de ket thuc chuong trinh");

                do
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("\t\t\t-  Moi ban dua ra lua chon : ");
                        choose = int.Parse(Console.ReadLine());
                        if (choose < 1 || choose > 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t=> Chi nhap (1, 2, 3 hoac 4) !!!");
                            check = false;
                        }
                        else
                            check = true;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t=> Chi nhap (1, 2, 3 hoac 4) !!!");
                        check = false;
                    }

                } while (!check);

                switch (choose)
                {
                    case 1:
                        DataBill = new Bills();
                        DataBill.Input();
                        break;
                    case 2:
                        Console.Clear();
                        if (DataBill == null)
                        {
                            Console.Write("\t\t\tHien tai chua co hoa don nao de xem, vui long nhan phim bat ki de tro lai menu ");
                            Console.ReadKey();
                        }    
                        else 
                            DataBill.Output();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\t\t\t" + @" Ban xem nhung file da tai xuong tai dia chi sau : C:\(Ten may cua ban)\Desktop\danh_sach_hoa_don.txt ");
                        Console.WriteLine ("\t\t\t Ban co the nhanh chong tim tai Desktop voi file co ten la danh_sach_hoa_don.txt");
                        Console.WriteLine("\t\t\t Vui long nhan phim bat ki de tro lai menu ");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t Chan thanh cam on ban da su dung chuong trinh cua minh !!!");
                        break;
                    default:
                        break;
                }
            } while (choose != 4);
            Console.ResetColor();
        }
    }
}
