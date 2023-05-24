using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ThemeLib;

namespace libs_
{
    public partial class App : Application
    {
        private static string lang;

        public static string Lang
        {
            get { return lang; }
            set
            {
                lang = value;
                var dict = new ResourceDictionary { Source = new Uri($"pack://application:,,,/LangLib;component/Themes/{value}.xaml", UriKind.Absolute) };
                Current.Resources.MergedDictionaries.RemoveAt(1);
                Current.Resources.MergedDictionaries.Insert(1, dict);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\theme.txt", value);
            }
        }

        private static string theme;

        public static string Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                var dict = new ResourceDictionary { Source = new Uri($"pack://application:,,,/ThemeLib;component/Themes/{value}.xaml", UriKind.Absolute) };
                Current.Resources.MergedDictionaries.RemoveAt(0);
                Current.Resources.MergedDictionaries.Insert(0, dict);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\theme.txt", value);
            }
        }
        public App()
        {
            InitializeComponent();
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists($"{desktop}\\theme.txt") && File.Exists($"{desktop}\\lang.txt"))
            {
                Theme = File.ReadAllText($"{desktop}\\theme.txt");
                lang = File.ReadAllText($"{desktop}\\lang.txt");
            }
        }
    }
}
