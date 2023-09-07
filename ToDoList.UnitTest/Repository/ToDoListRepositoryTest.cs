using Moq;
using Moq.Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using ToDoList.Domain.Model;
using ToDoList.Infrastructure.Interface;
using Xunit;
using Dapper;
using ToDoList.Infrastructure.Repository;
using System.Data;

namespace ToDoListUnitTest.Repository
{
    public class ToDoListRepositoryTest
    {
        private readonly Mock<IDbConnectionFactory> mockConnectionFactory = new Mock<IDbConnectionFactory>();

        public ToDoListRepositoryTest()
        {
            mockConnectionFactory = new Mock<IDbConnectionFactory>();
        }

        [Fact]
        public async Task UnitTest_ToDoListItems()
        {
            var todoListItems1 = toDoListItems();
            var mockConnection = new Mock<DbConnection>();
            mockConnection.SetupDapperAsync(c => c.QueryAsync<ToDoListItem>("GetAllItems", null, null, null, null))
                .ReturnsAsync(toDoListItems);

            mockConnectionFactory.Setup(f => f.GetDbConnection()).Returns(mockConnection.Object);

            var repository = new ToDoListRepository(mockConnectionFactory.Object);

            // Act
            var result = await repository.ToDoListItems();

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(todoListItems1, result);
        }

        //[Fact]
        //public async Task UnitTest_ToDoListItemById()
        //{
        //    // Arrange
        //    int itemId = 4;
        //    var expectedItem = toDoListItem();
        //    var mockConnection = new Mock<IDbConnection>();
        //    mockConnection
        //        .Setup(c => c.QueryFirstOrDefaultAsync<ToDoListItem>(
        //            "GetItemById",
        //            It.IsAny<object>(),
        //            null,
        //            null,
        //            CommandType.StoredProcedure
        //        )).ReturnsAsync(expectedItem);

        //    mockConnectionFactory.Setup(f => f.GetDbConnection()).Returns(mockConnection.Object);

        //    var repository = new ToDoListRepository(mockConnectionFactory.Object);

        //    // Act
        //    var result = await repository.ToDoListItemById(itemId);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(expectedItem.Id, result.Id);
        //}

        [Fact]
        public async Task AddToDoListItem_ReturnsTrueOnSuccess()
        {
            // Arrange
            var toDoListItem1 = toDoListItem();
            var mockConnection = new Mock<DbConnection>();
            mockConnection
                    .SetupDapperAsync(c => c.ExecuteAsync(
                        "AddItem",
                        It.IsAny<object>(),
                        null,
                        null,
                        CommandType.StoredProcedure
                    ))
                    .ReturnsAsync(1);

            mockConnectionFactory.Setup(f => f.GetDbConnection()).Returns(mockConnection.Object);

            var repository = new ToDoListRepository(mockConnectionFactory.Object);

            // Act
            var result = await repository.AddToDoListItem(toDoListItem1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task UpdateToDoListItem_ReturnsTrueOnSuccess()
        {
            // Arrange
            var toDoListItem1 = toDoListItem();

            var mockConnection = new Mock<DbConnection>();
            mockConnection
                .SetupDapperAsync(c => c.ExecuteAsync(
                    "UpdateItem",
                    It.IsAny<object>(),
                    null,
                    null,
                    CommandType.StoredProcedure
                ))
                .ReturnsAsync(1);

            mockConnectionFactory.Setup(f => f.GetDbConnection()).Returns(mockConnection.Object);

            var repository = new ToDoListRepository(mockConnectionFactory.Object);

            // Act
            var result = await repository.UpdateToDoListItem(toDoListItem1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteToDoListItem_ReturnsTrueOnSuccess()
        {
            // Arrange
            int itemId = 1;

            var mockConnection = new Mock<DbConnection>();
            mockConnection
                .SetupDapperAsync(c => c.ExecuteAsync(
                    "DeleteItem",
                    It.IsAny<object>(),
                    null,
                    null,
                    CommandType.StoredProcedure
                ))
                .ReturnsAsync(1);

            mockConnectionFactory.Setup(f => f.GetDbConnection()).Returns(mockConnection.Object);

            var repository = new ToDoListRepository(mockConnectionFactory.Object);

            // Act
            var result = await repository.DeleteToDoListItem(itemId);

            // Assert
            Assert.True(result);
        }

        private IEnumerable<ToDoListItem> toDoListItems()
        {

            return new List<ToDoListItem>
            {
                new ToDoListItem
                {
                    AddDate = DateTime.Now,
                    Id = 1,
                    IsDone = false,
                    Title = "Test1"
                },
                new ToDoListItem
                {
                    AddDate = DateTime.Now,
                    Id = 2,
                    IsDone = false,
                    Title = "Test2"
                },
                new ToDoListItem
                {
                    AddDate = DateTime.Now,
                    Id = 3,
                    IsDone = true,
                    Title = "Test3"
                }

            };
        }

        private ToDoListItem toDoListItem()
        {

            return new ToDoListItem
            {
                AddDate = DateTime.Now,
                Id = 4,
                IsDone = false,
                Title = "TestOne"
            };
        }
    }
}
