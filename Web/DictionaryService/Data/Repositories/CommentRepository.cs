using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;
using Npgsql;
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

        public IEnumerable<CommentDTO> GetPostComments(int postID)
        {
            throw new NotImplementedException();
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
