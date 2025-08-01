using NAudio.Wave;

namespace Zeus
{
    internal class SystemAudioRecorder
    {
        private WasapiLoopbackCapture capture;
        private WaveFileWriter writer;
        private readonly string outputFilePath;
        private bool isRecording = false;

        public SystemAudioRecorder(string outputFilePath)
        {
            this.outputFilePath = outputFilePath;
        }

        public void StartRecording()
        {
            if (isRecording) return;

            capture = new WasapiLoopbackCapture();
            writer = new WaveFileWriter(outputFilePath, capture.WaveFormat);

            capture.DataAvailable += OnDataAvailable;
            capture.RecordingStopped += OnRecordingStopped;

            capture.StartRecording();
            isRecording = true;
        }

        public void StopRecording()
        {
            if (!isRecording) return;

            capture.StopRecording();
            isRecording = false;
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            writer?.Dispose();
            capture?.Dispose();
        }
    }
}