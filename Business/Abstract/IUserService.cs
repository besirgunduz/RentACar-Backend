using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
    }
}
