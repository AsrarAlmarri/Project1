using System;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        // declare Global variables 
        public static int Count;
        public static int ID;
        public static string Name;
        public static string Class;
        public static string Section;
        static void Main(string[] args)
        {
            Console.WriteLine("                                      *****************WELCOME*********************\n\n\n ");
            Console.WriteLine("                                      This is Rainbow School Storing System ");
            Console.WriteLine("                                      ********************************************\n");
            Console.WriteLine("                                      Add New Data or Update an old one :");
            Console.WriteLine("                                      ********************************************");
            Console.WriteLine("                                      Insert the ID number :");

            // read from user

            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("                                      Name:");
            Name = Console.ReadLine();
            Console.WriteLine("                                      Class:");
            Class = Console.ReadLine();
            Console.WriteLine("                                      Section:");
            Section = Console.ReadLine();

            RunFile();
        }
        public static void RunFile()
        {
            //Adding the file to a directory
            string dir = Directory.GetCurrentDirectory();
            string filename = "TeacherData.txt";
            if (File.Exists(filename))
            {

                string[] check = File.ReadAllLines(filename);//Read the file to check if exisit 
                if (check.Contains("ID: " + ID))
                {
                    for (int i = 0; i < check.Length; i++)
                    {

                        if (check[i].Contains("ID: " + ID)) //Checking ID if listed
                        {
                            //Updating the old data
                            check[i + 1] = "Teacher Name: " + Name;
                            check[i + 2] = "Class: " + Class;
                            check[i + 3] = "Section: " + Section;

                            using (StreamWriter sw = File.CreateText(filename))
                            {

                                foreach (string line in check)
                                {
                                    sw.WriteLine(line);
                                }
                            }
                            Console.WriteLine("Data Edited Successfully!");

                        }
                    }
                }
                else
                {
                    //If ID of the teacher does not exists, a new for will be added
                    using (StreamWriter sw = File.AppendText(filename))
                    {
                        sw.WriteLine("ID: " + ID);
                        sw.WriteLine("Teacher Name: " + Name);
                        sw.WriteLine("Class: " + Class);
                        sw.WriteLine("Section: " + Section);
                        sw.WriteLine("********************************************");
                    }
                    Console.WriteLine("Data Added Successfully!");
                }
            }
            else
            {
                File.CreateText(filename);
            }


        }
    }
}

