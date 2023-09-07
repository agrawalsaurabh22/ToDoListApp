using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.ApplicationCore.Feature.ToDoListFeature.Command;
using ToDoList.Domain.Repository.Interface;

namespace ToDoList.ApplicationCore.Feature.ToDoListFeature.Handler
{
    public class CreateToDoListItemHandler : IRequestHandler<CreateToDoListItemCommand, bool>
    {
        private readonly IToDoListRepository toDoListRepository;
        public CreateToDoListItemHandler(IToDoListRepository toDoListRepository)
        {
            this.toDoListRepository = toDoListRepository;
        }
        public async Task<bool> Handle(CreateToDoListItemCommand request, CancellationToken cancellationToken)
        {
            return await toDoListRepository.AddToDoListItem(request.ToDoListItem);
        }

    }
}
