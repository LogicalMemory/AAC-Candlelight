using System.Formats.Tar;

namespace Hackathon_AAC_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            MainPage.BackgroundColor = new Color(0, 0, 0);

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "WordButtons.txt");
            if (!File.Exists(targetFile)) { CopyFileToAppDataDirectory("WordButtons.txt"); }

            Shell.Current.GoToAsync("//buttons");
        }


        public async Task CopyFileToAppDataDirectory(string filename)
        {
            // Open the source file
            using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(filename);

            // Create an output filename
            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, filename);

            // Copy the file to the AppDataDirectory
            using FileStream outputStream = File.Create(targetFile);
            await inputStream.CopyToAsync(outputStream);
        }
    }
}