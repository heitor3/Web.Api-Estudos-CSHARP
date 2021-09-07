using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Business.Entities;

namespace Web.Api.Business.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);

        void Commit();

        IList<Curso> ObterPorUsuario(int codigoUsuario);
    }
}
