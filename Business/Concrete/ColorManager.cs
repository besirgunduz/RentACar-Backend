using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color entity)
        {
            try
            {
                _colorDal.Add(entity);
                return new SuccessResult(Messages.Added);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Delete(Color entity)
        {
            try
            {
                _colorDal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<Color>>(Messages.Error);
            }
        }

        public IDataResult<Color> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Color>(_colorDal.Get(b => b.Id == id), Messages.Listed);
            }
            catch
            {
                return new ErrorDataResult<Color>(Messages.Error);
            }
        }

        public IResult Update(Color entity)
        {
            try
            {
                _colorDal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }
    }
}
