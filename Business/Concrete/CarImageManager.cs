using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var result = BusinessRules.Run(CheckIfCarImagePathExists(entity));
            if (result!=null)
            {
                return result;
            }

            _carImageDal.Add(entity);
            return new SuccessResult(Messages.Added);
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
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }
    }
}
