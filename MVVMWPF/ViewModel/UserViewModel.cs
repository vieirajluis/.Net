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
            Database db = new Database();
            //_UsersList = db.getUsersDataAdapter(_UsersList);
            _UsersList = db.getUsersDataReader(_UsersList);

          
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
