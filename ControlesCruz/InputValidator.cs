using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlesCruz
{
    public static class InputValidator
    {
        public static bool EsSoloNumeros(string texto)
        {
            return Regex.IsMatch(texto, @"^\d+$");
        }

        public static bool EsSoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }
    }
}
