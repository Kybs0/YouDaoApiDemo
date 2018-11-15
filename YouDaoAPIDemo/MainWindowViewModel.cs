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
            var wordsAsync =await YouDaoApiHelper.GetWordsAsync(SearchingText);

            Explaniation = wordsAsync.BasicTranslation.Phonetic + "\r\n" +
                           string.Join("\r\n", wordsAsync.BasicTranslation.Explains);
        }

        private string _explaniation;
        public string Explaniation
        {
            get => _explaniation;
            set
            {
                _explaniation = value;
                OnPropertyChanged();
            } }

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


    [DataContract]
    public class YouDaoTranslationResponse
    {
        [DataMember(Name = "errorCode")]
        public string ErrorCode { get; set; }

        [DataMember(Name = "query")]
        public string QueryText { get; set; }

        [DataMember(Name = "speakUrl")]
        public string InputSpeakUrl { get; set; }

        [DataMember(Name = "tSpeakUrl")]
        public string TranslationSpeakUrl { get; set; }

        /// <summary>
        /// 首选翻译
        /// </summary>
        [DataMember(Name = "translation")]
        public List<string> FirstTranslation { get; set; }

        /// <summary>
        /// 基本释义
        /// </summary>
        [DataMember(Name = "basic")]
        public TranslationBasicData BasicTranslation { get; set; }

        ///// <summary>
        ///// 网络释义，该结果不一定存在
        ///// </summary>
        //[DataMember(Name = "web")]
        //public string WebTranslation { get; set; }
    }

    /// <summary>
    /// 基本释义
    /// </summary>
    [DataContract]
    public class TranslationBasicData
    {
        [DataMember(Name = "phonetic")]
        public string Phonetic { get; set; }

        /// <summary>
        /// 英式发音
        /// </summary>
        [DataMember(Name = "uk-phonetic")]
        public string UkPhonetic { get; set; }

        /// <summary>
        /// 美式发音
        /// </summary>
        [DataMember(Name = "us-phonetic")]
        public string UsPhonetic { get; set; }

        /// <summary>
        /// 翻译
        /// </summary>
        [DataMember(Name = "explains")]
        public List<string> Explains { get; set; }
    }

    /// <summary>
    /// 网络释义
    /// </summary>
    [DataContract]
    public class TranslationWebData
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "value")]
        public List<string> Explains { get; set; }
    }
    internal class YouDaoApiHelper
    {
        const string _appKey = "75766d8fc97f34a3";
        const string _from = "en";
        const string _to = "zhs";
        const string _appSecret = "rFkTqsDws1bCoETcxSL7afG33emwJdr5";

        public static async Task<YouDaoTranslationResponse> GetWordsAsync(string queryText)
        {
            var requestUrl = GetRequestUrl(queryText);

            WebRequest translationWebRequest = WebRequest.Create(requestUrl);

            var response = await translationWebRequest.GetResponseAsync();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream ?? throw new InvalidOperationException(), Encoding.GetEncoding("utf-8")))
                {
                    string result = reader.ReadToEnd();
                    var youDaoTranslationResponse = JsonConvert.DeserializeObject<YouDaoTranslationResponse>(result);

                    return youDaoTranslationResponse;
                }
            }
        }

        private static string GetRequestUrl(string queryText)
        {
            string salt = DateTime.Now.Millisecond.ToString();

            MD5 md5 = new MD5CryptoServiceProvider();
            string md5Str = _appKey + queryText + salt + _appSecret;
            byte[] output = md5.ComputeHash(Encoding.UTF8.GetBytes(md5Str));
            string sign = BitConverter.ToString(output).Replace("-", "");

            var requestUrl = string.Format(
                "http://openapi.youdao.com/api?appKey={0}&q={1}&from={2}&to={3}&sign={4}&salt={5}",
                _appKey,
                HttpUtility.UrlDecode(queryText, System.Text.Encoding.GetEncoding("UTF-8")),
                _from, _to, sign, salt);

            return requestUrl;
        }
    }
}
