using Homework;
CD newSong1 = new CD("Title1", "Artist1", 1970);
CD newSong2 = new CD("Title2", "Artist2", 2015);
CD newSong3= new CD("Title3", "Artist3", 1922);
CD newSong4 = new CD("Title4", "Artist4", 2010);
CD song = new CD();

Console.WriteLine();

List<CD> list = CD.CreateCdList(newSong1, newSong2, newSong3, newSong4, song);

Console.WriteLine("Не сортированный список компакт-дисков\n");
foreach (CD cd in list)
{
    cd.PrintInfo();
    Console.WriteLine();
}

List<CD> sorted = CD.YearOfReleaseSort(list);

Console.WriteLine("Сортированный список компакт-дисков\n");
foreach (CD cd in sorted)
{
    cd.PrintInfo();
    Console.WriteLine();
}

Console.WriteLine("Поиск компакт-дисков по названию и автору\n");
CD.CdArtistSearch(list, "Artist1");
Console.WriteLine();
CD.CdNameSearch(list, "Title3");
Console.WriteLine();

Console.WriteLine("Количество компакт-дисков выпущенных после 2000 года");
Console.WriteLine(CD.CountDiscsReleasedAfterYear(list, 2000));