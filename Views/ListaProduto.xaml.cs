using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{	
	
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>(); 

	public ListaProduto()
	{
		InitializeComponent();

		//todos os produtos da ObservableCollection ir� para a lst_produtos
		lst_produtos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {//exibe a lista de produtos
        List<Produto> tmp = await App.Db.GetAll();
		tmp.ForEach(i => lista.Add(i));
    }

    //Evento acionado ap�s clicar no bot�o adicionar
    private void Adicionar_Clicked(object sender, EventArgs e)
    {
		//verifica se ocorre alguma exce��o
		try
		{
			//redireciona para a p�gina NovoProduto
			Navigation.PushAsync(new Views.NovoProduto());

		} catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		string q = e.NewTextValue;

		lista.Clear();

		List<Produto> tmp = await App.Db.Search(q);

		tmp.ForEach(i => lista.Add(i));
    }

    private void Somar_Clicked(object sender, EventArgs e)
    {
		double soma = lista.Sum(i => i.Total);

		string msg = $"O total � {soma:C}";
		DisplayAlert("Total dos Produtos", msg, "OK");
    }

    private void Remover_Clicked(object sender, EventArgs e)
    {

    }
}