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
        IColorDal _colorsDal;
        public ColorManager(IColorDal colorsDal)
        {
            _colorsDal = colorsDal;
        }

        public void Add(Color color)
        {
            _colorsDal.Add(color);
        }

        public void Delete(Color color)
        {
            _colorsDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorsDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorsDal.Get(p => p.Id == colorId);
        }

        public void Update(Color color)
        {
            _colorsDal.Update(color);
        }
    }
}
