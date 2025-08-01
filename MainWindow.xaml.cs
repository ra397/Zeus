using System.Windows;

namespace Zeus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SystemAudioRecorder recorder;
        private bool isRecording = false;
        public MainWindow()
        {
            InitializeComponent();

            recorder = new SystemAudioRecorder(@"C:\Users\rabia\Documents\record.wav");
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isRecording)
            {
                recorder.StartRecording();
                isRecording = true;
                PlayPauseButton.Content = "⏸";
            }
            else
            {
                recorder.StopRecording();
                isRecording = false;
                PlayPauseButton.Content = "⏵";
            }
        }
    }
}