using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Views.Models.Controls
{
    public class MenuColorTable : ProfessionalColorTable
    {
    //Fields
    private readonly Color _backColor;
    private readonly Color _leftColumnColor;
    private readonly Color _borderColor;
    private readonly Color _menuItemBorderColor;
    private readonly Color _menuItemSelectedColor;
    //Constructor
    public MenuColorTable(bool isMainMenu, Color primaryColor)
    {
        if (isMainMenu)
        {
            _backColor = Color.FromArgb(37, 39, 60);
            _leftColumnColor = Color.FromArgb(32, 33, 51);
            _borderColor = Color.FromArgb(32, 33, 51);
            _menuItemBorderColor = primaryColor;
            _menuItemSelectedColor = primaryColor;
        }
        else
        {
            _backColor = Color.White;
            _leftColumnColor = Color.LightGray;
            _borderColor = Color.LightGray;
            _menuItemBorderColor = primaryColor;
            _menuItemSelectedColor = primaryColor;
        }
    }
    //Overrides
    public override Color ToolStripDropDownBackground { get { return _backColor; } }
    public override Color MenuBorder { get { return _borderColor; } }
    public override Color MenuItemBorder { get { return _menuItemBorderColor; } }
    public override Color MenuItemSelected { get { return _menuItemSelectedColor; } }
    public override Color ImageMarginGradientBegin { get { return _leftColumnColor; } }
    public override Color ImageMarginGradientMiddle { get { return _leftColumnColor; } }
    public override Color ImageMarginGradientEnd { get { return _leftColumnColor; } }

    }
}
