namespace AutomatedWorkplaceCarService.WEB.Models
{
    public class EmployeeModel : UserModel
    {
        public int? PostId { get; set; }
        public string? PostName { get; set; }
    }
}
