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
    public class AeronavesRepository : IGenericRepository<Aeronave>
    {
        private IConnectionFactory _conn;
        public AeronavesRepository(IConnectionFactory conn){
            _conn = conn;
        }

        public async Task<Aeronave> BuscarPorIdAsync(int id)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<Aeronave>("BUSCAR_AERONAVES", new { IDAERONAVE = id }, commandType: System.Data.CommandType.StoredProcedure);
                    return lista.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                //Criar log
                return null;
            }
        }

        public async Task<IEnumerable<Aeronave>> BuscarTodosAsync()
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<Aeronave>("BUSCAR_AERONAVES", commandType: System.Data.CommandType.StoredProcedure);
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
