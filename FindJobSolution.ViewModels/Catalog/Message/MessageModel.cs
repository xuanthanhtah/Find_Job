using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Message
{
    public class MessageModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }
        public Guid userId { get; set; }
    }
}