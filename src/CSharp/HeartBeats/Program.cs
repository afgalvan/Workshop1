using System;
using System.Globalization;
using System.Linq;

namespace HeartBeats
{
    internal enum Genre : ushort
    {
        Female = 220,
        Male   = 210,
    }

    class Person
    {
        public Person(Genre genre, int age)
        {
            Genre = genre;
            Age   = age;
        }

        public Genre Genre { get; }
        public int   Age   { get; }
        public double HeartBeats() => ((int)Genre - Age) / 10.0;
    }

    class InvalidGenreException : Exception
    {
#nullable enable
        public InvalidGenreException(string? message) : base(message)
        {
        }
#nullable disable
    }

    static class Program
    {
        static void Main()
        {
            ShowResults(ReadPerson());
        }

        private static Person ReadPerson() => new(AskGenre(), AskAge());

        private static void ShowResults(Person person) =>
            Console.WriteLine($"Su pulsación es de {person.HeartBeats()}");

        private static int AskAge()
        {
            Console.WriteLine("Ingresa tu edad: ");
            return Convert.ToInt32(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);
        }

        private static Genre AskGenre()
        {
            while (true)
            {
                Console.WriteLine("Ingresa tu género [F/M]: ");
                try
                {
                    return MapCharToGenre(Console.ReadLine()
                        ?.ToUpper(CultureInfo.InvariantCulture).FirstOrDefault());
                }
                catch (InvalidGenreException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static Genre MapCharToGenre(char? letter) => letter switch
        {
            'F' => Genre.Female,
            'M' => Genre.Male,
            _ => throw new InvalidGenreException("Genero inválido.")
        };
    }
}
