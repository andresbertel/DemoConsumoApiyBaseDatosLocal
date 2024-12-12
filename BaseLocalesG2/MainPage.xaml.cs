using BaseLocalesG2.Models;
using System.Collections.Generic;

namespace BaseLocalesG2
{
    public partial class MainPage : ContentPage
    {
        
        private ApiService _apiService;

        public MainPage()
        {
            InitializeComponent();
            _apiService = new ApiService("https://a0ca-190-0-245-162.ngrok-free.app");
        }

        private async void Insertar(object sender, EventArgs e)
        {
            Persona persona = LlenarPersona();

           //int result = await App.PersonaDataBase.GuardarPersona(persona);
            int result = await _apiService.PostAsync<Persona,int>("api/Personas", persona);

            if (result > 0)
            {
                await DisplayAlert("Insert", "Exitoo", "Ok");
            }

            Limpiar();
        }



        private async void Actualizar(object sender, EventArgs e)
        {
            Persona persona = LlenarPersona(true);
            //int result = await App.PersonaDataBase.ActualizarPersona(persona);
           int result = await _apiService.PutAsync<Persona,int>($"api/Personas/{persona.Id}",persona);
            if (result > 0)
            {
                await DisplayAlert("Update", "Exitoo", "Ok");
            }
            Limpiar();
        }

        private async void Eliminar(object sender, EventArgs e)
        {
            Persona persona = await Buscar();
            int result = 0;

            if (persona != null)
            {
               // result = await App.PersonaDataBase.DeletePersona(persona);
                result = await _apiService.DeleteAsync($"api/Personas/{persona.Id}");
            }


            if (result > 0)
            {
                await DisplayAlert("Delete", "Exitoo", "Ok");
            }

            Limpiar();

        }

        private async void BuscarUno(object sender, EventArgs e)
        {
            Persona persona = await Buscar();

            if (persona != null)
            {
                nombre.Text = persona.Nombres;
                apellidos.Text = persona.Apellidos;
            }
            else
            {
                await DisplayAlert("Buscar", "Persona no encontrada", "Cerrar");
            }
        }
        private async void BucarTodos(object sender, EventArgs e)
        {
           // List<Persona> listadoPersonas = await App.PersonaDataBase.GetPersonas();
            List<Persona> listadoPersonas = await _apiService.GetAsync<List<Persona>>("api/Personas");
            TodosView todosView = new TodosView(listadoPersonas);

            await Navigation.PushAsync(todosView);

        }

        private void Limpiar()
        {
            apellidos.Text = "";
            nombre.Text = "";
        }

        private Persona LlenarPersona(bool isUpdate = false)
        {
            Persona persona = new Persona();

            if (isUpdate)
            {
                persona.Id = Convert.ToInt32(id.Text);
            }

            persona.Apellidos = apellidos.Text;
            persona.Nombres = nombre.Text;
            return persona;
        }

        private async Task<Persona> Buscar()
        {
            //var personaBuscarda =
              //     await App.PersonaDataBase.GetOnePersonas(Convert.ToInt32(id.Text));

            var personaBuscarda =
                await _apiService.GetAsync<Persona>($"api/Personas/{id.Text}");

            return personaBuscarda;
        }

    }

}
