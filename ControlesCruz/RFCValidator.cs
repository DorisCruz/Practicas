using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlesCruz
{
    public static class RFCValidator
    {
        public static bool EsRFCValido(string rfc)
        {
            return Regex.IsMatch(rfc, @"^[A-Z]{4}\d{6}[A-Z0-9]{2,3}$");
        }

        public static string CorregirRFC(string rfc)
        {
            rfc = rfc.ToUpper(); 
            rfc = rfc.Replace(" ", "").Replace("-", "");
            return rfc;
        }
    }
}
