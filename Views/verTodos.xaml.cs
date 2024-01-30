using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace Ejercicio_1._3.Views
{
    public partial class verTodos : ContentPage
    {
        private Controllers.PersonasController personDb;

        public verTodos()
        {
            InitializeComponent();
            personDb = new Controllers.PersonasController();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Obtiene la lista de personas de la base de datos
            List<Models.Persona> persons = await personDb.getListPersons();

            // Coloca la lista en el collection view
            collectionView.ItemsSource = persons;
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedPerson = button?.BindingContext as Models.Persona;

            if (selectedPerson != null)
            {
                var confirmed = await DisplayAlert("Borrar Persona", $"Esta seguro que desea borrar la persona: {selectedPerson.Nombres}?", "Si", "No");

                if (confirmed)
                {
                    // Borra la persona seleccionada
                    var result = await App.PersonasController.deletePerson(selectedPerson.Id);

                    if (result > 0)
                    {
                        await DisplayAlert("Persona Borrada", $"{selectedPerson.Nombres} ha sido borrado/a exitosamente!", "OK");

                        // Actualiza la lista despues de borrar
                        List<Models.Persona> persons = await App.PersonasController.getListPersons();
                        collectionView.ItemsSource = persons;
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo borrar la persona", "OK");
                    }
                }
            }
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedPerson = button?.BindingContext as Models.Persona;

            if (selectedPerson != null)
            {
                Navigation.PushAsync(new editPersona(selectedPerson, 0));
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            var label = sender as Label;
            var selectedPerson = label?.BindingContext as Models.Persona;

            if (selectedPerson != null)
            {
                Navigation.PushAsync(new verPersona(selectedPerson));
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            var label = sender as Label;
            var selectedPerson = label?.BindingContext as Models.Persona;

            if (selectedPerson != null)
            {
                Navigation.PushAsync(new verPersona(selectedPerson));
            }
        }
    }
}
