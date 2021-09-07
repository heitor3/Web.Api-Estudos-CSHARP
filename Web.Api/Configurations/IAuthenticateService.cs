using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Models.Usuarios;

namespace Web.Api.Configurations
{
    public interface IAuthenticateService
    {
        string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}
