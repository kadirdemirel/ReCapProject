using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void GetAll()
        {
            _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(p => p.Id == brandId);
        }
    }
}
