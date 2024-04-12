using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success) //Başarısız olan iş kurallarım var ise
                {
                    return logic;   //Mevcut hata varsa onu döndür.
                }

            }

            return null;    //Tüm kurallar başarılı ise null döndür
        }
    }
}
