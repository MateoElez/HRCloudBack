using ProjectAPI.Models.BaseFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public abstract class TEntity
    {
        public TEntity() { }

        public TEntity(BaseDto dto)
        {
            Id = dto.Id;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public virtual int Id { get; set; }

    }
}
