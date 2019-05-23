using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        static void Main()
        {
            var result = Generator.GetSurprise();

            Type type = result.GetType();

            Console.WriteLine("========Поля=========");

            foreach (FieldInfo fInfo in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(fInfo.Name + " = " + fInfo.GetValue(result));
            }
            Console.WriteLine("=======Методы========");

            //для исключения из итогового вывода методы object
            Type temp = new object().GetType();
            MethodInfo[] ObjectMethods = temp.GetMethods();

            foreach (var m in type.GetMethods())
            {
                bool Cont = false;
                foreach (var item in ObjectMethods)
                {
                    if (m.ToString() == item.ToString())
                    {
                        Cont = true;
                        break;
                    }
                }

                if (!Cont)
                {
                    Console.WriteLine(m);
                    Console.Write("Invoke =>");

                    try
                    {
                        object t = m.Invoke(result, new object[m.GetParameters().Length]);
                        Console.WriteLine(t + "\n------");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                   
                }
            }
        }
    }
}
