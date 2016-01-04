using System;
using Ufo.BL.Interfaces;
using Xunit;

namespace Ufo.BL.Test
{
    public class Tests
    {

        [Fact]
        [AutoRollback]
        public void UserExistTest()
        {
            IManager manager = BLFactory.GetManager();

            manager.Registrate(new Domain.User("swk5", "swk5", "swk5@students.fh-hagenberg.at"));

            Assert.True(manager.Exist("swk5"));
            Assert.False(manager.Exist("Daniel"));
        }

        [Fact]
        [AutoRollback]
        public void GetUsersTest()
        {
            IManager manager = BLFactory.GetManager();

            manager.Registrate(new Domain.User("swk5", "swk5", "swk5@students.fh-hagenberg.at"));
            manager.Registrate(new Domain.User("Daniel", "Daniel", "Daniel@students.fh-hagenberg.at"));
            manager.Registrate(new Domain.User("Rotaru", "Rotaru", "Rotaru@students.fh-hagenberg.at"));
            manager.Registrate(new Domain.User("NET", "NET", "NET@students.fh-hagenberg.at"));
            manager.Registrate(new Domain.User("Unit", "Unit", "Unit@students.fh-hagenberg.at"));

            var users = manager.GetAllUsers();
            Assert.NotNull(users);

            Assert.Equal(5, users.Count);
        }

        [Fact]
        [AutoRollback]
        public void LoginTest()
        {
            IManager manager = BLFactory.GetManager();

            var user = new Domain.User("swk5", "swk5", "swk5@students.fh-hagenberg.at");        
            manager.Registrate(user);

            manager.Login(user);
            var activeUser = manager.GetActiveUser();
            Assert.Equal(user, activeUser);
        }
    }
}
