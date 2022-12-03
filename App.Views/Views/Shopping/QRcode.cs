using AForge.Video.DirectShow;
using AForge.Video;
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
using ZXing;
using System.Text.RegularExpressions;
using System.Windows.Media.Media3D;
using static App.Views.Views.Shopping.ShoppingIndex;
using App.Business.Sevices.Shoppings;
using App.Data.Ultilities.ViewModels;

namespace App.Views.Views.Shopping
{
	public partial class QRcode : Form
	{
		private readonly IShoppingService _shoppingService;
		private FilterInfoCollection _filterInfoCollection;
		private VideoCaptureDevice _videoCaptureDevice;
		public ProductInShoppingVm product { get; set; }
		public ProductVariationVm pv { get; set; }
		public AddToCarts ADDtoCarts;

		public QRcode(IShoppingService shoppingService)
		{
			InitializeComponent();
			_shoppingService = shoppingService;
		}
		private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			picVideo.Image = (Bitmap)eventArgs.Frame.Clone();
		}
		BarcodeReader Reader = new BarcodeReader();
		private Result result { get; set; }

		private async void timer1_Tick_1(object sender, EventArgs e)
		{
			if (picVideo.Image != null)
			{
				result = Reader.Decode((Bitmap)picVideo.Image);
				if (result != null)
				{
					txtQR.Text = result.ToString();
					
				}
			}
		}

		private void QRcode_Load(object sender, EventArgs e)
		{
			_filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			foreach (FilterInfo Device in _filterInfoCollection)
			{
				combCam.Items.Add(Device.Name);
			}

			combCam.SelectedIndex = 0;
			timer1.Start();

		}

		private void BtnStart_Click(object sender, EventArgs e)
		{
			_videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[combCam.SelectedIndex].MonikerString);
			_videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
			_videoCaptureDevice.Start();

		}

		private void QRcode_FormClosing(object sender, FormClosingEventArgs e)
		{

			timer1.Stop();
			_videoCaptureDevice.SignalToStop();
		}

		private async void txtQR_TextChanged(object sender, EventArgs e)
		{
			try
			{
				pv = await _shoppingService.GetByQR(int.Parse(txtQR.Text));
				if (pv != null)
				{
					product = await _shoppingService.GetProductShoppingById(pv.ProductId);
					ADDtoCarts(new Data.Ultilities.Catalog.Carts.AddToCartRequest()
					{
						ColorId = pv.ColorId,
						SizeId = pv.SizeId,
						SizeName = pv.SizeName,
						ColorName = pv.SizeName,
						DiscountPercent = product.DiscountPercent,
						Quantity = 1,
						productId = product.Id,
						productName = product.Name,
						PvId = pv.Id
					});
					MessageBox.Show("Quét sản phẩm thành công !");
				}
			}
			catch
			{
				MessageBox.Show($"Mã QR {txtQR.Text} không xác định!");
			}
			
			Thread.Sleep(100);
		}
	}
}
