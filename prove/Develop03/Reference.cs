public class Reference
{
    private int _chapter;
    private int _verseNumber;
    private int _endVerse;
    private string _book;

    public Reference()
    {
        _book = "";
        _chapter = 0;
        _verseNumber = 0;
        _endVerse = 0;
    }

    public Reference(string book, int chapter, int verseNumber)
    {
        _book = book;
        _chapter = chapter;
        _verseNumber = verseNumber;
        _endVerse = 0;
    }

    public Reference(string book, int chapter, int verseNumber, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verseNumber = verseNumber;
        _endVerse = endVerse;
    }

    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }

    public void SetVerse(int verse)
    {
        _verseNumber = verse;
    }

    public void SetBook(string book)
    {
        _book = book;
    }

    public void SetEndVerse(int endVerse)
    {
        _endVerse = endVerse;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetVerse()
    {
        return _verseNumber;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }

    public string GetBook()
    {
        return _book;
    }
}