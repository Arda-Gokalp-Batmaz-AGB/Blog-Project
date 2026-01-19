namespace DictionaryService.Models.BindingModel
{
    public class AddInteractionToComment
    {
        public int CommentID { get; set; }
        public string InteractionType { get; set; }
        public string UserID { get; set; }
    }
}
