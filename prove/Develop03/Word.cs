public class Word
{
    private bool _isHidden;
    private string _word;

    public Word()
    {
        _word = "";
        _isHidden = false;
    }

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public string GetWord()
    {
        if (_isHidden)
        {
            return GetHiddenWord();
        }
        else
        {
            return _word;
        }
    }

    public string GetHiddenWord()
    {
        return new string('_', _word.Length);
    }

    public void SetWord(string word)
    {
        _word = word;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
}