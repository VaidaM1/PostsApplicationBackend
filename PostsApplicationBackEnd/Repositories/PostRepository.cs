using Microsoft.EntityFrameworkCore;
using PostsApplicationBackEnd.Data;
using PostsApplicationBackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsApplicationBackEnd.Repositories
{
    public class PostRepository
    {
        private readonly DataContext _dataContext;

        public PostRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await _dataContext.Posts.FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<int> CreateAsync(Post post)
        {
            _dataContext.Add(post);
            await _dataContext.SaveChangesAsync();
            return post.Id;
        }

        public async Task UpdateAsync(Post post)
        {
            _dataContext.Update(post);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Post post)
        {
            _dataContext.Remove(post);
            await _dataContext.SaveChangesAsync();
        }
    }
}
