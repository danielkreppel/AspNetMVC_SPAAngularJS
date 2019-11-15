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
    public class AeroportosRepository : IGenericRepository<Aeroporto>
    {
        private IConnectionFactory _conn;
        public AeroportosRepository(IConnectionFactory conn){
            _conn = conn;
        }

        public async Task<Aeroporto> BuscarPorIdAsync(int id)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<Aeroporto>("BUSCAR_AEROPORTOS", new { IDAERONAVE = id }, commandType: System.Data.CommandType.StoredProcedure);
                    return lista.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                //Criar log
                return null;
            }
        }

        public async Task<IEnumerable<Aeroporto>> BuscarTodosAsync()
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<Aeroporto>("BUSCAR_AEROPORTOS", commandType: System.Data.CommandType.StoredProcedure);
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Criar log
                return null;
            }
        }

    }

}
