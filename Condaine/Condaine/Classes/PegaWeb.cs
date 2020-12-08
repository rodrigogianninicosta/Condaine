using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Condaine
{
    public class PegaWeb
    {
        public String pegar()
        {
            //var requisicaoWeb = WebRequest.CreateHttp(@"https://economia.uol.com.br/cotacoes/");
            var requisicaoWeb = WebRequest.CreateHttp(@"https://www.google.com/search?client=firefox-b-d&q=cota%C3%A7%C3%A3o+do+dolar+hoje");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            String arquivo = null;
            
            try
            {
                var resposta = requisicaoWeb.GetResponse();
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                arquivo = reader.ReadToEnd();
                arquivo = filtro(arquivo);
                streamDados.Close();
                resposta.Close();
                reader.Close();
            }
            catch
            {
                arquivo = "OFF...";
            }
            return arquivo;
        }
        private String filtro(String arquivo)
        {
            //Uol
            //String fil = "";
            //for (int i = arquivo.IndexOf("subtituloGrafico subtituloGraficoValor") + 43; i < arquivo.Length; i++)
            //{
            //    try
            //    {
            //        int.Parse(arquivo[i].ToString());
            //    }
            //    catch
            //    {
            //        if (arquivo[i] != ',')
            //        {
            //            break;
            //        }
            //    }
            //    fil += arquivo[i];
            //}
            //return fil;

            //Google
            String fil = "";
            for (int i = arquivo.LastIndexOf("<div class="+'"'+"BNeawe iBp4i AP7Wnd"+'"'+">") + 33; i < arquivo.Length; i++)
            {
                try
                {
                    int.Parse(arquivo[i].ToString());
                }
                catch
                {
                    if (arquivo[i] != ',')
                    {
                        break;
                    }
                }
                fil += arquivo[i];
            }
            return fil;
        }
    }
}
