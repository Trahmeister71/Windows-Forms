using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SmartPhoneMutex
{
    public partial class Form1 : Form
    {
        List<Button> letterButtons = new List<Button>();
        string text;
        public Form1()
        {
            InitializeComponent();

            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    string buttonText = button.Text.ToLower();
                    foreach (char c in buttonText)
                    {
                        if (Char.IsLetter(c) && !letterButtons.Contains(button))
                        {
                            letterButtons.Add(button);
                            break;
                        }
                    }
                }
            }
            using (StreamReader read = new StreamReader("words.txt"))
            {
                text = read.ReadToEnd();
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            foreach (Button button in letterButtons)
            {
                string buttonText = button.Text.ToLower();
                foreach (char c in buttonText)
                {
                    if (Char.ToLower(e.KeyCode.ToString()[0]) == c)
                    {
                        button.Focus();
                        button.PerformClick();
                        Thread.Sleep(100);
                        richTextBox1.Focus();
                        return;
                    }
                }
            }

        }

        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>()
        {
                { "a", new List<string> { "and", "apple" } },
                { "b", new List<string> { "but", "book" } },
                { "c", new List<string> { "can", "cat" } },
                { "d", new List<string> { "do", "dog" } },
                { "e", new List<string> { "eat", "egg" } },
                { "f", new List<string> { "for", "friend" } },
                { "g", new List<string> { "go", "good" } },
                { "h", new List<string> { "have", "house" } },
                { "i", new List<string> { "in", "important" } },
                { "j", new List<string> { "just", "job" } },
                { "k", new List<string> { "know", "kind" } },
                { "l", new List<string> { "like", "love" } },
                { "m", new List<string> { "my", "man" } },
                { "n", new List<string> { "not", "new" } },
                { "o", new List<string> { "on", "one" } },
                { "p", new List<string> { "please", "people" } },
                { "q", new List<string> { "quite", "quality" } },
                { "r", new List<string> { "really", "room" } },
                { "s", new List<string> { "say", "some" } },
                { "t", new List<string> { "the", "time" } },
                { "u", new List<string> { "us", "under" } },
                { "v", new List<string> { "very", "voice" } },
                { "w", new List<string> { "with", "world" } },
                { "x", new List<string> { "x-ray", "xylophone" } },
                { "y", new List<string> { "you", "yes" } },
                { "z", new List<string> { "zebra", "zero" } }
        };
        private string currentWord = "";

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Mutex mutex = new Mutex(false);
            mutex.WaitOne();
            if (Char.IsLetter(e.KeyChar))
            {
                currentWord += e.KeyChar;
                List<string> matchingWords = new List<string>();
                string[] words = dictionary[currentWord.ToLower().ToCharArray().Last().ToString()].ToArray();
                foreach (string word in words)
                {
                    if (word.StartsWith(currentWord))
                    {
                        matchingWords.Add(word);
                    }
                }
                if (matchingWords.Count > 0)
                {
                    string suggestion = matchingWords[0].Substring(currentWord.Length);
                    richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.TextLength, suggestion);
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                currentWord = "";
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                if (currentWord.Length > 0)
                {
                    currentWord = currentWord.Substring(0, currentWord.Length - 1);
                }
            }
            mutex.ReleaseMutex();
        }

    }



}