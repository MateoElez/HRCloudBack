using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models.BaseFolder
{
    public abstract class BaseDto
    {
        public BaseDto()
        {}

        public BaseDto(TEntity entity)
        {
            Id = entity.Id;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }
    }
}
