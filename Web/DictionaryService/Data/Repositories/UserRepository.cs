using DictionaryService.Models.DTO;
using Npgsql;
using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;
namespace DictionaryService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string CS;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            CS = _configuration.GetConnectionString("PostGreConnection");
        }
        public UserDTO GetUserProfileByUserName(string username)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            UserDTO user = null;
            try
            {
                cmd.CommandText = $"SELECT * FROM public.\"User\" WHERE \"UserName\"=@UserName;";
                cmd.Parameters.AddWithValue("UserName", username);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string ID = reader["Id"].ToString();
                    string name = reader["Name"].ToString();
                    string surname = reader["SurName"].ToString();
                    string about = reader["About"].ToString();
                    List<string> followers = getFollowerList(ID);
                    List<string> followeds = getFollowedList(ID);
                    DateTime create = DateTime.Parse(reader["DateCreated"].ToString());
                    user = new UserDTO(ID, username, name, surname, about, followers, followeds, create);
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
            return user;
        }

        public int getFollowerCount(string userID)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            int followerCount = 0;
            try
            {
                cmd.CommandText = 
                    $"SELECT \"Id\",\"UserName\", follower_table.fCount AS \"FollowerCount\"" +
                    $"FROM (SELECT \"FollowedID\" AS fID,Count(*) AS fCount FROM \"Follow\" GROUP BY \"FollowedID\") follower_table" +
                    $"RIGHT JOIN \"User\" ON follower_table.fID = \"User\".\"Id\"" +
                    $"WHERE \"Id\" = @ID AND follower_table.fCount IS NOT NULL;";
                cmd.Parameters.AddWithValue("ID", userID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    followerCount = Convert.ToInt32(reader["FollowerCount"]);
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
            return followerCount;
        }

        public List<string> getFollowerList(string userID)
        {
            List<string> followers = new List<string>();
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            try
            {
                cmd.CommandText =
                    $"SELECT \"UserName\" FROM public.\"Follow\"" +
                    $"JOIN \"User\" ON \"Id\" = \"FollowerID\"" +
                    $"WHERE \"FollowedID\" = @FollowedID";
                cmd.Parameters.AddWithValue("FollowedID", userID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string uName = reader["UserName"].ToString();
                    followers.Add(uName);
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

            return followers;
        }
        public List<string> getFollowedList(string userID)
        {
            List<string> followeds = new List<string>();
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            try
            {
                cmd.CommandText =
                    $"SELECT \"UserName\" FROM public.\"Follow\"" +
                    $"JOIN \"User\" ON \"Id\" = \"FollowedID\"" +
                    $"WHERE \"FollowerID\" = @FollowerID";
                cmd.Parameters.AddWithValue("FollowerID", userID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string uName = reader["UserName"].ToString();
                    followeds.Add(uName);
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

            return followeds;
        }
        public int getFollowedCount(string userID)
        {
            return 0;
        }

        public UserDTO FollowUser(string followerID, string followedID)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText =
                    $"INSERT INTO public.\"Follow\"(\"FollowerID\", \"FollowedID\", \"Date\")" +
                    $"VALUES (@FollowerID, @FollowedID, @Date);";
                cmd.Parameters.AddWithValue("FollowerID", followerID);
                cmd.Parameters.AddWithValue("FollowedID", followedID);
                cmd.Parameters.AddWithValue("Date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return new UserDTO() { Id = followedID};
        }


        public string findIdByUserName(string username)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            string ID = "";
            try
            {
                cmd.CommandText =
                    $"SELECT \"Id\" FROM public.\"User\" WHERE \"UserName\" = @UserName;";
                cmd.Parameters.AddWithValue("UserName", username);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ID = reader["Id"].ToString();
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
            return ID;
        }

        public bool FollowExists(string followerID, string followedID)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            NpgsqlDataReader reader = null;
            string ID = "";
            try
            {
                cmd.CommandText =
                    $"SELECT \"FollowerID\", \"FollowedID\", \"Date\" FROM public.\"Follow\"" +
                    $"Where \"FollowerID\" = @FollowerID AND \"FollowedID\" = @FollowedID;";
                cmd.Parameters.AddWithValue("FollowerID", followerID);
                cmd.Parameters.AddWithValue("FollowedID", followedID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return true;
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

        public UserDTO UnFollowUser(string followerID, string followedID)
        {
            using var con = new NpgsqlConnection(CS);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText =
                    $"DELETE FROM public.\"Follow\" WHERE \"FollowerID\" = @FollowerID AND \"FollowedID\" = @FollowedID;";
                cmd.Parameters.AddWithValue("FollowerID", followerID);
                cmd.Parameters.AddWithValue("FollowedID", followedID);
                cmd.Parameters.AddWithValue("Date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return new UserDTO() { Id = followedID};
        }
    }
}
