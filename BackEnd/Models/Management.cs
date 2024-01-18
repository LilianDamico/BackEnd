using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Management
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Client { get; set; }

        [Required]
        [StringLength(50)]
        public string? BillOfLading { get; set; }

        [Required]
        [StringLength(50)]
        public string? ContainerType { get; set; }

        [Required]
        [StringLength(50)]
        public string? ContainerIdentity { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        [StringLength(50)]
        public string? MovementType { get; set; }

        [Required]
        [StringLength(50)]
        public string? TransportMode { get; set; }

        [Required]
        [StringLength(50)]
        public string? TransportIdentification { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
    }
}
