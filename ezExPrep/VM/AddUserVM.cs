
using ezExPrep.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ezExPrep.VM
{
    public class AddUserVM
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public CommandVM ADD { get; set; }

        public List<Role> Roles { get; set; }
        public Role SelectedRole { get; set; }

        public AddUserVM()
        {

            using (var db = new user2Context())
            {
                Roles = db.Roles.ToList();
            }

            ADD = new CommandVM(() => 
            {
                using (var db = new user2Context())
                {
                    var user = new User
                    {
                        Login = Login,
                        Password = Password,
                        RoleId = SelectedRole.Id
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь создан.");
                }
            });

        
        
        }
    }
}
