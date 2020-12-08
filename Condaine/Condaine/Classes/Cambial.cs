using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Condaine
{
    public class Cambial
    {
        //Lista com as listas
        public static List<Setup> seta = new List<Setup>();

        static String arquivo;

        //Selecionar o dólar
        public void selectDolar(int ano)
        {
            seta.Add(new Setup("", ""));
            bool pass = true;
            if (ano == 0) { pass = false; ano = 2008; }
            do
            {
                arquivo = "dol1_" + ano + ".csv";
                produz();
                arquivo = "dol2_" + ano + ".csv";
                produz();
                ano++;
            }
            while (pass != true && ano < 2021);
        }

        //Armazenar a data, o valor de compra e de venda
        public void produz()
        {
            List<String> reader = new List<String>();
            StreamReader st = new StreamReader(arquivo);
            reader = st.ReadToEnd().Split(';').ToList();
            seta.Add((new Setup(reader[0].Substring(0, 2) + '/' + reader[0].Substring(2, 2) + '/' + reader[0].Substring(4, 4), 1)));
            for (int i = 7; i < reader.Count - 6; i += 7)
            {
                reader[i] = reader[i].Remove(0, 7);
                seta.Add(new Setup(reader[i].Substring(0, 2) + '/' + reader[i].Substring(2, 2) + '/' + reader[i].Substring(4, 4), 1));
            }
            for (int i = 4; i < reader.Count; i += 7) { seta.Add(new Setup(reader[i], false)); }
            for (int i = 5; i < reader.Count; i += 7) { seta.Add(new Setup(reader[i], 'c')); }
        }
    }
}
