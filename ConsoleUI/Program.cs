using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("------------------------------------------------------------------------");

            //GetCarsByColorId(carManager);

            carManager.Add(new Car { ColorId = 1, BrandId = 1, DailyPrice = 100, ModelYear = 200, Description = "Fiat" });
            Console.WriteLine("Araba eklendi. ");
            GelAll(carManager);


            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine($"{car.Id}---{car.ModelYear}---{car.DailyPrice}---{car.Description}---{car.BrandId}---{car.ColorId}");
            }
        }

        private static void GelAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id}---{car.ModelYear}---{car.DailyPrice}---{car.Description}---{car.BrandId}---{car.ColorId}");
            }
        }
    }
}
