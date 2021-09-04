using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Add(CarImage entity);
        IResult Delete(CarImage entity);
        IResult Update(CarImage entity);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
