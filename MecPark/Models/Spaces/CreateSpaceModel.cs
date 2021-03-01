using System.ComponentModel.DataAnnotations;

namespace Models.Spaces
{
    public class CreateSpaceModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string TotalCapacity { get; set; }
        [Required]
        public int GarageId { get; set; }
    }
}
