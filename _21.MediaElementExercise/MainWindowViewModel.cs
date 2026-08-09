using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _21.MediaElementExercise
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Visibility _borderVisibility=Visibility.Visible;

        public Visibility BorderVisibility
        {
            get { return _borderVisibility=Visibility.Visible; }
            set { _borderVisibility = value;OnPropertyChanged(); }
        }
        public ICommand OpenFileCommand { get; set; }
        public ICommand PlayCommand { get; set; }
        public MainWindowViewModel()
        {
            OpenFileCommand = new RelayCommand(OnOpenFileCommand);
            PlayCommand = new RelayCommand(OnPlayCommand);
        }

        private void OnPlayCommand(object obj)
        {
           _mediaElement.Play();
        }

        private string _filePath;
        private MediaElement _mediaElement;
        
        private string _mediaBackgroundText = "MediaElement | 视频播放器";
        public string MediaBackgroundText
        {
            get { return _mediaBackgroundText = "MediaElement | 视频播放器";; }
            set { _mediaBackgroundText = value;OnPropertyChanged(); }
        }

        private TimeSpan _mediaTimeSpan=new TimeSpan(0,0,0);

        public TimeSpan MediaTimeSpan
        {
            get { return _mediaTimeSpan; }
            set { _mediaTimeSpan = value; OnPropertyChanged(); }
        }



        private void OnOpenFileCommand(object obj)
        {
            _mediaElement = obj as MediaElement;
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter="视频文件(.mp4)|*.mp4",
                Multiselect=false
            };
            var result=openFileDialog.ShowDialog();
            if (result==true)
            {
                _filePath = openFileDialog.FileName;
                BorderVisibility = Visibility.Collapsed;
            }
            _mediaElement.MediaOpened += _mediaElement_MediaOpened;
            _mediaElement.Source = new System.Uri(_filePath);
            MediaBackgroundText = _filePath;


        }

        private void _mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (_mediaElement.NaturalDuration.HasTimeSpan)
            {
               MediaTimeSpan=_mediaElement.NaturalDuration.TimeSpan;
            }
        }
    }
}
