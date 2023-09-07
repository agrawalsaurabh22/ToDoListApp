using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToDoList.ApplicationCore.Feature.ToDoListFeature.Command;
using ToDoList.ApplicationCore.Feature.ToDoListFeature.Query;
using ToDoList.Controllers;
using ToDoList.Domain.Model;
using Xunit;

namespace ToDoListUnitTest.Controllers
{
    public class ToDoListControllerTest
    {
        private readonly Mock<IMediator> _mediatR = new Mock<IMediator>();

        [Fact]
        public async Task UnitTest_Index()
        {
            _mediatR.Setup(x => x.Send(It.IsAny<GetToDoListItemQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(toDoListItems);
            // Arrange
            ToDoListController controller = new ToDoListController(_mediatR.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Unit_Test_Details()
        {
            // Arrange
            int id = 4;
            var toDoListItem1 = toDoListItem();
            _mediatR.Setup(x => x.Send(It.IsAny<GetToDoListItemByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(toDoListItem);

            var controller = new ToDoListController(_mediatR.Object);

            var result = await controller.Details(id) as ViewResult;

            // Assert
            Assert.NotNull(result); 
        }

        [Fact]
        public async Task UnitTest_Create()
        {
            // Arrange
            var toDoListItem1 = toDoListItem();

            _mediatR.Setup(x => x.Send(It.IsAny<CreateToDoListItemCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var controller = new ToDoListController(_mediatR.Object);
            var result = await controller.Create(toDoListItem1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UnitTest_Edit()
        {
            // Arrange
            var toDoListItem1 = toDoListItem();

            _mediatR.Setup(x => x.Send(It.IsAny<UpdateToDoListItemCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            var controller = new ToDoListController(_mediatR.Object); 

            // Act
            var result = await controller.Edit(toDoListItem1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UnitTest_Delete()
        {
            // Arrange
            var toDoListItemId = 1;
            _mediatR.Setup(x => x.Send(It.IsAny<DeleteToDoListItemCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var controller = new ToDoListController(_mediatR.Object);

            // Act
            var result = await controller.Delete(new ToDoListItem { Id = toDoListItemId });

            // Assert
            Assert.NotNull(result); 
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
