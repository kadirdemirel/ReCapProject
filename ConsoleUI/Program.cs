using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {


        static void Main(string[] args)
        {

            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            CarManager carManager = new CarManager(new InMemoryCarDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            Console.WriteLine("----------Marka Listesi---------");
            brandManager.GetAll();
            Console.WriteLine("----------Renk Listesi---------");
            colorManager.GetAll();
            Console.WriteLine("----------Araç Listesi----------");
            carManager.GetAll();


            Car car = new Car() { BrandId = 2, ColorId = 3, ModelYear = "2020", DailyPrice = 500, Description = "Farklılık sevenler için." };

            Console.WriteLine("--------Yeni Araç Eklendi--------");
            carManager.Add(car);
            carManager.GetAll();
            Console.WriteLine("-------Araç Bilgisi Silindi------");
            carManager.Delete(car);
            carManager.GetAll();
            Console.WriteLine("-----Araç Bilgisi Güncellendi-----");
            carManager.Update( new Car() { Id = 2, BrandId = 2, ColorId = 2, ModelYear = "2017", DailyPrice = 650, Description = "Konfor sevenler için." });
            carManager.GetAll();
            
        }

    }
}
