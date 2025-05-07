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

        }
    }
}