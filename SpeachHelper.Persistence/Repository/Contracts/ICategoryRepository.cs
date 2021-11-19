using SpeachHelper.Domain.Entitys;
using SpeachHelper.Persistance.Session;
using System.Threading.Tasks;

namespace SpeachHelper.Persistence.Repository.Contracts
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(ISession session, Category category);
    }
}