using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ContactsApp1Variant2
{
    public class PhoneNumber
    {
        /// <summary>
        /// Класс, хранящий номер телефона абонента, а также информацию
        /// о составе номера.
        /// </summary>
        private long _number;


        /// <summary>
        /// Свойство, предназначенное для внесения номера телефона экземпляра.
        /// </summary>
        public long Number
        {
            get
            {
                return _number;
            }
            set
            {
                {
                    var result = 0;
                    long temp = value;

                    while (temp > 0)
                    {
                        temp = temp / 10;
                        result++;

                    }

                    if (result != 11 || (value / 10000000000) != 7)
                    {
                        throw new ArgumentException("Неверный номер");
                    }
                    else
                    {
                        _number = value;
                    }

                }

            }
        }
    }
}

