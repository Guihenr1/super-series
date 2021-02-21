using SuperSeries.Enums;

namespace SuperSeries.Classes
{
    public class Serie : Base {
        public string Nome { get; }
        public int Ano { get; }
        public int Genero { get; }
        public string Descricao { get; }
        public bool Excluido { get; set; }

        public Serie(int id, string nome, int ano, Genero genero, string descricao)
        {
            Id = id;
            Nome = nome;
            Ano = ano;
            Genero = (int)genero;
            Descricao = descricao;
            Excluido = false;
        }
    }
}