namespace api.Controllers;

using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly ClientService _clientService;

    public ClientsController(ClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("test")]
    public string Test()
    {
        return "WORKS";
    }

    [HttpGet]
public ActionResult<IEnumerable<ClientDto>> GetAll()
{
    var clients = _clientService.GetAll()
        .Select(c => new ClientDto
        {
            Id = c.Id,
            Name = c.Name
        });

    return Ok(clients);
}

    [HttpGet("{id}")]
public ActionResult<ClientDto> GetById(int id)
{
    var client = _clientService.GetById(id);

    if (client == null)
        return NotFound();

    var dto = new ClientDto
    {
        Id = client.Id,
        Name = client.Name
    };

    return Ok(dto);
}

    [HttpPost]
public ActionResult<ClientDto> Create([FromBody] CreateClientDto dto)
{
    var client = _clientService.Create(dto);

    var result = new ClientDto
    {
        Id = client.Id,
        Name = client.Name
    };

    return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
}

[HttpPut("{id}")]
public ActionResult UpdateClient(int id, [FromBody] CreateClientDto dto)
{
    var existing = _clientService.GetById(id);

    if (existing == null)
        return NotFound();

    _clientService.UpdateClient(id, dto);

    return NoContent();
}

    [HttpDelete("{id}")]
public ActionResult Delete(int id)
{
    var success = _clientService.Delete(id);

    if (!success)
        return NotFound();

    return NoContent();
}
}