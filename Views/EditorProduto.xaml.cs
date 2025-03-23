using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditorProduto : ContentPage
{
	public EditorProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e) //método para atualizar os dados do produto
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;
            //passando os atributos do objeto criado
            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                //atributo do tipo texto convertido para double
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            //acessando o método update e passando o objeto
            await App.Db.Update(p);
            //informando que foi salvo com sucesso
            await DisplayAlert("Sucesso!", "Registro Atualizado", "Ok");
            //retorna para a tela anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)//capitura exceção
        {
            //informa sobre a exceção
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}