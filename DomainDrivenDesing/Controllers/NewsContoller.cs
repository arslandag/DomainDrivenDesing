using DomainDrivenDesing.Api.Contracts;
using DomainDrivenDesing.Application.Services;
using DomainDrivenDesing.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesing.Api.Controllers
{
    [ApiController]
    [Route("[contoller]")]
    public class NewsContoller : ControllerBase
    {
        private readonly string _staticFilePath =
            Path.Combine(Directory.GetCurrentDirectory(), "StatucFile/Image");
        private readonly NewsService _newsService;
        private readonly ImageService _imageService;

        public NewsContoller(NewsService newsService, ImageService imageService)
        {
            _newsService = newsService;
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNews(NewsRequest request)
        {
            var imageRezult = await _imageService.CreateImage(request.TitleImage, _staticFilePath);

            if (imageRezult.IsFailure)
            {
                return BadRequest(imageRezult.Error);
            }

            var news = News.Create(Guid.NewGuid(), request.Title, request.TextData, imageRezult.Value);

            if (news.IsFailure)
            {
                return BadRequest(news.Error);
            }

            return Ok(news);
        }

        [HttpPost]
        public async Task<ActionResult> CountViews()
        {
            await _newsService.CountView();

            return Ok();
        }
    }
}