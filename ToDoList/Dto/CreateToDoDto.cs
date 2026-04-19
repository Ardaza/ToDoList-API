using System.ComponentModel.DataAnnotations;

namespace ToDoList.Dto
{
    public class CreateToDoDto
    {
        [Required(ErrorMessage = "Title wajib diisi")]
        [MaxLength(100, ErrorMessage = "Title maksimal 100 karakter")]
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
