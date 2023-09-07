using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.ApplicationCore.Feature.ToDoListFeature.Query;
using ToDoList.Domain.Model;
using ToDoList.Domain.Repository.Interface;

namespace ToDoList.ApplicationCore.Feature.ToDoListFeature.Handler
{
    public class GetToDoListItemByIdHandler : IRequestHandler<GetToDoListItemByIdQuery, ToDoListItem>
    {
        private readonly IToDoListRepository toDoListRepository;

        public GetToDoListItemByIdHandler(IToDoListRepository toDoListRepository)
        {
            this.toDoListRepository = toDoListRepository;
        }

        public async Task<ToDoListItem> Handle(GetToDoListItemByIdQuery request, CancellationToken cancellationToken)
        {
            ToDoListItem toDoListItem = await toDoListRepository.ToDoListItemById(request.Id);
            return toDoListItem;
        }
    }
}
