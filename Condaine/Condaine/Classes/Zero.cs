using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace Condaine
{
    public class Zero : NovoFast
    {
        //Caso seja a opção todos, chama as threads
        //Caso não, chama de forma convencional
        public void fazer()
        {
            seta.Add(new Setup(""));
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
                    thread2(Math.Abs(guard));
                    ++i;
                    ++guard;
                }
                while (i < num);
            }
            else { thread2(year); }
        }

        //Armazena a data, o tipo, a abertura, o máximo, o mínimo, o médio e o fechamento das ações
        public static void thread2(int num1)
        {
            List<String> dois = new List<String>();
            List<String> tres = new List<String>();
            List<String> quatro = new List<String>();
            List<String> cinco = new List<String>();
            List<String> seis = new List<String>();
            List<String> sete = new List<String>();
            List<String> oito = new List<String>();
            Entrada ent = new Entrada();
            String[] guard = new String[5];
            int[] ind = { 56, 69, 82, 95, 108 };
            int y = 0;
            int an = num1;
            int i = 0;
            String ano = @"COTAHIST_A" + an + ".txt", line;
            StreamReader st = new StreamReader(ano);
            st.ReadLine();
            while ((line = st.ReadLine()) != null) 
            {
                if (regex.Replace(line.Substring(27, 12), "") == ent.getNome())
                {
                    if (yearFinal != 0) { dois.Add(line.Substring(8, 2) + '/' + line.Substring(6, 2) + '/' + line.Substring(2, 4)); }
                    else { dois.Add(line.Substring(8, 2) + '/' + line.Substring(6, 2)); }
                    tres.Add(line.Substring(12, 11));
                    y = 0;
                    do
                    {
                        i = 0;
                        guard[y] = line.Substring(ind[y], 11);
                        try
                        {
                            if (int.Parse(guard[y]) != 0)
                            {
                                while (guard[y].ToString()[i] == '0') { ++i; }
                                guard[y] = guard[y].Remove(0, i);
                            }
                            else { guard[y] = "0"; }
                        }
                        catch { }
                        ++y;
                    }
                    while (y < 5);
                    quatro.Add(guard[0] + ',' + line.Substring(67, 2));
                    cinco.Add(guard[1] + ',' + line.Substring(80, 2));
                    seis.Add(guard[2] + ',' + line.Substring(93, 2));
                    sete.Add(guard[3] + ',' + line.Substring(106, 2));
                    oito.Add(guard[4] + ',' + line.Substring(119, 2));
                }
            }
            st.Close();
            seta.Add(new Setup(dois, tres, quatro, cinco, seis, sete, oito));
        }
    }
}
