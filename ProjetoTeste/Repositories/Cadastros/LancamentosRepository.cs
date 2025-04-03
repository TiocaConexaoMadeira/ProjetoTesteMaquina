using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Infra.Database;
using ProjetoTeste.Model.Cadastro;
using System;


namespace ProjetoTeste.Repositories.Cadastros
{
    public class LancamentosRepository
    {
        private readonly ProjetoTesteContext _context;

        public LancamentosRepository(ProjetoTesteContext context)
        {
            _context = context;
        }

        public async Task<Lancamento> Cadastrar(Lancamento lancamento)
        {
            var maquina = await _context.maquinas.FirstOrDefaultAsync(m => m.Codigo == lancamento.CodigoMaquina);
            if (maquina == null)
            {
                throw new KeyNotFoundException("Máquina não encontrada.");
            }

            lancamento.CodigoMaquina = maquina.Codigo; 

            _context.lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<List<Lancamento>> ConsultarTodos()
        {
            return await _context.lancamentos.ToListAsync();
        }

        public async Task<Lancamento> ConsultarPorCodigo(int codigo)
        {
            return await _context.lancamentos.FirstOrDefaultAsync(l => l.Codigo == codigo);
        }
    }
}
