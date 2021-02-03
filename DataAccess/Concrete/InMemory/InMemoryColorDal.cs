﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryColorDal:IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{Id=1,ColorName="Beyaz"},
                new Color{Id=2,ColorName="Kırmızı"},
                new Color{Id=3,ColorName="Mavi"},
                new Color{Id=4,ColorName="Siyah"},
                new Color{Id=5,ColorName="Lacivert"},

            };
        }

        public void GetAll()
        {
            int sira = 0;
            var result = (from c in _colors
                          orderby c.ColorName ascending
                          select c);
            foreach (var color in result)
            {
                sira++;
                Console.WriteLine(sira + "-)" + color.ColorName);

            }
        }
    }
}
