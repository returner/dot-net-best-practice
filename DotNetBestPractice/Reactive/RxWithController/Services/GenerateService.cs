using RxWithController.Models;

namespace RxWithController.Services
{
    public interface IGenerateService
    {
        Task<GenerateMessage> NameAsync();
    }

    public class GenerateService : IGenerateService
    {
        public async Task<GenerateMessage> NameAsync()
        {
            await Task.CompletedTask;
            return new GenerateMessage(Guid.NewGuid().ToString());
        }
    }
}
