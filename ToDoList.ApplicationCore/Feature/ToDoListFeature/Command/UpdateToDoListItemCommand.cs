using MediatR;
using System;
using ToDoList.Domain.Model;

namespace ToDoList.ApplicationCore.Feature.ToDoListFeature.Command
{
    public class UpdateToDoListItemCommand : IRequest<bool>
    {
        public ToDoListItem ToDoListItem { get; }

        public UpdateToDoListItemCommand(ToDoListItem toDoListItem)
        {
            ToDoListItem = toDoListItem;
        }
    }
}
