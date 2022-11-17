using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Views.Models.Controls
{
    public class GadientPanel : Panel
    {
        private readonly Panel _panel = new();
        private Color _topLeftColor = Color.MediumSlateBlue;
        private Color _bottomRightColor = Color.HotPink;
        private int _borderRadius = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
                Point startPoint = new(0, 0);
                Point endPoint = new(this.Width, this.Height);

                LinearGradientBrush lgb =
                    new(startPoint, endPoint, _topLeftColor, _bottomRightColor);
                Graphics g = e.Graphics;
                g.FillRectangle(lgb, 0, 0, endPoint.X, endPoint.Y);
                // g.DrawLine(new Pen(Color.Yellow, 1.5f), startPoint, endPoint);
                //
                Graphics graph = e.Graphics;

                if (_borderRadius > 1) //Rounded TextBox
                {
                    //-Fields
                    var rectBorderSmooth = ClientRectangle;
                    int smoothSize = 0;
                    using GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, _borderRadius);
                    using Pen penBorderSmooth = new(Parent.BackColor, smoothSize);
                    //-Drawing
                    Region = new Region(pathBorderSmooth); //Set the rounded region of UserControl
                    if (_borderRadius > 15) SetTextBoxRoundedRegion(); //Set the rounded region of TextBox component
                    graph.SmoothingMode = SmoothingMode.AntiAlias;

                    if (true) //Line Style
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.SmoothingMode = SmoothingMode.None;
                    }
                }
               
        }

        public Color TopLeftColor
        {
            get { return _topLeftColor; }
            set
            {
                _topLeftColor = value;
                Invalidate();
            }
        }

        public Color BottomRightColor
        {
            get { return _bottomRightColor; }
            set
            {
                _bottomRightColor = value;
                Invalidate(); //Redraw control
            }
        }

        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                if (value >= 0)
                {
                    _borderRadius = value;
                    Invalidate();//Redraw control
                }
            }
        }
        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            pathTxt = GetFigurePath(_panel.ClientRectangle, 2);
            _panel.Region = new Region(pathTxt);

            pathTxt.Dispose();
        }
        private static GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
