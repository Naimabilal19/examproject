using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace exam
{
    class DictionaryRus
    {
        public string word { get; set; }
        public string word1 { get; set; }

        public DictionaryRus() { }
        public DictionaryRus(string w, string w1) { word = w; word1 = w1; }
        public void Show()
        {
            XDocument xdoc = XDocument.Load("../../Vocab1.xml");
            Console.WriteLine(xdoc);
        }
        public void vibor()
        {
            Console.WriteLine("\nВыберите функцию:\n1)Добавить слово в словарь\n2)Изменить перевод\n" +
                "3)Удалить слово в словаре\n4)Поиск слова\n5)Отобразить словарь\n");
            int c = Convert.ToInt32(Console.ReadLine());

            if (c == 1) { AddToRussian(); }
            else if (c == 2) { EditRus(); }
            else if (c == 3) { DeleteRus(); }
            else if (c == 4) { SearchRu(); }
            else if (c == 5) { Show(); }
        }
        public void AddToRussian()
        {
            XDocument xdoc = XDocument.Load("../../Vocab1.xml");
            XElement root = xdoc.Element("Dictionary");
            Console.WriteLine("\nЗапишите слово и его перевод");
            word1 = Console.ReadLine();
            word = Console.ReadLine();
            if (root != null)
            {
                root.Add(new XElement("Word",
                            new XAttribute("Russian", word1),
                            new XAttribute("English", word)));
                xdoc.Save("../../Vocab1.xml");
            }

            Console.WriteLine(xdoc);
        }
        public void EditRus()
        {
            XDocument xdoc = XDocument.Load("../../Vocab1.xml");
            Console.WriteLine(xdoc);
            Console.WriteLine("\nНапишите слово, которое хотите поменять и его перевод\n");
            string val = Console.ReadLine();
            string ch = Console.ReadLine();
            Console.WriteLine("\nНапишите новое слово и его перевод\n");
            string val1 = Console.ReadLine();
            string ch1 = Console.ReadLine();
            var w = xdoc.Element("Dictionary")?.Elements("Word")
                .FirstOrDefault(p => p.Attribute("Russian")?.Value == val && p.Attribute("English")?.Value == ch);
            if (w != null)
            {
                var engl = w.Attribute("Russian");
                if (engl != null) engl.Value = val1;
                var rus = w.Attribute("English");
                if (rus != null) rus.Value = ch1;
                xdoc.Save("../../Vocab1.xml");
            }
            Console.WriteLine(xdoc);
        }
        public void DeleteRus()
        {
            XDocument xdoc = XDocument.Load("../../Vocab1.xml");
            Console.WriteLine(xdoc);
            XElement root = xdoc.Element("Dictionary");

            if (root != null)
            {
                Console.WriteLine("\nНапишите слово, которое хотите удалить и его перевод\n");
                string del1 = Console.ReadLine();
                string del2 = Console.ReadLine();
                var del = root.Elements("Word")
                    .FirstOrDefault(p => p.Attribute("Russian")?.Value == del1 && p.Attribute("English")?.Value == del2);

                if (del != null)
                {
                    del.Remove();
                    xdoc.Save("../../Vocab1.xml");
                }
            }
            Console.WriteLine(xdoc);
        }
        public void SearchRu()
        {
            XDocument xdoc = XDocument.Load("../../Vocab1.xml");
            Console.WriteLine("\nНапишите слово, которое хотите найти и его перевод\n");
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            var tom = xdoc.Element("Dictionary")?
                .Elements("Word")
                .FirstOrDefault(p => p.Attribute("Russian")?.Value == s1 && p.Attribute("English")?.Value == s2);

            var engl = tom?.Attribute("Russian")?.Value;
            var rus = tom?.Attribute("English")?.Value;

            Console.WriteLine($"Russian: {engl}  English: {rus}");
        }
    }
    class DictionaryEngl
    {
        public string word { get; set; }
        public string word1 { get; set; }

        public DictionaryEngl() { }
        public DictionaryEngl(string w, string w1) { word = w;word1 = w1; }
        public void vibor()
        {
            Console.WriteLine("\nВыберите функцию:\n1)Добавить слово в словарь\n2)Изменить перевод\n" +
                "3)Удалить слово в словаре\n4)Поиск слова\n5)Отобразить словарь\n");
            int c = Convert.ToInt32(Console.ReadLine());

            if (c == 1) { AddToEnglish(); }
            else if (c == 2) { EditEngl(); }
            else if (c == 3) { DeleteEngl(); }
            else if (c == 4) { Search(); }
            else if (c == 5) { Show(); }
        }
        public void Show()
        {
            XDocument xdoc = XDocument.Load("../../Vocab.xml");
            Console.WriteLine(xdoc);
        }
        public void AddToEnglish()
        {
            XDocument xdoc = XDocument.Load("../../Vocab.xml");
            XElement root = xdoc.Element("Dictionary");
            Console.WriteLine("Запишите слово и его перевод\n");
            word = Console.ReadLine();
            word1 = Console.ReadLine();
            if (root != null)
            {
                root.Add(new XElement("Word",
                            new XAttribute("English", word),
                            new XAttribute("Russian", word1)));
                xdoc.Save("../../Vocab.xml");
            }

            Console.WriteLine(xdoc);
        }
        public void EditEngl()
        {
            XDocument xdoc = XDocument.Load("../../Vocab.xml");
            Console.WriteLine(xdoc);
            Console.WriteLine("\nНапишите слово, которое хотите поменять и его перевод\n");
            string val = Console.ReadLine();
            string ch = Console.ReadLine();
            Console.WriteLine("\nНапишите новое слово и его перевод\n");
            string val1 = Console.ReadLine();
            string ch1 = Console.ReadLine();
            var w = xdoc.Element("Dictionary")?.Elements("Word")
                .FirstOrDefault(p => p.Attribute("English")?.Value == val&& p.Attribute("Russian")?.Value == ch);
            if (w != null)
            {
                var engl = w.Attribute("English");
                if (engl != null) engl.Value = val1;
                var rus = w.Attribute("Russian");
                if (rus != null) rus.Value = ch1;
                xdoc.Save("../../Vocab.xml");
            }
            Console.WriteLine(xdoc);
        }
        public void DeleteEngl()
        {
            XDocument xdoc = XDocument.Load("../../Vocab.xml");
            Console.WriteLine(xdoc);
            XElement root = xdoc.Element("Dictionary");

            if (root != null)
            {
                Console.WriteLine("\nНапишите слово, которое хотите удалить и его перевод\n");
                string del1 = Console.ReadLine();
                string del2 = Console.ReadLine();
                var del = root.Elements("Word")
                    .FirstOrDefault(p => p.Attribute("English")?.Value == del1 && p.Attribute("Russian")?.Value == del2);
            
                if (del != null)
                {
                    del.Remove();
                    xdoc.Save("../../Vocab.xml");
                }
            }
              Console.WriteLine(xdoc);
        }
        public void Search()
        {
            XDocument xdoc = XDocument.Load("../../Vocab.xml");
            Console.WriteLine("\nНапишите слово, которое хотите найти и его перевод\n");
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            var tom = xdoc.Element("Dictionary")?  
                .Elements("Word")             
                .FirstOrDefault(p => p.Attribute("English")?.Value == s1 && p.Attribute("Russian")?.Value == s2);

            var engl = tom?.Attribute("English")?.Value;
            var rus = tom?.Attribute("Russian")?.Value;

            Console.WriteLine($"English: {engl}  Russian: {rus}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream("Vocab.xml", FileMode.Create);
            FileStream file1 = new FileStream("Vocab1.xml", FileMode.Create);
            DictionaryEngl v = new DictionaryEngl();
            DictionaryRus r = new DictionaryRus();

            Console.WriteLine("\t\tПрограмма словарь\n\tКакой словарь вы хотите создать?\n1)Англо-русский\n2)Русско-английский");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 1) { v.vibor(); }
            else if (n == 2) { r.vibor(); }

            Console.WriteLine("\nXотите продолжить?\n1)Да\n2)Нет\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            do
            {
                    Console.WriteLine("\nС каким словарем вы хотите работать или создать?\n1)Англо-русский\n" +
                 "2)Русско-английский\n3)Закончить");
                    int choice2 = Convert.ToInt32(Console.ReadLine());
                if (choice2 == 1) { v.vibor(); }
                else if (choice2 == 2) { r.vibor(); }
                else if(choice2 == 3) { Environment.Exit(0); }
            }while (choice != 2) ;
        }
    }
}
