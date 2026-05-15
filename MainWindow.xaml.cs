using System;
using System.Windows;
using NAudio.Wave;

namespace RadioPlayer
{
    public partial class MainWindow : Window
    {
        private IWavePlayer waveOut;
        private MediaFoundationReader reader;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = UrlTextBox.Text;

                reader = new MediaFoundationReader(url);

                waveOut = new WaveOut();

                waveOut.Init(reader);

                waveOut.Play();

                MessageBox.Show("Радио запущено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            waveOut?.Stop();

            reader?.Dispose();
            waveOut?.Dispose();
        }
    }
}
