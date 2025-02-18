using System;
using System.Numerics;

namespace Homework
{
    class CD
    {

        private static uint _nextCatalogNumber = 1;
        public string Title { get; set; }
        public string Artist { get; set; }
        public int YearOfRelease { get; set; }
        public uint CatalogNumber { get; }

        public CD()
        {
            bool isValidYear;
            do
            {
                Console.WriteLine("Введите название песни:");
                Title = Console.ReadLine();
                Console.WriteLine("Введите исполнителя:");
                Artist = Console.ReadLine();
                Console.WriteLine("Введите год выпуска:");
                string yearInput = Console.ReadLine();

                isValidYear = int.TryParse(yearInput, out int year);

                if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Artist) || !isValidYear)
                {
                    Console.WriteLine("Ошибка. Название песни, имя Артиста или год выпуска введены некорректно");
                }
                else{
                    YearOfRelease = year;
                }
            }
            while (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Artist) || !isValidYear);

            CatalogNumber = _nextCatalogNumber;
            _nextCatalogNumber++;
        }
        public CD(string title, string artist, int yearOfRelease)
        {

            Title = title;
            Artist = artist;
            YearOfRelease = yearOfRelease;
            CatalogNumber = _nextCatalogNumber;
            _nextCatalogNumber++;
        }

        public static void CdNameSearch(List<CD> cdList, string title)
        {
            bool found = false;
            foreach (CD cd in cdList) {
              if(cd.Title == title)
              {
                cd.PrintInfo();
                found = true;
              }
            }

            if (!found) {
                Console.WriteLine("Компакт-диск с таким названием песни не найден");
            }
        }

        public static void CdArtistSearch(List<CD> cdList, string artist)
        {
            bool found = false;
            foreach (CD cd in cdList)
            {
                if (cd.Artist == artist)
                {
                    cd.PrintInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Компакт-диск с таким автором не найден");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Artist: {Artist}");
            Console.WriteLine($"CatalogNumber: {CatalogNumber}");
            Console.WriteLine($"YearOfRelease {YearOfRelease}");
        }

        public static List<CD> CreateCdList(params CD[] cdArr)
        {
            List<CD> cdList = new List<CD>();
            foreach (CD cd in cdArr) {
                cdList.Add(cd);
            }

            return cdList;
        }

        public static List<CD> YearOfReleaseSort(List<CD> cdList) {
            List<CD> temp = new List<CD>(cdList);
            for (int i = 0; i < cdList.Count()-1; ++i)
            {
                for(int j = i+1; j < cdList.Count(); ++j)
                {
                    if (temp[i].YearOfRelease > temp[j].YearOfRelease)
                    {
                        (temp[i], temp[j]) = (temp[j], temp[i]);
                    }      
                }   
            }
            return temp;
        }

        public static int CountDiscsReleasedAfterYear(List<CD> cdList, int year) {
            int count = 0;
            foreach (CD cd in cdList) {
                if (cd.YearOfRelease > year) {
                    count++;
                }
            }
            return count;
        }

    }
}
