using RxWithController.Models;

namespace RxWithController.Services
{
    public interface IGenerateService
    {
        GenerateMessage Name();
    }

    public class GenerateService : IGenerateService
    {
        public GenerateMessage Name()
        {
            return new GenerateMessage(Guid.NewGuid().ToString());
        }
    }
}
