using PostsApplicationBackEnd.Entities;
using PostsApplicationBackEnd.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsApplicationBackEnd.Services
{
    public class PostService
    {
        private readonly PostRepository _postRepository;

        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await _postRepository.GetById(id);
            if (post == null)
            {
                throw new ArgumentException("Post was not found");
            }
            return post;
        }

        public async Task<int> CreateAsync(Post post)
        {
            return await _postRepository.CreateAsync(post);
        }

        public async Task UpdateAsync(Post post)
        {
            await _postRepository.UpdateAsync(post);
        }
        public async Task DeleteAsync(int id)
        {
            var post = await GetByIdAsync(id);
            await _postRepository.DeleteAsync(post);
        }
    }
}
