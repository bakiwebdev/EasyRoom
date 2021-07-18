using EasyRoomServiceApi.Models;
using System;
using System.Linq;


namespace EasyRoomServiceApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EasyRoomContext context)
        {

            SetUsername(context);

            SetPost(context);

            SetNotification(context);

            SetInterest(context);

            SetRegister(context);

            SetFriend(context);

            SetMessage(context);

        }

        private static void SetMessage(EasyRoomContext context)
        {
            context.Database.EnsureCreated();

            //if Message tabel is empity
            if (!context.Messages.Any())
            {
                var messages = new Message[]
                {
                    new Message
                    {
                        FromID = 1,
                        ToID = 2,
                        DateTime = DateTime.Now,
                        Body = "Hello ;)"
                    },

                    new Message
                    {
                        FromID = 2,
                        ToID = 1,
                        DateTime = DateTime.Now,
                        Body = "Hello, you konw we need to check if the chat functionality is working"
                    },

                    new Message
                    {
                        FromID = 1,
                        ToID = 2,
                        DateTime = DateTime.Now,
                        Body = "I know right?, i hope it's working by now"
                    }
                };

                //Add Messages instance into the database
                foreach (Message m in messages)
                {
                    context.Messages.Add(m);
                }
                context.SaveChanges();
            }
        }

        private static void SetFriend(EasyRoomContext context)
        {
            context.Database.EnsureCreated();

            //if Friend tabel is empity
            if (!context.Friends.Any())
            {
                //Friends instance
                var friends = new Friend[]
                {
                    new Friend
                    {
                        UserID = 1,
                        PartnerID = 4,
                        Status = true
                    },
                    new Friend
                    {
                        UserID = 2,
                        PartnerID = 3,
                        Status = true
                    }
                };

                //Add Registers instance into the database
                foreach (Friend f in friends)
                {
                    context.Friends.Add(f);
                }
                context.SaveChanges();
            }
        }

        private static void SetRegister(EasyRoomContext context)
        {
            context.Database.EnsureCreated();

            //if Register tabel is empity
            if (!context.Registers.Any())
            {
                //Register instance
                var registers = new Register[]
                {
                new Register
                {
                    UserID = 1,
                    PostID = 2,
                    Status = true
                },

                new Register
                {
                    UserID = 2,
                    PostID = 3,
                    Status = false
                },

                new Register
                {
                    UserID = 3,
                    PostID = 4,
                    Status = true
                },

                new Register
                {
                    UserID = 4,
                    PostID = 5,
                    Status = true
                }
                };

                //Add Registers instance into the database
                foreach (Register r in registers)
                {
                    context.Registers.Add(r);
                }
                context.SaveChanges();
            }
        }

        private static void SetInterest(EasyRoomContext context)
        {
            context.Database.EnsureCreated();

            //if Intersts tabel is empity
            if (!context.Interests.Any())
            {
                //Interest instance
                var interests = new Interest[]
                {
                new Interest
                {
                    UserID = 1,
                    Game = 1
                },

                new Interest
                {
                    UserID = 2,
                    Game = 2
                },

                new Interest
                {
                    UserID = 3,
                    Game = 3
                },

                new Interest
                {
                    UserID = 4,
                    Game = 4
                }
                };

                //Add interest instance into the database
                foreach (Interest i in interests)
                {
                    context.Interests.Add(i);
                }
                context.SaveChanges();
            }
        }

        private static void SetNotification(EasyRoomContext context)
        {
            context.Database.EnsureCreated();

            //if Notification tabel is empity
            if (!context.Notifications.Any())
            {
                //Notification instance
                var notifications = new Notification[]
                {
                new Notification
                {
                    Status = false,
                    UserID = 1,
                    Date = DateTime.Now,
                    PostID = 1
                },

                new Notification
                {
                    Status = false,
                    UserID = 2,
                    Date = DateTime.Now,
                    PostID = 2
                },

                new Notification
                {
                    Status = false,
                    UserID = 3,
                    Date = DateTime.Now,
                    PostID = 3
                },

                new Notification
                {
                    Status = false,
                    UserID = 4,
                    Date = DateTime.Now,
                    PostID = 4
                },
                };

                //Add notification instance into the database
                foreach (Notification n in notifications)
                {
                    context.Notifications.Add(n);
                }
                context.SaveChanges();
            }
        }

        private static void SetPost(EasyRoomContext context)
        {
            context.Database.EnsureCreated();

            //if Post tabel is empity
            if (!context.Posts.Any())
            {
                //Post instance
                var posts = new Post[]
                {
                    new Post
                    {
                        CreatedDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddDays(10),
                        Title = "Title 1.0",
                        Body = "Body 1.0",
                        UserID = 1
                    },

                    new Post
                    {
                        CreatedDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddDays(10),
                        Title = "Title 2.0",
                        Body = "Body 2.0",
                        UserID = 2
                    },

                    new Post
                    {
                        CreatedDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddDays(10),
                        Title = "Title 3.0",
                        Body = "Body 3.0",
                        UserID = 3
                    },

                    new Post
                    {
                        CreatedDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddDays(10),
                        Title = "Title 4.0",
                        Body = "Body 4.0",
                        UserID = 4
                    },

                    new Post
                    {
                        CreatedDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddDays(10),
                        Title = "Title 1.1",
                        Body = "Body 1.1",
                        UserID = 1
                    },

                    new Post
                    {
                        CreatedDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddDays(10),
                        Title = "Title 2.1",
                        Body = "Body 2.2",
                        UserID = 2
                    },

                    new Post
                    {
                        CreatedDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddDays(10),
                        Title = "Title 3.1",
                        Body = "Body 3.3",
                        UserID = 3
                    },

                    new Post
                    {
                        CreatedDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddDays(10),
                        Title = "Title 4.1",
                        Body = "Body 4.1",
                        UserID = 4
                    }
                };

                //Add post instance into the database
                foreach (Post p in posts)
                {
                    context.Posts.Add(p);
                }
                context.SaveChanges();
            }
        }

        private static void SetUsername(EasyRoomContext context)
        {
            context.Database.EnsureCreated();

            //if User teble is empity
            if (!context.Users.Any())
            {
                var user1password = "biruk_endris";
                var user2password = "lamrot_endris";
                var user3password = "eyouab_endris";
                var user4password = "miraph_endris";
                //user instance
                var users = new User[]
                {
                     new User
                     {
                         FirstName = "Biruk",
                         LastName = "Endris",
                         Username = "BirukEndris",
                         Password = user1password,
                         Email = "birukendris@gmail.com",
                         BirthDate = DateTime.Now,
                         Gender = Gender.Male
                     },

                     new User
                     {
                         FirstName = "Lamrot",
                         LastName = "Endris",
                         Username = "LamrotEndris",
                         Password = user2password,
                         Email = "lamrotendris@gmail.com",
                         BirthDate = DateTime.Now,
                         Gender = Gender.Female
                     },

                     new User
                     {
                         FirstName = "Eyouab",
                         LastName = "Endris",
                         Username = "EyouabEndris",
                         Password = user3password,
                         Email = "eyouabendris@gmail.com",
                         BirthDate = DateTime.Now,
                         Gender = Gender.Female
                     },

                     new User
                     {
                         FirstName = "Miraph",
                         LastName = "Endris",
                         Username = "MiraphEndris",
                         Password = user4password,
                         Email = "miraphendris@gmail.com",
                         BirthDate = DateTime.Now,
                         Gender = Gender.Male
                     }
                };

                //Add user instance into the database
                foreach (User u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
            }
        }
    }
}
