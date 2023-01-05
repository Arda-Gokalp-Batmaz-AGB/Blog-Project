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
                    string PostTitle = this.findCommentPostTitleByPostID(PostID);
                    int ParentID = -1;
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        ParentID = Convert.ToInt32(reader["ParentID"]);
                    }
                    string AuthorID = reader["AuthorID"].ToString();
                    int likeCount = GetInteractionCount("like", ID);
                    int dislikeCount = GetInteractionCount("dislike", ID);
                    comments.Add(new CommentDTO(ID,Text,create,update,postID, 
                        ParentID,AuthorID, GetAuthorById(AuthorID), likeCount,dislikeCount, PostTitle));
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

        private int GetInteractionCount(string type,int commentID)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            List<CommentDTO> comments = new List<CommentDTO>();
            int count = 0;
            try
            {
                cmd.CommandText = $"SELECT \"ID\",Count(*) AS interactionCount FROM \"Comment\" " +
                    $"LEFT JOIN \"Interact\" ON \"ID\" = \"CommentID\"" +
                    $"WHERE \"Type\" = @Type GROUP BY \"ID\" HAVING \"ID\" = @id";
                cmd.Parameters.AddWithValue("id", commentID);
                cmd.Parameters.AddWithValue("Type", type);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader["interactionCount"]);
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
            return count;
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

        public CommentDTO InteractWithComment(AddInteractionToComment model)
        {
            checkLastInteractionRemoveIfExists(model);
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = 
                $"INSERT INTO public.\"Interact\"(\"CommentID\", \"UserID\", \"Type\", \"Date\")" +
	            $"VALUES(@CommentID, @UserID, @Type, @CreateDate); ";
                cmd.Parameters.AddWithValue("CommentID", model.CommentID);
                cmd.Parameters.AddWithValue("UserID", model.UserID);
                cmd.Parameters.AddWithValue("Type", model.InteractionType);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return new CommentDTO() { ID = model.CommentID,
                LikeCount = GetInteractionCount("like",model.CommentID),
            DislikeCount = GetInteractionCount("dislike",model.CommentID)};//get interaction count
        }

        private void checkLastInteractionRemoveIfExists(AddInteractionToComment model)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            if (checkInteraction(model) == false)
                return;
            try
            {
                cmd.CommandText =
                $"DELETE FROM public.\"Interact\"" +
                $"WHERE \"CommentID\" = @CommentID AND \"UserID\" = @UserID; ";
                cmd.Parameters.AddWithValue("CommentID", model.CommentID);
                cmd.Parameters.AddWithValue("UserID", model.UserID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        private bool checkInteraction(AddInteractionToComment model)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            string AuthorName = "";
            try
            {
                cmd.CommandText = $"SELECT * FROM public.\"Interact\"" +
                    $"WHERE \"CommentID\" = @CommentID AND \"UserID\" = @UserID;";
                cmd.Parameters.AddWithValue("CommentID", model.CommentID);
                cmd.Parameters.AddWithValue("UserID", model.UserID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return true;
                    // string ID = reader["Id"].ToString();
                    //string Text = reader["Text"].ToString();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                reader.Close();
            }
            return false;
        }
        public void UpdateComment(CommentDTO updatedComment)
        {
            throw new NotImplementedException();
        }

        public List<CommentDTO> getUserComments(string userID)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            List<CommentDTO> comments = new List<CommentDTO>();
            int count = 0;
            try
            {
                cmd.CommandText = $"SELECT * FROM public.\"Comment\"" +
                    $"WHERE \"AuthorID\" = @AuthorID ORDER BY \"CreateDate\" DESC LIMIT 5;";
                cmd.Parameters.AddWithValue("AuthorID", userID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    string Text = reader["Text"].ToString();
                    DateTime create = DateTime.Parse(reader["CreateDate"].ToString());
                    DateTime update = DateTime.Parse(reader["UpdateDate"].ToString());
                    int PostID = Convert.ToInt32(reader["PostID"]);
                    string PostTitle = this.findCommentPostTitleByPostID(PostID);
                    int ParentID = -1;
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        ParentID = Convert.ToInt32(reader["ParentID"]);
                    }
                    string AuthorID = reader["AuthorID"].ToString();
                    int likeCount = GetInteractionCount("like", ID);
                    int dislikeCount = GetInteractionCount("dislike", ID);
                    comments.Add(new CommentDTO(ID, Text, create, update, PostID,
                        ParentID, AuthorID, GetAuthorById(AuthorID), likeCount, dislikeCount,PostTitle));
                }
            }
            catch (Exception ex)
            {
                return comments;
            }
            finally
            {
                reader.Close();
            }
            return comments;
        }

        public string findCommentPostTitleByPostID(int postID)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            string title = "";
            try
            {
                cmd.CommandText = $"SELECT \"Title\" FROM public.\"Post\" WHERE \"ID\" = @ID;";
                cmd.Parameters.AddWithValue("ID", postID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    title = reader["Title"].ToString();
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
            return title;
        }

        public CommentDTO createNewCommentOnPost(int postID, string authorID, int parentID, string text)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            int newID = -1;
            try
            {
                cmd.CommandText = $"INSERT INTO public.\"Comment\"" +
                    $"(\"Text\", \"CreateDate\", \"UpdateDate\", \"PostID\", \"AuthorID\",\"ParentID\")" +
                    $"VALUES(@Text, @CreateDate, @UpdateDate, @PostID, @AuthorID,@ParentID) RETURNING \"ID\"";
                cmd.Parameters.AddWithValue("Text", text);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("PostID", postID);
                cmd.Parameters.AddWithValue("AuthorID", authorID);
                cmd.Parameters.AddWithValue("ParentID", parentID);
                newID = Convert.ToInt32(cmd.ExecuteScalar());

                //int identity = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return new CommentDTO(newID, text, DateTime.Now, DateTime.Now,
            postID, parentID, authorID, GetAuthorById(authorID), 0,0, this.findCommentPostTitleByPostID(postID));
        }
    }
}
