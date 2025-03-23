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

        //todos os produtos da ObservableCollection irá para a lst_produtos
        lst_produtos.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {//exibe a lista de produtos
        try
        {
            List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    //Evento acionado após clicar no botão adicionar
    private void Adicionar_Clicked(object sender, EventArgs e)
    {
        //verifica se ocorre alguma exceção
        try
        {
            //redireciona para a página NovoProduto
            Navigation.PushAsync(new Views.NovoProduto());

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string q = e.NewTextValue;

            lista.Clear();

            List<Produto> tmp = await App.Db.Search(q);

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void Somar_Clicked(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total);

        string msg = $"O total é {soma:C}";
        DisplayAlert("Total dos Produtos", msg, "OK");
    }

    private async void Remover_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem selecionado = sender as MenuItem; //produto selecionado

            Produto p = selecionado.BindingContext as Produto;

            bool confirm = await DisplayAlert(
                "Tem Certeza?", $"Remover {p.Descricao}?", "Sim", "Não"); //solicita confirmação do usuário para excluir

            if (confirm)//remove o item selecionado do BD e ObservableCollection
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e) //edita produto
    {
        try
        {
            Produto p = e.SelectedItem as Produto; //produto selecionado

            Navigation.PushAsync(new Views.EditorProduto
            {
                BindingContext = p
            });
        }
        catch(Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}