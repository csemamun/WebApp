namespace WebApp.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
