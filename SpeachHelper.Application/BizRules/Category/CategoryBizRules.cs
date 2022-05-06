using SpeachHelper.Domain.Entitys;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Persistance.Session;
using SpeachHelper.Persistence.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.Application.BizRules
{
    public class CategoryBizRules : ICategoryBizRules
    {
        private ICategoryRepository categoryRepository;
        private ISessionFactory sessionFactory;
        public CategoryBizRules()
        {
            categoryRepository = ServiceLocator.GetService<ICategoryRepository>();
            sessionFactory = ServiceLocator.GetService<ISessionFactory>();
        }

        public async Task AddCategoryAsync(Category category)
        {
            using (var session = sessionFactory.CreateSession())
            {
                await categoryRepository.AddCategoryAsync(session, category);
            }
        }

        public Task DeleteCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task AddCommandInCategory(int commandId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCommandInCategory(int commandId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetAllCategoryNames()
        {
            using (var session = sessionFactory.CreateSession())
            {
                return (await categoryRepository.GetAllGategoryes(session)).Select(c => c.Name).ToList();
            }
        }
    }
}
