using System;
using MermaidDotNet;
using MermaidDotNet.ClassDiagrams;

namespace MyApp
{
    public class Animal
    {
        public int Age { get; set; }
        public string Gender { get; set; }

        public virtual bool IsMammal()
        {
            return true;
        }

        public void Eat()
        {
    
        }
    }
    
    public class Dog : Animal
    {
        public string Breed { get; set; }
        public Test Test { get; set; }

        public override bool IsMammal()
        {
            return true;
        }

        public void Woof()
        {
            // ...
        }
    }

    public class Test
    {
        public string MyString { get; set; }

        public bool MyBool()
        {
            return true;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            var diagram = new ClassDiagram(typeof(Dog), "My test");

            //var test = diagram.ClassFromType(typeof(Dog)).ToString();
            //Console.WriteLine(test);
            Console.WriteLine(diagram.ToString());
        }
    }
}