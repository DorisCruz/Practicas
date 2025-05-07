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
            await Shell.Current.GoToAsync(nameof(Contactos));
        }

        private async void IrCrearContacto(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CrearContacto));
        }

        private async void IrConfiguracion(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Configuracion));
        }
    }
}