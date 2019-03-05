using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Newtonsoft.Json;

namespace HelloSpirit
{
    [JsonObject]
    public class SpiritThemeColor
    {
        #region Window
        //ウィンドウ
        [JsonProperty]
        public static SolidColorBrush WindowBackground { get; set; } = new SolidColorBrush(Color.FromRgb(0x2b, 0x2b, 0x2b));
        [JsonProperty]
        public static SolidColorBrush WindowBorderColor { get; set; } = Brushes.LightGray;

        //ウィンドウタイトル
        [JsonProperty]
        public static SolidColorBrush TitleFontColor { get; set; } = Brushes.WhiteSmoke;
        [JsonProperty]
        public static SolidColorBrush WindowTitleBackground { get; set; } = Brushes.Black;

        //最小化ボタン
        [JsonProperty]
        public static SolidColorBrush MinButtonBackground { get; set; } = Brushes.Black;
        [JsonProperty]
        public static SolidColorBrush MinButtonForeground { get; set; } = Brushes.WhiteSmoke;
        [JsonProperty]
        public static SolidColorBrush MinButtonMouseOverBackground { get; set; } = Brushes.DarkGray;

        //閉じるボタン
        [JsonProperty]
        public static SolidColorBrush CloseButtonBackground { get; set; } = Brushes.Black;
        [JsonProperty]
        public static SolidColorBrush CloseButtonForeground { get; set; } = Brushes.WhiteSmoke;
        [JsonProperty]
        public static SolidColorBrush CloseButtonMouseOverBackground { get; set; } = Brushes.Red;
        #endregion

        #region MainWindow
        //設定ボタン
        [JsonProperty]
        public static SolidColorBrush SettingButtonBackground { get; set; } = Brushes.Black;
        [JsonProperty]
        public static SolidColorBrush SettingButtonMouseOverBackground { get; set; } = Brushes.Gray;

        //Hello, {UserName}! テキスト
        [JsonProperty]
        public static SolidColorBrush HelloTextColor { get; set; } = Brushes.WhiteSmoke;

        //SpiritList
        [JsonProperty]
        public static SolidColorBrush ListBackground { get; set; } = Brushes.Black;
        [JsonProperty]
        public static SolidColorBrush ListTitleColor { get; set; } = Brushes.White;

        //SpiritListの削除ボタン (ToDoリスト削除ボタン)
        [JsonProperty]
        public static SolidColorBrush ListDeleteButtonDefaultForeground { get; set; } = Brushes.WhiteSmoke;
        [JsonProperty]
        public static SolidColorBrush ListDeleteButtonDefaultBackground { get; set; } = Brushes.Black;
        [JsonProperty]
        public static SolidColorBrush ListDeleteButtonMouseOverBackground { get; set; } = Brushes.Red;

        //ListBoxの追加ボタン (ToDoリスト追加ボタン)
        [JsonProperty]
        public static SolidColorBrush ListPlusButtonBackground { get; set; } = Brushes.Black;
        [JsonProperty]
        public static SolidColorBrush ListPlusButtonForeground { get; set; } = Brushes.Gray;
        [JsonProperty]
        public static SolidColorBrush ListPlusButtonMouseOverBackground { get; set; } = Brushes.DimGray;

        //タスク追加ボタン
        [JsonProperty]
        public static SolidColorBrush SpiritAddButtonBackground { get; set; } = Brushes.Black;
        [JsonProperty]
        public static SolidColorBrush SpiritAddButtonForeground { get; set; } = Brushes.DimGray;
        [JsonProperty]
        public static SolidColorBrush SpiritAddButtonMouseOverBackground { get; set; } = Brushes.LightGray;

        //フッター
        [JsonProperty]
        public static SolidColorBrush FootterColor { get; set; } = Brushes.DarkGray;
        #endregion

        #region SpiritWindow
        //タスクのタイトルとディスクリプション
        [JsonProperty]
        public static SolidColorBrush SpiritTextBoxForeground { get; set; } = Brushes.WhiteSmoke;

        //タスクのディスクリプション
        [JsonProperty]
        public static SolidColorBrush SpiritDescriptionNormalBackground { get; set; } = Brushes.DimGray;

        //チェックリスト追加ボタン
        [JsonProperty]
        public static SolidColorBrush CheckListAddButtonBackground { get; set; } = WindowBackground;
        [JsonProperty]
        public static SolidColorBrush CheckListAddButtonForeground { get; set; } = Brushes.WhiteSmoke;
        [JsonProperty]
        public static SolidColorBrush CheckListAddButtonMouseOverBackground { get; set; } = Brushes.DimGray;

        //チェックリスト
        [JsonProperty]
        public static SolidColorBrush CheckListBackground { get; set; } = Brushes.DimGray;
        [JsonProperty]
        public static SolidColorBrush CheckListForeground { get; set; } = Brushes.WhiteSmoke;
        [JsonProperty]
        public static SolidColorBrush CheckListMouseOverBackground { get; set; } = Brushes.Gray;

        //チェックリスト終了カウンタ
        [JsonProperty]
        public static SolidColorBrush NumberFontColor { get; set; } = Brushes.WhiteSmoke;

        //タスク削除ボタン
        [JsonProperty]
        public static SolidColorBrush DeleteButtonBackground { get; set; } = WindowBackground;
        [JsonProperty]
        public static SolidColorBrush DeleteButtonForeground { get; set; } = Brushes.WhiteSmoke;
        [JsonProperty]
        public static SolidColorBrush DeleteButtonMouseOverBackground { get; set; } = Brushes.Red;
        #endregion
    }
}
