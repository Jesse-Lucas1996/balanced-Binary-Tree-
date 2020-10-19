using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Jesse Lucas
// 14/08/2020
// P274063
namespace Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            bt.Add("Jesse");
            bt.Add("Calum");
            bt.Add("Nathan");
            bt.Add("Travis");
            bt.Add("Inarius");
            bt.Add("Bundo");
            bt.Add("Balgour");
            bt.Add("Hughug");
            bt.Add("Jessica");
            bt.Add("Lucy");
   


            bt.Display();
            Console.WriteLine();
            string choice = DisplayMenu();
            Console.WriteLine();
            do
            {
                switch (choice)
                {
                    case "A":
                        bt.Add(NewItem());
                        break;
                    case "D":
                        bt.Delete(DeleteItem());
                        break;
                    case "F":
                        bt.SearchItem(SearchItem());
                        break;
                    default: break;
                }
                if (choice != "Q")
                {
                    bt.Display();
                    Console.WriteLine();
                    choice = DisplayMenu();
                    Console.WriteLine();
                }
            }
            while (choice != "Q");
        }
           
            static public string SearchItem()
            {
            Console.WriteLine("Enter data to be searched");
            return Console.ReadLine();
            
            }
            static public string DeleteItem()
            {
                Console.WriteLine("Enter data item for deletion");
            
            return Console.ReadLine();
            }
            static public string NewItem()
            {
                Console.WriteLine("Enter data item into Tree");
                 return Console.ReadLine();
           

            }
            static public string DisplayMenu()
            {
                Console.WriteLine("(A)dd item");
                Console.WriteLine("(D)elete item");
                Console.WriteLine("(F)ind item");
                Console.WriteLine("(Q)uit");
                Console.WriteLine("Please select an Option: ");
                return Console.ReadLine().ToUpper();
            }
        }
    }
