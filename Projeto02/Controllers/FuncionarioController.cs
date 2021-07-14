using Newtonsoft.Json;
using Projeto02.Entities;
using Projeto02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Controllers
{
    public class FuncionarioController
    {
        public void CadastrarFuncionario()
        {
            Console.WriteLine("\n --- CADASTRO DE FUNCIONÁRIO --- \n");
            var funcionario = new Funcionario();

            funcionario.Setor = new Setor();
            funcionario.Dependentes = new List<Dependente>();

            funcionario.IdFuncionario = Guid.NewGuid();

            Console.Write("Nome do funcionário..................: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("CPF do funcionário...................: ");
            funcionario.Cpf = Console.ReadLine();

            Console.Write("Matrícula do funcionário.............: ");
            funcionario.Matricula = Console.ReadLine();

            Console.Write("Data de Admissão do funcionário......: ");
            funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

            funcionario.Setor.IdSetor = Guid.NewGuid();

            Console.Write("Nome do setor........................: ");
            funcionario.Setor.Nome = Console.ReadLine();

            Console.Write("Descrição do setor...................: ");
            funcionario.Setor.Descricao = Console.ReadLine();

            Console.Write("Número de dependentes................: ");
            var numDependentes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numDependentes; i++)
            {
                var dependente = new Dependente();
                dependente.IdDependente = Guid.NewGuid();

                Console.WriteLine($"\nENTRE COM O {i+1}º DEPENDENTE:\n");

                Console.Write("Nome do dependente..............: ");
                dependente.Nome = Console.ReadLine();

                Console.Write("Data de nascimento..............: ");
                dependente.DataNascimento = DateTime.Parse(Console.ReadLine());

                funcionario.Dependentes.Add(dependente);
            }

            var funcionarioRepository = new FuncionarioRepository();
            funcionarioRepository.ExportarJSON(funcionario);

            Console.WriteLine("\nARQUIVO JSON GERADO COM SUCESSO!");
        }
    }
}
