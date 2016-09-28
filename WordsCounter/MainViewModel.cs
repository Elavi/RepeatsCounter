using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WordsCounter
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand PrepareTextCommand { get; private set; }
        public RelayCommand CopyToClipboardCommand { get; private set; }
        public MainViewModel()
        {
            this.PrepareTextCommand = new RelayCommand(this.PrepareText);
            this.CopyToClipboardCommand = new RelayCommand(this.CopyToClipboard);
        }

        private void PrepareText()
        {
            var preparator = new StringPreparator();
            ParsedDictionary = preparator.CalculateWordsCount(TextToParse);
        }

        private void CopyToClipboard()
        {
            var replacementsText = string.Join(Environment.NewLine,
                ParsedDictionary.Select(d => string.Format("{0} - {1}", d.Key, d.Value)));
            Clipboard.SetText(replacementsText);
        }

        private string _textToParse;

        public string TextToParse
        {
            get { return _textToParse; }
            set { _textToParse = value; }
        }

        private Dictionary<string, int> _parsedDictionary;

        public Dictionary<string, int> ParsedDictionary
        {
            get { return _parsedDictionary; }
            set
            {
                if (value != null)
                {
                    _parsedDictionary = value;
                    RaisePropertyChanged("ParsedDictionary");
                }
            }
        }
        

    }
}
