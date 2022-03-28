using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    //Methode d'extension
    public static class StringExtension
    {
        public static string Upper(this String s)
        {
            s = s[0].ToString().ToUpper() + s.Substring(1,s.Length-1);
            return s;
        }
    }
}
