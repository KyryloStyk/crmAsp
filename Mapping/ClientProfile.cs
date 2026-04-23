using AutoMapper;
using api.DTOs.Client;
using api.DTOs.Order;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>()
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));

        CreateMap<CreateClientDto, Client>();

        CreateMap<Order, OrderDto>();
        CreateMap<CreateOrderDto, Order>();
    }
}