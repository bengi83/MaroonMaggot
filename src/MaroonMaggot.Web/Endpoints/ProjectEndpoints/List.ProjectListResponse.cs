using System.Collections.Generic;
using MaroonMaggot.Core.ProjectAggregate;

namespace MaroonMaggot.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
