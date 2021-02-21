using System.Collections.Generic;
using System.Linq;
using SuperSeries.Classes;

namespace SuperSeries.Repositorios
{
    public class SerieRepositorio : IRepository<Serie>
    {
        private List<Serie> Series = new List<Serie>();

        public IEnumerable<Serie> Listar()
        {
            return Series;
        }

        public Serie ObterPorId(int id)
        {
            return Series.FirstOrDefault(x => x.Id == id);
        }

        public void Inserir(Serie serie)
        {
            Series.Add(serie);
        }

        public void Excluir(int id)
        {
            Series[id].Excluido = true;
        }

        public void Atualizar(Serie serie)
        {
            Series[serie.Id] = serie;
        }

        public int ProximoId()
        {
            return Series.Count + 1;
        }
    }
}