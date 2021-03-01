using System.ComponentModel.DataAnnotations;

namespace Models.Spaces
{
    public class UpdateSpaceModel
    {

        [Required]
        public string Code { get; set; }
        [Required]
        public string TotalCapacity { get; set; }
    }
}
