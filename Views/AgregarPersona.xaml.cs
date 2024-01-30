using Microsoft.Maui.Graphics.Text;

namespace Ejercicio_1._3.Views;

public partial class AgregarPersona : ContentPage
{
    Controllers.PersonasController personDB;
    public AgregarPersona()
	{
		InitializeComponent();
        personDB = new Controllers.PersonasController();
	}

    public AgregarPersona(Controllers.PersonasController dbPath)
    {
        InitializeComponent();
        personDB = dbPath;
    }

    private async void btnAgregar2_Clicked(object sender, EventArgs e)
    {
        var person = new Models.Persona
        {
            Nombres = txtNombres.Text,
            Apellidos = txtApellidos.Text,
            Edad = Convert.ToInt32(txtEdad.Text),
            Correo = txtCorreo.Text,
            Direccion = txtDireccion.Text
        };

        try
        {
            if(personDB != null)
            {
                if (await personDB.storePersona(person) > 0)
                {
                    await DisplayAlert("Aviso", "Registro Ingresado con Exito!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Ocurrio un Error", "OK");
                }
            }
        }catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrio un Error: {ex.Message}", "OK");
        }

        
    }

    private void btnRegresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}