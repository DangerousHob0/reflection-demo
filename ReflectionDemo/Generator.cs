using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Generator
    {
        public enum SupriseTypes: byte
        { TypeOne, TypeTwo, TypeThree }

        public static dynamic GetSurprise()
        {
            Array values = Enum.GetValues(typeof(SupriseTypes));
            Random r = new Random();
            SupriseTypes type = (SupriseTypes)values.GetValue(r.Next(values.Length));

            switch (type)
            {
                case SupriseTypes.TypeOne:
                    return new Person() { Name = "John" };
                case SupriseTypes.TypeTwo:
                    return new { Id = 2, Name = "Ivan", Age = 30};
                case SupriseTypes.TypeThree:
                    return new { Data = new Person() { Name = "Yurii" }, Process = new Action(Generator.PrintAPerson) };       
            }
            return null;
        }

        public static void PrintAPerson()
        {
            Console.WriteLine("Stub");
        }
    }
}
