using Ejercicio_1._3.Views;

namespace Ejercicio_1._3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPersona());
        }

        private void btnVerPersonas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new verTodos());
        }
    }

}
