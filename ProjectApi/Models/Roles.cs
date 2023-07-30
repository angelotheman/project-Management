namespace ProjectApi.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public RoleId role { get; set; }
    }

    public enum RoleId
    {
        CollegeOfScience,
        CollegeOfNaturalScience,
        CollegeOfHumanities,
        CollegeOfSocialSciences,
        CollegeOfHealth,
        CollegeOfArts
    }
}
