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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

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
            Console.WriteLine("14-)Kullanıcı Ekle");
            Console.WriteLine("15-)Kullanıcı Sil");
            Console.WriteLine("16-)Kullanıcı Güncelle");
            Console.WriteLine("17-)Kullanıcı Listesi");
            Console.WriteLine("18-)Müşteri Ekle");
            Console.WriteLine("19-)Müşteri Sil");
            Console.WriteLine("20-)Müşteri Güncelle");
            Console.WriteLine("21-)Müşteri Listesi");
            Console.WriteLine("22-)Araç Kirala");
            Console.WriteLine("23-)Kiralanmış Araç Bilgilerini Güncelle");
            Console.WriteLine("24-)Kiralanmış Araç Listesi");
            Console.WriteLine("25-)Araç Teslim Et");
            Console.WriteLine("26-)Programı Sonlandır");
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
                        var result = carManager.GetCarDetails();
                        if (result.Success)
                        {
                            Console.WriteLine("**************Araç Listesi**************");
                            foreach (var carDto in carManager.GetCarDetails().Data)
                            {

                                Console.WriteLine("Id:" + carDto.Id + "/" + carDto.BrandName + "/" + carDto.ColorName + "/" + carDto.ModelYear + "/" + carDto.DailyPrice + "/" + carDto.Description);
                                Console.WriteLine("---------------------------------------------");
                            }
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
                        var result = brandManager.GetAll();
                        if (result.Success)
                        {
                            Console.WriteLine("******************Marka Listesi******************");
                            foreach (var brand in brandManager.GetAll().Data)
                            {
                                Console.WriteLine("Id:" + brand.Id + "/" + brand.BrandName);
                                Console.WriteLine("---------------------------------------------");
                            }
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
                        var result = colorManager.GetAll();
                        if (result.Success)
                        {
                            foreach (var color in colorManager.GetAll().Data)
                            {
                                Console.WriteLine("Id:" + color.Id + "/" + color.ColorName);
                                Console.WriteLine("---------------------------------------------");
                            }
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
                        var result = carManager.GetByDailyPrice(minMoney, maxMoney);
                        if (result.Success)
                        {
                            foreach (var i in carManager.GetByDailyPrice(minMoney, maxMoney).Data)
                            {
                                Console.WriteLine("Id:" + i.Id + "/" + brandManager.GetById(i.BrandId).Data.BrandName + "/" + colorManager.GetById(i.ColorId).Data.ColorName + "/" + i.ModelYear + "/" + i.DailyPrice + "/" + i.Description);
                            }
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
                        var result = carManager.GetCarAsc();
                        if (result.Success)
                        {
                            foreach (var asc in carManager.GetCarAsc().Data)
                            {
                                Console.WriteLine("Id:" + asc.Id + "/" + asc.BrandName + "/" + asc.ColorName + "/" + asc.ModelYear + "/" + asc.DailyPrice + "/" + asc.Description);
                            }
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
                        var result = carManager.GetCarDesc();
                        if (result.Success)
                        {
                            foreach (var desc in carManager.GetCarDesc().Data)
                            {
                                Console.WriteLine("Id:" + desc.Id + "/" + desc.BrandName + "/" + desc.ColorName + "/" + desc.ModelYear + "/" + desc.DailyPrice + "/" + desc.Description);
                            }
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
                        Brand brand1 = new Brand { Id = id, BrandName = marka };
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
                        Color color1 = new Color { Id = id, ColorName = renk };
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
                        string ad, soyad, email, password;
                        Console.WriteLine("Kullanıcı adı giriniz.");
                        ad = Console.ReadLine();
                        Console.WriteLine("Kullanıcı soyadı giriniz.");
                        soyad = Console.ReadLine();
                        Console.WriteLine("Email giriniz.");
                        email = Console.ReadLine();
                        Console.WriteLine("Şifre giriniz.");
                        password = Console.ReadLine();
                        User user = new User { FirstName = ad, LastName = soyad, Email = email, Password = password };
                        userManager.Add(user);
                        Console.WriteLine("Kullanıcı başarıyla eklendi.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }

                        break;
                    }
                case 15:
                    {
                        int id = 0;
                        Console.WriteLine("Silmek istediğiniz kullanıcının Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        User user = new User { Id = id };
                        userManager.Delete(user);
                        Console.WriteLine("Kullanıcı başarıyla silindi.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 16:
                    {
                        int id = 0;
                        string ad, soyad, email, password;
                        Console.WriteLine("Güncellemek istediğiniz kullanıcının Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Kullanıcı adı giriniz.");
                        ad = Console.ReadLine();
                        Console.WriteLine("Kullanıcı soyadı giriniz.");
                        soyad = Console.ReadLine();
                        Console.WriteLine("Email giriniz.");
                        email = Console.ReadLine();
                        Console.WriteLine("Şifre giriniz.");
                        password = Console.ReadLine();
                        User user = new User { FirstName = ad, LastName = soyad, Email = email, Password = password };
                        userManager.Update(user);
                        Console.WriteLine("Kullanıcı bilgileri başarıyla güncellenmiştir.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 17:
                    {
                        foreach (var user in userManager.GetAll().Data)
                        {
                            Console.WriteLine("Id:" + user.Id + "/" + user.FirstName + "/" + user.LastName + "/" + user.Email + "/" + user.Password);
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
                case 18:
                    {
                        int userId;
                        string companyName;
                        Console.WriteLine("Eklemek istediğiniz müşterinin kullanıcı Id değerini giriniz.");
                        userId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Şirket adını giriniz.");
                        companyName = Console.ReadLine();
                        Customer customer = new Customer { UserId = userId, CompanyName = companyName };
                        customerManager.Add(customer);
                        Console.WriteLine("Müşteri başarıyla eklendi.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 19:
                    {
                        int id = 0;
                        Console.WriteLine("Silmek istediğiniz müşterinin Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Customer customer = new Customer { Id = id };
                        customerManager.Delete(customer);
                        Console.WriteLine("Müşteri başarıyla silindi.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 20:
                    {
                        int userId, id;
                        string companyName;
                        Console.WriteLine("Güncellemek istediğiniz müşterinin Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Güncellemek istediğiniz müşterinin kullanıcı Id değerini giriniz.");
                        userId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Şirket adını giriniz.");
                        companyName = Console.ReadLine();
                        Customer customer = new Customer { Id = id, UserId = userId, CompanyName = companyName };
                        customerManager.Update(customer);
                        Console.WriteLine("Müşteri bilgileri başarıyla güncellendi.");
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;

                    }
                case 21:
                    {
                        foreach (var customer in customerManager.GetCustomerDetails().Data)
                        {
                            Console.WriteLine("Id:" + customer.Id + "/" + customer.FirstName + "/" + customer.LastName + "/" + customer.Email + "/" + customer.Password + "/" + customer.CompanyName);
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
                case 22:
                    {
                        DateTime rentDate, returnDate;
                        int carId = 0, customerId = 0;
                        Console.WriteLine("Kiralamak istediğiniz aracın Id değerini giriniz.");
                        carId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Kiralamak istediğiniz müşterinin Id değerini giriniz.");
                        customerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Başlangıç tarihini giriniz.");
                        rentDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Bitiş tarihini giriniz.");
                        returnDate = DateTime.Parse(Console.ReadLine());
                        Rental rental = new Rental { CarId = carId, CustomerId = customerId, RentDate = rentDate, ReturnDate = returnDate };
                        var result2 = rentalManager.GetById(carId);
                        if (result2.Success)
                        {
                            Console.WriteLine("Bu araç zaten kiralandı.");
                        }
                        else
                        {

                            rentalManager.Add(rental);


                        }

                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 23:
                    {
                        DateTime rentDate, returnDate;
                        int carId = 0, customerId = 0;
                        Console.WriteLine("Güncellemek istediğiniz aracın Id değerini giriniz.");
                        carId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Güncelemek istediğiniz müşterinin Id değerini giriniz.");
                        customerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Başlangıç tarihini giriniz.");
                        rentDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Bitiş tarihini giriniz.");
                        returnDate = DateTime.Parse(Console.ReadLine());
                        Rental rental = new Rental { CarId = carId, CustomerId = customerId, RentDate = rentDate, ReturnDate = returnDate };
                        var result = rentalManager.Update(rental);
                        if (result.Success)
                        {
                            rentalManager.Update(rental);

                        }
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 24:
                    {
                        Console.WriteLine("**************Kiralanmış Araç Listesi**************");
                        foreach (var rentalDto in rentalManager.GetRentalDetails().Data)
                        {
                            Console.WriteLine("Id:" + rentalDto.Id + "/" + rentalDto.FirstName + "/" + rentalDto.LastName + "/" + rentalDto.RentDate + "/" + rentalDto.RentDate + "/" + rentalDto.BrandName + "/" + rentalDto.ColorName + "/" + rentalDto.ModelYear + "/" + rentalDto.DailyPrice + "/" + rentalDto.Description + "/" + rentalDto.CompanyName);
                            Console.WriteLine("---------------------------------------------");
                        }
                        break;
                    }
                case 25:
                    {
                        int carId, id;
                        Console.WriteLine("Teslim etmek istediğiniz kiralık araç Id değerini giriniz.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Teslim etmek istediğiniz aracın Id değerini giriniz.");
                        carId = Convert.ToInt32(Console.ReadLine());
                        Rental rental = new Rental { Id = id, CarId = carId };
                        var result = rentalManager.GetById(carId);
                        if (result.Success)
                        {
                            rentalManager.Delete(rental);
                        }
                        else
                        {
                            Console.WriteLine("Böyle bir araç kaydı bulunmamaktadır.");
                        }
                        Console.WriteLine("Ana menüye dönmek ister misiniz? Evet==e||Hayır==h");
                        anaMenu = Console.ReadLine();
                        if (anaMenu == "e")
                        {

                            goto Tekrar;

                        }
                        break;
                    }
                case 26:
                    {
                        Console.WriteLine("Bir tuşa basın...");
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
