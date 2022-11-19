using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteriorDesign.Infrastructure.Data.Models
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        //[Column(TypeName = "date")]
        public DateTime? DeletedOn { get; set; }
    }
}
