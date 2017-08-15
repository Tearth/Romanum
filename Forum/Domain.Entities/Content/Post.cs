using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Content
{
    public class Post : EntityBase
    {
        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }

        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                ModifyTime = DateTime.Now;
                _content = value;
            }
        }
    }
}
