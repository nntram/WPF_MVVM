using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;

namespace WPF_LoginForm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Fields
        private UserAccountModel? _currentUserAccount;
        private IUserRepository _userRepository;

        public UserAccountModel? CurrentUserAccount { 
            get => _currentUserAccount ?? null;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public MainViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = _userRepository.GetByUserName(Thread.CurrentPrincipal?.Identity?.Name);

            if (user != null)
            {
                CurrentUserAccount!.Username = user.UserName;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount!.DisplayName = "Invalid user, not logged in";
                // Hide child view
            }
        }
    }
}
