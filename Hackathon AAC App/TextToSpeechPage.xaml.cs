namespace Hackathon_AAC_App
{
    public partial class TextToSpeechPage : ContentPage
    {
       
        public TextToSpeechPage()
        {
            InitializeComponent();
            TalkButton.Clicked += OnTalkClicked;
            entry.Completed += OnTalkClicked;
        }

        private void OnTalkClicked(object sender, EventArgs e)
        {
            if (entry.Text != null) { Speak(entry.Text); }
            entry.Text = null;
        }

        public async void Speak(string toSay) =>
            await TextToSpeech.Default.SpeakAsync(toSay);
    }
}