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
            // Kiralamak istediğimiz araç daha önce hiç kiralanmadıysa kiralayabilecez
            // Kiralamak istediğimiz araç daha önce kiralandıysa, kiralamak istediğimiz tarih aracın teslim tarihinden büyük olması gerekiyor

            var isRental = _rentalDal.Get(c => c.CarId == entity.CarId);//araç daha önce kiranmış mı?

            if (isRental==null || entity.RentDate>isRental.ReturnDate)
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

        public void Update(Rental entity)
        {
            _rentalDal.Update(entity);
        }
    }
}
