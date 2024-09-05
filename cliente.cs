namespace Cliente_space
{
    public class Cliente
    {
        string? nombre;
        string? direccion;
        string? telefono;
        string datosReferenciaDireccion;

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

        public Cliente(string nombre, string dir, string? tel, string drd)
        {
            Nombre = nombre;
            Direccion = dir;
            Telefono = tel;
            DatosReferenciaDireccion = drd;
        }
    }
}