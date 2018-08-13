using System;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Data.Base
{
    public class EntityBase : IEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }

        public bool isDeleted => DeleteDateTime != null;
      
    }
}
