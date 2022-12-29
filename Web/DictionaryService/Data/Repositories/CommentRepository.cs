using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;
using Npgsql;
using System.Data.SqlTypes;

namespace DictionaryService.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string CS;
        public CommentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            CS = _configuration.GetConnectionString("PostGreConnection");
        }
        public void DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDTO> getFirstCommentOfPost(int postID)
        {
            throw new NotImplementedException();
        }

        public List<CommentDTO> GetPostComments(int postID)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            List<CommentDTO> comments = new List<CommentDTO>();
            try
            {
                cmd.CommandText = $"SELECT * FROM public.\"Comment\" WHERE \"PostID\" = @PostID;";
                cmd.Parameters.AddWithValue("PostID", postID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string Text = reader["Text"].ToString();
                    DateTime create = DateTime.Parse(reader["CreateDate"].ToString());
                    DateTime update = DateTime.Parse(reader["UpdateDate"].ToString());
                    int PostID = Convert.ToInt32(reader["PostID"]);
                    int ParentID = -1;
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        ParentID = Convert.ToInt32(reader["ParentID"]);
                    }
                    string AuthorID = reader["AuthorID"].ToString();
                    comments.Add(new CommentDTO(ID,Text,create,update,postID, ParentID,AuthorID));
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
            return comments;
        }

        public Task<CommentDTO> InsertCommentToPost(AddUpdateCommentBindingModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentDTO> InsertFirstCommentToPost(int PostID,AddUpdateCommentBindingModel model)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = $"INSERT INTO public.\"Comment\"" +
                    $"(\"Text\", \"CreateDate\", \"UpdateDate\", \"PostID\", \"AuthorID\")" +
                    $"VALUES(@Text, @CreateDate, @UpdateDate, @PostID, @AuthorID)";
                cmd.Parameters.AddWithValue("Text", model.Text);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("PostID", PostID);
                cmd.Parameters.AddWithValue("AuthorID", model.AuthorID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return new CommentDTO() { AuthorID = model.AuthorID,Text = model.Text };
        }

        public void UpdateComment(CommentDTO updatedComment)
        {
            throw new NotImplementedException();
        }
    }
}
