﻿using Microsoft.EntityFrameworkCore;

namespace api;

public class CommentRepository: ICommentRepository
{
    private readonly ApplicationDBContext _context;
    public CommentRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }
}
