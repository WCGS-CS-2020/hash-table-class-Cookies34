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
                int Location = Hash(data);
                table[Location].Remove(data);
            }

            public void Find(object data) 
            {
                int Location = Hash(data);
                if (table[Location].Index(data) != -1) {
                    Console.WriteLine("Object[{2}] found at {0},{1}", Location, table[Location].Index(data), data);
                }
            }

            public void LoadFactor() {
                int count = 0;
                foreach (var c in table) {
                    Console.WriteLine("{0}. {1}",count,c.Length());
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
                while (thing.ToString() != x.ToString()) {
                    try
                    {
                        currentNode = currentNode.next;
                        thing = currentNode.data;
                        count++;
                    }
                    catch (System.NullReferenceException) {
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
                        else {
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
            table.Add("Bobb");
            table.Add("yayayayayay");
            table.Add(69);
            table.Add(9.668F);
            table.Add(3F / 5F);
            table.Add("johnny woz ere");
            table.Add("ZOOOOMMMMBIEIE");
            table.Add(895);
            table.Add("wudhyug");
            table.Add("gyqwhgu");
            table.Add("wudhugy");
            table.Add("Kelvin");
            table.Print();
            Console.Write("\n");
            table.Remove("wudhyug");
            table.Print();
            Console.Write("\n");
            table.LoadFactor();
            table.Find("wudhugy");
            table.Find("Bobb");
        }
    }
}