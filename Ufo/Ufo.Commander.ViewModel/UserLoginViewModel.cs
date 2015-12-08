using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.Commander.Model;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.ViewModel
{
    public class UserLoginViewModel: ViewModelBase
    {
        #region Private Members
        private User user;
        private IManager manager;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginViewModel"/> class.
        /// </summary>
        public UserLoginViewModel(IManager manager)
        {
            this.user = new User();
            this.manager = manager;
        }

        public UserLoginViewModel(User user, IManager manager)
        {
            this.user = user;
            this.manager = manager;
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
                    user.Password = manager.HashPassword(value);
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
                manager.Login(user);
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
