using System.Collections;
using System.Collections.Generic;

namespace SuperSeries.Repositorios
{
    public interface IRepository<T>
    {
        IEnumerable<T> Listar();
        T ObterPorId(int id);
        void Inserir(T objeto);
        void Excluir(int id);
        void Atualizar(T objeto);
        int ProximoId();
    }
}