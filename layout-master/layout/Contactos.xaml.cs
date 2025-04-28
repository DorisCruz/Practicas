namespace layout
{
    public partial class Contactos : ContentPage
    {
        public Contactos()
        {
            InitializeComponent();
            var contactos = new List<Contacto>
            {
                new Contacto { Nombre = "Doris", Telefono = "6461317126", Correo = "bdb@gmail.com" },
                new Contacto { Nombre = "Fernanda", Telefono = "64655798", Correo = "fern@gmail.com" }
            };

            ContactosCollectionView.ItemsSource = contactos;
        }
    }

    public class Contacto
    {
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
    }
}