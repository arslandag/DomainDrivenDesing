using CSharpFunctionalExtensions;
using System.Data;
using System.Diagnostics;

namespace DomainDrivenDesing.Core.Models
{
    public class News
    {
        public const int  MAX_TITLE_LENGTH = 150;
        private News(Guid id, string title, string textData, DateTime createdDate, Image? titleImage)
        {
            Id = id;
            Title = title;
            TextDate = textData;
            CreateDate = createdDate;
            TitleImage = titleImage;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string TextDate { get; } = string.Empty;
        public DateTime CreateDate { get; }
        public int Views { get; private set; } = 0;
        public Image? TitleImage { get;}

        public void CountView () => Views++;

        public static Result<News> Create(Guid id, string title, string textData, Image? titleImage)
        {
            if(string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                return Result.Failure<News>("'{nameof(title)}' cannot be less then 250 or empty");
            }

            if(string.IsNullOrEmpty(textData) || textData.Length > MAX_TITLE_LENGTH)
            {
                return Result.Failure<News>($"'{nameof(textData)}' cannot be less then 250 or empty");
            }

            var news = new News(id, title, textData, DateTime.Now,titleImage);

            return Result.Success(news);
        }
    }
}
