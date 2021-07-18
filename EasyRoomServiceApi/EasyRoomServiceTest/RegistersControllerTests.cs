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
    public class RegistersControllerTests
    {
        private readonly DbContextOptions<EasyRoomContext> dbContextOptions = new DbContextOptionsBuilder<EasyRoomContext>()
            .UseInMemoryDatabase(databaseName: "EasyRoom").Options;

        private RegistersController controller;

        [OneTimeSetUp]
        public void Setup()
        {
            //SeedDb
            DbInitializer.Initialize(new EasyRoomContext(dbContextOptions));

            controller = new RegistersController(new RegisterService(new EasyRoomContext(dbContextOptions)));
        }
    }
}
