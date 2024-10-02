using Microsoft.AspNetCore.Mvc;
using Prueba1.Controllers.Models;
using System.Net.Security;

namespace Prueba1.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        // Método para listar clientes
        [HttpGet]
        [Route("listar")]
        public IActionResult ListarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    Id = "1",
                    Correo = "bernardoGoogle@gmail.com",
                    Edad = "19",
                    Nombre = "Bernardo Peña"
                },
                new Cliente
                {
                    Id = "2",
                    Correo = "miguelGoogle@gmail.com",
                    Edad = "23",
                    Nombre = "Miguel Mantilla"
                }
            };

            return Ok(clientes);
        }

        // Método para listar cliente por ID
        [HttpGet]
        [Route("listarxId")]
        public IActionResult ListarClientexId(int codigo)
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    Id = codigo.ToString(),
                    Correo = "romanGoogle@gmail.com",
                    Nombre = "Román Solís",
                    Edad = "23",
                }
            };

            return Ok(clientes);
        }

        // Método para guardar cliente
        [HttpPost]
        [Route("guardar")]
        public IActionResult GuardarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null || string.IsNullOrEmpty(cliente.Nombre))
            {
                return BadRequest("Datos del cliente inválidos");
            }

            cliente.Id = "3";
            return Ok(new
            {
                success = true,
                message = "Cliente registrado",
                Results = cliente
            });
        }

        // Método para eliminar cliente
        [HttpPost]
        [Route("eliminar")]
        public IActionResult EliminarCliente([FromBody] Cliente cliente)
        {
            string token = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;

            if (token != "marcopolo")
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Token incorrecto",
                    Results = ""
                });
            }

            return Ok(new
            {
                success = true,
                message = "Cliente eliminado",
                Results = cliente
            });
        }
    }
}

namespace Prueba1.Controllers.Models
{
    public class Cliente
    {
        public required string Id { get; set; }
        public required string Nombre { get; set; }
        public required string Edad { get; set; }
        public required string Correo { get; set; }
    }
}
