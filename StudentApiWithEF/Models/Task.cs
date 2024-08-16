using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApiWithEF.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required(ErrorMessage ="Task Name is mandatory")]
        [MinLength(10, ErrorMessage ="Min 10 characters are needed")]
        [MaxLength(20, ErrorMessage ="Max 20 charc")]
        public string TaskName { get; set; }
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string AssignedBy { get; set; }

        [Required]
        [Range(10,30)]
        public int Duration { get; set; }

        //add in parent table
        public virtual List<SubTask>? SubTasks { get; set; }

    }
}
