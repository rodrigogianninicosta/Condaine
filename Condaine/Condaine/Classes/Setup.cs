using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condaine
{
    public class Setup
    {
        //Nome das empresas sem repetição e em ordem
        public static List<String> emp { get; set; }

        //Nome das empresas com repetição e fora da ordem
        public static List<String> repEmp { get; set; }
        //Ano, mês e dia dos dados
        public static List<String> aammdd { get; set; }
        //Tipo das ações
        public static List<String> tipos { get; set; }
        //Preço de abertura
        public static List<String> aber { get; set; }
        //Preço máximo
        public static List<String> max { get; set; }
        //Preço mínimo
        public static List<String> min { get; set; }
        //Preço médio
        public static List<String> med { get; set; }
        //Preço de fechamento
        public static List<String> encer { get; set; }

        public Setup() { }

        public Setup(int a) { emp = new List<String>(); repEmp = new List<String>(); }
        public Setup(List<String> a) { repEmp.AddRange(a); }

        //Elimina as repetições e coloca em ordem
        public Setup(bool a) { emp = repEmp.Distinct().ToList(); emp.Sort(); }

        public Setup(String a)
        {
            aammdd = new List<String>();
            tipos = new List<String>();
            aber = new List<String>();
            max = new List<String>();
            min = new List<String>();
            med = new List<String>();
            encer = new List<String>();
        }
        public Setup(List<String> b, List<String> c, List<String> d, List<String> e, List<String> f, List<String> g, List<String> h)
        {
            aammdd.AddRange(b);
            tipos.AddRange(c);
            aber.AddRange(d);
            max.AddRange(e);
            min.AddRange(f);
            med.AddRange(g);
            encer.AddRange(h);
        }
        public List<String> getEmp() { return emp; }

        public List<String> getAammdd() { return aammdd; }
        public List<String> getTipos() { return tipos; }
        public List<String> getAber() { return aber; }
        public List<String> getMax() { return max; }
        public List<String> getMin() { return min; }
        public List<String> getMed() { return med; }
        public List<String> getEncer() { return encer; }

        //                                                                       CAMBIAL
        //Ano, mês e dia dos dados
        public static List<String> amd { get; set; }
        //Valor de compra
        public static List<String> compra { get; set; }
        //Valor de venda
        public static List<String> venda { get; set; }
        public Setup(String a, String b)
        {
            amd = new List<String>();
            compra = new List<String>();
            venda = new List<String>();
        }
        public Setup(String b, int a)
        {
            amd.Add(b);
        }
        public Setup(String b, bool a)
        {
            compra.Add(b);
        }
        public Setup(String b, char a)
        {
            venda.Add(b);
        }
        public List<String> getAmd() { return amd; }
        public List<String> getCompra() { return compra; }
        public List<String> getVenda() { return venda; }
    }
}
