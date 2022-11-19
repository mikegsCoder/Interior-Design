using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteriorDesign.Infrastructure.Data.Models
{
    public abstract class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public Guid Id { get; set; }

        //[Column(TypeName = "date")]
        public DateTime CreatedOn { get; set; }

        //[Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }
    }
}
