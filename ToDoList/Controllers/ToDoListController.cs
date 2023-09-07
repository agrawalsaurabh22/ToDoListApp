using MediatR;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToDoList.ApplicationCore.Feature.ToDoListFeature.Command;
using ToDoList.ApplicationCore.Feature.ToDoListFeature.Query;
using ToDoList.Domain.Model;

namespace ToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IMediator mediator;

        public ToDoListController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<ActionResult> Index()
        {
            var toDoListItems = await mediator.Send(new GetToDoListItemQuery());
            return View("Index", toDoListItems);
        }

        // GET: Todo/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var toDoListItem = await mediator.Send(new GetToDoListItemByIdQuery(id));
            return View(toDoListItem);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ToDoListItem toDoListItem)
        {
            var toDoListItems = await mediator.Send(new CreateToDoListItemCommand(toDoListItem));
            return RedirectToAction(nameof(Index));
        }

        // GET: Todo/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var toDoListItem = await mediator.Send(new GetToDoListItemByIdQuery(id));
            return View(toDoListItem);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ToDoListItem toDoListItem)
        {
            try
            {
                var toDoListItems = await mediator.Send(new UpdateToDoListItemCommand(toDoListItem));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var toDoListItem = await mediator.Send(new GetToDoListItemByIdQuery(id));
            return View(toDoListItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ToDoListItem toDoListItem)
        {
            try
            {
                var toDoListItems = await mediator.Send(new DeleteToDoListItemCommand(toDoListItem.Id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}