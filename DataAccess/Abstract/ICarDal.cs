using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        void GetAll();
        List<Car> GetAllByBrand(int brandId);
        List<Car> GetAllByColor(int colorId);
    }
}
