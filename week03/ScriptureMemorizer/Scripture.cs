using System;
using System.Collections.Generic;
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        string[] pieces = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string piece in pieces)
        {
            Word newWord = new Word (piece);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        Random random = new Random();
        int countToHide = Math.Min(Math.Max(numberToHide, 0), visibleWords.Count);

        for (int i = 0; i < countToHide; i++)
        {
            int randomIndex = random.Next(visibleWords.Count);
            Word selectedWord = visibleWords[randomIndex];

            selectedWord.Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", displayWords)}";
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