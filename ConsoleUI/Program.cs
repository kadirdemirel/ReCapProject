using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Car car = new Car() { BrandId = 2, ColorId = 3, ModelYear = "2020", DailyPrice = 500, Description = "Farklılık sevenler için." };
            // carManager.Add(car);
            Console.WriteLine("-------------------Araba Listesi-------------------");
            foreach (var i in carManager.GetAll())
            {
                Console.WriteLine(brandManager.GetById(i.BrandId).BrandName + " marka aracımızın, rengi " + colorManager.GetById(i.ColorId).ColorName + " modeli " + i.ModelYear + " model olup kiralama ücreti " + i.DailyPrice + " TL'dir." + i.Description);
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("*1 Markası Fiat olan arabamızı getirelim");
            foreach (var i in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(brandManager.GetById(i.BrandId).BrandName + " marka aracımızın, rengi " + colorManager.GetById(i.ColorId).ColorName + " modeli " + i.ModelYear + " model olup kiralama ücreti " + i.DailyPrice + " TL'dir." + i.Description);
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("*2 Rengi mavi olan arabamızı getirelim");
            foreach (var i in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(brandManager.GetById(i.BrandId).BrandName + " marka aracımızın, rengi " + colorManager.GetById(i.ColorId).ColorName + " modeli " + i.ModelYear + " model olup kiralama ücreti " + i.DailyPrice + " TL'dir." + i.Description);
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("*3 Günlük ücreti 400-600 arasındaki arabaları getirelim");
            foreach (var i in carManager.GetByDailyPrice(400, 600))
            {
                Console.WriteLine(brandManager.GetById(i.BrandId).BrandName + " marka aracımızın, rengi " + colorManager.GetById(i.ColorId).ColorName + " modeli " + i.ModelYear + " model olup kiralama ücreti " + i.DailyPrice + " TL'dir." + i.Description);
            }



            //Console.WriteLine("----------Marka Listesi---------");
            //brandManager.GetAll();
            //Console.WriteLine("----------Renk Listesi---------");
            //colorManager.GetAll();
            //Console.WriteLine("----------Araç Listesi----------");
            //carManager.GetAll();
            //Console.WriteLine("--------Yeni Araç Eklendi--------");
            //carManager.Add(car);
            //carManager.GetAll();
            //Console.WriteLine("-------Araç Bilgisi Silindi------");
            //carManager.Delete(car);
            //carManager.GetAll();
            //Console.WriteLine("-----Araç Bilgisi Güncellendi-----");
            //carManager.Update( new Car() { Id = 2, BrandId = 2, ColorId = 2, ModelYear = "2017", DailyPrice = 650, Description = "Konfor sevenler için." });
            //carManager.GetAll();

        }

    }
}
