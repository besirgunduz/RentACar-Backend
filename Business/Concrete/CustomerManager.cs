using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            try
            {
                _customerDal.Add(entity);
                return new SuccessResult(Messages.Added);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Delete(Customer entity)
        {
            try
            {
                _customerDal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
            }
            catch
            {

                return new ErrorDataResult<List<Customer>>(Messages.Error);
            }
        }

        public IDataResult<Customer> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(b => b.Id == id), Messages.Listed);
            }
            catch
            {
                return new ErrorDataResult<Customer>(Messages.Error);
            }
        }

        public IResult Update(Customer entity)
        {
            try
            {
                _customerDal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }
        [TransactionScopeAspect]
        public IResult TransactionalTest(Customer entity)
        {
            //Transaction => Tutarlılığı sağlamak için kullanılır. Herhangi bir hata ile karşılaşırsa işlemi geri alır. 

            _customerDal.Update(entity);
            _customerDal.Add(entity);

            return new SuccessResult();
        }
    }
}
