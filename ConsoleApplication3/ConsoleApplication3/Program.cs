using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        class HashTable
        {
            LinkedList[] table = new LinkedList[31];

            public HashTable()
            {
                for (int i = 0; i < table.Length; i++)
                {
                    table[i] = new LinkedList();
                }
            }

            private int Hash(object s)
            {
                string data = s.ToString();
                int total = 0;
                foreach (char c in data)
                {
                    total += System.Convert.ToInt32(c);
                }
                total += 2456;
                return total % 31;
            }

            public void Add(object data)
            {
                int Location = Hash(data);
                table[Location].Append(data);
            }

            public void Remove(object data)
            {
                try
                {
                    int Location = Hash(data);
                    table[Location].Remove(data);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("HashTable> Value [{0}] has been removed", data);
                }
                catch (System.NullReferenceException) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Object not found (Null at hash)");
                }
            }

            public void Find(object data)
            {
                int Location = Hash(data);
                try
                {
                    if (table[Location].Index(data) != -1)
                    {
                        Console.WriteLine("Object[{2}] found at {0},{1}", Location, table[Location].Index(data), data);
                    }
                }
                catch (System.NullReferenceException) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Object not found in list (Null at hash)");  
                }
            }

            public void LoadFactor()
            {
                int count = 0;
                foreach (var c in table)
                {
                    Console.WriteLine("{0}. {1}", count, c.Length());
                    count++;
                }
            }

            public void Print()
            {
                for (int i = 0; i < table.Length; i++)
                {
                    Console.Write(i + ". ");
                    table[i].Print();
                    Console.WriteLine("");
                }
            }
        }

        class Node
        {
            public Node next = null;
            public object data = null;

            public Node(object a)
            {
                data = a;
                next = null;
            }

            public void Print()
            {
                Console.Write("[" + data + "]->");
                if (next != null)
                {
                    next.Print();
                }
            }

            public void Append(object x)
            {
                if (next == null)
                {
                    next = new Node(x);
                }
                else
                {
                    next.Append(x);
                }
            }
        }
        class LinkedList
        {
            Node head;

            public LinkedList()
            {
                head = null;
            }

            public void Print()
            {
                if (head == null)
                {
                    Console.Write("No data");
                }
                else
                {
                    head.Print();
                }
            }

            public void Append(object p)
            {
                if (head == null)
                {
                    head = new Node(p);
                }
                else
                {
                    head.Append(p);
                }
            }

            public void Remove(object x)
            {
                var currentNode = head;
                int count = 1;
                object thing = currentNode.data;
                bool toRemove = true;
                while (thing.ToString() != x.ToString())
                {
                    try
                    {
                        currentNode = currentNode.next;
                        thing = currentNode.data;
                        count++;
                    }
                    catch (System.NullReferenceException)
                    {
                        Console.Write("\n");
                        Console.WriteLine("Object not in list");
                        toRemove = false;
                        break;
                    }
                }
                if (count == 1)
                {
                    if (head.next == null)
                    {
                        head = null;
                    }
                    else
                    {
                        if (head.next.next != null)
                        {
                            head.next = head.next.next;
                        }
                        else
                        {
                            head.next = null;
                        }
                    }
                }
                else if (toRemove)
                {
                    currentNode = head;
                    for (int i = 0; i < count - 2; i++)
                    {
                        currentNode = currentNode.next;
                    }
                    currentNode.next = currentNode.next.next;
                }
            }

            public int Length()
            {
                var currentNode = head;
                int count = 0;
                while (currentNode != null)
                {
                    currentNode = currentNode.next;
                    count++;
                }
                return count;
            }

            public int Index(object x)
            {
                var currentNode = head;
                int count = 1;
                object thing = currentNode.data;
                while (thing.ToString() != x.ToString())
                {
                    try
                    {
                        currentNode = currentNode.next;
                        thing = currentNode.data;
                        count++;
                    }
                    catch (System.NullReferenceException)
                    {
                        Console.Write("\n");
                        Console.WriteLine("Object not in list");
                        return -1;
                    }
                }
                return count;
            }
        }

        static void Main(string[] args)
        {
            HashTable table = new HashTable();
            while (menu(table)) {
                continue;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Program end");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static bool menu(HashTable t) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================\n      Menu      \n================");
            Console.Write("[1] Add\n[2] Remove\n[3] Display Hash Table\n[4] Find Value\n[5] Load Factor\n[6] Quit\n>");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string input = Console.ReadLine();
            switch (input) { 
                case "1":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("HashTable> Enter value to add\n>");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string add = Console.ReadLine();
                    t.Add(add);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("HashTable> Value [{0}] has been added", add);
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("HashTable> Enter value to remove\n>");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string remove = Console.ReadLine();
                    t.Remove(remove);
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    t.Print();
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("HashTable> Enter value to find\n>");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    t.Find(Console.ReadLine());
                    break;
                case "5":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    t.LoadFactor();
                    break;
                case "6":
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Console> Invalid input");
                    break;
            }

            return true;
        }
    }
}