using System;
using System.Collections.Generic;

public class Scripture
{
    private List<Word> _words;
    private Reference _ref;
    private Random _random;

    public Scripture(string bookName, int chapter, int verseNumber, int endVerse, string scriptureText)
    {
        _ref = new Reference();
        _ref.SetBook(bookName);
        _ref.SetChapter(chapter);
        _ref.SetVerse(verseNumber);
        _ref.SetEndVerse(endVerse);

        _words = new List<Word>();
        _random = new Random();

        string[] wordArray = scriptureText.Split(" ");

        foreach (string text in wordArray)
        {
            Word word = new Word();
            word.SetWord(text);
            _words.Add(word);
        }
    }

    public string GetReference(int chapter, int verseNumber, int endVerse, string bookName)
    {
        Reference reference = new Reference();
        reference.SetBook(bookName);
        reference.SetChapter(chapter);
        reference.SetVerse(verseNumber);
        reference.SetEndVerse(endVerse);

        return reference.GetBook() + " " + reference.GetChapter() + ":" + reference.GetVerse();
    }

    public string Display()
    {
        string displayText = "";

        displayText += _ref.GetBook() + " ";
        displayText += _ref.GetChapter() + ":";
        displayText += _ref.GetVerse();

        if (_ref.GetEndVerse() != 0)
        {
            displayText += "-" + _ref.GetEndVerse();
        }

        displayText += " ";

        foreach (Word word in _words)
        {
            displayText += word.GetWord() + " ";
        }

        return displayText.Trim();
    }

    public void HideRandomWords(int numberToHide)
    {
        int wordsHidden = 0;

        while (wordsHidden < numberToHide && !IsCompletelyHidden())
        {
            int randomIndex = _random.Next(_words.Count);

            if (!_words[randomIndex].IsHidden())
            {
                _words[randomIndex].Hide();
                wordsHidden++;
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}