namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	public ListaProduto()
	{
		InitializeComponent();
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
}