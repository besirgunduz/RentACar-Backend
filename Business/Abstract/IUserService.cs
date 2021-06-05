using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User entity);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string mail);
    }
}
