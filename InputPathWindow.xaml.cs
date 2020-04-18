using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FileSortingSystemV2._0
{
    /// <summary>
    /// Логика взаимодействия для InputPathWindow.xaml
    /// </summary>
    public partial class InputPathWindow : Window
    {
        Regex reg = new Regex(@"[A-Z]\:\\[а-яА-ЯA-Za-z0-9]*");

        public InputPathWindow()
        {
            InitializeComponent();
            ReDrawUI();
        }

        private void ReDrawUI()
        {
            if (DataBase.isEditing)
            {
                nameInputBox.Text = DataBase.createdPaths[DataBase.openedIndex].constructedName;
                pathInputBox.Text = DataBase.createdPaths[DataBase.openedIndex].constructedPath;
                tagInputBox.Text = DataBase.createdPaths[DataBase.openedIndex].constructedTag;
                createBtn.Content = "Изменить";
                this.Title = "Изменение существующего пути";
            }

            extListBox.Items.Clear();
            foreach (var ext in DataBase.createdPaths[DataBase.openedIndex].constructedExtensions)
            {
                extListBox.Items.Add(ext);
            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBase.createdPaths[DataBase.openedIndex].constructedName = nameInputBox.Text;
            DataBase.createdPaths[DataBase.openedIndex].constructedPath = pathInputBox.Text;
            DataBase.createdPaths[DataBase.openedIndex].constructedTag = tagInputBox.Text;
            
            DataBase.createdPaths[DataBase.openedIndex].constructedExtensions.Clear();
            foreach (var ext in extListBox.Items)
                DataBase.createdPaths[DataBase.openedIndex].constructedExtensions.Add((string)ext);

            // Закрываемся
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!DataBase.isEditing)
            {
                DataBase.createdPaths.RemoveAt(DataBase.openedIndex);
                DataBase.openedIndex = -1;
            }
            DataBase.isEditing = false;
            this.Close();
        }

        private void SortPathBtn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Выбор пути для папки назначения ... ";
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathInputBox.Text = dialog.SelectedPath;
            }
            else
            {
                // ... Nothing
            }
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (extListBox.SelectedIndex > 0)
            {
                extListBox.Items.RemoveAt(extListBox.SelectedIndex);
                extListBox.SelectedIndex = -1;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Сначала выберите расширение для удаления!", "Ошибка");
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            inputCanvas.Visibility = Visibility.Visible;
        }

        private void inputExtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            extListBox.Items.Add(inputExtBox.Text);
            inputCanvas.Visibility = Visibility.Hidden;
        }

        private void declineBtn_Click(object sender, RoutedEventArgs e)
        {
            inputCanvas.Visibility = Visibility.Hidden;
        }
    }
}
