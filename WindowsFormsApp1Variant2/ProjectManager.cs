using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp1Variant2;
using Newtonsoft.Json;


namespace ContactsApp
{
    /// <summary>
    /// Класс, который копирует списки контактов из приложения и добавляет их в отдельный файл на компьютере.
    /// </summary>
    public class ProjectManager
    {
        public static void SaveToFile(object data)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Mishaxd\Desktop\oeplabs.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, data);
            }
        }


        public static object LoadFromFile()

        {
            Contact temp = null;
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(@"C:\Users\Mishaxd\Desktop\oeplabs.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                temp = (Contact)serializer.Deserialize<Contact>(reader);
                Console.WriteLine($"Surname: {temp.Surname}");
                Console.WriteLine($"Name: {temp.Name}");
                Console.WriteLine($"PhoneNumber: {temp.number.Number}");
                Console.WriteLine($"Surname: {temp.Birthday}");
                Console.WriteLine($"E-mail: {temp.Mail}");
                Console.WriteLine($"ID ВКонтакте: {temp.IdVk}");
            }

            return 0;
        }


    }





}