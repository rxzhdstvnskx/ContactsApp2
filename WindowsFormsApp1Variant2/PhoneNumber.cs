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
        public long Number;

        /// <summary>
        /// Метод-сеттер, предназначеннный для внесения номера телефона экземпляра.
        /// </summary>
        public void SetNumber(long number)
        {

            var result = 0;
            long temp = number;

            while (temp > 0)
            {
                temp = temp / 10;
                result++;

            }

            if (result != 11 || (number / 10000000000) != 7)
            {
                throw new ArgumentException("Неверный номер");
            }
            else
            {
                Number = number;
            }
        }
        /// <summary>
        /// Метод-геттер, предназначеннный для получения номера телефона экземпляра.
        /// </summary>
        public long GetNumber()
        {
            return Number;
        }
    }
}

