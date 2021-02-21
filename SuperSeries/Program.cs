using System;
using System.Text;
using SuperSeries.Classes;
using SuperSeries.Enums;
using SuperSeries.Repositorios;

namespace SuperSeries {
    class Program {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            int opcao;

            do {
                ApresentarMenu();
                opcao = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(string.Empty);

                switch (opcao)
                {
                    case (int)Menu.Listar:
                        Listar();
                        break;
                    case (int)Menu.Buscar:
                        Buscar();
                        break;
                    case (int)Menu.Adicionar:
                        Adicionar();
                        break;
                    case (int)Menu.Editar:
                        Editar();
                        break;
                    case (int)Menu.Excluir:
                        Excluir();
                        break;
                    default:
                        Console.WriteLine("Digite uma opcao valida");
                        break;
                }

                Console.WriteLine(string.Empty);
            } while (opcao != 0);
        }

        #region CRUD

        static void Adicionar() {
            Console.WriteLine("Bem vindo ao cadastro de serie ");
            Console.Write("Digite o nome: ");
            var nome = Console.ReadLine();

            Console.Write("Digite o ano: ");
            var ano = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Generos disponiveis: ");
            ListarEnum<Genero>();
            Console.Write("Digite o identificador do genero: ");
            Genero genero = (Genero)Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a descicao: ");
            var descricao = Console.ReadLine();

            var serie = new Serie(repositorio.ProximoId(), nome, ano, genero, descricao);

            repositorio.Inserir(serie);
        }

        static void Editar() {
            Console.WriteLine("Bem vindo a edicao de serie ");

            Console.Write("Digite o identificador: ");
            var id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o nome: ");
            var nome = Console.ReadLine();

            Console.Write("Digite o ano: ");
            var ano = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Genero disponiveis: ");
            ListarEnum<Genero>();
            Console.Write("Digite o identificador do genero: ");
            Genero genero = (Genero)Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a descicao: ");
            var descricao = Console.ReadLine();

            var serie = new Serie(id - 1, nome, ano, genero, descricao);

            repositorio.Atualizar(serie);
        }

        static void Listar() {
            var series = repositorio.Listar();

            foreach (var serie in series) {
                ExibirSerie(serie);
            }
        }

        static void Buscar() {
            Console.Write("Digite o identificador da serie desejada: ");
            var id = Convert.ToInt32(Console.ReadLine());

            var serie = repositorio.ObterPorId(id);

            ExibirSerie(serie);
        }

        static void Excluir() {
            Console.Write("Digite o identificador da serie a ser excluida: ");
            var id = Convert.ToInt32(Console.ReadLine());

            repositorio.Excluir(id - 1);
        }

        #endregion

        #region Utils

        static void ApresentarMenu() {
            Console.WriteLine("Opcoes disponiveis:");
            ListarEnum<Menu>();

            Console.WriteLine(string.Empty);
            Console.Write("Digite a opcao desejada: ");
        }

        static void ExibirSerie(Serie serie) {
            Console.WriteLine(string.Empty);
            Console.WriteLine("Identificador: " + serie.Id);
            Console.WriteLine("Nome: " + serie.Nome);
            Console.WriteLine("Descricao: " + serie.Descricao);
            Console.WriteLine("Ano: " + serie.Ano);
            Console.WriteLine("Genero: " + Enum.GetName(typeof(Genero), serie.Genero));
            Console.WriteLine("Ativo: " + (serie.Excluido ? "Nao" : "Sim"));
            Console.WriteLine(string.Empty);
        }

        static void ListarEnum<E>() where E : Enum
        {
            foreach (var valor in Enum.GetValues(typeof(E))) {
                Console.WriteLine($"{(int)valor} - {valor}");
            }
        }

        #endregion
    }
}
