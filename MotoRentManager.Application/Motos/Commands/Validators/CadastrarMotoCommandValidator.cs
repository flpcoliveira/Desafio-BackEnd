using FluentValidation;
using MotoRentManager.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoRentManager.Application.Motos.Commands.Validators
{
    public class CadastrarMotoCommandValidator : AbstractValidator<CadastrarMotoCommand>
    {

        private readonly int _anoAtual = DateTime.Now.Year;
        private readonly int _anoMinimo = DateTime.Now.AddYears(-10).Year;

        public CadastrarMotoCommandValidator(IMotoRepository motoRepository)
        {
            RuleFor(x => x.Identificador)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("A identificação da moto é obrigatória")
                .MaximumLength(25)
                .WithMessage("A identificação da moto deve ter no máximo 25 caracteres");

            RuleFor(x => x.Modelo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O modelo da moto é obrigatório")
                .MaximumLength(100).WithMessage("O modelo da moto deve ter no máximo 100 caracteres");

            RuleFor(x => x.Ano)
                .Cascade(CascadeMode.Stop)
                .Must(ano =>
                {
                    return ano >= _anoMinimo && ano <= _anoAtual;
                })
                .WithMessage($"O ano da moto deve ser entre {_anoMinimo} e o ano atual");

            RuleFor(x => x.Placa)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("A placa da moto é obrigatória")
                .Matches("^[a-zA-Z]{3}[-][0-9]([0-9]|[a-j]|[A-J])[0-9]{2}$")
                .WithMessage("Placa inválida")
                .MustAsync((async (placa, cancellationToken) =>
                {
                    var exists = await motoRepository.VerificarExistenciaPorPlacaAsync(placa);
                    return !exists;
                }))
                .WithMessage("Placa já está sendo utilizada");
        }
    }
}
