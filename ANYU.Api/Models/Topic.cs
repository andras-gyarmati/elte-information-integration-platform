using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("Topic")]
public class Topic
{
    [Key]
    public int TopicId { get; set; }

    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }

    [MaxLength(255)]
    public string Title { get; set; }

    [MaxLength(1000)]
    public string Content { get; set; }

    public int Likes { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<Comment> Comments { get; set; }
}
