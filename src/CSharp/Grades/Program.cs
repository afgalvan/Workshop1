using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Grades
{
    internal class Grade
    {
        private IEnumerable<double> Grades { get; }

        public Grade(IEnumerable<double> grades) => Grades = grades;

        public double Average() =>
            // Grades.Average();
            Grades.Zip(new[] {0.3, 0.3, 0.4}, (a, b) => a * b)
                .Sum();

        public bool Passes() => Average() >= 3.0;
    }

    internal static class Program
    {
        public static int GradesAmount = 3;

        private static void Main()
        {
            Grade grade = new(AskUserGrades(GradesAmount).ToList());
            Console.WriteLine(ShowResults(grade));
        }

        private static double AskGrade(int gradeIndex)
        {
            Console.Write($"{gradeIndex}. Ingrese una nota: ");
            return Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
        }

        private static IEnumerable<double> AskUserGrades(int amount)
        {
            for (var i = 1; i <= amount; i++)
                yield return AskGrade(i);
        }

        private static string ResultString(Grade grade) => grade.Passes() ? "ganó" : "perdió";

        private static string ShowResults(Grade grade) =>
            $"\nEl estudiante {ResultString(grade)} la materia con una nota de {grade.Average()}.";
    }
}