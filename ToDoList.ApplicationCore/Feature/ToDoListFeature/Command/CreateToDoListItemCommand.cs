using MediatR;
using System;
using ToDoList.Domain.Model;

namespace ToDoList.ApplicationCore.Feature.ToDoListFeature.Command
{
    public class CreateToDoListItemCommand : IRequest<bool>
    {
        public ToDoListItem ToDoListItem { get; set; }  

        public CreateToDoListItemCommand(ToDoListItem toDoListItem)
        {
            ToDoListItem = toDoListItem;
        }
    }
}
