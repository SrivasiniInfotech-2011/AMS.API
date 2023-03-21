using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Models.Entities
{
    public class Response
    {
        public Status Status { get; set; }
        public Error Error { get; set; }

        public string Message { get; set; }
        public int? Id { get; set; }
    }

    public class Error
    {
        public string ErrorMessage { get; set; }
    }
    public enum Status
    {
        Success,
        Error
    }
}
