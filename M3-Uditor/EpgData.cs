using M3_Uditor.Forms;
using M3_Uditor.Properties;
using M3Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlTv;

namespace M3_Uditor
{
    public class EpgItem : ListBoxItem
    {
        public string Name { get => _name; set { _name = value; Title = value; } }
        public string EpgId { get => _epgid; set { _epgid = value; Description = value; } }

        string _name, _epgid;
    }

    internal class EpgData
    {
        public static AutoCompleteStringCollection ToAutoCompleteStringCollection()
        {
            var autoComplete = new AutoCompleteStringCollection();
            foreach (var item in _EpgItemList)
            {
                autoComplete.Add(item.EpgId);
            }
            return autoComplete;
        }

        public static List<EpgItem> EpgItemList { get => _EpgItemList; }
        private static List<EpgItem> _EpgItemList = new List<EpgItem>();

        public static void StartListening()
        {
            //LoadResource("SmartIPTV");
            EpgParser.ProcessingStatusChanged += EpgParser_ProcessingStatusChanged;
        }
        private static void EpgParser_ProcessingStatusChanged(object sender, ProcessingEventArgs e)
        {
            if (e.Status == EpgParser.ProcessingStatus.Success)
            {
                _EpgItemList.Clear();

                foreach (var item in EpgParser.Channels)
                {
                    EpgItemList.Add(new EpgItem()
                    {
                        Name = item.Name,
                        EpgId = item.ID
                    });
                }
            }
        }
        public static EpgItem GetItemByChannelId(string channelId)
        {
            return EpgItemList.Where(item => item.EpgId == channelId).FirstOrDefault();
        }

        public static void GetData(string XmlUri)
        {
            EpgParser epgParser = new EpgParser(XmlUri, new EpgParserSettings(true, false));
            epgParser.Parse();
        }
        public static void ResetData()
        {
            EpgParser.EpgParserInstance?.Abort();
            _EpgItemList.Clear();
        }
    }
}
