namespace ANYU.Api.Responses;

public class TopicResponse
{
    public int TopicId { get; set; }

    public int UserId { get; set; }
    
    public string User { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int Likes { get; set; }
}