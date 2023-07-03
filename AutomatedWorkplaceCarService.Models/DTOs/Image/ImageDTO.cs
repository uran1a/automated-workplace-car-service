namespace AutomatedWorkplaceCarService.BLL.DTOs.Image
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int CarId { get; set; }
    }
}
