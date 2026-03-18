using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly IDataRepository<ProductCommentEntity> _commentRepository;

        public CommentController(IDataRepository<ProductCommentEntity> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [Route("/comment")]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [Route("/comment/{commentId:int}/approve")]
        [HttpGet]
        public async Task<IActionResult> Approve(int commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            if (comment == null)
                return NotFound();

            comment.IsConfirmed = true;

            _commentRepository.Update(comment);
            await _commentRepository.SaveAsync();

            TempData["Success"] = $"Yorum #{commentId} onaylandı.";
            return RedirectToAction("List", "Comment");
        }
    }
}