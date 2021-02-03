using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colors;
        public ColorManager(IColorDal colors)
        {
            _colors = colors;
        }
        public void GetAll()
        {
            _colors.GetAll();
        }
    }
}
