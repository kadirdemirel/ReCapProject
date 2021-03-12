using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }



        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }
        [SecuredOperation("brand.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);

        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);


        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId));
        }

        public IDataResult<List<CarDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDto>> GetCarAsc()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarAsc());
        }

        public IDataResult<List<CarDto>> GetCarDesc()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDesc());
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if(car.DailyPrice<100)
            {
                throw new Exception();
            }
            Add(car);
            return null;
            
        }
    }
}
