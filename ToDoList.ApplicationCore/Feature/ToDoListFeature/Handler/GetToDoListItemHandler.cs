using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.ApplicationCore.Feature.ToDoListFeature.Query;
using ToDoList.Domain.Model;
using ToDoList.Domain.Repository.Interface;

namespace ToDoList.ApplicationCore.Feature.ToDoListFeature.Handler
{
    public class GetToDoListItemHandler : IRequestHandler<GetToDoListItemQuery, IEnumerable<ToDoListItem>>
    {
        private readonly IToDoListRepository toDoListRepository;

        public GetToDoListItemHandler(IToDoListRepository toDoListRepository)
        {
            this.toDoListRepository = toDoListRepository;
        }

        public async Task<IEnumerable<ToDoListItem>> Handle(GetToDoListItemQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ToDoListItem> toDoListItems = await toDoListRepository.ToDoListItems();
            return toDoListItems;
        }
    }
}
