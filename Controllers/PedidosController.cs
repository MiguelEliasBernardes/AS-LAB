using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoRepository _repository;
    private readonly IFornecedorRepository _fornecedorRepository;

    public PedidosController(IPedidoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var pedidos = await _repository.GetAllAsync();
        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pedido = await _repository.GetByIdAsync(id);
        if (pedido == null)
            return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pedido pedido)
    {
        await _repository.AddAsync(pedido);
        return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Pedido pedido)
    {
        if (id != pedido.Id)
            return BadRequest();

        await _repository.UpdateAsync(pedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}