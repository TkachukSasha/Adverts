using System;
using System.Net;

namespace Adverts.Domain.Models.Response
{
    public class CreateAdvertResponse
    {
        public Guid GID { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
