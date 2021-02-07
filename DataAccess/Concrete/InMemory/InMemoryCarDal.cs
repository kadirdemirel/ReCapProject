using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear ="2018",DailyPrice=700,Description="Konfor ve rahatlık sevenler için."},
                new Car { Id = 2, BrandId = 2, ColorId = 2, ModelYear = "2017",DailyPrice=500,Description="Konfor sevenler için."},
                new Car { Id = 3, BrandId = 3, ColorId = 3, ModelYear = "2016",DailyPrice=400,Description="Hız sevenler için."},
                new Car { Id = 4, BrandId = 4, ColorId = 4, ModelYear = "2015",DailyPrice=300,Description="Farklı araç sürmek isteyenler için."},
                new Car { Id = 5, BrandId = 5, ColorId = 1, ModelYear = "2014",DailyPrice=200,Description="Her kesim için ideal."},
            };
            _brands = new List<Brand>()
                {
                    new Brand { Id = 1, BrandName = "Toyota" },
                    new Brand { Id = 2, BrandName = "Opel" },
                    new Brand { Id = 3, BrandName = "BMW" },
                    new Brand { Id = 4, BrandName = "Scoda" },
                    new Brand { Id = 5, BrandName = "Fiat" },
                };

            _colors = new List<Color>
            {
                new Color{Id=1,ColorName="Beyaz"},
                new Color{Id=2,ColorName="Kırmızı"},
                new Color{Id=3,ColorName="Mavi"},
                new Color{Id=4,ColorName="Siyah"},
                new Color{Id=5,ColorName="Lacivert"},

            };


        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }



        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            int sira = 0;
            var result = (from c in _cars
                          join b in _brands on c.BrandId equals b.Id
                          join c2 in _colors on c.ColorId equals c2.Id
                          orderby c.DailyPrice ascending, b.BrandName ascending
                          select new CarDto { Id = c.Id, BrandName = b.BrandName, ColorName = c2.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description });

            foreach (var car in result)
            {
                sira++;                   
                Console.WriteLine(sira + "-)" + " Marka: " + car.BrandName   + " Renk: " + car.ColorName + " Model " + car.ModelYear + " Ücret : " + car.DailyPrice + " TL " + car.Description);

            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();

        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(p => p.ColorId == colorId).ToList();
        }

        public List<CarDto> GetCarAsc()
        {
            throw new NotImplementedException();
        }

        public List<CarDto> GetCarDesc()
        {
            throw new NotImplementedException();
        }

        public List<CarDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;


        }
    }
}
