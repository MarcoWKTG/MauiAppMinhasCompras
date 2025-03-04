namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //new NavigationPage altera a página home, nova Home é ListaProdutos da pasta Views
            MainPage = new NavigationPage(new Views.ListaProduto());

        }
    }
}
