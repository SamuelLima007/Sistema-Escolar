using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Domain.Models;

namespace ProjetoScores.Domain.Interfaces
{
    public interface ITokenService
    {
         public string GenerateToken(User user);
    }
}