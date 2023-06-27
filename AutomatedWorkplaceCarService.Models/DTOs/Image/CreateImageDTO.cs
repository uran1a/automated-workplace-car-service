namespace AutomatedWorkplaceCarService.BLL.DTOs.Image
{
    public class CreateImageDTO
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int? ApplicationId { get; set; }
        public int? CarId { get; set; }
    }
}
