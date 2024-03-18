using DomainDrivenDesing.Core.Models;

namespace DomainDrivenDesing.Application.Services
{
    public class NewsService
    {
        public async Task CountView(News news)
        {
            news.CountView();          
        }
    }
}
