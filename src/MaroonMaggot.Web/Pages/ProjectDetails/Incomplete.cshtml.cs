using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaroonMaggot.Core.ProjectAggregate;
using MaroonMaggot.Core.ProjectAggregate.Specifications;
using MaroonMaggot.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaroonMaggot.Web.Pages.ToDoRazorPage
{
    public class IncompleteModel : PageModel
    {
        private readonly IRepository<Project> _repository;

        public List<ToDoItem> ToDoItems { get; set; }

        public IncompleteModel(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            var projectSpec = new ProjectByIdWithItemsSpec(1); // TODO: get from route
            var project = await _repository.GetBySpecAsync(projectSpec);
            var spec = new IncompleteItemsSpec();

            ToDoItems = spec.Evaluate(project.Items).ToList();
        }
    }
}
