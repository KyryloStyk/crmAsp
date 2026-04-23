namespace api.Controllers;

using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("test")]
    public string Test()
    {
        return "WORKS";
    }

    [HttpGet]
public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll()
{
    var clients = await _clientService.GetAllAsync();

    var result = clients.Select(c => new ClientDto
    {
        Id = c.Id,
        Name = c.Name
    });

    return Ok(result);
}

[HttpGet("{id}")]
public async Task<ActionResult<ClientDto>> GetById(int id)
{
    var client = await _clientService.GetByIdAsync(id);

    if (client == null)
        return NotFound();

    return Ok(new ClientDto
    {
        Id = client.Id,
        Name = client.Name
    });
}

[HttpPost]
public async Task<ActionResult<ClientDto>> Create(CreateClientDto dto)
{
    var client = await _clientService.CreateAsync(dto);

    var result = new ClientDto
    {
        Id = client.Id,
        Name = client.Name
    };

    return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
}

[HttpPut("{id}")]
public async Task<ActionResult> Update(int id, CreateClientDto dto)
{
    var success = await _clientService.UpdateAsync(id, dto);

    if (!success)
        return NotFound();

    return NoContent();
}

[HttpDelete("{id}")]
public async Task<ActionResult> Delete(int id)
{
    var success = await _clientService.DeleteAsync(id);

    if (!success)
        return NotFound();

    return NoContent();
}
}