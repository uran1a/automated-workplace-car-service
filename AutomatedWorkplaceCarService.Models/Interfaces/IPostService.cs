using AutomatedWorkplaceCarService.BLL.DTOs;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
	public interface IPostService
	{
		Task<List<PostDTO>> GetAllPostsAsync(int postId);
	}
}
