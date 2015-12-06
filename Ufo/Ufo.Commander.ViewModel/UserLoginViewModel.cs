using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.Commander.Model;

namespace Ufo.Commander.ViewModel
{
    public class UserLoginViewModel: ViewModelBase
    {
        #region Private Members
        private UserModel user;
        private IManager manager;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginViewModel"/> class.
        /// </summary>
        public UserLoginViewModel()
        {
            user = new UserModel();
            manager = ManagerFactory.GetManager();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username
        {
            get
            {
                return user.Username;
            }

            set
            {
                if (user.Username != value)
                {
                    user.Username = value;
                    RaisePropertyChangedEvent("Username");
                }
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get
            {
                return user.Password;
            }

            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    RaisePropertyChangedEvent("Password");
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Logins this instance.
        /// </summary>
        public void Login()
        {
            try
            {
                manager.Login(user.GetInstance());
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
