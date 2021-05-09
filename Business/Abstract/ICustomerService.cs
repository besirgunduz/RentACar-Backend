using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
    }
}
