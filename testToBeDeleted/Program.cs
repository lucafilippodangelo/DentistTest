using System;

namespace testToBeDeleted
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Derived Luca = new Derived();
            Console.ReadLine();
        }
    }



    public class Base
    {
        public Base()
        {
            Console.WriteLine("In base");
        }
    }
    public class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("In derived");
        }
    }






}
