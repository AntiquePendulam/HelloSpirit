using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HelloSpirit
{
    public static class SpiritThemeColor
    {
        #region Window
        public static SolidColorBrush WindowBackground { get; set; } = new SolidColorBrush(Color.FromRgb(0x2b, 0x2b, 0x2b));
        public static SolidColorBrush WindowBorderColor { get; set; } = Brushes.LightGray;

        public static SolidColorBrush TitleFontColor { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush WindowTitleBackground { get; set; } = Brushes.Black;

        public static SolidColorBrush MinButtonBackground { get; set; } = Brushes.Black;
        public static SolidColorBrush MinButtonForeground { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush MinButtonMouseOverBackground { get; set; } = Brushes.DarkGray;

        public static SolidColorBrush CloseButtonBackground { get; set; } = Brushes.Black;
        public static SolidColorBrush CloseButtonForeground { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush CloseButtonMouseOverBackground { get; set; } = Brushes.Red;

        public static SolidColorBrush ButtonDefaultBackground { get; set; }
        public static SolidColorBrush ButtonDefaultForeground { get; set; }
        #endregion

        #region MainWindow
        public static SolidColorBrush SettingButtonBackground { get; set; } = Brushes.Black;
        public static SolidColorBrush SettingButtonMouseOverBackground { get; set; } = Brushes.Gray;


        public static SolidColorBrush HelloTextColor { get; set; } = Brushes.WhiteSmoke;

        public static SolidColorBrush ListBackground { get; set; } = Brushes.Black;
        public static SolidColorBrush ListTitleColor { get; set; } = Brushes.White;

        public static SolidColorBrush ListDeleteButtonDefaultForeground { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush ListDeleteButtonDefaultBackground { get; set; } = Brushes.Black;
        public static SolidColorBrush ListDeleteButtonMouseOverBackground { get; set; } = Brushes.Red;

        public static SolidColorBrush ListPlusButtonBackground { get; set; } = Brushes.Black;
        public static SolidColorBrush ListPlusButtonForeground { get; set; } = Brushes.Gray;
        public static SolidColorBrush ListPlusButtonMouseOverBackground { get; set; } = Brushes.DimGray;

        public static SolidColorBrush SpiritAddButtonBackground { get; set; } = Brushes.Black;
        public static SolidColorBrush SpiritAddButtonForeground { get; set; } = Brushes.DimGray;
        public static SolidColorBrush SpiritAddButtonMouseOverBackground { get; set; } = Brushes.LightGray;

        public static SolidColorBrush FootterColor { get; set; } = Brushes.DarkGray;
        #endregion

        #region SpiritWindow

        public static SolidColorBrush SpiritTextBoxBackground { get; set; } = Brushes.Gray;
        public static SolidColorBrush SpiritTextBoxForeground { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush SpiritTextBoxActiveBackground { get; set; } = Brushes.Gray;
        public static SolidColorBrush SpiritTextBoxActiveForeground { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush SpiritTextBoxBorderColor { get; set; } = Brushes.LightGray;

        public static SolidColorBrush SpiritTitleForeground { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush SpiritTitleBorderColor { get; set; } = Brushes.LightGray;

        public static SolidColorBrush SpiritDescriptionNormalBackground { get; set; } = Brushes.DimGray;

        public static SolidColorBrush CheckListAddButtonBackground { get; set; } = Brushes.Black;
        public static SolidColorBrush CheckListAddButtonForeground { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush CheckListAddButtonMouseOverBackground { get; set; } = Brushes.DimGray;

        public static SolidColorBrush CheckListBackground { get; set; } = Brushes.DimGray;
        public static SolidColorBrush CheckListForeground { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush CheckListMouseOverBackground { get; set; } = Brushes.Gray;

        public static SolidColorBrush NumberFontColor { get; set; } = Brushes.WhiteSmoke;

        public static SolidColorBrush DeleteButtonBackground { get; set; } = Brushes.Black;
        public static SolidColorBrush DeleteButtonForeground { get; set; } = Brushes.WhiteSmoke;
        public static SolidColorBrush DeleteButtonMouseOverBackground { get; set; } = Brushes.Red;
        #endregion
    }
}
