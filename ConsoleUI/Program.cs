using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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

        Tekrar:
            Console.WriteLine("********Rent A Car Sistemine Hoşgeldiniz********");
            Console.WriteLine("1-)Kiralık Araç Listesi");
            Console.WriteLine("2-)Marka Listesi");
            Console.WriteLine("3-)Renk Listesi");
            Console.WriteLine("4-)Kiralık Araç Ekle");
            Console.WriteLine("5-)Marka Ekle");
            Console.WriteLine("6-)Renk Ekle");
            Console.WriteLine("7-)Araç Sil");
            Console.WriteLine("8-)Araç Bilgisi Güncelleştir");
            Console.WriteLine("9-)Fiyat Aralığındaki Araç Listesi");
            Console.WriteLine("10-)Fiyata Göre Artan Araç Listesi");
            Console.WriteLine("11-)Fiyata Göre Azalan Araç Listesi");
            Console.WriteLine("12-)Marka Güncelle");
            Console.WriteLine("13-)Renk Güncelle");
            Console.WriteLine("14-)Programı Sonlandır");
            string anaMenu;
            int secim = 0;
            try
            {
                secim = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Yanlış karakter girdiniz !");
            }
            switch (secim)
            {
                case 1:
                    {
                       
                        Console.WriteLine("**************Kiralık Araç Listesi**************");
                        foreach (var carDto in carManager.GetCarDetails())
                        {

                            Console.WriteLine("Id:" + carDto.Id + "/" + carDto.BrandName + "/" + carDto.ColorName + "/" + carDto.ModelYear + "/" + carDto.DailyPrice + "/" + carDto.Description);
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }



                        break;
                    }
                case 2:
                    {
                       
                        Console.WriteLine("******************Marka Listesi******************");
                        foreach (var brand in brandManager.GetAll())
                        {
                            Console.WriteLine("Id:" + brand.Id + "/" + brand.BrandName);
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 3:
                    {
                       
                        Console.WriteLine("******************Renk Listesi******************");
                        foreach (var color in colorManager.GetAll())
                        {
                            Console.WriteLine("Id:" + color.Id + "/" + color.ColorName);
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 4:
                    {
                        string modelYear, description;
                        int brand = 0, color = 0, dailyPrice = 0;
                        Console.WriteLine("Eklemek istediğiniz aracın bilgilerini giriniz");
                        Console.WriteLine("Markanın BrandId değerini giriniz.");
                        brand = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Rengin ColorId değerini giriniz");
                        color = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Model yılınız giriniz");
                        modelYear = Console.ReadLine();
                        Console.WriteLine("Kiralama ücretini giriniz");
                        dailyPrice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Açıklama giriniz");
                        description = Console.ReadLine();
                        Car car1 = new Car { BrandId = brand, ColorId = color, ModelYear = modelYear, DailyPrice = dailyPrice, Description = description };
                        carManager.Add(car1);
                        Console.WriteLine("Araç başarılı bir şekilde sistem tarafından eklendi.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }


                        break;
                    }
                case 5:
                    {
                        string marka;
                        Console.WriteLine("Eklemek istediğiniz markayı yazınız");
                        marka = Console.ReadLine();
                        Brand brand1 = new Brand { BrandName = marka };
                        brandManager.Add(brand1);
                        Console.WriteLine("Marka ekleme işlemi başarılı şekilde yapıldı.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {


                            goto Tekrar;

                        }
                        break;
                    }
                case 6:
                    {
                        string renk;
                        Console.WriteLine("Eklemek istediğiniz rengi yazınız");
                        renk = Console.ReadLine();
                        Color color1 = new Color { ColorName = renk };
                        colorManager.Add(color1);
                        Console.WriteLine("Renk ekleme işlemi başarılı şekilde yapıldı.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 7:
                    {
                      
                        int id = 0;
                        Console.WriteLine("Silmek istediğiniz aracın Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Car car2 = new Car { Id = id };
                        carManager.Delete(car2);
                        Console.WriteLine("Silme işlemi başarıyla tamamlandı.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }


                        break;
                    }
                case 8:
                    {
                        string modelYear, description;
                        int brand = 0, color = 0, dailyPrice = 0, id = 0;
                        Console.WriteLine("Güncellemek istediğiniz aracın bilgilerini giriniz");
                        Console.WriteLine("Güncellemek istediğiniz aracın Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Markanın BrandId değerini giriniz.");
                        brand = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Rengin ColorId değerini giriniz");
                        color = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Model yılınız giriniz");
                        modelYear = Console.ReadLine();
                        Console.WriteLine("Kiralama ücretini giriniz");
                        dailyPrice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Açıklama giriniz");
                        description = Console.ReadLine();
                        Car car1 = new Car { Id = id, BrandId = brand, ColorId = color, ModelYear = modelYear, DailyPrice = dailyPrice, Description = description };
                        Console.WriteLine("Güncelleştirme işlemi başarıyla tamamlandı");
                        carManager.Update(car1);
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 9:
                    {
                        
                        int minMoney = 0, maxMoney = 0;
                        Console.WriteLine("Kiralamak istediğiniz değer aralığını giriniz.");
                        Console.WriteLine("Minumum ücreti giriniz.");
                        minMoney = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Maxiumum ücreti giriniz.");
                        maxMoney = Convert.ToInt32(Console.ReadLine());
                        foreach (var i in carManager.GetByDailyPrice(minMoney, maxMoney))
                        {
                            Console.WriteLine("Id:"+i.Id+"/"+brandManager.GetById(i.BrandId).BrandName+ "/" + colorManager.GetById(i.ColorId).ColorName +"/"+ i.ModelYear +"/" + i.DailyPrice + "/"+ i.Description); 
                        }
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 10:
                    {
                         
                        foreach (var asc in carManager.GetCarAsc())
                        {
                            Console.WriteLine("Id:" + asc.Id + "/" + asc.BrandName + "/" + asc.ColorName + "/" + asc.ModelYear + "/" + asc.DailyPrice + "/" + asc.Description);
                        }
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 11:
                    {
                       
                        foreach (var desc in carManager.GetCarDesc())
                        {
                            Console.WriteLine("Id:" + desc.Id + "/" + desc.BrandName + "/" + desc.ColorName + "/" + desc.ModelYear + "/" + desc.DailyPrice + "/" + desc.Description);
                        }
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 12:
                    {
                        string marka;
                        int id = 0;
                        Console.WriteLine("Id");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Yeni markayı yazınız");
                        marka = Console.ReadLine();
                        Brand brand1 = new Brand {Id=id, BrandName = marka };
                        brandManager.Update(brand1);
                        Console.WriteLine("Marka güncelleme işlemi başarılı şekilde yapıldı.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {


                            goto Tekrar;

                        }
                     
                        break;
                    }
                case 13:
                    {
                        string renk;
                        int id = 0;
                        Console.WriteLine("Güncellemek istediğiniz rengin Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Yeni rengi yazınız");
                        renk = Console.ReadLine();
                        Color color1 = new Color {Id=id, ColorName = renk };
                        colorManager.Update(color1);
                        Console.WriteLine("Renk güncelleme işlemi başarılı şekilde yapıldı.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 14:
                    {
                        Console.WriteLine("Bir tuşa basınız konsol uygulaması tamamen sonlanacaktır...");
                        Environment.Exit(0);
                        
                        break;
                    }


                default:
                    {
                        Console.WriteLine("Yanlış seçim lütfen tekrar deneyiniz !");
                        goto Tekrar;

                    }
            }



        }
 
    }
}
