namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	public ListaProduto()
	{
		InitializeComponent();
	}

	//Evento acionado após clicar no botão adicionar
    private void Adicionar_Clicked(object sender, EventArgs e)
    {
		//verifica se ocorre alguma exceção
		try
		{
			//redireciona para a página NovoProduto
			Navigation.PushAsync(new Views.NovoProduto());

		} catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
    }
}