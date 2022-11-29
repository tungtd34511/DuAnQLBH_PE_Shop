using App.Business.Sevices.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Views.Views.Users
{
    public partial class ChangePassword : Form
    {
        private readonly IUserService _userService;
        public Data.Entities.User User { get; set; }
        public ChangePassword(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            User.PasswordHash = txtConfirmnewPass.Text;
            if(await _userService.UpdatePassword(User))
            {
                MessageBox.Show("Cập nhật mật khẩu thành công !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu thất bại !");
                this.Close();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
