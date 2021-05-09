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

        // Kiralamak istediğimiz araç daha önce hiç kiralanmadıysa veya kiralamak istediğimiz tarih aracın teslim tarihinden büyük olması gerekiyor.
        public void Add(Rental entity)
        {
            var isRental = _rentalDal.Get(c => c.CarId == entity.CarId);

            if (isRental == null || entity.RentDate > isRental.ReturnDate)
            {
                _rentalDal.Add(entity);
                Console.WriteLine("Araç kiralandı");
            }
            else
            {
                Console.WriteLine("Araç başkası tarafından kullanılmaktadır.");
            }

        }

        public void Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
        }

        public List<Rental> GetAll()
        {
            return _rentalDal.GetAll();
        }

        public Rental GetById(int id)
        {
            return _rentalDal.Get(r => r.Id == id);
        }

        public void Update(Rental entity)
        {
            _rentalDal.Update(entity);
        }
    }
}
