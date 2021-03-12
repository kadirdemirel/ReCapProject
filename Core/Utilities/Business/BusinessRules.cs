using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //params ile iş kurallarını bir diziye aktarıp bütün kuralları tek tek parametre olarak kurallarımızı geçebiliriz.
        //Bütün kurallar gezilip kuralama uymayan varsa o kural döndürülür.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
