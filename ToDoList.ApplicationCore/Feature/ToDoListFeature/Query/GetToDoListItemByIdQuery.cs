using MediatR;
using System.Collections.Generic;
using ToDoList.Domain.Model;

namespace ToDoList.ApplicationCore.Feature.ToDoListFeature.Query
{
    public class GetToDoListItemByIdQuery : IRequest<ToDoListItem>
    {
        public int Id { get; }
        public GetToDoListItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
