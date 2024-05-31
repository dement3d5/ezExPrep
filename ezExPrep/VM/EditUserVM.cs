
using ezExPrep.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ezExPrep.VM
{
    public class EditUserVM : BaseVM
    {
        
        private User user;
        public string Login
        {
            get => user?.Login;
            set
            {
                if(user != null)
                {
                    user.Login = value;
                    Signal();
                }
            }
        }
        public string Password
        {
            get => user?.Password;
            set
            {
                if (user != null)
                {
                    user.Password = value;
                    Signal();
                   
                }
            }
        }

        private List<Role> roles;
        public List<Role> Roles
        {
            get => roles;
            set
            {
                roles = value;
                Signal();
            }
        }

        private Role selectedRole;
        public Role SelectedRole
        {
            get
            {
                return selectedRole;
            }
            set
            {
                selectedRole = value;
                if (selectedRole != null)
                {
                    user.RoleId = selectedRole.Id;
                }
            }
        }


        public CommandVM EDIT { get; set; }

        public EditUserVM(User selectedUser)
        {
            user = selectedUser;

            using (var db = new user2Context())
            {
                Roles = db.Roles.ToList();
                SelectedRole = Roles.FirstOrDefault(r => r.Id == selectedUser.RoleId);
                Signal();
            }

            EDIT = new CommandVM(() => 
            {

                if (user != null)
                {
                    using (var db = new user2Context())
                    {
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    MessageBox.Show("Пользователь успешно отредактирован!");
                }
                else
                {
                    MessageBox.Show("Выберите пользователя");
                }


            });
        
        
        }
    }
}
