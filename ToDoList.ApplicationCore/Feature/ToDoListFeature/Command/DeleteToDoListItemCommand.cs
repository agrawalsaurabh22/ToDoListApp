using MediatR;
using System;

namespace ToDoList.ApplicationCore.Feature.ToDoListFeature.Command
{
    public class DeleteToDoListItemCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteToDoListItemCommand(int id)
        {
            Id = id;
        }
    }
}
