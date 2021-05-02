using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("------------------------------------------------------------------------");

            carManager.Add(new Car { Id = 5, BrandId = 5, ColorId = 5, ModelYear = 2018, DailyPrice = 440, Description = "Yeni Lüx Araba" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id}-{car.BrandId}-{car.ColorId}-{car.Description}");
            }

            Console.WriteLine("----------------------------------------------------------------------");

            Console.WriteLine(carManager.GetById(10));
        }
    }
}
