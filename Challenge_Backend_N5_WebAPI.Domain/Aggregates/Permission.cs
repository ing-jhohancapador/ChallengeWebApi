using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Backend_N5_WebAPI.Domain.Aggregates
{
    [Table("Permisos", Schema = "dbo")]
    public class Permission : BaseEntity
    {
        [Required]
        [Column("NombreEmpleado")]
        [StringLength(150)]
        public string? FirstName { get; set; }

        [Required]
        [Column("ApellidoEmpleado")]
        [StringLength(150)]
        public string? LastName { get; set; }

        [Required]
        [Column("FechaPermiso", TypeName = "datetime")]
        public DateTime DateOfPermission { get; set; }

        [Required]
        [Column("TipoPermiso")]
        public long TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual PermissionType? Type { get; set; }


    }
}
