using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            try
            {
                _userDal.Add(entity);
                return new SuccessResult(Messages.Added);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Delete(User entity)
        {
            try
            {
                _userDal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<User>>(Messages.Error);
            }
        }

        public IDataResult<User> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<User>(_userDal.Get(b => b.Id == id), Messages.Listed);
            }
            catch
            {
                return new ErrorDataResult<User>(Messages.Error);
            }
        }

        public IResult Update(User entity)
        {
            try
            {
                _userDal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }
    }
}
