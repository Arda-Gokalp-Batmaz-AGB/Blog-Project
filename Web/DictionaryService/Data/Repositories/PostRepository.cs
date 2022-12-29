using DictionaryService.Data.Entities;
using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;
using System.Data.Common;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace DictionaryService.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string CS;
        public PostRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            CS = _configuration.GetConnectionString("PostGreConnection");
        }
        //private readonly string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public void DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostDTO> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostComments(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> InsertPost(AddUpdatePostBindingModel model)
        {
            //var cs = "Host=localhost;Username=postgres;Password=tabak34b;Database=Blog"

            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            //cmd.CommandText = @"INSERT INTO public.""Post""(""Title"", ""AuthorID"") VALUES ('Audi7','8080ff0e-e3dd-46a6-adb5-cdd331458e0c');";
            try
            {
                cmd.CommandText = $"INSERT INTO public.\"Post\"(\"Title\", \"AuthorID\") VALUES (@Title,@AuthorID);";
                cmd.Parameters.AddWithValue("Title", model.Title);
                cmd.Parameters.AddWithValue("AuthorID", model.AuthorID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return new Post() { Title = model.Title,AuthorID=model.AuthorID};
        }

        public void UpdatePost(Post updateApp)
        {
            throw new NotImplementedException();
        }
    }
}
