using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Newtonsoft.Json;
using YouDaoAPIDemo.Annotations;

namespace YouDaoAPIDemo
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public MainWindowViewModel()
        {
            SearchCommand = new DelegateCommand(Search_OnExecute);
        }
        public ICommand SearchCommand { get; }
        private async void Search_OnExecute()
        {
            var result = await YouDaoApiHelper.GetWordsAsync(SearchingText);

            Explaniation = result.YouDaoTranslation.BasicTranslation.Phonetic + "\r\n" +
                           string.Join("\r\n", result.YouDaoTranslation.BasicTranslation.Explains);
            SearchResultDetail = result.ResultDetail;
        }

        private string _searchResultDetail;
        public string SearchResultDetail
        {
            get => _searchResultDetail;
            set
            {
                _searchResultDetail = value;
                OnPropertyChanged();
            }
        }

        private string _explaniation;
        public string Explaniation
        {
            get => _explaniation;
            set
            {
                _explaniation = value;
                OnPropertyChanged();
            }
        }

        public string UTF8Encode(string input)
        {
            if (input == null)
            {
                return "";
            }

            try
            {
                return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(input));
            }
            catch (InvalidOperationException e)
            {
            }

            return input;
        }


        private string _searchingText = string.Empty;
        public string SearchingText
        {
            get => _searchingText;
            set
            {
                _searchingText = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
