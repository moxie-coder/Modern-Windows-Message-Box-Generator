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
        public static void ApplyThemeRecursive(
            Control Target,
            Dictionary<Type, (Color, Color)> ColorTheme
        )
        {
            Type TargetType = Target.GetType();

            if (ColorTheme.TryGetValue(TargetType, out var colors))
            {
                (Target.ForeColor, Target.BackColor) = colors;
            }
            else if (TargetType.BaseType != null && ColorTheme.TryGetValue(TargetType.BaseType, out colors))
            {
                (Target.ForeColor, Target.BackColor) = colors;
            }
            else
            {
                // Fallback to some default colors if no match is found
                (Target.ForeColor, Target.BackColor) = (SystemColors.ControlText, SystemColors.Control);
            }

            foreach (Control TargetChild in Target.Controls)
            {
                ApplyThemeRecursive(TargetChild, ColorTheme);
            }
        }

        public static bool IsSystemDarkTheme()
        {
            using (
                RegistryKey key = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"
                )
            )
            {
                return key?.GetValue("AppsUseLightTheme") as int? == 0;
            }
        }

        // Type => Foreground Color, Background Color
        public static Dictionary<Type, (Color, Color)> LightThemeColors = new()
        {
            { typeof(Form), (SystemColors.ControlText, SystemColors.Control) },
            { typeof(Button), (SystemColors.WindowText, SystemColors.Window) },
            { typeof(TextBox), (SystemColors.WindowText, SystemColors.Window) },
            { typeof(Label), (SystemColors.ControlText, SystemColors.Control) },
            { typeof(ComboBox), (SystemColors.WindowText, SystemColors.Window) },
            { typeof(CheckBox), (SystemColors.ControlText, SystemColors.Control) },
            { typeof(RadioButton), (SystemColors.ControlText, SystemColors.Control) },
            { typeof(FlowLayoutPanel), (SystemColors.ControlText, SystemColors.Control) },
            { typeof(GroupBox), (SystemColors.ControlText, SystemColors.Control) },
        };

        // Type => Foreground Color, Background Color
        public static Dictionary<Type, (Color, Color)> DarkThemeColors = new()
        {
            { typeof(Form), (DarkThemePalette.Text, DarkThemePalette.Base) },
            { typeof(Button), (DarkThemePalette.Text, DarkThemePalette.Element) },
            { typeof(TextBox), (DarkThemePalette.Text, DarkThemePalette.Element) },
            { typeof(Label), (DarkThemePalette.Text, DarkThemePalette.Base) },
            { typeof(ComboBox), (DarkThemePalette.Text, DarkThemePalette.Element) },
            { typeof(CheckBox), (DarkThemePalette.Text, DarkThemePalette.Base) },
            { typeof(RadioButton), (DarkThemePalette.Text, DarkThemePalette.Base) },
            { typeof(FlowLayoutPanel), (DarkThemePalette.Text, DarkThemePalette.Base) },
            { typeof(GroupBox), (DarkThemePalette.Text, DarkThemePalette.Base) },
        };
    }

    public static class DarkThemePalette
    {
        public static Color Base = ColorTranslator.FromHtml("#202020");
        public static Color Element = ColorTranslator.FromHtml("#353535");
        public static Color Text = ColorTranslator.FromHtml("#FFFFFF");
        public static Color DisabledText = ColorTranslator.FromHtml("#AAAAAA");
    }
}
