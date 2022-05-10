using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets
{
    public interface IOperationFailure
    {
        public string PropertyName { get; set; }
        public string description{get; set;}
        public string Code { get; set; }
    }

    public class OperationFailure : IOperationFailure
    {
        public string PropertyName { get;set; }
        public string description { get; set; }
        public string Code { get; set; }
    }
}
