using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ContactsApp1Variant2
{
    /// <summary>
    /// Класс, предназначенный для хранения информации об абоненте.
    /// </summary>
    public class Contact

    {
        public string Surname;
        public string Name;
        public PhoneNumber number = new PhoneNumber();
        public DateTime Birthday;
        public string Mail;
        public int IdVk;

        /// <summary>
        /// Метод-сеттер, предназначеннный для запсии фамилии экземпляра класса.
        /// </summary>
        public void SetSurname(string surname)
        {
            if (!string.IsNullOrEmpty(surname) && surname.Length <= 50)
            {
                surname = char.ToUpper(surname[0]) + surname.Substring(1);
                Surname = surname;
            }
            else
            {
                throw new ArgumentException("Некорректные данные");
            }
        }

        /// <summary>
        /// Метод-сеттер, предназначеннный для запсии имени экземпляра класса.
        /// </summary>
        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name) && name.Length <= 50)
            {
                name = char.ToUpper(name[0]) + name.Substring(1);
                Name = name;
            }
            else
            {
                throw new ArgumentException("Некорректные данные");
            }
        }

        /// <summary>
        /// Метод-сеттер, предназначеннный для запсии даты рождения экземпляра класса.
        /// </summary>
        public void SetBirthday(DateTime birthday)
        {
            if (birthday.Year > 1900 && birthday.Date <= DateTime.Today)
            {
                Birthday = birthday;
            }
            else
            {
                throw new ArgumentException("Некорректные данные");
            }

        }

        /// <summary>
        /// Метод-сеттер, предназначеннный для запсии адреса электронной почты экземпляра класса.
        /// </summary>
        public void SetMail(string mail)
        {
            if (!string.IsNullOrEmpty(mail) && mail.Length <= 50)
            {
                Mail = mail;
            }
            else
            {
                throw new ArgumentException("Некорректные данные");
            }
        }

        /// <summary>
        /// Метод-сеттер, предназначеннный для запсии Id-страницы "ВКонтакте" экземпляра класса.
        /// </summary>
        public void SetVk(int id)
        {
            string ident = id.ToString();

            if (string.IsNullOrEmpty(ident) && ident.Length > 15)
            {
                throw new ArgumentException("Неверный номер");
            }

            else IdVk = id;

        }

        /// <summary>
        /// Метод-геттер, предназначеннный для получения фамилии экземпляра класса.
        /// </summary>
        public string GetSurname()
        {
            return Surname;
        }

        /// <summary>
        /// Метод-геттер, предназначеннный для получения имени экземпляра класса.
        /// </summary>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// Метод-геттер, предназначеннный для получения даты рождения экземпляра класса.
        /// </summary>
        public DateTime GetBirthday()
        {
            return Birthday;
        }

        /// <summary>
        /// Метод-геттер, предназначеннный для получения адреса электронной почты экземпляра класса.
        /// </summary>
        public string GetMail()
        {
            return Mail;
        }

        /// <summary>
        /// Метод-геттер, предназначеннный для получения id-старницы "ВКонтакте" экземпляра класса.
        /// </summary>
        public int GetVk()
        {
            return IdVk;
        }
    }
}
