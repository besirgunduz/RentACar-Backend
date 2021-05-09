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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = DateTime.Now,ReturnDate=DateTime.Now.AddDays(7)}); //Aracı 7 gün kiralamak istiyorum.

            //GetCarsByColorId(carManager);
            //GelAll(carManager);
            //GetCarDetais(carManager);
            //AddCar(carManager);

            //userManager.Add(new User { FirstName = "Beşir", LastName = "Gündüz", Email = "besirgunduz1993@gmail.com", Password = "123" });
            //customerManager.Add(new Customer { UserId = 1, CompanyName = "Lc Waikiki" });
            //customerManager.Add(new Customer { UserId = 1, CompanyName = "Taha Giyim" });




            Console.ReadKey();
        }

        private static void AddCar(CarManager carManager)
        {
            Console.WriteLine(carManager.Add(new Car { ColorId = 1, BrandId = 1, DailyPrice = 100, ModelYear = 200, Description = "F" }).Message);
        }
        private static void GetCarDetais(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"CarName : {car.CarName} BrandName : {car.BrandName} ColorName : {car.ColorName} DailyPrice : {car.DailyPrice}");
            }
            Console.WriteLine(carManager.GetCarDetails().Message);
        }
        private static void GetCarsByColorId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine($"{car.Id}---{car.ModelYear}---{car.DailyPrice}---{car.Description}---{car.BrandId}---{car.ColorId}");
            }
        }
        private static void GelAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id}---{car.ModelYear}---{car.DailyPrice}---{car.Description}---{car.BrandId}---{car.ColorId}");
            }
        }
    }
}
