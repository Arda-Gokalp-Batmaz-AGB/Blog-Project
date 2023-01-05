namespace DictionaryService.Data.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int PostID { get; set; }
        public int ParentID { get; set; }
        public string AuthorID { get; set; }
    }
}
