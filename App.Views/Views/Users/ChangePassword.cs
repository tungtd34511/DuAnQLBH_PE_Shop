using App.Business.Sevices.Users;
using App.Data.Entities;
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
            var txt = await Validation();
            if (txt != "")
            {
                MessageBox.Show(txt);
            }
            else
            {
                User.PasswordHash = txtConfirmnewPass.Text;
                if (await _userService.UpdatePassword(User))
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
        }
        private async Task<string> Validation()
        {
            var txt = "";
            if (txtNewPass.Text != txtConfirmnewPass.Text)
            {
                txt+="Mật khẩu mới không trùng khớp!\n";
            }
            if(User.PasswordHash!= await _userService.GetMD5(txtOldPass.Text) ){
                txt += "Mật khẩu cũ không chính xác!\n";
            }
            if(String.IsNullOrEmpty(txtConfirmnewPass.Text)&& txtConfirmnewPass.Text.Contains(" ")&& txtConfirmnewPass.Text.Length<8&&txtConfirmnewPass.Text.Length>15)
            {
                txt += "Mật khẩu phải từ 8 đến 15 ký tự và không chứa khoảng trắng!";
            }
            if (String.IsNullOrEmpty(txtNewPass.Text) && txtNewPass.Text.Contains(" ") && txtNewPass.Text.Length < 8 && txtNewPass.Text.Length > 15)
            {
                txt += "Mật khẩu phải từ 8 đến 15 ký tự và không chứa khoảng trắng!";
            }
            return txt;
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
