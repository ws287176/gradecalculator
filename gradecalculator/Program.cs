using System;

namespace GradeCalculator
{
    class Program
    {

        public class Student  // Public class student is where all the information is kept. 
        {
            public string Name = ""; // Public Access modifiers have been used 
            public int Mark;
            public bool GradeType = false;
            public Student(string name, int mark, bool grading) // This is the Constructor and it is called when the object of a class is created. 
            {
                Name = name;
                Mark = mark;  // 
                GradeType = grading;
            }

        }

        static bool CheckPass(string grade)
        {
            if(grade == "F" || grade == "U") // This if statement is used to determine what grades pass and fail. For example if you get anything F and below you fail otherwise you pass. 
            {
                return false;
            }
            return true;
        }
        static string CalcGrade(int mark, bool grade_type)
        {
            if(grade_type == true)
            {
                if(mark >= 91)
                {
                    return "A*";

                }
                else if(mark >= 81)
                {
                    return "A";
                }
                 else if(mark >= 71)
                {
                    return "B";
                }
                 else if(mark >= 61)
                {
                    return "C";
                }
                 else if(mark >= 51)
                {
                    return "D";
                }
                 else if(mark >= 31)
                {
                    return "E";
                }
                 else if(mark >= 11)
                {
                    return "F";
                }
                 else if(mark >= 0)
                {
                    return "U";
                }

            }

            if(mark >= 91)
            {
                return "B";
            }
            else if(mark >= 81)
            {
                return "C";
            }
            else if(mark >= 61)
            {
                return "D";
            }
            else if(mark >= 41)
            {
                return "E";
            }
            else if(mark >= 21)
            {
                return "F";
            }
            else if(mark >= 0)
            {
                return "U";
            }
             return ""; 
            }

        static void ListInfo(List<Student> students)
        {
            double higher_average_grade = -1;
            double lower_average_grade = -1;

            var higher_students = students.Where(student => student.GradeType == true);
            int higher_count = higher_students.Count();
            if(higher_count > 0)
            {
                higher_average_grade = higher_students.Average(x => x.Mark);
                higher_students = higher_students.OrderByDescending(x => x.Mark);
                foreach( Student student in higher_students)
                {
                    Console.WriteLine(student.Name.PadRight(20) + "|" + student.Mark.ToString().PadRight(5) + "|"  + CalcGrade(student.Mark, true).PadRight(5) + "|" + (CheckPass(CalcGrade(student.Mark, true)) ? "Passed" : "Failed").PadRight(10) + "|higher");

                }
            }

            var lower_students = students.Where(student => student.GradeType == false);
            int lower_count = lower_students.Count();
            if(lower_count > 0)
            {
                lower_average_grade = lower_students.Average(x => x.Mark);
                     lower_students = lower_students.OrderByDescending(x => x.Mark);
                foreach( Student student in lower_students)
                {
                    Console.WriteLine(student.Name.PadRight(20) + "|" + student.Mark.ToString().PadRight(5) + "|" + CalcGrade(student.Mark, false).PadRight(5) + "|" +
                     (CheckPass(CalcGrade(student.Mark, false)) ? "Passed" : "Failed").PadRight(10) + "|lower");

                }
            
            }

            if(lower_count > 0 && higher_count > 0)
            {
               // Console.WriteLine("The average grade for higher students was " + higher_average_grade + ": this grade is: " + CalcGrade(Convert.ToInt32(higher_average_grade), true));
               // Console.WriteLine("The average grade for lower students was " + + lower_average_grade + ": this grade is: " + CalcGrade(Convert.ToInt32(lower_average_grade), false));
            }
            else
            {
               // Console.WriteLine("The average grade was " + students.Average(student => student.Mark));
            }       
        }                           

        static Student GenerateStudent(int student_num)
        {
            student_num++;
            string name = "";
            int mark = 0;
            bool grading = false;

            Console.WriteLine("What is the first name of student " + student_num + ": ");
            name = Console.ReadLine() ?? ""; // Sets students name, or sets to a blank value if null
           
            bool found = false;
            while (!found) //Starting a loop to get students mark
            {
                Console.WriteLine("What is the mark of student " + student_num + ": ");
                bool convert_test = int.TryParse(Console.ReadLine(), out mark); // Checks if numeric value if so return true and return mark as this value
                if (convert_test == true)
                {
                    if (mark >= 0 && mark <= 100)
                    {
                        found = true;
                    }
                    else
                    {
                        Console.WriteLine("Please pick a value from 0 to 100");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a correct value");
                }
            }

            found = false;
            while (!found) //Starting a loop to get students grade type
            {
                Console.WriteLine("What is the grade type of " + student_num + ": 0 for lower or 1 for higher ");
                int temp_grade = -1;
                bool convert_test = int.TryParse(Console.ReadLine(), out temp_grade);
                if (convert_test == true)
                {
                    if (temp_grade == 0 || temp_grade == 1)
                    {
                        found = true;
                        if (temp_grade == 1)
                        {
                            grading = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please pick a value of 0 or 1");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a correct value");
                }
            }

            Student student = new Student(name, mark, grading);
            return student;
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>(); //data type

            for (int i = 0; i < 8; i++)
            {
                students.Add(GenerateStudent(i)); // curly brackets - loops/functions - anything that contains code () - calling functions - console.writeline("") parameters - <> - for specfic data types - [] - choosing index values
            }

            // Student new_student = new Student("Emily Barton", 95, true); // This creates a student object
            // Console.WriteLine(new_student.Name + " " + new_student.Mark); // This returns data from the object to make sure it works

        ListInfo(students);

        }
    
    }
}