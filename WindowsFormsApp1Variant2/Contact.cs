using ContactsApp1Variant2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ContactsApp
{
    /// <summary>
    /// Класс, предназначенный для хранения информации об абоненте
    /// </summary>
    public class Contact

    {
        private string _name;
        private string _surname;
        private PhoneNumber _phoneNumber = new PhoneNumber();
        private DateTime _birthday = DateTime.Today;
        private string _mail;
        private long _id;



        /// <summary>
        /// Свйоство, предназначеннное для запсии фамилии экземпляра класса.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                {
                    var name = nameof(Surname);

                    throw new ArgumentException($"Длина {name} равна {value.Length}, " + $"а должно быть меньше 50.", name);

                }
                else
                {
                    value = char.ToUpper(value[0]) + value.Substring(1);
                    _surname = value;
                }

            }
        }

        /// <summary>
        /// Свйоство, предназначеннное для запсии имени экземпляра класса.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                {
                    var name = nameof(Name);

                    throw new ArgumentException($"Длина {name} равна {value.Length}, " + $"а должно быть меньше 50.", name);
                }
                else
                {
                    value = char.ToUpper(value[0]) + value.Substring(1);
                    _name = value;
                }

            }
        }

        /// <summary>
        /// Свйоство, предназначеннное для запсии номера телефона.
        /// </summary>
        public PhoneNumber PhoneNumber

        {
            get
            {
                return _phoneNumber;
            }

            set
            {

                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Свйоство, предназначеннное для запсии даты рождения экземпляра класса.
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (value.Year < 1900 || value.Date > DateTime.Today)
                {
                    throw new ArgumentException("Некорректные данные");
                }
                else
                {
                    _birthday = value;
                }

            }
        }

        /// <summary>
        /// Свйоство, предназначеннное для запсии адреса электронной почты экземпляра класса.
        /// </summary>
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                {
                    throw new ArgumentException("Некорректные данные");
                }
                else
                {
                    _mail = value;
                }

            }
        }


        /// <summary>
        /// Свйоство, предназначеннное для запсии Id-страницы "ВКонтакте" экземпляра класса.
        /// </summary>
        public long Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value.ToString().Length > 15)
                {
                    throw new ArgumentException("Неверный id");
                }

                else _id = value;

            }
        }
    }
}
