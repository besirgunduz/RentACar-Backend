using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        // Kiralamak istediğimiz araç daha önce hiç kiralanmadıysa(yani kiralama tablosunda kaydı yoksa) veya 
        // Kiralamak istediğimiz tarih aracın teslim tarihinden büyük ise aracı kiralayabilecez.
        public IResult Add(Rental entity)
        {
            var isRental = _rentalDal.Get(c => c.CarId == entity.CarId);

            if (isRental == null || entity.RentDate > isRental.ReturnDate)
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }

        }

        public IResult Delete(Rental entity)
        {
            try
            {
                _rentalDal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<Rental>>(Messages.Error);
            }
        }

        public IDataResult<Rental> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == id), Messages.Listed);
            }
            catch
            {
                return new ErrorDataResult<Rental>(Messages.Error);
            }
        }

        public IResult Update(Rental entity)
        {
            try
            {
                _rentalDal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }
    }
}