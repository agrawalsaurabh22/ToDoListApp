using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Model;

namespace ToDoList.Domain.Repository.Interface
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<ToDoListItem>> ToDoListItems();

        Task<ToDoListItem> ToDoListItemById(int id);

        Task<bool> AddToDoListItem(ToDoListItem toDoListItem);

        Task<bool> UpdateToDoListItem(ToDoListItem toDoListItem);

        Task<bool> DeleteToDoListItem(int id);
    }
}
