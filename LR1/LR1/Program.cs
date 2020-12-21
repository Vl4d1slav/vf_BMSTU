using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;



namespace SquareRoot
{
    interface RootsResult { };
    class NoRoots : RootsResult { };
    class OneRoot : RootsResult
    {
        public double root { get; set; }

    }
    class TwoRoots : RootsResult
    {
        public double root1 { get; set; }
        public double root2 { get; set; }

    }
    class ThreeRoots : RootsResult
    {
        public double root1 { get; set; }
        public double root2 { get; set; }
        public double root3 { get; set; }

    }
    class FourRoots : RootsResult
    {
        public double root1 { get; set; }
        public double root2 { get; set; }
        public double root3 { get; set; }
        public double root4 { get; set; }
    }
    class SquareRoot_WithInterface
    {
        public int CheckS(double s)
        {
            int k = 0;
            if (s == 0)
            {
                k = 1;
                return k;
            }
            else if (s > 0)
            {
                k = 2;
                return k;
            }
            else
            {
                k = 0;
                return k;
            }
        }

        public RootsResult CalculateRoots(double a, double b, double c)
        {
            List<double> roots = new List<double>();
            // int temp = 0; // кол-во корней
            double D = b * b - 4 * a * c;
            if (D == 0)
            {
                double s = -b / (2 * a);
                switch (CheckS(s))
                {
                    case 1:
                        return new OneRoot()
                        {
                            root = Math.Sqrt(s)
                        };
                    case 2:
                        return new TwoRoots()
                        {
                            root1 = Math.Sqrt(s),
                            root2 = -Math.Sqrt(s)
                        };
                    default:
                        return new NoRoots()
                        {
                        };
                }
            }
            else if (D > 0)
            {
                double s1 = (-b + Math.Sqrt(D)) / (2 * a);
                double s2 = (-b + Math.Sqrt(D)) / (2 * a);
                // temp = CheckS(s1);
                switch (CheckS(s1))
                {
                    case 0:
                        if (CheckS(s2) == 0)
                            return new NoRoots()
                            {

                            };
                        else if (CheckS(s2) == 1)
                            return new OneRoot()
                            {
                                root = Math.Sqrt(s2)
                            };
                        else if (CheckS(s2) == 2)
                            return new TwoRoots()
                            {
                                root1 = Math.Sqrt(s2),
                                root2 = -Math.Sqrt(s2)
                            };
                        break;
                    case 1:
                        if (CheckS(s2) == 0)
                            return new OneRoot()
                            {
                                root = Math.Sqrt(s1)
                            };
                        else if (CheckS(s2) == 1)
                            return new TwoRoots()
                            {
                                root1 = Math.Sqrt(s1),
                                root2 = Math.Sqrt(s2)
                            };
                        else if (CheckS(s2) == 2)
                            return new ThreeRoots()
                            {
                                root1 = Math.Sqrt(s1),
                                root2 = Math.Sqrt(s2),
                                root3 = -Math.Sqrt(s2)
                            };
                        break;
                    case 2:
                        if (CheckS(s2) == 0)
                            return new TwoRoots()
                            {
                                root1 = Math.Sqrt(s1),
                                root2 = -Math.Sqrt(s2)
                            };
                        else if (CheckS(s2) == 1)
                            return new ThreeRoots()
                            {
                                root1 = Math.Sqrt(s1),
                                root2 = -Math.Sqrt(s1),
                                root3 = Math.Sqrt(s2)
                            };
                        else if (CheckS(s2) == 2)
                            return new FourRoots()
                            {
                                root1 = Math.Sqrt(s1),
                                root2 = -Math.Sqrt(s1),
                                root3 = Math.Sqrt(s2),
                                root4 = -Math.Sqrt(s2)
                            };
                        break;
                    default:
                        Console.Write("Ошибка");
                        return new NoRoots()
                        {

                        };
                }

            }
            else if (D < 0)
            {
                Console.Write("Дискриминант < 0\n");
                return new NoRoots()
                {

                };
            }
            return new NoRoots();
        }
        public void PrintRoots(double a, double b, double c)
        {
            RootsResult result = this.CalculateRoots(a, b, c);
            Console.Write("Коэффициенты: a={0}, b={1}, c={2}. ", a, b, c);
            string resultType = result.GetType().Name;
            if (resultType == "NoRoots")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nКорней нет.");
            }
            else if (resultType == "OneRoot")
            {
                OneRoot rt1 = (OneRoot)result;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nОдинкорень {0}", rt1.root);
            }
            else if (resultType == "TwoRoots")
            {
                TwoRoots rt2 = (TwoRoots)result;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nДва корня: {0} и {1}", rt2.root1, rt2.root2);
            }
            else if (resultType == "ThreeRoots")
            {
                ThreeRoots rt3 = (ThreeRoots)result;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nТри корня: {0}, {1}, {2}", rt3.root1, rt3.root2, rt3.root3);
            }
            else if (resultType == "FourRoots")
            {
                FourRoots rt4 = (FourRoots)result;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nЧетыре корня: {0}, {1}, {2}, {3}", rt4.root1, rt4.root2, rt4.root3, rt4.root4);
            }
        }


    }
    class program
    {
        //public static bool TryParse(string s, out int result);
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                int a, b, c;
                Console.WriteLine("\t\tЛР1\tФурасов В.Д.\tИУ5-34Б\n");

                Console.WriteLine("Введите коэффициент a:");
                while (true)
                {
                    if (Int32.TryParse(Console.ReadLine(), out a))
                        break;
                    else
                        Console.WriteLine("Вы ввели некорректное значение, повторите ввод коэффициента a:");
                }
                Console.WriteLine("Введите коэффициент b:");
                while (true)
                {
                    if (Int32.TryParse(Console.ReadLine(), out b))
                        break;
                    else
                        Console.WriteLine("Вы ввели некорректное значение, повторите ввод коэффициента b:");
                }
                Console.WriteLine("Введите коэффициент c:");
                while (true)
                {
                    if (Int32.TryParse(Console.ReadLine(), out c))
                        break;
                    else
                        Console.WriteLine("Вы ввели некорректное значение, повторите ввод коэффициента c:");
                }

                SquareRoot_WithInterface abs = new SquareRoot_WithInterface();
                abs.PrintRoots(a, b, c);
            }
            else
            {
                int a, b, c;
                Console.WriteLine("\t\tЛР1\tФурасов В.Д.\tИУ5-34Б\n");
                Console.WriteLine("! Введены аргументы командной строки !\n");               

                while (true)
                {
                    if (Int32.TryParse(args[0], out a))
                        break;
                    else
                        Console.WriteLine("Вы ввели некорректное значение, измените параметр  a:");
                }
                while (true)
                {
                    if (Int32.TryParse(args[1], out b))
                        break;
                    else
                        Console.WriteLine("Вы ввели некорректное значение, измените параметр  b:");
                }
                while (true)
                {
                    if (Int32.TryParse(args[2], out c))
                        break;
                    else
                        Console.WriteLine("Вы ввели некорректное значение, измените параметр c:");
                }
             //   Console.WriteLine("Введены аргументы: a = {0}, b = {1}, c={2}",a,b,c);

                SquareRoot_WithInterface abs = new SquareRoot_WithInterface();
                abs.PrintRoots(a, b, c);

                Console.ReadKey();
            }
        }
    }
}
