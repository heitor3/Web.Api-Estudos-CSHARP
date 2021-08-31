using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Filters;
using Web.Api.Models;
using Web.Api.Models.Usuarios;

namespace Web.Api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewOutPut))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]

        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "heitor",
                Email = "heitorfernandes@teste.com"
            };

            var secret = Encoding.ASCII.GetBytes("2bA5UCyDq7n_G1bQgJq2V0TzhBC5bgeZ9d8S-QHsVAsebcmHBJ1vghee_nvVwpZizYO8OverZwqRuoSjBF8l9Izw9G0KJyklHKDeipldpaCZQ3l5IYzDwaGYd3DDRQ2fFkzHSE3lnqUzmkVxCDFgYqXE0yTmeIcvJnH6xb1n3srZqgeh87qhFSsw_JYLCWq12FMcYoU9vSlF884ESnjLx38qBAbnLzZPCjstXtA3ZQ4jIf5I76N03ZqzqWP7eanbhHiVvCyFhrgh9AU1pACWkhDlllzRuhhblfA54S2-jb4BQnofxJwFJPmJWCo0ACOm6Ann7DPw_lIzpH22iBwzQ");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);


            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutput
            });
        }

        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {

            return Created("", registroViewModelInput);
        }

        
    }
}
