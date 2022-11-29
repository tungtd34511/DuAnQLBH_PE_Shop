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
    public partial class UserDetails : Form
    {
        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;
        public Data.Entities.User User { get; set; }
        public Data.Entities.UserDetail UserDetail { get; set; }
        public UserDetails(IUserService userService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userService = userService;
            _serviceProvider = serviceProvider;
        }
        private async Task LoadDetails()
        {
            
            //
            LblName.Text = UserDetail.Name;
            LblPhoneNumber.Text = UserDetail.PhoneNumber;
            LblCCCD.Text =  UserDetail.CCCD;
            LblDob.Text = UserDetail.DoB.ToString("dd/MM/yyyy");
            LblDateCreated.Text = UserDetail.Created.ToString("dd/MM/yyyy");
            LblEmail.Text = UserDetail.Email;
            LblRole.Text = User.Role.ToString();
            LblSex.Text = UserDetail.Gender.ToString();
            TxtAdress.Text = UserDetail.Address;
            txt_Email.Text = UserDetail.Email.Split("@").First();
            txt_lastName.Text = UserDetail.Name.Split(" ").Last();
            try
            {
                panlImg.BackgroundImage = Image.FromFile(UserDetail.ImagePath);
            }
            catch
            {

            }
        }

        private async void UserDetails_Load(object sender, EventArgs e)
        {
            UserDetail = User.UserDetail;
            await LoadDetails();
        }

        private async void vbButton1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UserDetail.ImagePath = openFileDialog.FileName;
                    panlImg.BackgroundImage = Image.FromFile(UserDetail.ImagePath);
                    await _userService.UpdateImage(UserDetail);
                }
            }
        }
        private void vbButton2_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<UpdateUser>();
            form.Detail = UserDetail;
            form.FormClosed += async (o, s) =>
            {
                await LoadDetails();
            };
            form.ShowDialog();
        }

        private void vbButton3_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<ChangePassword>();
            form.User = User;
            form.ShowDialog();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public async Task IsNotHome()
        {
            BtnBack.Visible = true;
            vbButton2.Visible = false;
            vbButton3.Visible = false;
        }
    }
}
