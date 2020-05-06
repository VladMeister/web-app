
namespace ProductTracking.MVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string RoleName { get; set; }
    }
}
