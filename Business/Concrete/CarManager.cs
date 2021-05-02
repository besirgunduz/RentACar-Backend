using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            //iş kodları
            _carDal.Add(car);
        }

        public List<Car> GetAll()
        {
            //iş kodları
           return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            //iş kodları
            return _carDal.GetById(id);
        }
    }
}
