namespace DictionaryService.Models.DTO
{
    public class UserDTO
    {
        public UserDTO(string Id, string UserName, string Name, string Surname, 
            string About, int followerCount, int followedCount, DateTime DateCreated)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Name = Name;
            this.Surname = Surname;
            this.About = About;
            this.followerCount = followerCount;
            this.followedCount = followedCount;
            this.DateCreated = DateCreated;
        }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public int followerCount { get; set; }
        public int followedCount { get; set; }
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        // public string Password { get; set; }

    }
}
