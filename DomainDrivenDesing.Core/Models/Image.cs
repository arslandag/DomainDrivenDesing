using CSharpFunctionalExtensions;

namespace DomainDrivenDesing.Core.Models
{
    public class Image
    {
        private Image(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; } = string.Empty;
        public Guid Id { get; }

        public static Result<Image> Create(string fileName)
        {
            if(string.IsNullOrEmpty(fileName))
            {
                return Result.Failure<Image>($"'{nameof(fileName)}' cannot be not empty");
            }

            var image = new Image(fileName);

            return Result.Success(image);
        }
    }
}