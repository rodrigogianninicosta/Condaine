using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Condaine
{
    public class NovoFast:MudaAno
    { 
        public static List<Setup> seta = new List<Setup>();
        public static int num;
        public static Regex regex = new Regex(@"\s{2,}");
        //Caso seja a opção todos, chama as threads
        //Caso não, chama de forma convencional
        public void faz()
        {
            seta.Add(new Setup(1));
            int guard = 0;
            if (yearFinal != 0)
            {
                if (yearFinal < year)
                {
                    num = year - yearFinal + 1;
                    guard = yearFinal;
                }
                else
                {
                    num = yearFinal - year + 1;
                    guard = year;
                }
                int i = 0;
                do
                {
                    thread(Math.Abs(guard));
                    ++i;
                    ++guard;
                }
                while (i < num);
            }
            else { thread(year); }
            try { seta.Add(new Setup(false)); }
            catch { seta.Add(new Setup(false)); }

        }
        public static void thread(int num1)
        {
            List<String> um = new List<String>();
            int an = num1;
            String ano = @"COTAHIST_A" + an + ".txt", line;
            StreamReader st = new StreamReader(ano);
            st.ReadLine();
            while ((line = st.ReadLine()) != null) { um.Add(regex.Replace(line.Substring(27, 12), "")); }
            um.RemoveAt(um.Count - 1);
            st.Close();
            seta.Add(new Setup(um));          
        }
    }
}
