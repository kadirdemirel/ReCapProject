using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDto> GetCarAsc()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join c2 in context.Colors on c.ColorId equals c2.Id
                             orderby c.DailyPrice ascending
                             select new CarDto { Id = c.Id, BrandName = b.BrandName, ColorName = c2.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
            
        }

        public List<CarDto> GetCarDesc()
        {

            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join c2 in context.Colors on c.ColorId equals c2.Id
                             orderby c.DailyPrice descending
                             select new CarDto { Id = c.Id, BrandName = b.BrandName, ColorName = c2.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
        }

        public List<CarDto> GetCarDetails()
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join c2 in context.Colors on c.ColorId equals c2.Id
                             select new CarDto { Id = c.Id, BrandName = b.BrandName, ColorName = c2.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
                           
            }
        }
    }
}
