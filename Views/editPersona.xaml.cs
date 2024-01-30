namespace Ejercicio_1._3.Views;

public partial class editPersona : ContentPage
{
    private Models.Persona editedPerson;
    public int tipoActualizacion;

    public editPersona(Models.Persona selectedPerson, int tipo)
	{
		InitializeComponent();
        BindingContext = editedPerson = selectedPerson;
        tipoActualizacion = tipo;
	}

    private void btnRegresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private async void btnAgregar2_Clicked(object sender, EventArgs e)
    {
        // Guarda la informacion actualizada
        await App.PersonasController.storePersona(editedPerson);

        // Display an alert or navigate back
        await DisplayAlert("Persona Actualizada!", "La información de la persona ha sido actualizada!", "OK");

        if(tipoActualizacion == 0)
        {
            await Navigation.PopAsync();
        }
        else
        {
            await Navigation.PushAsync(new verTodos());
        }
        
    }
}