using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GO.ECM.ScriptDotNet.Atributos;
using GO.ECM.ScriptDotNet.ProdutoEspecifico;
using ConsoleApp1.Entities;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Serialization;

namespace DLLImportaBancoDeDados
{
    [ClasseScript]
    public class Class1 : ScriptEcm
    {
        public Class1()
        {

        }
        public Class1(Object obj)
        {

        }

        [MetodoScript]
        public void ImportaBanco()
        {
            string strConexao = "Server=osas;Initial Catalog=DB_CadastroFunc;user id=sa;pwd=x";
            var conn = new SqlConnection(strConexao);
            conn.Open();
            var comm = new SqlCommand("select * from Cadastro", conn);
            SqlDataReader dr = comm.ExecuteReader();

            var funcionarios = new List<Funcionario>();
            string[] valores = new string[7];
            int count = 0;
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    valores[count] = dr[i].ToString();
                    if (count > 5)
                    {
                        funcionarios.Add(new Funcionario
                        {
                            Id = int.Parse(valores[0]),
                            Matricula = valores[1],
                            Graduacao = valores[2],
                            NomeDeGuerra = valores[3],
                            Nome = valores[4],
                            Quantidade = int.Parse(valores[5]),
                            Ativo = bool.Parse(valores[6])
                        });
                        count = 0;
                    }
                    else
                    {
                        count++;
                    }
                }

            }

            dr.Close();
            conn.Close();
            var json = new JavaScriptSerializer().Serialize(funcionarios);
            base.SetCampoValor(8, json);
        }

    }
}
