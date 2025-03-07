using MauiAppMinhasCompras.Models;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

	//Evento clicked acionado ap�s clicar no bot�o Salvar
    private async void Salvar_Novo_Produto_Clicked(object sender, EventArgs e)
    {
		try
		{
			//passando os atributos do objeto criado
			Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				//atributo do tipo texto convertido para double
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};
			//acessando o m�todo insert e passando o objeto
			await App.Db.Insert(p);
			//informando que foi salvo com sucesso
			await DisplayAlert("Sucesso!", "Registro Inserido", "Ok");

		} catch(Exception ex)//capitura exce��o
		{
			//informa sobre a exce��o
			await DisplayAlert("Ops", ex.Message, "OK");
		}
    }
}