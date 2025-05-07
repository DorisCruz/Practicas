using System.Diagnostics; 
using Microsoft.Maui.Controls;
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
            Routing.RegisterRoute("crearcontacto", typeof(CrearContacto));
            Routing.RegisterRoute("contactos", typeof(Contactos));

            Routing.RegisterRoute("contactos/detalles", typeof(DetalleContactoPage));

            Debug.WriteLine("Rutas registradas:");
            foreach (var route in Routing.GetRouteNames())
            {
                Debug.WriteLine($"- {route}");
            }
        }
    }
}