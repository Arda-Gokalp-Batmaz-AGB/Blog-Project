namespace AuthorizationService.Models.DTO
{
    public class UserDTO
    {
        public UserDTO(string UserName,string Email,DateTime DateCreated)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.DateCreated = DateCreated;
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public string Token { get; set; }
        // public string Password { get; set; }

    }
}
