
using System.ComponentModel.DataAnnotations;

namespace yearbook.Models;

public class Comment
{
    [Key]
    public int Id { get; set; }
    // inconsistent name. need to be changed

    [Required]
    public string Content { get; set; } = null!;

    [Required]
    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;

    [Required]
    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;

    public DateTime Modified { get; set; }

    public DateTime Created { get; set; }

}
