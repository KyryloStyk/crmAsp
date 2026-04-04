using AutoMapper;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<CreateClientDto, Client>();
    }
}