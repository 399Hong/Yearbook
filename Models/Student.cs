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

    public ICollection <Project>  Projects { get; set;} = new List<Project>();

    public ICollection <Comment> Comments { get; set;} = new List<Comment>();

}