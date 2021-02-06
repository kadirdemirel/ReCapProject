using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {

            
                _brands = new List<Brand>()
                {
                    new Brand { Id = 1, BrandName = "Toyota" },
                    new Brand { Id = 2, BrandName = "Opel" },
                    new Brand { Id = 3, BrandName = "BMW" },
                    new Brand { Id = 4, BrandName = "Scoda" },
                    new Brand { Id = 5, BrandName = "Fiat" },
                };


        }

        public void Add(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            int sira = 0;
            var result = (from b in _brands
                         orderby b.BrandName ascending
                         select b);
            foreach (var brand in result)
            {
                sira++;
                Console.WriteLine(sira + "-)" + brand.BrandName);
            }
                
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}