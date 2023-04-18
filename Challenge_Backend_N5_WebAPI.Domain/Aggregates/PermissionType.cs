using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Backend_N5_WebAPI.Domain.Aggregates
{
    [Table("TipoPermisos", Schema = "dbo")]
    public class PermissionType : BaseEntity
    {
        [Required]
        [Column("Descripcion")]
        [StringLength(150)]
        public string Description { get; set; }

    }
}
