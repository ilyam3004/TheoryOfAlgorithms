using System;
using Lab4.LinkedList;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
           //Creating students
           Student student1 = new("Дем'ян", "Що таке O(n)?", "Розфарбуйте граф");
           Student student2 = new("Iлля", "Розкажiть про методи розобки алгоритмiв.", "Реалiзуйте на даному графi пошук вглиб");
           Student student3 = new("Сергiй", "Що таке звя'знiсть графу?", "Реалiзуйте на даному графi пошук в ширину");
           Student student4 = new("Iван", "Пояснiть алгоритми пошуку в ширину та в глибину.", "Знайдiть максимальний потiк у мережi");
           //Forming group
           LinkedList<Student> group = new();
           group.Add(student1);
           group.Add(student2);
           group.Add(student3);
           group.Add(student4);
           //Student info 
           Console.WriteLine("Student info:");
           Console.WriteLine("-------------");
           foreach (Student student in group) 
               Console.WriteLine("Student: " + student.name);
           Console.WriteLine("-------------");
           //Test
           string transmited = "Що таке граф?";
           foreach (Student student in group)
           {
               student.givenTheoryQuestion = transmited;
               Console.WriteLine($"{student.name} is doing theory test");
               Console.WriteLine($"{student.name} has first theory question: \"{student.theoryQuestion}\"");
               Console.WriteLine($"{student.name} has second theory question from prev student: \"{student.givenTheoryQuestion}\"");
               Console.WriteLine($"{student.name} is doing practical test");
               Console.WriteLine($"{student.name} has practical question: \"{student.practQuestion}\"");
               Console.WriteLine("--------------------------------");
               transmited = student.theoryQuestion;
           }
           
        }
    }
}
