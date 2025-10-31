using MotoRentManager.Application.Motos.Commands;

namespace MotoRentManager.API.Dtos
{
    public class CadastrarMotoRequest
    {
        public string Identificador { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;

        public static implicit operator CadastrarMotoCommand(CadastrarMotoRequest request)
        {
            return new CadastrarMotoCommand(request.Identificador, request.Modelo, request.Ano, request.Placa);            
        }

        public static implicit operator CadastrarMotoRequest(CadastrarMotoCommand command)
        {
            return new CadastrarMotoRequest
            {
                Identificador = command.Identificador,
                Ano = command.Ano,
                Modelo = command.Modelo,
                Placa = command.Placa
            };
        }
    }
}
