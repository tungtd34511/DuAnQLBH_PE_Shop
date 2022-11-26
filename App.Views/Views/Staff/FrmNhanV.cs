using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Business.Sevices.Staffs;

namespace App.Views.Views.Staff
{
    public partial class FrmNhanV : Form
    {
        private IUserService _iUserService;
        public FrmNhanV(IUserService iUserService)
        {
            InitializeComponent();
            _iUserService = iUserService;
        }
        public void LoadNhanVien()
        {
            dgv_ShowNv.Rows.Clear();
            dgv_ShowNv.ColumnCount = 10;
            dgv_ShowNv.Columns[0].Name = "Chức vụ";
            dgv_ShowNv.Columns[1].Name = "Trạng thái";
            dgv_ShowNv.Columns[2].Name = "Họ Tên";
            dgv_ShowNv.Columns[3].Name = "Số điện thoại";
            dgv_ShowNv.Columns[4].Name = "Giới tính";
            dgv_ShowNv.Columns[5].Name = "Email";
            dgv_ShowNv.Columns[6].Name = "CCCD";
            dgv_ShowNv.Columns[7].Name = "Ngày sinh";
            dgv_ShowNv.Columns[8].Name = "Ngày tạo";
            dgv_ShowNv.Columns[9].Name = "Địa chỉ";
            foreach (var item in _iUserService.ShowAllUser())
            {
                dgv_ShowNv.Rows.Add(item.Role, item.Status, item.Name, item.PhoneNumber, item.Gender, item.Email, item.CCCD, item.DoB, item.Created, item.Address);
            }
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            ThemNhanV nv = new ThemNhanV(_iUserService);
            nv.ShowDialog();
            LoadNhanVien();
        }

        private void Cb_HIenThi_CheckedChanged(object sender, EventArgs e)
        {
            if (Cb_HIenThi.Checked)
            {
                LoadNhanVien();
            }
            else
            {
                
            }
        }
    }
}
