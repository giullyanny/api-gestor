using ApiGestor.Comunicacao;
using Microsoft.AspNetCore.Mvc;
namespace ApiGestor.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUsuario), StatusCodes.Status201Created)]
    public IActionResult Registrar(RegistroUsuario usuario)
    {

        return Created("http://www.google.com.br", new ResponseUsuario { Nome = usuario.Nome });
    }
}
