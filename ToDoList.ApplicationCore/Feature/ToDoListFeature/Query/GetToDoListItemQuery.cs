using MediatR;
using System.Collections.Generic;
using ToDoList.Domain.Model;

namespace ToDoList.ApplicationCore.Feature.ToDoListFeature.Query
{
    public class GetToDoListItemQuery : IRequest<IEnumerable<ToDoListItem>>
    {

    }
}
