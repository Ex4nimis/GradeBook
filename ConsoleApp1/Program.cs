using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        
        static void Main(string[] args)
        {

            var folder = @$"C:\Users\govis\source\repos\GradeBook\";
            IBook book = new DiskBook("Wojciech Grade Book", folder);
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The Lowest grade is {stats.Low}");
            Console.WriteLine($"The Highest grade is {stats.High}");
            Console.WriteLine($"The Avrage grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");


        }

        private static void EnterGrades(IBook book)
        {
            do
            {

                Console.WriteLine("Pass grade and press enter or press only enter to calculate stats");
                var input = Console.ReadLine();
                if (input != "")
                {
                    try
                    {
                        book.AddGrade(double.Parse(input));
                        Console.WriteLine("Grade Added");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        //.. always execute even when theres an exception
                        Console.WriteLine("**");
                    }
                }
                else
                {
                    break;
                }


            } while (true);
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}