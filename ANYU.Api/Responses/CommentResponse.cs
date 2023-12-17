namespace ANYU.Api.Responses;

public class CommentResponse
{
    public int CommentId { get; set; }

    public int UserId { get; set; }
    
    public string User { get; set; }

    public int TopicId { get; set; }

    public string Topic { get; set; }
    
    public string Content { get; set; }

    public int Likes { get; set; }

}