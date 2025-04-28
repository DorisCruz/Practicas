namespace layout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void IrListaContactos(object sender, EventArgs e)
        {
            // Navega a la página de lista de contactos
            await Navigation.PushAsync(new Contactos());
        }

        private async void IrCrearContacto(object sender, EventArgs e)
        {
            // Navega a la página de crear contacto
            await Navigation.PushAsync(new CrearContacto());
        }

        private async void IrConfiguracion(object sender, EventArgs e)
        {
            // Navega a la página de configuración
            await Navigation.PushAsync(new Configuracion());
        }
    }
}