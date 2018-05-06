using apiCrud.bo.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace apiCrud.bo.negocio
{
    public class PessoaNegocio
    {
        public static List<pessoa> ListarTodos (){
            using (var context = new ApiCrudEntity())
            {
                var listaPessoasBanco = context.pessoa.ToList();
                return listaPessoasBanco;
            }
        }
    

        public static pessoa ListaPorID(Guid id)
        {
            using (var context = new ApiCrudEntity())
            {
                var pessoaBanco = context.pessoa.Where(x => x.id == id).FirstOrDefault();
                return pessoaBanco;
            }
        }

        public static pessoa ListarPorNome (String nome){
            using (var context = new ApiCrudEntity()) {
                var pessoaBanco = context.pessoa.Where(x => x.nome == nome).FirstOrDefault();
                return pessoaBanco;
            }
        }

        public static bool AddPessoa(pessoa p)
        {
            using (var context = new ApiCrudEntity()) {
                pessoa pessoaCompare = context.pessoa.FirstOrDefault(x => x.CPF == p.CPF);
                if (pessoaCompare != null) {
                    return false;
                }
                string dataNascimento = Regex.Replace(p.Nascimento, @"-.*-.*", "");
                int anoNascimento = Convert.ToInt32(dataNascimento);
                string dataAtual = DateTime.Now.ToString();
                dataAtual = Regex.Replace(dataAtual, @".*/.*/", "");
                int anoAtual = Convert.ToInt32(Regex.Replace(dataAtual, @"(\d){2,2}:(\d){2,2}:(\d){2,2}", ""));
                int resultado = anoAtual - anoNascimento;
                p.idade = resultado.ToString();
                context.pessoa.Add(p);
                context.SaveChanges();
                return true;  
            }
        }

        public static void EditaPessoa(Guid id, pessoa p)
        {
            using (var context = new ApiCrudEntity())
            {
                context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
        }

        public static bool RemovePessoa(Guid id)
        {
            using (var context = new ApiCrudEntity())
            {
                var pessoaBanco = context.pessoa.Where(x => x.id == id).FirstOrDefault();
                context.pessoa.Remove(pessoaBanco);
                context.SaveChanges();
                return true;
            }
        }
    }
}
