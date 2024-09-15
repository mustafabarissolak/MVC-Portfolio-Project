namespace Portfolio_MVC.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool Status { get; set; } = false;
    }
}
