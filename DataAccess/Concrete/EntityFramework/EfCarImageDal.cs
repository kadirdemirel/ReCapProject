using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarContext>, ICarImageDal
    {
        public List<CarImageDto> GetCarImageDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cr in context.CarImages
                             join c in context.Cars on cr.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join c2 in context.Colors on c.ColorId equals c2.Id
                             select new CarImageDto { Id = cr.Id, BrandName = b.BrandName, ColorName = c2.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description, ImagePath = cr.ImagePath, Date = cr.Date };
                return result.ToList();
            }
        }
    }
}
