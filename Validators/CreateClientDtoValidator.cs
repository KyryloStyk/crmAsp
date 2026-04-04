using FluentValidation;

public class CreateClientDtoValidator : AbstractValidator<CreateClientDto>
{
    public CreateClientDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Имя обязательно")
            .MinimumLength(2).WithMessage("Минимум 2 символа");
    }
}