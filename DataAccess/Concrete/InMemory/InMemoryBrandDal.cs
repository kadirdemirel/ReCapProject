using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
    }
}