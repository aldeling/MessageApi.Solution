namespace MessageApi.Models
{
    public class Board
    {
        public int BoardId { get; set; }
        public string UserName { get; set; }
        public string UserMessage { get; set; }
        public DateTime Date { get; set; }
    }
}