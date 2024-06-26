﻿
using ezExPrep.Tools;
using ezExPrep.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ezExPrep.VM
{
    public class AdminVM : BaseVM   
    {
        public List<User> users { get; set; }
        private User listUser;
        public User ListUser
        {
            get => listUser;
            set
            {
                listUser = value;
                Signal();
            }
        }


        public CommandVM EditUser { get;set; }
        public CommandVM DeleteUser { get; set; }

        public List<Order> orders { get; set; }
        private Order listOrder;
        public Order ListOrder
        {
            get => listOrder;
            set
            {
                listOrder = value;
                Signal();
            }
        }

        public void UpdateUserStatus(User user, int statusId)
        {
            using (var db = new user2Context())
            {
                var updatedOrder = db.Users.FirstOrDefault(o => o.Id == user.Id);
                if (updatedOrder != null)
                {
                    updatedOrder.StatusId = statusId;
                    db.SaveChanges();
                }
            }
        }

        public void RefreshUsers()
        {
            using (var db = new user2Context())
            {
                users = db.Users.Include(o => o.Role).Include(o => o.Status).ToList();
                Signal(nameof(users));
            }
        }

        public void RefreshOrders()
        {
            using (var db = new user2Context())
            {
                orders = db.Orders.Include(o => o.Product).Include(o => o.OrderStaus).ToList();
                Signal(nameof(orders));
            }
        }




        public AdminVM()
        {
            using (var db = new user2Context())
            {
                users = db.Users.Include(o => o.Role).Include(o => o.Status).ToList();
            }

            using (var db = new user2Context())
            {
                orders = db.Orders.Include(o => o.Product).Include(o => o.OrderStaus).ToList();
            }
            DeleteUser = new CommandVM(() => 
            {
                if (listUser is User selectedUser)
                {
                    try
                    {
                        using (var db = new user2Context())
                        {
                            db.Users.Remove(selectedUser);
                            db.SaveChanges();
                        }
                        MessageBox.Show("Удалено");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления");
                    }
                }


            });

            EditUser = new CommandVM(() =>
            {
                if(listUser is User selectedUser)
                {
                    EditUserWin editUserWin = new EditUserWin(listUser);
                    editUserWin.DataContext = new EditUserVM(listUser);
                    editUserWin.ShowDialog();

                }
                else
                {

                    MessageBox.Show("Выберите пользователя!");
                }
               

            });



        }    
    }
}
