using System;

namespace ДЗ_8_v1
{
    class Node
    {
        // Сотрудник - кортеж
        public (int, string) Person;
        // Левое поддерево
        public Node Left { get; set; }
        // Правое поддерево
        public Node Right { get; set; }
    }

    class Program
    {
        // цифра перехода программы к этапу. 0 (переход к началу программы) или 1 (снова поиск зарплаты)
        public static int countI = 0;
        // Корень дерева
        public static Node root = null;

        static void Main(string[] args)
        {
            while (true)
            {

                int j = SalaryTable(countI);

                if (j > 1) break;

            }
        }

        public static int SalaryTable(int i)
        {

            // счётчик сотрудников в дереве
            int countEmployee = 0;
            // проверка на ввод int
            bool intBool;


            // Ввод информации о сотруднике и построение дерева
            if (i == 0)
            {
                root = null; // Корень дерева

                while (true)
                {
                    countEmployee++;

                    Console.WriteLine($"Введите имя сотрудника № {countEmployee} и зарплату:");

                    var name = Console.ReadLine();

                    if (name.Length == 0) break;

                    var salary = Console.ReadLine();
                    intBool = int.TryParse(salary, out _);
                    if (intBool)
                    {
                        if (root == null)
                        {
                            root = new Node
                            {
                                Person = (int.Parse(salary), name)
                            };
                        }
                        else
                        {
                            AddNode(root, new Node
                            {

                                Person = (int.Parse(salary), name)
                            });
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Ошибка ввода данных по зарплате");
                        countEmployee--;
                        Console.ResetColor();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("ИМЯ - ЗАРПЛАТА");
                Console.WriteLine("--------------");

                // Вывод информации о ЗП сотрудников из дерева по возрастанию 
                SalaryIncrease(root);

                // Поиск сотрудника по ЗП
                Console.WriteLine();
                Console.WriteLine("Какой размер зарплаты интересует?");
                var needle = Console.ReadLine();
                intBool = int.TryParse(needle, out _);

                if (intBool)
                {
                    var salaryToFind = Find(root, int.Parse(needle));
                    if (salaryToFind != null)
                    {
                        Console.WriteLine($"Нашли зарплату: {needle} у сотрудника {salaryToFind.Person.Item2}");
                    }
                    else
                    {
                        Console.WriteLine("Такой сотрудник не найден");
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ошибка ввода данных по зарплате");
                    countEmployee--;
                    Console.ResetColor();
                }

                // возврат к этапу программы
                Console.WriteLine();
                Console.WriteLine("Введите цифру 0 (переход к началу программы) или 1 (снова поиск зарплаты)");
                var programm = Console.ReadLine();

                intBool = int.TryParse(programm, out _);
                if (intBool)
                {
                    countI = int.Parse(programm);
                    return countI;
                }
                {

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ошибка ввода данных, программа возвращается к началу");
                    Console.ResetColor();

                    return 0;
                }

            }
            // Поиск сотрудника по ЗП
            else if (i == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Какой размер зарплаты интересует?");
                var needle = Console.ReadLine();
                intBool = int.TryParse(needle, out _);

                if (intBool)
                {
                    var salaryToFind = Find(root, int.Parse(needle));
                    if (salaryToFind != null)
                    {
                        Console.WriteLine($"Нашли зарплату: {needle} у сотрудника {salaryToFind.Person.Item2}");
                    }
                    else
                    {
                        Console.WriteLine("Такой сотрудник не найден");
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ошибка ввода данных по зарплате");
                    countEmployee--;
                    Console.ResetColor();
                }

                // возврат к этапу программы
                Console.WriteLine();
                Console.WriteLine("Введите цифру 0 (переход к началу программы) или 1 (снова поиск зарплаты)");
                var programm = Console.ReadLine();

                intBool = int.TryParse(programm, out _);
                if (intBool)
                {
                    countI = int.Parse(programm);
                    return countI;
                }
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ошибка ввода данных, программа возвращается к началу");
                    Console.ResetColor();
                    return 0;
                }

            }

            return 2;
        }


        public static Node Find(Node node, int needle)
        {
            if (needle < node.Person.Item1)
            {
                // ищем в левом поддереве
                if (node.Left == null)
                {
                    return null;
                }
                return Find(node.Left, needle);
            }
            else if (needle > node.Person.Item1)
            {
                // ищем в правом поддереве
                if (node.Right == null)
                {
                    return null;
                }
                return Find(node.Right, needle);
            }
            else
            {
                return (node);
            }
        }


        public static void AddNode(Node node, Node person)
        {
            if (person.Person.Item1 < node.Person.Item1)
            {
                // Добавляем в левое поддерево
                if (node.Left == null)
                {
                    node.Left = person;
                }
                else
                {
                    AddNode(node.Left, person);
                }
            }
            else
            {
                // Добавляем в правое поддерево
                if (node.Right == null)
                {
                    node.Right = person;
                }
                else
                {
                    AddNode(node.Right, person);
                }
            }
        }


        public static void SalaryIncrease(Node node)
        {
            if (node.Left != null)
            {
                SalaryIncrease(node.Left);
            }

            Console.WriteLine($"{node.Person.Item2} - {node.Person.Item1}");

            if (node.Right != null)
            {
                SalaryIncrease(node.Right);
            }
        }

    }



}
