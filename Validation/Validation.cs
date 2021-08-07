using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Validation
{
    class Validation : ObservableObject
    {
        private string val_username;
        private string val_login;
        //private string val_password;
        //private string val_new_password;

        [Required(ErrorMessage = "Строка не должна быть пустой")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Должно быть от 5 до 30 символов")]
        public string Username
        {
            get { return val_username; }
            set
            {
                ValidateProperty(value, "Username");
                OnPropertyChanged(ref val_username, value);
            }
        }

        [Required(ErrorMessage = "Строка не должна быть пустой")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Должно быть от 5 до 30 символов")]
        public string Login
        {
            get { return val_login; }
            set
            {
                ValidateProperty(value, "Login");
                OnPropertyChanged(ref val_login, value);
            }
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }


    }
}
