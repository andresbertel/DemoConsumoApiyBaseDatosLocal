using BaseLocalesG2.Models;

namespace BaseLocalesG2;

public partial class TodosView : ContentPage
{
	public TodosView(List<Persona> listado)
	{
		InitializeComponent();
        listadoPersonas.ItemsSource = listado;
    }
}