namespace DictionaryService.Models.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(string Id, string UserName, string Name, string Surname, 
            string About, List<string> followers, List<string> followeds, DateTime DateCreated)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Name = Name;
            this.Surname = Surname;
            this.About = About;
            this.followers = followers;
            this.followeds = followeds;
            this.DateCreated = DateCreated;
        }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public List<string> followers { get; set; }
        public List<string> followeds { get; set; }
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        // public string Password { get; set; }

    }
}
