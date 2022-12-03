using App.Business.Sevices.Users;
using App.Business.Ultilities.Mails;
using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace App.Views.Views.Users
{
    public partial class AddUser : Form
    {
        private readonly IUserService _userService;
        public Role[] Roles { get; set; } = {Role.Admin,Role.Staff};
        public Gender[] Genders { get; set; } = { Gender.Male,Gender.Female,Gender.UniSex};
        public Data.Entities.User User { get; set; }
        public AddUser(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!@£$%^&*()#€";
        public string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,int passwordSize)
        {
            char[] _password = new char[passwordSize];
            string charSet = "";
            System.Random _random = new Random();
            int counter;


            if (useLowercase) charSet += LOWER_CASE;

            if (useUppercase) charSet += UPPER_CASE;

            if (useNumbers) charSet += NUMBERS;

            if (useSpecial) charSet += SPECIALS;

            for (counter = 0; counter < passwordSize; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return string.Join(null, _password);
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            User = new();
            User.UserDetail = new();
            CombRole.Items.AddRange(Roles.ToList().Select(c=>c.ToString()).ToArray());
            CombRole.SelectedIndex = 1;
            combGender.SelectedIndex = 0;
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var id = Guid.NewGuid();
            User.Id= id;
            User.Status = UserStatus.FirstLogin;
            User.UserName = "Peshop" + GeneratePassword(true, true, true, false, 4);

            User.PasswordHash = GeneratePassword(true, true, true, false, 8);
            User.Role = Roles[CombRole.SelectedIndex];
            User.UserDetail.Name = txtName.Text;
            User.UserDetail.Gender = Genders[combGender.SelectedIndex];
            User.UserDetail.DoB = datePickerDob.Value;
            User.UserDetail.Created = DateTime.Now;
            User.UserDetail.Email = txtEmail.Text;
            User.UserDetail.Address = TxtAddress.Text;
            User.UserDetail.CCCD = txtCCCD.Text;
            User.UserDetail.PhoneNumber = txtPhoneNumber.Text;
            User.UserDetail.ImagePath = "C:\\Users\\taduy\\source\\repos\\DuAnQLBH_PE_Shop\\App.Business\\Images\\6d391946-6c70-4c79-ad96-fd4f058eb0e7.jpg";
			SentMail.SendMailGoogleSmtp("tungtdph16451@fpt.edu.vn", "taduytung24112000@gmail.com", "Tài Khoản và Mật khẩu từ Egale", "<h1>Tài khoản <h1/>\n" + $"{User.UserName}" + "<h1>Mật khẩu <h1/>\n" + $"{User.PasswordHash}"

					, "tungtdph16451@fpt.edu.vn", "Taduytung123");
			if (await _userService.AddUser(User))
            {
				
				MessageBox.Show("Thêm mới nhân viên thành công!");
                Close();
            }
            else
            {
                MessageBox.Show("Thêm mới nhân viên thất bại");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
