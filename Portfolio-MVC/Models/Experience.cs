namespace Portfolio_MVC.Models
{
	public class Experience
	{
		public int Id { get; set; }
		public string DateTime { get; set; }
		public string CompanyName { get; set; }
		public string? Department { get; set; } = null;
		public string Project { get; set; }
		public string Description { get; set; }
	}
}
