using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ContactsApp;
using ContactsApp1Variant2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ContactsAppUI
{
    public partial class Form1 : Form
    {
        private Project project = new Project(); //экземпляр класса Project
        private Project temp = new Project(); //экземпляр класса Project, необходимый для того, чтобы подтянуть базу контактов из файла сериализации
        ListBox ContactsListboxSort = new ListBox(); //копия списка контактов интерфейса, необходимая для поиска подстроки среди контактов в интерфейсе формы

        public Form1()
        {
            InitializeComponent();
            project.Contactslist = new List <Contact>(); //создаем новый список в классе Project
            temp = ProjectManager.LoadFromFile(); //переменная, необходимая для копирования базы данных контактов из текстового файла


            if (temp != null) //копируем базу данных в приложение, если она не пустая в файле
            {
                project = temp;
            }

            if (project.Contactslist.Count != 0) //если списсок контактов не пуст
            {

                for (int i = 0; i < project.Contactslist.Count; i++)
                {
                    ContactsListbox.Items.Add(project.Contactslist[i].Surname);//выводим список фамилий в интерфейс приложения

                    if (project.Contactslist[i].Birthday.Date.Day == DateTime.Now.Day &&
                        project.Contactslist[i].Birthday.Date.Month == DateTime.Now.Month) //если дата рождения совпадает с сегодняшней, вывод фамилии контакта в интерфейс
                    {
                        BirthdayListbox.Items.Add(project.Contactslist[i].Surname);
                    }
                }
            }
        }

        private void splitContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExitToolstripmenuitem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ContactsListbox.Sorted = true; //при запуске программы сортируем список выводящихся контактов (фамилий)

            foreach (var item in ContactsListbox.Items) //создаем копию списка фамилий ContactsListbox
            {
                ContactsListboxSort.Items.Add(item);
            }
        }

        private void ContactsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ContactsListbox_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedIndex = ContactsListbox.SelectedIndex;

            if (selectedIndex != -1) //если выбрана строка ListBox
            {
                var selectedValue = ContactsListbox.SelectedItem.ToString(); //переменная, хранит значение выбранной строки
                for (int i = 0; i < project.Contactslist.Count; i++)
                {
                    if (selectedValue == project.Contactslist[i].Surname) //находим в списке ContactList фамилию, которая соответсвует выбранной в selectedValue
                    {
                        NameTextboxMain.Text = project.Contactslist[i].Name; //выводим остальные данные этого контакта
                        SurnameTextboxMain.Text = project.Contactslist[i].Surname;
                        PhoneTextboxMain.Text = project.Contactslist[i].PhoneNumber.Number.ToString();
                        BirthdayTimepickerMain.Value = project.Contactslist[i].Birthday;
                        MailTextboxMain.Text = project.Contactslist[i].Mail;
                        VkTextboxMain.Text = project.Contactslist[i].Id.ToString();
                    }
                }
            }
        }

        private void AddToolstripmenuitem_Click(object sender, EventArgs e)
        {
            var inner = new EditForm(); //создаем форму
            inner.Contact = new Contact(); //создаем экземпляр класса Contact
            inner.ShowDialog(); //выводим форму EditForm
            var addedData = inner.Contact; //записываем в переменную данные, которые передаются в конструктор

            if (inner.DialogResult == DialogResult.OK) //если после данных нажата кнопка ОК
            {
                project.Contactslist.Add(addedData); //в список добавляем данные, введенные в полях формы
                var listboxPreview = addedData.Surname; //переменная, которая хранит фамилию нового контакта
                ContactsListbox.Items.Add(listboxPreview); //отображаем в интерфейс формы добавленную фамилию контакта

                ContactsListboxSort.Items.Clear();
                foreach (var item in ContactsListbox.Items) //создаем копию списка фамилий ContactsListbox
                {
                    ContactsListboxSort.Items.Add(item);
                }

                ProjectManager.SaveToFile(project); //сериализация, обновляем данные в документе

                ContactsListbox.Sorted = true; //сортируем список в интерфейсе формы
            }
        }

        private void EditTolstripmenuitem_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListbox.SelectedIndex; //присваиваем переменной хначение индекса выбранногоконтакта 
            if (selectedIndex != -1) //если пользователь выбрал контакт, то:
            {
                var selectedData = project.Contactslist[selectedIndex]; //экземляр списка под выбранном индексом 
                var inner = new EditForm(); //Создаем форму
                var selectedValue = ContactsListbox.SelectedItem.ToString(); //переменная, хранит значение выбранной строки списка в форме

                for (int i = 0; i < project.Contactslist.Count; i++)
                {
                    if (selectedValue == project.Contactslist[i].Surname) //находим в списке ContactList фамилию, которая соответсвует выбранной в selectedValue
                    {
                        selectedData = project.Contactslist[i];
                        inner.Contact = selectedData; //Передаем форме данные
                    }
                }


                inner.ShowDialog(); //Отображаем форму для редактирования


                if (inner.DialogResult == DialogResult.OK) //если после данных нажата кнопка ОК
                {
                    var updatedData = inner.Contact; //Создание экземпляра класса "Contact"
                    ContactsListbox.Items.RemoveAt(selectedIndex); //Удаление фамилии из списка формы по выбранному индексу
                    project.Contactslist.Remove(selectedData); //Удаление фамилии из списка по выбранному индексу

                    project.Contactslist.Insert(selectedIndex, updatedData); //Вставляем новую фамилию в список по текущему индексу
                    var listboxPreview = updatedData.Surname; //Присваиваем переменной новое значение фамилии,
                                                              //если оно было изменено
                    ContactsListbox.Items.Insert(selectedIndex, listboxPreview); //Отоюражаем в списке формы новую фамилию

                    ContactsListboxSort.Items.Clear();
                    foreach (var item in ContactsListbox.Items) //создаем копию списка фамилий ContactsListbox
                    {
                        ContactsListboxSort.Items.Add(item);
                    }
                    ProjectManager.SaveToFile(project); //Активируем сериализацию в файл
                    ContactsListbox.Sorted = true; //сортируем список в интерфейсе формы
                }

            }

            else //если пользователь не выбрал контакт, то выводим соответсвующий MessageBox
            {
                MessageBox.Show("Сначала выберите контакт из списка", "Выберите контакт", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void RemoveToolstripmenuitem_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListbox.SelectedIndex; //индекс в списке, в нашем случае нужен по размеру

            if (selectedIndex != -1) //если выбран элемент списка
            {
                DialogResult result = MessageBox.Show("Удалить выбраный контакт?", "Удаление", MessageBoxButtons.OKCancel); //вывод подтвержающего окна об удалении

                if (result == DialogResult.OK) //если выбрано ОК
                {
                    var selectedValue = ContactsListbox.SelectedItem.ToString(); //переменная, хранит значение выбранной строки списка в форме

                    for (int i = 0; i < project.Contactslist.Count; i++)
                    {
                        if (selectedValue == project.Contactslist[i].Surname) //находим в списке ContactList фамилию, которая соответсвует выбранной в selectedValue
                        {
                            var selectedData = project.Contactslist[i]; //переменная, хранит экземпляр списка, который необходимо удалить
                            project.Contactslist.Remove(selectedData); //удаляем выбранный контакт
                            ContactsListbox.Items.RemoveAt(selectedIndex); //удаляем выбранный контаки из инерфейса формы
                        }
                    }
                    ContactsListboxSort.Items.Clear();

                    foreach (var item in ContactsListbox.Items) //создаем копию списка фамилий ContactsListbox
                    {
                        ContactsListboxSort.Items.Add(item);
                    }
                    ProjectManager.SaveToFile(project); //сериализация после внесения изменений
                }
            }

            else //вывод предупреждения, если не выбран контакт из списка
            {
                MessageBox.Show("Сначала выберите контакт из списка", "Выберите контакт", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Вы хотите закрыть программу?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;

        }

        private void AboutToolstripmenuIiem_Click(object sender, EventArgs e)
        {
            AboutForm.AboutFormList.ShowForm(); //вывод формы about

        }

        private void FindTextbox_TextChanged(object sender, EventArgs e)
        {
            string searchString = FindTextbox.Text.ToLower(); //переменная, хранит введеную строку в нижнем регистре

            ContactsListbox.Items.Clear(); //очищаем список формы, для того, чтобы вывести контакты, удовлетворяющие поиску

            foreach (string item in ContactsListboxSort.Items) //для каждого контакта в копии списка ContactListbox
            {
                if (item.ToLower().Contains(searchString)) // если перевденная в нижний регистр строка списика содержит введенную подстроку
                {
                    ContactsListbox.Items.Add(item); //выводим в список контакты удовлетворяющие введенной подстроке
                }
            }
        }
    }
}
