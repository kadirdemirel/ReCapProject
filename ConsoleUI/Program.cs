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
            Car car = new Car() { BrandId = 2, ColorId = 3, ModelYear = "2020", DailyPrice = 500, Description = "Farklılık sevenler için." };
            carManager.Add(car);
            Console.WriteLine("Marka|Renk|Model|Günlük Ücret | Açıklama");
            Console.WriteLine("-----|----|-----|------------ | --------");
            foreach (var i in carManager.GetAll())
            {
                Console.WriteLine(i.BrandId.ToString() + "      " + i.ColorId + "   " + i.ModelYear + "      " + i.DailyPrice.ToString() + "        " + i.Description);
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("*1 BrandId'si 1 olan Arabanın açıklamasını getirelim");
            foreach (var i in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(i.Description);
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("*2 ColorId'si 3 olan Arabanın günlük ücretini getirelim");
            foreach (var i in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(i.DailyPrice);
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("*3 Günlük ücreti 400-600 arasındaki arabaları getirelim");
            foreach (var i in carManager.GetByDailyPrice(400,600))
            {
                Console.WriteLine(i.BrandId.ToString() + "      " + i.ColorId + "   " + i.ModelYear + "      " + i.DailyPrice.ToString() + "        " + i.Description);
            }
            //BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            //ColorManager colorManager = new ColorManager(new InMemoryColorDal());
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
