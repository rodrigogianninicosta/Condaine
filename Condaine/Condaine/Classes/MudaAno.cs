using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condaine
{
    public class MudaAno
    {
        public static String stN;
        public static String algo = "";
        public static int year;
        public static int yearFinal;

        public void setAlgo(String _algo) { algo = _algo; }
        public void setYear(int _year) { year = _year; }
        public void setYearFinal(int _year) { yearFinal = _year; }

        public String getAlgo() { return algo; }
        public int getYear() { return year; }
        public int getYearFinal() { return yearFinal; }

        //Ano do arquivo que será lido
        public MudaAno()
        {
            stN = @"COTAHIST_A" + year + ".txt";
        }
    }
}
