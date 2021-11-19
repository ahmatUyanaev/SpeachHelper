using SpeachHelper.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.Application.BizRules
{
    public interface ICategoryBizRules
    {
        Task AddCategoryAsync(Category category);

        Task DeleteCategoryAsync(int categoryId);

        Task AddCommandInCategory(int commandId, int categoryId);

        Task DeleteCommandInCategory(int commandId, int categoryId);
    }
}
