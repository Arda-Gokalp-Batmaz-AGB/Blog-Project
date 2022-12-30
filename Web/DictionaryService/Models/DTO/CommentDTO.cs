namespace DictionaryService.Models.DTO
{
    public class CommentDTO
    {
        public CommentDTO(int ID, string Text, DateTime DateCreated, DateTime DateModified,
            int PostID,int ParentID,string AuthorID,string AuthorName, int LikeCount, int DislikeCount)
        {
            this.ID = ID;
            this.Text = Text;
            this.DateCreated = DateCreated;
            this.DateModified = DateModified;
            this.PostID = PostID;
            this.ParentID = ParentID;
            this.AuthorID = AuthorID;
            this.AuthorName = AuthorName;
            this.LikeCount = LikeCount;
            this.DislikeCount = DislikeCount;
        }
        public CommentDTO() { }
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int PostID { get; set; }
        public int ParentID { get; set; }
        public string AuthorID { get; set; }
        public string? AuthorName { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}
