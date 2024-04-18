namespace api;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreateOn = commentModel.CreateOn,
            StockID = commentModel.StockID
        };
    }

    public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockID = stockId,
        };
    }
}
