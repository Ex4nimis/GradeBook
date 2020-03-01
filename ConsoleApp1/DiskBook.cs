using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{
    class DiskBook : Book
    {
        public string Folder = @"C:\";
        public DiskBook(string name, string folder) : base(name)
        {
            Name = name;
            Folder = folder;
        }
       
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Folder}{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Folder}{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }

                
            }
            return result;
        }
    }
}
