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

            carManager.Add(new Car { BrandId = 2, ColorId = 1, ModelYear = 2015,DailyPrice=290,Description="X" });

     

            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}
