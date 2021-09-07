using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Business.Entities;
using Web.Api.Business.Repositories;

namespace Web.Api.Infrastructure.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDbContext _contexto;
        public CursoRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Curso curso)
        {
            _contexto.Curso.Add(curso);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IList<Curso> ObterPorUsuario(int codigoUsuario)
        {
            return _contexto.Curso
                .Include(x => x.Usuario)
                .Where(w => w.CodigoUsuario == codigoUsuario).ToList();
        }
    }
}
