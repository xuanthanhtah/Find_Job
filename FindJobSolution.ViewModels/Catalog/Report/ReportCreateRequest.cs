using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Report
{
    public class ReportCreateRequest
    {
        [DisplayName("Tên của bạn (không cần tên thật của bạn)")]
        public string Name { get; set; }
        [DisplayName("Bạn muốn nói gì với chúng tôi")]
        public string Content { get; set; }
    }
}