using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace GlanApp
{
    /// <summary>
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        public UserPageWindow()
        {
            InitializeComponent();

            btnCreateDocument.Click += BtnCreateDocument_Click;
        }

        private void BtnCreateDocument_Click(object sender, RoutedEventArgs e)
        {
            bool isWhiteSpace = !string.IsNullOrWhiteSpace(textBoxNumberDogovor.Text)
                && !string.IsNullOrWhiteSpace(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxPatronymic.Text)
                && !string.IsNullOrWhiteSpace(textBoxSeriesPassport.Text) && !string.IsNullOrWhiteSpace(textBoxNumberPassport.Text)
                && !string.IsNullOrWhiteSpace(textBoxLocationPassport.Text) && !string.IsNullOrWhiteSpace(textBoxCodePassport.Text)
                && !string.IsNullOrWhiteSpace(textBoxAddressPassport.Text) && !string.IsNullOrWhiteSpace(textBoxPostEmployee.Text)
                && !string.IsNullOrWhiteSpace(textBoxPostDepartament.Text) && !string.IsNullOrWhiteSpace(textBoxSalary.Text)
                && !string.IsNullOrWhiteSpace(textBoxMounthCount.Text);

            if (isWhiteSpace)
            {
                var data = new Dictionary<string, string> 
                {
                    { "<NUMBER_DOGOVOR>", textBoxNumberDogovor.Text },
                    { "<DATE_DOGOVOR>",  DateTime.Now.ToString("dd.MM.yyyy")},
                    { "<FIRST_NANE>", textBoxName.Text },
                    { "<LAST_NAME>", textBoxLastName.Text},
                    { "<PATRONYMIC>", textBoxPatronymic.Text },
                    { "<SERIES_PASPORT>", textBoxSeriesPassport.Text},
                    { "<NUMBER_PASPORT>", textBoxNumberPassport.Text },
                    { "<POST_EMPLOYEE>", textBoxPostEmployee.Text },
                    { "<POST_DEPARTAMENT>", textBoxPostDepartament.Text },
                    { "<DATE_START_WORK>", textBoxDateDateStartWork.Text },
                    { "<COUNT_MOUNTH>", textBoxMounthCount.Text },
                    { "<SALARY>", textBoxSalary.Text },
                    { "<FIRST_NANE_2>", textBoxName.Text },
                    { "<LAST_NAME_2>", textBoxLastName.Text},
                    { "<PATRONYMIC_2>", textBoxPatronymic.Text },
                    { "<SERIES_PASPORT_2>", textBoxSeriesPassport.Text},
                    { "<NUMBER_PASPORT_2>", textBoxNumberPassport.Text },
                    { "<LOCATION_PASPORT>", textBoxLocationPassport.Text },
                    { "<DATE_PASPORT>", textBoxDatePassport.Text },
                    { "<CODE_DEPARTAMENT_PASPORT>", textBoxCodePassport.Text },
                    { "<ADDRESS_REGISTR>", textBoxAddressPassport.Text},
                    { "<DATE_DOGOVOR_2>",  DateTime.Now.ToString("dd.MM.yyyy")}
                };

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Документ MS Word (*.doc)|*.doc";
                if (saveFileDialog.ShowDialog() == true)
                {
                    var helper = new WordHelper("template_dogovr.doc", saveFileDialog.FileName);

                    var isSave = helper.Process(data);
                    if (isSave == true)
                    {
                        MessageBox.Show("Файл сохранен");
                    } else
                    {
                        MessageBox.Show("Ошибка!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Проверьте введенность всех данных");
            }
        }
    }
}
