using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("Product.Add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            _carDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car entity)
        {
            try
            {
                _carDal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<Car>>(Messages.Error);
            }
        }

        public IDataResult<Car> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<Car>(Messages.Error);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            try
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<CarDetailDto>>(Messages.Error);
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<Car>>(Messages.Error);
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<Car>>(Messages.Error);
            }
        }

        public IResult Update(Car entity)
        {
            try
            {
                _carDal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }
            catch
            {

                return new ErrorResult(Messages.Error);
            }
        }
    }
}
