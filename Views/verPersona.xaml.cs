namespace Ejercicio_1._3.Views;

public partial class verPersona : ContentPage
{
	public verPersona(Models.Persona selectedPerson)
	{
		InitializeComponent();
		BindingContext = selectedPerson;
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var selectedPerson = button?.BindingContext as Models.Persona;

        if (selectedPerson != null)
        {
            Navigation.PushAsync(new editPersona(selectedPerson, 1));
        }
    }

    private void btnRegresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}