using AutomatedWorkplaceCarService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPostsAsync(int postId);
    }
}
