using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface ITokenService
    {
         public string GenerateToken(User user);
    }
}