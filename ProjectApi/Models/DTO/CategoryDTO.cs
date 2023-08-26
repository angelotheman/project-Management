namespace ProjectApi.Models.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;
    }

    public class CategoryForManipulationDTO
    {
        public string CategoryName { get; set; } = null!;
    }

    public class CreateCategoryDTO : CategoryForManipulationDTO { }

    public class UpdateCategoryDTO : CategoryForManipulationDTO { }
}
