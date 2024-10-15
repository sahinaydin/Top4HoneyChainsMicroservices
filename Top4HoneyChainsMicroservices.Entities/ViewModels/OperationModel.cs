using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top4HoneyChainsMicroservices.Entities.ViewModels
{
    public class OperationModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Datetime { get; set; } = DateTime.Now;
    }
}
