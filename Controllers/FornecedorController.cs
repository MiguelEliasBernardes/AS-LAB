using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FornecedorController : ControllerBase
{
    private readonly IFornecedorRepository _repository;

    public FornecedorController(IFornecedorRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var fornecedor = await _repository.GetAllAsync();
        return Ok(fornecedor);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var fornecedor = await _repository.GetByIdAsync(id);
        if (fornecedor == null)
            return NotFound();
        return Ok(fornecedor);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Fornecedor fornecedor)
    {
        await _repository.AddAsync(fornecedor);
        return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
            return BadRequest();

        await _repository.UpdateAsync(fornecedor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}