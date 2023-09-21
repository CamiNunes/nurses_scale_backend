using Nurses_Scale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurses_Scale.Application.Interfaces
{
    public interface IAuthService
    {
        string GerarJwtToken(string email, Guid usuarioId);
        //bool VerificarPassword(Usuario usuario, string senha);
    }
}
