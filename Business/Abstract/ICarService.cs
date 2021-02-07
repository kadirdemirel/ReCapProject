﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int carId);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<CarDto> GetCarDetails();
        List<CarDto> GetCarDesc();
        List<CarDto> GetCarAsc();



    }
}
