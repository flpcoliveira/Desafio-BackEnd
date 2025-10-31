namespace MotoRentManager.Domain.Entities
{
    public class Moto
    {
        private Moto(string identificador, int ano, string modelo, string placa)
        {
            Id = Guid.NewGuid();
            Identificador = identificador;
            Ano = ano;
            Modelo = modelo;
            Placa = placa;
        }
        public Guid Id { get; private set; }
        public string Identificador { get; private set; }
        public int Ano { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }

        public void AtualizarPlaca(string placa)
        {
            Placa = placa;
        }

        public static Moto Criar(string identificacao, int ano, string modelo, string placa)
        {
            var moto = new Moto(identificacao, ano, modelo,placa);
            return moto;
        }
    }
}
