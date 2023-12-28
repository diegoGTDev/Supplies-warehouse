namespace WebService.Models.Common
{
    public class User : iUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
    }
}