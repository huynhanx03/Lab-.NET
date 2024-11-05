using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ResponeBase<T>
    {
        public ResponeStatus Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Result { get; set; } = new List<T>();
    }

    public enum ResponeStatus
    {
        Success = 200,
        ForBiden = 403,
        BadRequesr = 400,
        Authorie = 401,
        NotFound = 404,
        InternalServer = 500
    }
}
