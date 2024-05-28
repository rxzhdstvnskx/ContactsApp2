using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactsApp
{
    /// <summary>
    /// Класс, который содержит список всех контактов, созданных в приложении.
    /// </summary>
    /// 

    public class Project
    {
        private List<Contact> PhoneBook;

        public List<Contact> Contactslist
        {
            get
            {
                return PhoneBook;
            }
            set
            {
                PhoneBook = value;
            }
        }


    }
}