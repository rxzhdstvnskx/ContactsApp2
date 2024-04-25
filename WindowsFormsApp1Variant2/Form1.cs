using ContactsApp;
using ContactsApp1Variant2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1Variant2;

namespace WindowsFormsApp1Variant2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var contact = new Contact(); //Создание экземпляра класса "Contact"
            var contact2 = new Contact(); //Создание второго экземпляра класса "Contact");

            List<Contact> phoneList = new List<Contact>(); //Создание экземпляра класса "Project"



            contact.SetSurname("Oleg");
            contact.SetName("Enough");
            contact.number.SetNumber(77777777777);
            contact.SetBirthday(new DateTime(1977, 7, 7));
            contact.SetMail("example@mail.com");
            contact.SetVk(7777777);

            contact2.SetSurname("Ben");
            contact2.SetName("Big");
            contact2.number.SetNumber(71111111111);
            contact2.SetBirthday(new DateTime(1991, 1, 1));
            contact2.SetMail("Example@yandex.ru");
            contact2.SetVk(111111111);


            phoneList.Add(contact); //Добавление экземляра "Contact" в список
            phoneList.Add(contact2); //Добавление экземляра "Contact2" в список


            for (int i = 0; i < phoneList.Count; i++) 
            //Цикл для вывода накопленной информации
            //В списке "phoneList" в случае, если 
            //Поля класса "Contact" находятся под 
            //Модификатором "private"
            {
                Console.WriteLine(phoneList[i].GetName());
                Console.WriteLine(phoneList[i].GetSurname());
                Console.WriteLine(phoneList[i].number.GetNumber());
                Console.WriteLine(phoneList[i].GetBirthday());
                Console.WriteLine(phoneList[i].GetMail());
                Console.WriteLine(phoneList[i].GetVk());
                Console.WriteLine(" ");
            }

            ProjectManager.SaveToFile(phoneList); //Загрузка списка контактов в файл
            //Console.WriteLine(ProjectManager.LoadFromFile()); //Выгрузка их файла
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
