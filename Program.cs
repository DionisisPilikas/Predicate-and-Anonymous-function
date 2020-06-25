using System;
using System.Collections.Generic;
using System.Linq;

namespace delegates1
{
    //delegate bool Mydelegate(Laptop laptop);
    class Laptop
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class DataBase
    {
        public List<Laptop> Laptops { get; set; }
        public DataBase()
        {
            Laptop L1 = new Laptop() { Name = "Samsung1", Price = 300m };
            Laptop L2 = new Laptop() { Name = "Samsung2", Price = 350m };
            Laptop L3 = new Laptop() { Name = "Samsung3", Price = 250m };
            Laptop L4 = new Laptop() { Name = "Samsung4", Price = 320m };

            Laptops = new List<Laptop>() { L1, L2, L3, L4 };
        }
    }
    //delegate decimal Mydelegate(List<Laptop> laptops);
    class BackEnd
    {
        DataBase db = new DataBase();
        public List<Laptop> GetLaptops()
        {
            var allLaptops = db.Laptops.ToList();
            return allLaptops;
        }          
        public void GetMaxPrice(Predicate<Laptop> elegxos)
        {
            var allLaptops = db.Laptops.ToList();
            decimal maxPrice = 0;
            foreach (var laptop in allLaptops)
            {
                if (elegxos(laptop))  //if(laptop.Price > maxPrice)
                {
                    maxPrice = laptop.Price;
                }             
            }
            Console.WriteLine("Max price = " + maxPrice);
        }
    }
    class FronfEnd
    {
        //static bool Max(Laptop l)
        //{
        //    decimal max = 0;
        //    if (l.Price > max)
        //        return true;
        //    else
        //        return false;
        //}
        //Mydelegate chekarisma = Max;

        Predicate<Laptop> check = (l)=>
        {
            decimal max = 0;
            if (l.Price > max)
                return true;
            else
                return false;
        };

        public void PrinMaxValue()
        {
            var all = backEnd.GetLaptops();

            decimal max = 0;
            backEnd.GetMaxPrice((l) => l.Price > max ? true : false);  //Anonymous function

        }

        BackEnd backEnd = new BackEnd();
        public void PrintAll()
        {
           var all= backEnd.GetLaptops();
            foreach (var laptop in all)
            {
                Console.WriteLine("name= " + laptop.Name + " Price = " + laptop.Price);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FronfEnd fr = new FronfEnd();
            fr.PrintAll();
            fr.PrinMaxValue();
            Console.ReadKey();
        }
    }
}
