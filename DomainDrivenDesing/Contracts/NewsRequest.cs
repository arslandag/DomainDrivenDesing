using DomainDrivenDesing.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace DomainDrivenDesing.Api.Contracts
{
    public record NewsRequest(
        [Required][MaxLength(News.MAX_TITLE_LENGTH)] string Title,
        [Required] string TextData,
        IFormFile TitleImage
        );
}
