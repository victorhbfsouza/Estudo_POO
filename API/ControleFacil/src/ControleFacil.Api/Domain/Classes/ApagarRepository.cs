using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Interfaces;
using ControleFacil.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Classes
{
    public class ApagarRepository : IApagarRepository
    {
        private readonly ApplicationContext _contexto;

        public ApagarRepository(ApplicationContext context)
        {
            _contexto = context;
        }
        public async Task<Apagar> Adicionar(Apagar entidade)
        {
            await _contexto.Apagar.AddAsync(entidade);
            await _contexto.SaveChangesAsync();

            return entidade;
        }

        public async Task<Apagar> Atualizar(Apagar entidade)
        {
            Apagar entidadeBanco = _contexto.Apagar
            .Where(u => u.Id == entidade.Id)
            .FirstOrDefault();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<Apagar>(entidadeBanco);

            await _contexto.SaveChangesAsync();

            return entidadeBanco;
        }

        public async Task Deletar(Apagar entidade)
        {
            //Deletar lógico, só altero a data de inativação
            entidade.DataInativacao = DateTime.Now;
            await Atualizar(entidade);
        }

        public async Task<IEnumerable<Apagar>> Obter()
        {
            return await _contexto.Apagar.AsNoTracking()
                                        .OrderBy(u => u.Id)
                                        .ToListAsync();
        }

        public async Task<Apagar?> Obter(long id)
        {
            return await _contexto.Apagar.AsNoTracking()
                                        .Where(n => n.Id == id)
                                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Apagar>> ObterPeloIdUsuario(long idUsuario)
        {
            return await _contexto.Apagar.AsNoTracking()
                                        .Where(n => n.IdUsuario == idUsuario)
                                        .OrderBy(n => n.Id)
                                        .ToListAsync();
        }
    }
}