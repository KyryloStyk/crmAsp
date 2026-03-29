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

    [HttpGet]
    public ActionResult<IEnumerable<Client>> GetAllClients()
    {
        return Ok(_clientService.GetAllClients());
    }

    [HttpGet("{id}")]
    public ActionResult<Client> GetById(int id)
    {
        var client = _clientService.GetById(id);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    [HttpPost]
    public ActionResult AddClient(CreateClientDto dto)
    {
        var client = _clientService.Add(dto);

        return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteClient(int id)
    {
        var existingClient = _clientService.GetById(id);

        if (existingClient == null)
        {
            return NotFound();
        }

        _clientService.DeleteClient(id);

        return NoContent();
    }
}