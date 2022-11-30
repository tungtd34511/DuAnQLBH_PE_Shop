using App.Business.Sevices.Users;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class UserLogin : Form
    {
        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;
        public Data.Entities.User User { get; set; } = new();
        public bool IsAuthenticate { get; set; } = false;
        public UserLogin(IUserService userService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userService = userService;
            _serviceProvider = serviceProvider;
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            User = await _userService.Authenticate(txt_Acc.Text, txt_Pass.Text);
            if(User != null)
            {
                MessageBox.Show("Đăng nhập thành công !");
                
                if (User.Status == Data.Ultilities.Enums.UserStatus.FirstLogin)
                {
                    MessageBox.Show("Xin vui lòng đổi mật khẩu");
                    var form = _serviceProvider.GetRequiredService<ChangePassword>();
                    form.User = User;
                    form.User.Status = Data.Ultilities.Enums.UserStatus.Active;
                    form.ShowDialog();
                    form.FormClosed += (o, s) =>
                    {
                        IsAuthenticate = true;
                        this.Close();
                    };
                }
                else
                {
                    IsAuthenticate = true;
                    this.Close();
                }
            }
            else {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
            }
        }

        private void cbox_HienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(cbox_HienMatKhau.Checked)
            {
                txt_Pass.PasswordChar = new();
            }
            else
            {
                txt_Pass.PasswordChar =("●")[0];
            }
        }
    }
}
