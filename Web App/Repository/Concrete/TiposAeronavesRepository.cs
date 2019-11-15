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
    public class TiposAeronavesRepository : IGenericRepository<TipoAeronave>
    {
        private IConnectionFactory _conn;
        public TiposAeronavesRepository(IConnectionFactory conn){
            _conn = conn;
        }

        public async Task<TipoAeronave> BuscarPorIdAsync(int id)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<TipoAeronave>("BUSCAR_TIPOS_AERONAVES", new { IDAERONAVE = id }, commandType: System.Data.CommandType.StoredProcedure);
                    return lista.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                //Criar log
                return null;
            }
        }

        public async Task<IEnumerable<TipoAeronave>> BuscarTodosAsync()
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<TipoAeronave>("BUSCAR_TIPOS_AERONAVES", commandType: System.Data.CommandType.StoredProcedure);
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
