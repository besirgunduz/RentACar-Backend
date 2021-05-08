using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public void Add(Rental entity)
        {
            _rentalDal.Add(entity);
        }

        public void Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
        }

        public List<Rental> GetAll()
        {
            return _rentalDal.GetAll();
        }

        public void Update(Rental entity)
        {
            _rentalDal.Update(entity);
        }
    }
}
