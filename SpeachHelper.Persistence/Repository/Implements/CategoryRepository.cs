using SpeachHelper.Domain.Entitys;
using SpeachHelper.Persistance.Session;
using SpeachHelper.Persistence.Repository.Contracts;
using System.Threading.Tasks;

namespace SpeachHelper.Persistence.Repository.Implements
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task AddCategoryAsync(ISession session, Category category)
        {
            var parametrs = new
            {
                name = category.Name,
            };

            string insert = @"
INSERT INTO Commands
    (Name)
VALUES
    (@name)
";
            await session.ExecuteAsync(insert, parametrs);
        }
    }
}
