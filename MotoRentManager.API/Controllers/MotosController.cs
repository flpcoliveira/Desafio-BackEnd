using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MotoRentManager.API.Dtos;
using MotoRentManager.Application.Common.Interfaces;
using MotoRentManager.Application.Motos.Commands;
using System.Net;

namespace MotoRentManager.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotosController(ICommandHandler<CadastrarMotoCommand> command, ILogger<MotosController> logger) : ControllerBase
    {
        [HttpPost]
        [EndpointSummary("Cadastrar uma nova moto")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErroResponse), (int)HttpStatusCode.BadRequest)]        
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CadastrarMotoAsync([FromBody] CadastrarMotoRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Processando requisição para o cadastro de uma nova moto: {@Request}", request);

            try
            {
                await command.ExecuteAsync(request, cancellationToken);

                return Created();
            }
            catch (ValidationException ex)
            {
                logger.LogError(ex, "Dados inválidos para o cadastro de uma nova moto: {@Request}", request);
                return BadRequest(new ErroResponse());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro interno ao processar o cadastro de uma nova moto: {@Request}", request);
                return StatusCode(500, new ErroResponse("Ocorreu um erro interno no servidor"));
            }
            finally
            {
                logger.LogInformation("Fim do processamento da requisição para o cadastro de uma nova moto: {@Request}", request);
            }
        }
    }
}
