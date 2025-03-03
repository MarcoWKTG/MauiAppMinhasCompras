using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper 
    {
        // declaração da variável _connection que armazena a conexão com o BD
        readonly SQLiteAsyncConnection _connection; 

        //construtor que é chamado quando um objeto é ciado
        //"path" representa o caminho onde o BD está armazenado ou será criado
        public SQLiteDatabaseHelper(string path) 
        {
            //cria a conexão com o BD informando o caminho "path"
            _connection = new SQLiteAsyncConnection(path); 
            
            //cria a tabela Produto
            _connection.CreateTableAsync<Produto>().Wait();
        }

        //método para inserir um novo produto no BD
        //p é um objeto do tipo Produto
        public Task<int> Insert(Produto p) 
        {
            //retorna a quantidade de linhas afetadas
            return _connection.InsertAsync(p);
        }

        //metodo para atualizar dados de um produto existente
        public Task<List<Produto>> Update(Produto p) 
        {
            //declara uma string que contém a consulta SQL para atualizar o produto
            string sql = "UPDATE Produto SET Descrição=?, Quantidade=?, Preço=? WHERE Id=?";

            //realiza a execução da consulta de forma assíncrona
            return _connection.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        //metodo que exclui um produto do BD
        public Task<int> Delete(int id) 
        {
            //o metodo DeleteAsync é usado para remover a linha correspindente ao produto
            return _connection.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        //metodo que retorna todos os itens da tabela
        public Task<List<Produto>> GetAll() 
        {
            //retorna todos os produtos da tabela Produlo de forma assíncrona
            return _connection.Table<Produto>().ToListAsync();
        }

        //metodo de buscar produtos no BD
        public Task<List<Produto>> Search(string q) 
        {
            //declaração de uma consulta SQL que busca produtos
            string sql = "SELECT * FROM Produto WHERE descrição LIKE '%" + q +"%'";

            //executa a consulta e retorna uma lista de produtos
            return _connection.QueryAsync<Produto>(sql);
        }
    }
}
