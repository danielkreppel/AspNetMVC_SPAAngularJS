using Domain;
using Repository.Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Repository.Concrete
{
    public class PlanoVooRepository : IPlanoVooRepository<PlanoVoo>, IGenericRepository<PlanoVoo>
    {
        private IConnectionFactory _conn;
        public PlanoVooRepository(IConnectionFactory conn){
            _conn = conn;
        }

        public async Task<bool> InserirAsync(PlanoVoo entidade)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    await conn.ExecuteAsync("INSERIR_PLANO_VOO", entidade, commandType: System.Data.CommandType.StoredProcedure);
                    return true;
                }
            }
            catch(Exception ex)
            {
                //Criar mecanismo de log
                return false;
            }
        }

        public async Task<bool> AtualizarAsync(PlanoVoo entidade)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    await conn.ExecuteAsync("ATUALIZAR_PLANO_VOO", entidade, commandType: System.Data.CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Criar mecanismo de log
                return false;
            }
        }

        public async Task<PlanoVoo> BuscarPorIdAsync(int id)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<PlanoVoo>("BUSCAR_PLANO_VOO", new { IDPLANOVOO = id }, commandType: System.Data.CommandType.StoredProcedure);
                    return lista.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                //Criar log
                return null;
            }
        }

        public async Task<IEnumerable<PlanoVoo>> BuscarTodosAsync()
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<PlanoVoo>("BUSCAR_PLANO_VOO", commandType: System.Data.CommandType.StoredProcedure);
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Criar log
                return null;
            }
        }

        public async Task<bool> RemoverAsync(int id)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    await conn.ExecuteAsync("EXCLUIR_PLANO_VOO", new { IDPLANOVOO = id}, commandType: System.Data.CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Criar mecanismo de log
                return false;
            }
        }
    }

}
