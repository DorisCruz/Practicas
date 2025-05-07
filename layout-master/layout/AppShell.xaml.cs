namespace layout
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CrearContacto), typeof(CrearContacto));
            Routing.RegisterRoute(nameof(Contactos), typeof(Contactos));
            Routing.RegisterRoute(nameof(Configuracion), typeof(Configuracion));

        }
    }
}