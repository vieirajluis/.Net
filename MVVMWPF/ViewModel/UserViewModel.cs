using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using MVVMWPF.Model;

namespace MVVMWPF.ViewModel
{
    class UserViewModel
    {
        private IList<User> _UsersList;

        public UserViewModel ()
        {
            _UsersList = new List<User>
            {
                new User{UserId=1,FirstName="Joao",LastName="Vieira",City="Itaicaba",State="Ceara",Country="Brazil"},
                new User{UserId=2,FirstName="Luis",LastName="Silva",City="Toronto",State="Ontario",Country="Canada"},
                new User{UserId=3,FirstName="Marcos",LastName="Vieira",City="Itaicaba",State="Ceara",Country="Brazil"},
                new User{UserId=4,FirstName="Marcia",LastName="Vieira",City="Fortaleza",State="Ceara",Country="Brazil"},
            };
        }

        public IList<User> UsersList { get => _UsersList; set => _UsersList = value; }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get {
                if (mUpdater == null) { mUpdater = new Updater(); }
                return mUpdater;

            }
            set { mUpdater = value; }
        }


        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
    }
}
