using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contract
{
    public interface IPlanoVooRepository<T> where T : class
    {
        Task<bool> RemoverAsync(int id);
        Task<bool> AtualizarAsync(T entidade);
        Task<bool> InserirAsync(T entidade);
    }
}
