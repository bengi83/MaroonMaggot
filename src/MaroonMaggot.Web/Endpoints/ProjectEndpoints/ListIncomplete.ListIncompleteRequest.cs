using Microsoft.AspNetCore.Mvc;
using System;

namespace MaroonMaggot.Web.Endpoints.ProjectEndpoints
{
    public class ListIncompleteRequest
    {
        [FromRoute]
        public int ProjectId { get; set; }
        [FromQuery]
        public string SearchString { get; set; }
    }
}
