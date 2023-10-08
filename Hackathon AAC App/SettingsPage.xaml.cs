
namespace Hackathon_AAC_App
{
    public partial class SettingsPage : ContentPage
    {

        public SettingsPage()
        {
            InitializeComponent();
            SaveButton.Clicked += OnSaveClicked;
            LoadTextBox();
        }

        private async void LoadTextBox() {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "WordButtons.txt");
            using FileStream outputStream = File.OpenRead(targetFile);
            using StreamReader reader = new StreamReader(outputStream);
           
            string line = reader.ReadLine();
            string txt = "";
            while (line != null && line.Length > 3)
            {
                txt += line + "\n";
                line = reader.ReadLine();
            }
            entry.Text = txt;
            reader.Close();
            outputStream.Close();
           
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "WordButtons.txt");
            using FileStream outputStream = File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync(entry.Text +"\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            streamWriter.Close();
            outputStream.Close();

            ButtonsPage.loadWords();            
        }

        

    }
}