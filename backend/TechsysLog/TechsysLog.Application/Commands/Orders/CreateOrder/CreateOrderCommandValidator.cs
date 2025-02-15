using FluentValidation;
using TechsysLog.Domain.Entities;

namespace TechsysLog.Application.Commands.Orders.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("O número do pedido é obrigatório.")
            .GreaterThan(0).WithMessage("O número do pedido deve ser maior que zero.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória.");

        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("O valor é obrigatório.")
            .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");
    }
}

public class OrderAddressValidator : AbstractValidator<OrderAddress>
{
    public OrderAddressValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O ID do endereço é obrigatório.");

        RuleFor(x => x.Cep)
            .NotEmpty().WithMessage("O CEP é obrigatório.");

        RuleFor(x => x.Rua)
            .NotEmpty().WithMessage("A rua é obrigatória.");

        RuleFor(x => x.Numero)
            .NotEmpty().WithMessage("O número é obrigatório.");

        RuleFor(x => x.Bairro)
            .NotEmpty().WithMessage("O bairro é obrigatório.");

        RuleFor(x => x.Cidade)
            .NotEmpty().WithMessage("A cidade é obrigatória.");

        RuleFor(x => x.Estado)
            .NotEmpty().WithMessage("O estado é obrigatório.");
    }
}