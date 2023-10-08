using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Hackathon_AAC_App
{
    public partial class ButtonsPage : ContentPage
    {
        public ButtonsPage()
        {
            InitializeComponent();

            loadWords();

            collectionView.ItemsSource = GetWords();
            BackButton.Clicked += onClickBack;


        }

        public void onClickBack(object sender, EventArgs e) {
            if (Word.WordList[0].topWord.topWord != null)
            { 
                Word.WordList[0].topWord.topWord.onClickWord();
            }
        }

        private ObservableCollection<Word> GetWords() {
            return Word.WordList;
        }


        async static public void loadWords() {
            Word.WordList.Clear();
            Word TopMostWord = new Word("TOPMOST", null);
            TopMostWord.subWords = new List<Word>();

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "WordButtons.txt");
            using FileStream outputStream = File.OpenRead(targetFile);
            using StreamReader reader = new StreamReader(outputStream);
            string line = reader.ReadLine();
            while (line != null && line.Length > 5)
            {
                Word w = FormatSubWords(line, TopMostWord);
                Word.WordList.Add(w);
                TopMostWord.subWords.Add(w);
                line = reader.ReadLine();
            }
            reader.Close();
            outputStream.Close();
        }

        private static Word FormatSubWords(string line, Word tW)
        {
            
            int startSub = line.IndexOf('(');
            string wordM = line.Substring(0, startSub);
            Word topWord = new Word(wordM, tW);
            List<Word> subs = new List<Word>();
            try
            {




                line = line.Substring(startSub + 1);
                line = line.Substring(0, line.Length - 1);



                int end = line.IndexOf('(');
                string extra = "";
                if (end != -1)
                {
                    for (int i = end; i > 0; i--) { if (line[i] == ',') { extra = line.Substring(i + 1); line = line.Substring(0, i); break; } }
                }

                foreach (string w in line.Split(','))
                {
                    subs.Add(new Word(w, topWord));
                }
                if (end != -1) { subs.Add(FormatSubWords(extra, topWord)); }

                topWord.subWords = subs;

            } catch (Exception ex)
            {
                Debug.Print("Yo!");
            }
            return topWord;
        }
    }
}