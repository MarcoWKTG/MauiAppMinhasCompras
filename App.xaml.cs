using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;//campo privado

        public static SQLiteDatabaseHelper Db//propriedade
        {
            get
            {//verifica se o BD existe, caso não exita é criado um
                if(_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    _db = new SQLiteDatabaseHelper(path);
                }
                //retorna o diretório do BD
                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //new NavigationPage altera a página home, nova Home é ListaProdutos da pasta Views
            MainPage = new NavigationPage(new Views.ListaProduto());

        }
    }
}
