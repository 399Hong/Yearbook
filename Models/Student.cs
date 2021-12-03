using System.ComponentModel.DataAnnotations;

namespace yearbook.Models;

public class Student
{
    
    [Key]    
    public int id {get; set;}

    [Required]
    public string name {get; set;}
    [Required]
    public string Github {get; set;}

    public string ?imageURI {get; set;}

}