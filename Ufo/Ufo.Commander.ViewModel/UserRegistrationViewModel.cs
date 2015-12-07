using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.Commander.Model;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.ViewModel
{
    public class UserRegistrationViewModel : ViewModelBase
    {
        #region private members
        private UserModel user;
        private IManager manager;
        #endregion

        #region ctor
        public UserRegistrationViewModel()
        {
            this.user = new UserModel();
            this.manager = ManagerFactory.GetManager();
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username
        {
            get { return user.Username; }
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
            get { return user.Password; }
            set
            {
                if (user.Password != value)
                {
                    user.Password = manager.HashPassword(value);
                    RaisePropertyChangedEvent("Password");
                }
            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email
        {
            get { return user.Email; }
            set
            {
                if (user.Email != value)
                {
                    user.Email = value;
                    RaisePropertyChangedEvent("Email");
                }
            }
        }
        #endregion

        #region methods
        public void Registrate()
        {
            try
            {
                manager.Registrate(user.GetInstance());
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
