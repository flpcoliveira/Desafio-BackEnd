namespace MotoRentManager.API.Dtos
{
    public class ErroResponse
    {
        public ErroResponse(string? mensagem = default)
        {
            if(!string.IsNullOrWhiteSpace(mensagem))
                Mensagem = mensagem;            
        }

        public string Mensagem { get; set; } = "Dados inválidos";
    }
}
