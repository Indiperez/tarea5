namespace api.Controllers
{
    using api.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>();

        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public IActionResult CreateCliente([FromBody] Cliente cliente)
        {
            cliente.Id = clientes.Any() ? clientes.Max(c => c.Id) + 1 : 1;
            clientes.Add(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            var existingCliente = clientes.FirstOrDefault(c => c.Id == id);
            if (existingCliente == null)
                return NotFound();

            existingCliente.Nombre = cliente.Nombre;
            existingCliente.CorreoElectronico = cliente.CorreoElectronico;
            existingCliente.Telefono = cliente.Telefono;
            existingCliente.Direccion = cliente.Direccion;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            clientes.Remove(cliente);
            return NoContent();
        }
    }

}
