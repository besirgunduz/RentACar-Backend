using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage entity)
        {
            var result = BusinessRules.Run(CheckIfCarImagePathExists(entity), CheckIfCarImageCount(entity));
            if (result != null)
            {
                return result;
            }
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        private IResult CheckIfCarImageCount(CarImage entity)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == entity.CarId).Count;
            if (result>=5)
            {
                return new ErrorResult("Hata...Bir arabanın en fazla 5 resmi olabilir.");
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImagePathExists(CarImage entity)
        {
            var result = _carImageDal.GetAll(ci => ci.ImagePath == entity.ImagePath).Any();
            if (result)
            {
                return new ErrorResult("Hata...Araba resmi sistemde mevcuttur.");
            }

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<CarImage>>(Messages.Error);
            }
        }

        public IResult Delete(CarImage entity)
        {
            try
            {
                _carImageDal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Update(CarImage entity)
        {
            try
            {
                _carImageDal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }
            catch
            {

                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            try
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci=>ci.CarId==carId), Messages.Listed);
            }
            catch
            {
                return new ErrorDataResult<List<CarImage>>(Messages.Error);
            }
        }
    }
}
