﻿using Business.Abstract;
using Core.Utilities.Results;
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

        public IResult Add(Color color)
        {
            if(color.ColorName.Length>2)
            {
                _colorsDal.Add(color);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
           
        }

        public IResult Delete(Color color)
        {
            _colorsDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorsDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorsDal.Get(p => p.Id == colorId));
        }

        public IResult Update(Color color)
        {
       
            if (color.ColorName.Length > 2)
            {
                _colorsDal.Update(color);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }
    }
}
