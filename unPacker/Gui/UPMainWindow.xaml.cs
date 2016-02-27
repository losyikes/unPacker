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
    /// Interaction logic for UPMainWindow.xaml
    /// </summary>
    public partial class UPMainWindow : System.Windows.Controls.UserControl
    {
        Controller control = new Controller();
        DataHandler dataHandler = new DataHandler();
        public UPMainWindow()
        {
            InitializeComponent();
            control.Main = this;
            selectedFolderTxtBlock.Text = dataHandler.DefaultUnpackDir;
            selectedOutputTxtBlock.Text = dataHandler.DefaultUnpackOutputDir;
        }

        void selectFolderBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFolderTxtBlock.Text = dialog.SelectedPath;
            }
            
        }

        private void unPackBtn_Click(object sender, RoutedEventArgs e)
        {
            control.StartUnpacking(selectedFolderTxtBlock.Text, selectedOutputTxtBlock.Text);
        }

        private void selectOutputBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedOutputTxtBlock.Text = dialog.SelectedPath;
            }
        }
    }
}
