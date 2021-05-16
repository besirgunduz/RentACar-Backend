using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand entity)
        {
            try
            {
                _brandDal.Add(entity);
                return new SuccessResult(Messages.Added);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Delete(Brand entity)
        {
            try
            {
                _brandDal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<Brand>>(Messages.Error);
            }
        }

        public IDataResult<Brand> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id), Messages.Listed);
            }
            catch
            {
                return new ErrorDataResult<Brand>(Messages.Error);
            }
        }

        public IResult Update(Brand entity)
        {
            try
            {
                _brandDal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }
    }
}
