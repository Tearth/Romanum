using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.ViewModels
{
    public class CategoryDetalisViewModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int TopicsCount { get; set; }
        public int PostsCount { get; set; }
        public DateTime LastPostTime { get; set; }
    }
}
