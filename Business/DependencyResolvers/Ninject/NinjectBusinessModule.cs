using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Ninject
{
    public class NinjectBusinessModule : NinjectModule
    {
        //Autofac yerine Ninject kullanmak istersek.
        public override void Load()
        {
            Bind<IBrandService>().To<BrandManager>();
            Bind<IBrandDal>().To<EfBrandDal>();
            Bind<ICarService>().To<CarManager>();
            Bind<ICarDal>().To<EfCarDal>();
            Bind<IColorService>().To<ColorManager>();
            Bind<IColorDal>().To<EfColorDal>();
            Bind<ICustomerService>().To<CustomerManager>();
            Bind<ICustomerDal>().To<EfCustomerDal>();
            Bind<IRentalService>().To<RentalManager>();
            Bind<IRentalDal>().To<EfRentalDal>();
            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

        }
    }
}
