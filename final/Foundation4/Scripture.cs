using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public string Display()
    {
        List<string> pieces = new List<string>();
        foreach (Word w in _words)
        {
            pieces.Add(w.Display());
        }

        return $"{_reference.GetDisplayText()} - {string.Join(" ", pieces)}";
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> available = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                available.Add(i);
            }
        }

        for (int i = 0; i < numberToHide && available.Count > 0; i++)
        {
            int pickIndex = _random.Next(available.Count);
            int wordIndex = available[pickIndex];

            _words[wordIndex].Hide();
            available.RemoveAt(pickIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
