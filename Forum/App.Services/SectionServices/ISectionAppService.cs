using App.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.SectionServices
{
    public interface ISectionAppService
    {
        IEnumerable<SectionWithCategoriesViewModel> GetAllSectionsWithDetails();
    }
}
