using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Message
{
    public class MessageCreateRequest
    {
        public string text { get; set; }
        public DateTime time { get; set; }
    }
}