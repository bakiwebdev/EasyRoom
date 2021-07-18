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
    public class PostsControllerTests
    {
        private readonly DbContextOptions<EasyRoomContext> dbContextOptions = new DbContextOptionsBuilder<EasyRoomContext>()
            .UseInMemoryDatabase(databaseName: "EasyRoom").Options;

        private PostsController controller;

        [OneTimeSetUp]
        public void Setup()
        {
            //SeedDb
            DbInitializer.Initialize(new EasyRoomContext(dbContextOptions));

            controller = new PostsController(new PostService(new EasyRoomContext(dbContextOptions)));
        }

        [Test]
        public async Task Get_All_Posts()
        {
            //Arrange
            int count;
            //Act
            var result = (await controller.GetPosts()).Value.ToList();
            count = result.Count;

            //Assert
            Assert.AreEqual(8, count);

        }

        [Test]
        public async Task Get_Post_By_ID()
        {
            //Arrange
            int ID_To_Search = 3;

            //Act
            var result = await controller.GetPost(ID_To_Search);

            //Assert
            Assert.AreEqual(ID_To_Search, result.Value.PostID);
        }

        [Test]
        public async Task Create_New_Post()
        {
            //Arrange
            var post = new PostRequest
            {
                Title = "Test Title",
                Body = "Test Body",
                UserID = 1
            };

            int prevPostCount = 0;
            int newPostCount = 0;

            //Act

            //Create local db 
            DbContextOptions<EasyRoomContext> localDbContext = new DbContextOptionsBuilder<EasyRoomContext>()
                .UseInMemoryDatabase(databaseName: "LocalDb").Options;

            //seed few data into new database
            DbInitializer.Initialize(new EasyRoomContext(localDbContext));

            var localController = new PostsController(new PostService(new EasyRoomContext(localDbContext)));

            //Act
            prevPostCount = (await controller.GetPosts()).Value.ToList().Count;

            //add new post
            await localController.PostPost(post);

            newPostCount = (await localController.GetPosts()).Value.ToList().Count;


            //Assert

            Assert.AreEqual(++prevPostCount, newPostCount);
        }

        [Test]
        public async Task Delete_Post_And_Count()
        {
            //Arrange
            int prevPostCount = 0;
            int newPostCount = 0;
            int ID = 1;

            //Act

            //Create local db 
            DbContextOptions<EasyRoomContext> localDbContext = new DbContextOptionsBuilder<EasyRoomContext>()
                .UseInMemoryDatabase(databaseName: "LocalDb").Options;

            //seed few data into new database
            DbInitializer.Initialize(new EasyRoomContext(localDbContext));

            var localController = new PostsController(new PostService(new EasyRoomContext(localDbContext)));

            //Act
            prevPostCount = (await controller.GetPosts()).Value.ToList().Count;

            //delete post
            await localController.DeletePost(ID);

            newPostCount = (await localController.GetPosts()).Value.ToList().Count;


            //Assert

            Assert.AreEqual(prevPostCount, newPostCount);
        }

    }
}