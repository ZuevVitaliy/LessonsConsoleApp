﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LessonsConsoleApp
{
    public delegate void MessageHandler(double value);

    public partial class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("Виталий");
            names.Add("Алексей");
            names.Add("Юлия");
            names.Add("Владимир");
            names.Add("Станiслав");

            ShowNames(names);
            ShowNames(names, ";");

            Console.ReadKey();
        }

        public static void ShowNames(List<string> names)
        {
            ShowNames(names, ",");
        }

        public static void ShowNames(List<string> names, string separator)
        {
            for (int i = 0; i < names.Count; i++)
            {
                if (i < names.Count - 1)
                {
                    Console.Write((names[i]) + separator);
                }
                else Console.WriteLine(names[i]);
            }
        }

        public abstract class Human : ISpecialist
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Human(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public void ToWork()
            {
                Console.WriteLine($"Меня зовут {Name}, мне {Age} и я работаю");
            }
        }

        public class Programmer : Human, IProgrammer, IGuardian
        {
           
            void IProgrammer.ToWork()
            {
                Console.WriteLine($"Меня зовут {Name}, мне {Age} и я программирую");
            }

            void IGuardian.ToWork()
            {
                Console.WriteLine($"Меня зовут {Name}, мне {Age} и я охраняю");
            }

            public Programmer(string name, int age) : base(name, age)
            {
            }
        }

        public class Medic : Human, IMedic
        {
            public void ToWork()
            {
                Console.WriteLine($"Меня зовут {Name}, мне {Age} и я лечу людей");
            }

            public Medic(string name, int age) : base(name, age)
            {
            }
        }

        interface ISpecialist
        {
            void ToWork();
        }

        interface IProgrammer : ISpecialist
        {
            void ToWork();
        }

        interface IMedic : ISpecialist
        {
            void ToWork();
        }

        interface IGuardian : ISpecialist
        {
            void ToWork();
        }
        public class Warrior
        {
            private double mHp;
            public double HP
            {
                get => mHp;
                set
                {
                    double oldValue = mHp;
                    mHp = value;
                    HealthPointsChanged?.Invoke(value);
                }
            }

            public event MessageHandler HealthPointsChanged;

            public double Armor { get; set; }

            public Warrior()
            {
                HP = 100;
                Armor = 0;
            }

            public virtual void GetDamage(double damage)
            {
                HP -= damage;
            }
        }

        public class WarriorInLightArmor : Warrior
        {
            public WarriorInLightArmor()
            {
                Armor = 50;
            }

            public override void GetDamage(double damage)
            {
                if (damage < Armor / 2)
                {
                    Armor -= damage;
                }
                else if (damage >= Armor / 2 && damage < Armor)
                {
                    HP -= (damage - Armor / 2) / 2;
                    Armor -= damage;
                }
                else
                {
                    HP -= damage - Armor + Armor / 4;
                    Armor = 0;
                }

            }



        }

        public class WarriorInHeavyArmor : Warrior
        {
            public WarriorInHeavyArmor()
            {
                Armor = 50;
            }
            public override void GetDamage(double damage)
            {
                if (damage < Armor / 2)
                {
                    Console.WriteLine("Броня не пробита!");
                }
                else if (damage >= Armor / 2 && damage < Armor)
                {
                    Armor -= damage;
                }
                else
                {
                    HP -= damage - Armor;
                    Armor = 0;
                }
            }
        }


    }

    //public partial class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //while (true)
    //        //{

    //        //    Console.WriteLine("Введите аргументы: ");
    //        //    double a, b, c;
    //        //    Console.Write("a = ");
    //        //    try
    //        //    {
    //        //        a = double.Parse(Console.ReadLine());

    //        //        Console.Write("b = ");

    //        //        b = double.Parse(Console.ReadLine());
    //        //        Console.Write("c = ");

    //        //        c = double.Parse(Console.ReadLine());
    //        //    }
    //        //    catch (Exception e)
    //        //    {
    //        //        Console.WriteLine("Вы ввели не число.");
    //        //        Console.ReadKey();
    //        //        return;
    //        //    }

    //        //    double discriminant = FindDiscriminant(a, b, c);
    //        //    double x1 = ((-b + Math.Sqrt(discriminant)) / (2 * a));
    //        //    double x2 = ((-b - Math.Sqrt(discriminant)) / (2 * a));
    //        //    if (discriminant < 0)
    //        //    {
    //        //        Console.WriteLine("Корней нет");
    //        //    }
    //        //    else if (discriminant == 0)
    //        //    {
    //        //        double x = x1;
    //        //        Console.WriteLine("x =" + x);
    //        //    }
    //        //    else
    //        //    {
    //        //        Console.WriteLine("x1 = " + x1);
    //        //        Console.WriteLine("x2 = " + x2);
    //        //    }
    //        //    Console.ReadKey();
    //        //}

    //        List<Animal> animals = new List<Animal>();
    //        animals.Add(new Dog("Барбос"));
    //        animals.Add(new Cat("Барсик"));
    //        animals.Add(new Dog("Полкан"));

    //        foreach (Animal animal in animals)
    //        {
    //            var dog = animal as Dog;
    //            var cat = animal as Cat;
    //            if (dog != null)
    //            {
    //                //что-то для собакена
    //            }

    //            if (cat != null)
    //            {
    //                //что-то для котейки
    //            }

    //        }
    //        Console.ReadLine();
    //    }

    //    public static double FindDiscriminant(double arg1, double arg2, double arg3)
    //    {
    //        return Math.Pow(arg2, 2) - 4 * arg1 * arg3;
    //    }

    //    public class Student
    //    {
    //        private string mName;
    //        private int mCourse;
    //        private bool mStudentship;

    //        public Student()
    //        {
    //            this.mName = "";
    //            this.mCourse = 0;
    //            this.mStudentship = false;
    //        }

    //        public Student(string name, int course, bool studentship)
    //        {
    //            this.mName = name;
    //            if (course < 1)
    //            {
    //                this.mCourse = 1;

    //            }
    //            else if (course > 6)
    //            {
    //                this.mCourse = 6;
    //            }
    //            else
    //            {
    //                this.mCourse = course;
    //            }
    //            this.mStudentship = studentship;
    //        }
    //    }

    //    public abstract class Animal
    //    {
    //        public string Name { get; set; }

    //        public abstract void ToSound();

    //        public virtual void ToWalk()
    //        {
    //            Console.WriteLine(Name + " прошел 4 клетки");
    //        }

    //        public Animal(string name)
    //        {
    //            Name = name;
    //        }
    //    }

    //    public class Dog : Animal
    //    {
    //        public Dog(string name) : base(name)
    //        {}

    //        public void Guard()
    //        {
    //            Console.WriteLine(Name+" охраняет");
    //        }

    //        public override void ToWalk()
    //        {
    //            base.ToWalk();
    //            ToSound();
    //        }

    //        public override void ToSound()
    //        {
    //            Console.WriteLine("Гав!");
    //        }
    //    }

    //    public class Cat : Animal
    //    {
    //        public Cat(string name) : base(name)
    //        { }

    //        public void CatchMouse()
    //        {
    //            Console.WriteLine(Name + " ловит мышь");
    //        }

    //        public override void ToSound()
    //        {
    //            Console.WriteLine("Мяууу.....");
    //        }

    //        public override void ToWalk()
    //        {
    //            Console.WriteLine(Name + " забил хер на 4 клетки и прошел две");
    //        }
    //    }
    //}
}
