using System.ComponentModel.DataAnnotations;
using Tasks.Data.Base;
using Tasks.Data.ValueObjects;

namespace Tasks.Data.Entities
{
    public class Task : EntityBase
    {
        public Task()
        {

        }

        
        [Required(ErrorMessage ="O campo título é obrigatório!")]
        [StringLength(100, ErrorMessage ="Tamanho máximo de 100 caracteres.")]
        public string Titulo {get; set;}

        public TaskStatus Status { get; set;  }
        
    }
}
