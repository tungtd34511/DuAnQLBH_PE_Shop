using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Data.Ultilities.Enums;
using App.Business.Sevices.Staffs;
using App.Data.Entities;

namespace App.Views.Views.Staff
{
    public partial class ThemNhanV : Form
    {
        private IUserService _iUserService;
        string _linkAnh = "";
        public ThemNhanV(IUserService iUserService)
        {
            InitializeComponent();
            _iUserService = iUserService;
        }
        private string GetUserNameByEmail(string email)
        {
            var mail = new System.Net.Mail.MailAddress(email);
            return mail.User;
        }
        public class Validator
        {
            public static IEnumerable<string> ValidateUI(string email)
            {
                if (string.IsNullOrEmpty(email))
                {
                    yield return "Email không được để trống";
                }
                yield break;
            }
        }
        public void loadimg(ref string imgname)
        {
            OpenFileDialog fileimgname = new OpenFileDialog();
            if (fileimgname.ShowDialog() == DialogResult.OK)
            {
                imgname = fileimgname.FileName;
            }

        }
        private void btn_ThemAnh_Click(object sender, EventArgs e)
        {
            loadimg(ref _linkAnh);
            ptb_Anh.Image = new Bitmap(_linkAnh);
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            string email = tb_Email.Text;

            // Nên validate trước khi lưu
            foreach (var msg in Validator.ValidateUI(email))
            {
                // Validate Email, null, empty,...
                //Validator là mình tạo class 
                MessageBox.Show(msg);
                return;
            }
            // Đoạn này là set giá trị
            DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var user = new User()
                {
                    UserName = GetUserNameByEmail(tb_Email.Text),
                    //Role = _iUserService.GetAllUser()[cbb_ChucVu.SelectedIndex].Role,
                    Role = Role.Staff,
                    Status = UserStatus.FirstLogin,
                    Id = Guid.NewGuid(),
                    UserDetail = new UserDetail()
                    {
                        Name = tb_HoTen.Text,
                        PhoneNumber = tb_Sdt.Text,
                        Gender = rdb_Nam.Checked == true ? Gender.Male : rdb_Nu.Checked == true ? Gender.Female : Gender.UniSex,
                        Email = tb_Email.Text,
                        CCCD = tb_Cccd.Text,
                        Address = tb_DiaChi.Text,
                        DoB = dtp_NgaySinh.Value,
                        Created = DateTime.Now,
                        ImagePath = _linkAnh,
                    }
                };
                _iUserService.Save(user);
                MessageBox.Show("Thêm nhân viên thành công");
            }
        }
        public void LoadCbbRole()
        {
            foreach (var x in _iUserService.GetAllUser())
            {
                cbb_ChucVu.Items.Add(x.Role);
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            cbb_ChucVu.Text = "";
            tb_HoTen.Text = "";
            tb_Sdt.Text = "";
            rdb_Nam.Checked = false;
            rdb_Nu.Checked = false;
            tb_Email.Text = "";
            tb_Cccd.Text = "";
            tb_DiaChi.Text = "";
            dtp_NgaySinh.Value = DateTime.Now;
            ptb_Anh.Visible = false;
        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();


                //this.Close();
            }
        }
    }
}
