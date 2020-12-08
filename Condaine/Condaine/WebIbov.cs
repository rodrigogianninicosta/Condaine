using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Condaine
{
    public static class WebIbov
    {
        public static List<String> pegar()
        {
            var requisicaoWeb = WebRequest.CreateHttp(@"https://br.investing.com/indices/bovespa-components");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            String arquivo = null;

            //try
            //{
                var resposta = requisicaoWeb.GetResponse();
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                arquivo = reader.ReadToEnd();
                streamDados.Close();
                resposta.Close();
                reader.Close();
            //}
            //catch
            //{
            //    arquivo = "OFF...";
            //}
            return filtro(arquivo);
        }
        private static List<String> filtro(String arquivo)
        {
            //Investing
            String[] tipos = new String[6] { "last", "high", "-low", "-pc" + '"', "-pcp", "over" };
            List<String> valores = new List<String>();
            int con = 0;
            for (int i = arquivo.IndexOf("bold left noWrap elp plusIconTd"); i < arquivo.Length; ++i)
            {
                if (arquivo[i + 1].ToString() + arquivo[i + 2] + arquivo[i + 3] + arquivo[i + 4] + arquivo[i + 5] == "title")
                {
                    do
                    {
                        ++i;
                    }
                    while (arquivo[i - 1] != '"');
                    String algo = "";
                    do
                    {
                        algo += arquivo[i];
                        ++i;
                    }
                    while (arquivo[i] != '"');
                    if (algo.Contains("Brasil")) { continue; }
                    do
                    {
                        ++i;
                    }
                    while (arquivo[i - 1] != '>');
                    //Ação da Empresa
                    algo = "";
                    do
                    {
                        algo += arquivo[i];
                        ++i;
                    }
                    while (arquivo[i] != '<');
                    valores.Add(algo);
                    do
                    {
                        ++i;
                    }
                    while (arquivo[i - 1] != '"');
                    //Nome da Empresa
                    algo = "";
                    do
                    {
                        //algo += arquivo[i];
                        ++i;
                    }
                    while (arquivo[i] != '"');
                    //valores.Add(algo);
                    int y = 0;
                    do
                    {
                        do
                        {
                            ++i;
                        }
                        while (arquivo[i + 1].ToString() + arquivo[i + 2] + arquivo[i + 3] + arquivo[i + 4] != tipos[y]);
                        do
                        {
                            ++i;
                        }
                        while (char.IsNumber(arquivo[i]) == false);
                        //Último preço
                        algo = "";
                        if (y == 3 || y == 4) { --i; }
                        do
                        {
                            algo += arquivo[i];
                            ++i;
                        }
                        while (char.IsNumber(arquivo[i]) || arquivo[i] == ',');
                        valores.Add(algo);
                        ++y;
                    }
                    while (y < 6);
                    ++con;
                    if (con == 62) { break; }
                }
            }
            return valores;
        }
    }
}
