namespace Cadete_space
{
    public class Cadete
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string telefono;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public double JornalACobrar()
        {
            Random rand = new Random();
            double jornal = rand.NextDouble() * 10000 + 500;

            return jornal;
        }

        public void TomarPedido(Pedido pedido)
        {

        }

    }
}