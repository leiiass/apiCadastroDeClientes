using Dominio.Modelos;
using FluentValidation;

namespace Dominio.Validadores
{
    public class ClienteValidador : AbstractValidator<Cliente>
    {
        public ClienteValidador()
        {
            RuleFor(nome => nome.Nome).NotEmpty().NotNull().WithMessage("Nome é obrigatório.");
            RuleFor(sobrenome => sobrenome.Sobrenome).NotEmpty().NotNull().WithMessage("Sobrenome é obrigatório.");
            RuleFor(cpf => cpf.CPF).Length(11).NotEmpty().NotNull().WithMessage("CPF é obrigatório.");
            RuleFor(telefone => telefone.Telefone).Length(11).NotNull().NotEmpty().WithMessage("Telefone é obrigatório.");
            RuleFor(idade => idade.Idade).NotNull().NotEmpty().WithMessage("Idade é obrigatório.");
            RuleFor(endereco => endereco.Endereco.Cidade).NotEmpty().NotNull();
            RuleFor(endereco => endereco.Endereco.Estado).NotEmpty().NotNull();
            RuleFor(endereco => endereco.Endereco.Rua).NotEmpty().NotNull();
        }
    }
}