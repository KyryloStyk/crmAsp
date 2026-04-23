namespace api.Controllers;
namespace api.DTOs.Client;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using api.DTOs.Client;
using api.DTOs.Order;
[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;

    public ClientsController(IClientService clientService, IMapper mapper)
{
    _clientService = clientService;
    _mapper = mapper;
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

    var result = _mapper.Map<IEnumerable<ClientDto>>(clients);

    return Ok(result);
}

[HttpGet("{id}")]
public async Task<ActionResult<ClientDto>> GetById(int id)
{
    var client = await _clientService.GetByIdAsync(id);

    if (client == null)
        return NotFound();

    return Ok(_mapper.Map<ClientDto>(client));
}

[HttpPost]
public async Task<ActionResult<ClientDto>> Create(CreateClientDto dto)
{
    var client = await _clientService.CreateAsync(dto);

    var result = _mapper.Map<ClientDto>(client);

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