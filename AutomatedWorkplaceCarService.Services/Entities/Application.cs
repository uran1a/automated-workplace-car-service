using System.ComponentModel.DataAnnotations.Schema;

namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Application
    {
        public int Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartWork { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndWork { get; set; }
        public int Amount { get; set; }
        public string Descriptions { get; set; }
        public int StageId { get; set; }
        public Stage Stage { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
