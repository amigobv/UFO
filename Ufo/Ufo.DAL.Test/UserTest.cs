using System;
using System.Collections.Generic;
using Ufo.DAL.Common.Domain;
using System.Security.Cryptography;
using Xunit;
using Ufo.DAL.Test.Common;
using Ufo.DAL.SqlServer;
using Ufo.DAL.Common;
using Ufo.DAL.SqlServer.Dao;

namespace Ufo.DAL.Test
{
    public class UserTest : DaoTest<User, string>
    {
        private const string ALTER_USERNAME = "newUser";
        private const string ALTER_PASSWORD = "newUserPassword";
        private const string ALTER_MAIL= "newUser@mail.com";


        private const string USER1_NAME = "testuser1";
        private const string USER1_PASSWORD = "testuser1_password";
        private const string USER1_MAIL = "testuser1@mail.com";

        private const string USER2_NAME = "testuser2";
        private const string USER2_PASSWORD = "testuser2_password";
        private const string USER2_MAIL = "testuser2@mail.com";
        
        private const string USER3_NAME = "testuser3";
        private const string USER3_PASSWORD = "testuser3_password";
        private const string USER3_MAIL = "testuser3@mail.com";

        private const string USER4_NAME = "testuser4";
        private const string USER4_PASSWORD = "testuser4_password";
        private const string USER4_MAIL = "testuser4@mail.com";


        internal override void CreateTestData()
        {
            items = new List<User>();
            SHA1Managed security = new SHA1Managed();
            items.Add(new User(USER1_NAME, USER1_PASSWORD, USER1_MAIL));
            items.Add(new User(USER2_NAME, USER2_PASSWORD, USER2_MAIL));
            items.Add(new User(USER3_NAME, USER3_PASSWORD, USER3_MAIL));
            items.Add(new User(USER4_NAME, USER4_PASSWORD, USER4_MAIL));
        }


        [Fact]
        [AutoRollback]
        public void InsertCategoryTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            UserDao userDao = new UserDao(database);
            InsertDummyData(userDao);
            Assert.Equal(items.Count, userDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void FindAllUsersTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            UserDao userDao = new UserDao(database);
            InsertDummyData(userDao);
            Assert.Equal(items.Count, userDao.Count());

            IList<User> dbUsers = userDao.FindAll();
            Assert.NotNull(dbUsers);
            Assert.Equal(items.Count, dbUsers.Count);

            foreach(var user in dbUsers)
            {
                Assert.True(items.Contains(user));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindUserByIdTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            UserDao userDao = new UserDao(database);
            InsertDummyData(userDao);
            Assert.Equal(items.Count, userDao.Count());

            User myUser = userDao.FindById(USER1_NAME);
            Assert.NotNull(myUser);
            Assert.Equal(USER1_NAME, myUser.Username);
            Assert.Equal(USER1_PASSWORD, myUser.Password);
            Assert.Equal(USER1_MAIL, myUser.Email);

            userDao.Delete(myUser.Username);
            Assert.Equal(3, userDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void UpdateUserTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            UserDao userDao = new UserDao(database);
            InsertDummyData(userDao);
            Assert.Equal(items.Count, userDao.Count());


            userDao.Update(new User(USER1_NAME, ALTER_PASSWORD, ALTER_MAIL));
            var myNewUser = userDao.FindById(USER1_NAME);
            Assert.NotNull(myNewUser);
            Assert.True(!items.Contains(myNewUser));
            Assert.Equal(USER1_NAME, myNewUser.Username);
            Assert.Equal(ALTER_PASSWORD, myNewUser.Password);
            Assert.Equal(ALTER_MAIL, myNewUser.Email);

        }

        [Fact]
        [AutoRollback]
        public void DeleteUserTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            UserDao userDao = new UserDao(database);
            InsertDummyData(userDao);
            Assert.Equal(items.Count, userDao.Count());

            foreach (var item in items)
            {
                userDao.Delete(item.Username);
            }
            Assert.Equal(0, userDao.Count());
        }


    }
}
