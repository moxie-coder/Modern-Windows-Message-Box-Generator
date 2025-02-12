using Microsoft.Win32;

namespace Windows_Task_Dialog_Generator
{
    public static class ThemeProvider
    {
        /// <summary>
        /// Set target control's background and foreground color and iterate child.
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="ColorTheme"></param>
        public static void ApplyThemeRecursive(Control Target, Dictionary<Type, (Color, Color)> ColorTheme)
        {
            Type TargetType = Target.GetType();

            //(Target.ForeColor, Target.BackColor) = ColorTheme[TargetType];
            try
            {
                (Target.ForeColor, Target.BackColor) = ColorTheme[TargetType];
            }
            catch (KeyNotFoundException)
            {
                (Target.ForeColor, Target.BackColor) = ColorTheme[TargetType.BaseType];
            }

            foreach (Control TargetChild in Target.Controls)
            {
                ApplyThemeRecursive(TargetChild, ColorTheme);
            }
        }

        public static bool IsSystemDarkTheme()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
            {
                return key?.GetValue("AppsUseLightTheme") as int? == 0;
            }
        }

        // Type => Foreground Color, Background Color
        public static Dictionary<Type, (Color, Color)> LightThemeColors = new()
        {
            { typeof(Form), (SystemColors.ControlText , SystemColors.Control) },

            { typeof(Button), (SystemColors.WindowText, SystemColors.Window) },
            { typeof(TextBox), (SystemColors.WindowText, SystemColors.Window) },
            { typeof(Label), (SystemColors.ControlText, SystemColors.Control) },

            { typeof(ComboBox), (SystemColors.WindowText, SystemColors.Window) },
            { typeof(CheckBox), (SystemColors.ControlText, SystemColors.Control) },
            { typeof(RadioButton), (SystemColors.ControlText, SystemColors.Control) },

            { typeof(FlowLayoutPanel), (SystemColors.ControlText, SystemColors.Control) },
            { typeof(GroupBox), (SystemColors.ControlText, SystemColors.Control) }
        };

        // Type => Foreground Color, Background Color
        public static Dictionary<Type, (Color, Color)> DarkThemeColors = new()
        {
            { typeof(Form), (DarkThemePallet.Text, DarkThemePallet.Base) },

            { typeof(Button), (DarkThemePallet.Text, DarkThemePallet.Element) },
            { typeof(TextBox), (DarkThemePallet.Text, DarkThemePallet.Element) },
            { typeof(Label), (DarkThemePallet.Text, DarkThemePallet.Base) },

            { typeof(ComboBox), (DarkThemePallet.Text, DarkThemePallet.Element) },
            { typeof(CheckBox), (DarkThemePallet.Text, DarkThemePallet.Base) },
            { typeof(RadioButton), (DarkThemePallet.Text, DarkThemePallet.Base) },

            { typeof(FlowLayoutPanel), (DarkThemePallet.Text, DarkThemePallet.Base) },
            { typeof(GroupBox), (DarkThemePallet.Text, DarkThemePallet.Base) }
        };
    }

    public static class DarkThemePallet
    {
        public static Color Base = ColorTranslator.FromHtml("#202020");
        public static Color Element = ColorTranslator.FromHtml("#353535");
        public static Color Text = ColorTranslator.FromHtml("#FFFFFF");
        public static Color DisabledText = ColorTranslator.FromHtml("#AAAAAA");
    }
}
