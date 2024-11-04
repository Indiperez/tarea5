using Microsoft.AspNetCore.Mvc;
using MiAppWeb.Models;
using MiAppWeb.Services;
using System.Threading.Tasks;
using MiAppWeb.Services;

public class ClientesController : Controller
{
    private readonly ClienteService _clienteService;

    public ClientesController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public async Task<IActionResult> Index()
    {
        var clientes = await _clienteService.GetClientesAsync();
        return View(clientes);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            await _clienteService.CreateClienteAsync(cliente);
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cliente = await _clienteService.GetClienteByIdAsync(id);
        return cliente == null ? NotFound() : View(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            await _clienteService.UpdateClienteAsync(cliente);
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _clienteService.DeleteClienteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
