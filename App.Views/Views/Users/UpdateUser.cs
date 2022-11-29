using App.Business.Sevices.Users;
using App.Data.Entities;
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

namespace App.Views.Views.Users
{
    public partial class UpdateUser : Form
    {
        private readonly IUserService _userService;
        public UserDetail Detail { get; set; }
        private readonly List<Gender> genders = new() { Gender.Male, Gender.Female, Gender.UniSex };
        public UpdateUser(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }
        private async Task AddCombgender()
        {
            combGender.Items.AddRange(genders.Select(c=>c.ToString()).ToArray());
        }

        private async void UpdateUser_Load(object sender, EventArgs e)
        {
            await AddCombgender();
            txtCCCD.Text = Detail.CCCD;
            txtEmail.Text = Detail.Email;
            txtPhoneNumber.Text = Detail.PhoneNumber;
            TxtAddress.Text = Detail.Address;
            txtName.Text = Detail.Name;
            datePickerDob.Value = Detail.DoB;
            combGender.SelectedIndex = genders.IndexOf(Detail.Gender);
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            Detail.Name = txtName.Text;
            Detail.CCCD = txtCCCD.Text;
            Detail.Email = txtEmail.Text;
            Detail.PhoneNumber = txtPhoneNumber.Text;
            Detail.DoB = datePickerDob.Value;
            Detail.Address = TxtAddress.Text;
            Detail.Gender = genders[combGender.SelectedIndex];
            if(await _userService.UpdateUser(Detail))
            {
                MessageBox.Show("Cập nhật thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
