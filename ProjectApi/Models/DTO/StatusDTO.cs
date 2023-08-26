namespace ProjectApi.Models.DTO
{
    public class StatusDTO
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; } = null!;
    }

    public class ManipulateStatusDTO
    {
        
    }

    public class CreateStatusDTO : ManipulateStatusDTO { }

    public class UpdateStatusDTO : ManipulateStatusDTO { }
}
