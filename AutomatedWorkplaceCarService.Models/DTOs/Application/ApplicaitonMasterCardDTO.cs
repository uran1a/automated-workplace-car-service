namespace AutomatedWorkplaceCarService.BLL.DTOs.Application
{
    public class ApplicaitonMasterCardDTO
    {
        public int Id { get; set; }
        public string StageName { get; set; }
        public string ServiceName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ClientFullName { get; set; }
        public byte[] ImageCarContent { get; set; }
    }
}
