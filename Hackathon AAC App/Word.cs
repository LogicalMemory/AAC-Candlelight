using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hackathon_AAC_App
{
    internal class Word
    {
        public static ObservableCollection<Word> WordList = new ObservableCollection<Word>();
        

        public Word(string w, Word tW) {
            word = w.Trim();
            topWord = tW;

            MyCommand = new Command(
            execute: () =>
            {
                onClickWord();
               
            },
            canExecute: () =>
            {
                return true;
            });
        }
        public string word { get; set; }
        public ICommand MyCommand { private set; get; }

        public Word topWord { get; set; }
        public List<Word> subWords = null;

        public void onClickWord()
        {
            if (subWords == null)
            {
                Speak();
            }
            else
            {
                WordList.Clear();
                foreach (Word w in subWords) {
                    WordList.Add(w);
                }
            }
        }

        public async void Speak() => 
            await TextToSpeech.Default.SpeakAsync(word);
    }
}
