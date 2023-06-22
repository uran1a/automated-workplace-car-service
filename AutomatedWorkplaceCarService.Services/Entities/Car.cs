namespace AutomatedWorkplaceCarService.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int YearOfRelease { get; set; }
        public int EnginePower { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int TransmissionId { get; set; }
        public Transmission Transmission { get; set; }
        public int OwnerId { get; set; }
        public Client Owner { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<Image> Images { get; set; }

    }
}
