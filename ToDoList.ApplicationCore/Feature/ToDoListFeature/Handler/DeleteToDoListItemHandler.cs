using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.ApplicationCore.Feature.ToDoListFeature.Command;
using ToDoList.Domain.Repository.Interface;

namespace ToDoList.ApplicationCore.Feature.ToDoListFeature.Handler
{
    public class DeleteToDoListItemHandler : IRequestHandler<DeleteToDoListItemCommand, bool>
    {
        private readonly IToDoListRepository toDoListRepository;

        public DeleteToDoListItemHandler(IToDoListRepository toDoListRepository)
        {
            this.toDoListRepository = toDoListRepository;
        }
        public async Task<bool> Handle(DeleteToDoListItemCommand request, CancellationToken cancellationToken)
        {
            return await toDoListRepository.DeleteToDoListItem(request.Id);
        }
    }
}
