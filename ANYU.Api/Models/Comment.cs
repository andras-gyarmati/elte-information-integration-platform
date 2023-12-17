using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("Comment")]
public class Comment
{
    [Key]
    public int CommentId { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    public int TopicId { get; set; }

    [ForeignKey("TopicId")]
    public Topic Topic { get; set; }

    [MaxLength(1000)]
    public string Content { get; set; }

    public int Likes { get; set; }

    public DateTime CreatedAt { get; set; }

}
