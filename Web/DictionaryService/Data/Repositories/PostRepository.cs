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
      //  private readonly ICommentRepository _commentRepository;
        public PostRepository(IConfiguration configuration)//,ICommentRepository commentRepository
        {
            _configuration = configuration;
            CS = _configuration.GetConnectionString("PostGreConnection");
            //_commentRepository = commentRepository;
        }
        //private readonly string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public void DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public int FindPostIdByTitle(string Title)
        {
            int ID = -1;
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            try
            {
                cmd.CommandText = $"SELECT \"ID\" FROM public.\"Post\" where \"Title\" = @Title;";
                cmd.Parameters.AddWithValue("Title", Title);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ID = Convert.ToInt32(reader["ID"]);
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                reader.Close();
            }
            return ID;

        }

        public List<PostDTO> GetAllPosts()
        {
            int ID = -1;
            string Title = "";
            string AuthorID = "";
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            List<PostDTO> posts = new List<PostDTO>();
            try
            {
                cmd.CommandText = $"SELECT * FROM public.\"Post\"";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ID = Convert.ToInt32(reader["ID"]);
                    Title = reader["Title"].ToString();
                    AuthorID = reader["AuthorID"].ToString();
                    posts.Add(new PostDTO(ID, Title, AuthorID, null, GetAuthorById(AuthorID)));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                reader.Close();
            }
            return posts;
        }
        public string GetAuthorById(string id)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            string AuthorName = "";
            try
            {
                cmd.CommandText = $"SELECT \"UserName\" FROM public.\"User\" WHERE \"Id\" = @Id;";
                cmd.Parameters.AddWithValue("Id", id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AuthorName = reader["UserName"].ToString();
                    // string ID = reader["Id"].ToString();
                    //string Text = reader["Text"].ToString();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                reader.Close();
            }
            return AuthorName;
        }

        public PostDTO GetPostById(int id)
        {
            PostDTO post = null;

            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            try
            {
                cmd.CommandText = $"SELECT * FROM public.\"Post\" where \"ID\" = @ID;";
                cmd.Parameters.AddWithValue("ID", id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    int ID = Convert.ToInt32(reader["ID"]);
                    string Title = reader["Title"].ToString();
                    string AuthorID = reader["AuthorID"].ToString();
                    post = new PostDTO(ID, Title, AuthorID, null, GetAuthorById(AuthorID));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                reader.Close();
            }
            return post;

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
            int ID = -1;
            //cmd.CommandText = @"INSERT INTO public.""Post""(""Title"", ""AuthorID"") VALUES ('Audi7','8080ff0e-e3dd-46a6-adb5-cdd331458e0c');";
            try
            {
                cmd.CommandText = $"INSERT INTO public.\"Post\"(\"Title\", \"AuthorID\") VALUES (@Title,@AuthorID);";
                cmd.Parameters.AddWithValue("Title", model.Title);
                cmd.Parameters.AddWithValue("AuthorID", model.AuthorID);
                cmd.ExecuteNonQuery();

                ID = FindPostIdByTitle(model.Title);

                //await _commentRepository.InsertFirstCommentToPost(ID, model.FirstComment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return new Post() { ID=ID,Title = model.Title,AuthorID=model.AuthorID};
        }

        public void UpdatePost(Post updateApp)
        {
            throw new NotImplementedException();
        }
    }
}
