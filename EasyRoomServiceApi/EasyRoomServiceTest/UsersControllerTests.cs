using EasyRoomServiceApi.Controllers;
using EasyRoomServiceApi.Data;
using EasyRoomServiceApi.Models;
using EasyRoomServiceApi.Request;
using EasyRoomServiceApi.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRoomServiceTest
{
    public class UsersControllerTests
    {
        private readonly DbContextOptions<EasyRoomContext> dbContextOptions = new DbContextOptionsBuilder<EasyRoomContext>()
            .UseInMemoryDatabase(databaseName: "EasyRoom").Options;

        private UsersController controller;

        [OneTimeSetUp]
        public void Setup()
        {
            //SeedDb
            DbInitializer.Initialize(new EasyRoomContext(dbContextOptions));

            controller = new UsersController(new UserService(new EasyRoomContext(dbContextOptions)));
        }

        [Test]
        public async Task Get_All_Users()
        {
            //Arrange
            int count;
            //Act
            var result = (await controller.GetUsers()).Value.ToList();
            count = result.Count;

            //Assert
            Assert.AreEqual(4, count);

        }

        [Test]
        public async Task Get_User_By_ID()
        {
            //Arrange
            int ID_To_Search = 3;

            //Act
            var result = await controller.GetUser(ID_To_Search);

            //Assert
            Assert.AreEqual(ID_To_Search, result.Value.ID);
        }

        [Test]
        public async Task Get_User_With_Wrong_ID()
        {
            //Arrange
            int Request_ID = 100;

            //Act
            var result = await controller.GetUser(Request_ID);

            //Assert
            Assert.IsNull(result.Value);
        }

        [Test]
        public async Task Get_User_With_Negetive_ID()
        {
            //Arrange
            int Negetive_ID = -1;

            //Act
            var result = await controller.GetUser(Negetive_ID);

            //Assert
            Assert.IsNull(result.Value);
        }

        [Test]
        public async Task Create_New_User()
        {
            //Arrange
            var user = new UserRequest
            {
                Firstname = "Biruk",
                Lastname = "Endris",
                Username = "BirukEndris",
                Password = "biruk_endris",
                Email = "birukendris@gmail.com",
                BirthDate = DateTime.Now,
                Gender = "Male"
            };

            int prevUserCount = 0;
            int newUserCount = 0;

            //Act

            //Create local db 
            DbContextOptions<EasyRoomContext> localDbContext = new DbContextOptionsBuilder<EasyRoomContext>()
                .UseInMemoryDatabase(databaseName: "LocalDb").Options;

            //seed few data into new database
            DbInitializer.Initialize(new EasyRoomContext(localDbContext));

            var localController = new UsersController(new UserService(new EasyRoomContext(localDbContext)));

            //Act
            prevUserCount = (await controller.GetUsers()).Value.ToList().Count;

            //add new post
            await localController.PostUser(user);

            newUserCount = (await localController.GetUsers()).Value.ToList().Count;


            //Assert

            Assert.AreEqual(++prevUserCount, newUserCount);
        }

        [Test]
        public async Task Edit_Existed_User_Value()
        {
            //Arrange
            int ID = 1;

            UserRequest newUser = new UserRequest
            {
                ID = 1,
                Firstname = "FirstnameChanged",
                Lastname = "LastnameChanged",
                Email = "EmailChanged"
            };

            //Act

            //Create local db 
            DbContextOptions<EasyRoomContext> localDbContext = new DbContextOptionsBuilder<EasyRoomContext>()
                .UseInMemoryDatabase(databaseName: "LocalDb").Options;

            //seed few data into new database
            DbInitializer.Initialize(new EasyRoomContext(localDbContext));

            var localController = new UsersController(new UserService(new EasyRoomContext(localDbContext)));

            var oldUser = await localController.GetUser(ID);

            await localController.PutUser(ID, newUser);

            var result = await localController.GetUser(ID);

            //Assert
            Assert.AreNotEqual(oldUser, result);

            Assert.AreNotEqual(oldUser.Value.Firstname, result.Value.Firstname);
        }
    }
}
