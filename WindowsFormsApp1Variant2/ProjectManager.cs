using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ContactsApp
{
    /// <summary>
    /// Класс, который копирует списки контактов из приложения и добавляет их в отдельный файл на компьютере.
    /// </summary>
    public class ProjectManager
    {
        public static void SaveToFile(Project project)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Mishaxd\Desktop\oeplabs.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и c объект, который хотим сериализовать
                serializer.Serialize(writer, project);
            }
        }


        public static Project LoadFromFile()

        {
            Project project = null;
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(@"C:\Users\Mishaxd\Desktop\oeplabs.txt"))
            using (JsonReader reader = new JsonTextReader(sr))

                project = (Project)serializer.Deserialize<Project>(reader);


            return project;
        }
    }
}