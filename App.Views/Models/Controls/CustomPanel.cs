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
    public class CustomPanel : Panel
    {
        private readonly Panel _panel = new();
        private Color _borderColor = Color.MediumSlateBlue;
        private Color _borderFocusColor = Color.HotPink;
        private int _borderSize = 2;
        private bool _underlinedStyle = false;
        private readonly bool _isFocused = false;
        private int _borderRadius = 0;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public Color BorderFocusColor
        {
            get { return _borderFocusColor; }
            set { _borderFocusColor = value; }
        }

        public int BorderSize
        {
            get { return _borderSize; }
            set
            {
                if (value >= 1)
                {
                    _borderSize = value;
                    Invalidate();
                }
            }
        }

        public bool UnderlinedStyle
        {
            get { return _underlinedStyle; }
            set
            {
                _underlinedStyle = value;
                Invalidate();
            }
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                _panel.ForeColor = value;
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (_borderRadius > 1)//Rounded TextBox
            {
                //-Fields
                var rectBorderSmooth = ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -_borderSize, -_borderSize);
                int smoothSize = _borderSize > 0 ? _borderSize : 1;

                using GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, _borderRadius);
                using GraphicsPath pathBorder = GetFigurePath(rectBorder, _borderRadius - _borderSize);
                using Pen penBorderSmooth = new(Parent.BackColor, smoothSize);
                using Pen penBorder = new(_borderColor, _borderSize);
                //-Drawing
                Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl
                if (_borderRadius > 15) SetTextBoxRoundedRegion();//Set the rounded region of TextBox component
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                penBorder.Alignment = PenAlignment.Center;
                if (_isFocused) penBorder.Color = _borderFocusColor;

                if (_underlinedStyle) //Line Style
                {
                    //Draw border smoothing
                    graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                    //Draw border
                    graph.SmoothingMode = SmoothingMode.None;
                    graph.DrawLine(penBorder, 0, Height - 1, Width, Height - 1);
                }
                else //Normal Style
                {
                    //Draw border smoothing
                    graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                    //Draw border
                    graph.DrawPath(penBorder, pathBorder);
                }
            }
        }
        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;


            pathTxt = GetFigurePath(_panel.ClientRectangle, _borderSize * 2);
            _panel.Region = new Region(pathTxt);

            pathTxt.Dispose();
        }
        private static GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new ();
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