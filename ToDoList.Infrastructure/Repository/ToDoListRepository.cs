using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ToDoList.Domain.Model;
using ToDoList.Domain.Repository.Interface;
using ToDoList.Infrastructure.Interface;

namespace ToDoList.Infrastructure.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        protected readonly IDbConnectionFactory dbConnectionFactory;
        public ToDoListRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<ToDoListItem>> ToDoListItems()
        {
            var connection = dbConnectionFactory.GetDbConnection();
            IEnumerable<ToDoListItem> toDoListItems = await connection.QueryAsync<ToDoListItem>("GetAllItems", commandType: CommandType.Text).ConfigureAwait(false);
            return toDoListItems;
        }

        public async Task<ToDoListItem> ToDoListItemById(int id)
        {
            var connection = dbConnectionFactory.GetDbConnection();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, direction: ParameterDirection.Input);
            ToDoListItem toDoListItem = await connection.QueryFirstOrDefaultAsync<ToDoListItem>("GetItemById", parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            return toDoListItem;
        }

        public async Task<bool> AddToDoListItem(ToDoListItem toDoListItem)
        {
            var connection = dbConnectionFactory.GetDbConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@title", toDoListItem.Title, DbType.String, direction: ParameterDirection.Input);
            int rowAffected = await connection.ExecuteAsync("AddItem", parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            if (rowAffected > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateToDoListItem(ToDoListItem toDoListItem)
        {
            var connection = dbConnectionFactory.GetDbConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", toDoListItem.Id, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@addDate", toDoListItem.AddDate, DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("@title", toDoListItem.Title, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@isDone", toDoListItem.IsDone, DbType.Boolean, direction: ParameterDirection.Input);
            int rowAffected = await connection.ExecuteAsync("UpdateItem", parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            if (rowAffected > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteToDoListItem(int id)
        {
            var connection = dbConnectionFactory.GetDbConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, direction: ParameterDirection.Input);
            int rowAffected = await connection.ExecuteAsync("DeleteItem", parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            if (rowAffected > 0)
                return true;
            else
                return false;
        }

    }
}
