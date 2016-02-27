using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Microsoft.Win32;

namespace unPacker
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : System.Windows.Controls.UserControl
    {
        Controller control = new Controller();
        DataHandler dataHandler = new DataHandler();
        
        public Settings()
        {
            InitializeComponent();
            location7zTxtBox.Text = dataHandler.Default7zLocation;
            locationDefaultUnpackDir.Text = dataHandler.DefaultUnpackDir;
            locationDefaultUnpackOutputDir.Text = dataHandler.DefaultUnpackOutputDir;
        }

        private void Loc7zBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                location7zTxtBox.Text = dialog.FileName;
            }
        }

        private void saveSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> settingsList = new List<string>();
            settingsList.Add("7z File Location=" + location7zTxtBox.Text);
            settingsList.Add("Default Unpack Dir=" + locationDefaultUnpackDir.Text);
            settingsList.Add("Default Unpack Output Dir=" + locationDefaultUnpackOutputDir.Text);
            dataHandler.writeSettingsToFile(settingsList);
            
        }

        private void locationDefaultUnpackDirBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                locationDefaultUnpackDir.Text = dialog.SelectedPath;
            }
        }

        private void locationDefaultUnpackOutputDirBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                locationDefaultUnpackOutputDir.Text = dialog.SelectedPath;
            }
        }
    }
}
