using EasyRoomServiceApi.Controllers;
using EasyRoomServiceApi.Data;
using EasyRoomServiceApi.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRoomServiceTest
{
    public class FriendsControllerTests
    {
        private readonly DbContextOptions<EasyRoomContext> dbContextOptions = new DbContextOptionsBuilder<EasyRoomContext>()
            .UseInMemoryDatabase(databaseName: "EasyRoom").Options;

        private FriendsController controller;

        [OneTimeSetUp]
        public void Setup()
        {
            //SeedDb
            DbInitializer.Initialize(new EasyRoomContext(dbContextOptions));

            controller = new FriendsController(new FriendService(new EasyRoomContext(dbContextOptions)));
        }

        [Test]
        public async Task Show_All_Friend()
        {
            //Arrange
            int count;
            //Act
            var result = await controller.GetFriends();
            count = result.Value.Count();

            //Assert
            Assert.NotNull(count);

        }

        [Test]
        public async Task Show_Friend_By_ID()
        {
            //Arrange
            int targetID = 1;

            //Act
            var result = await controller.GetFriend(targetID);

            //Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.Value.ID, targetID);
        }
    }
}
