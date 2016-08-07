using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TVContext;

namespace TvForms
{
    public partial class ucShowProgramsListV : UserControl
    {
        /// <summary>
        /// the day what will be shown after DayTab click
        /// </summary>
        private readonly int _downloadDay;
        public ucShowProgramsListV()
        {
            InitializeComponent();
        }


        public ucShowProgramsListV(int day, bool isCheckBox)
        {
            InitializeComponent();
            lvShowPrograms.CheckBoxes = isCheckBox;
            _downloadDay = day;
            DownloadShows();
        }

        private void DownloadShows()
        {
            using (var context = new TvDBContext())
            {
                var sh = from s in context.TvShows
                         select s;
                int number = 1;
                foreach (var item in sh)
                    if ((int)item.Date.DayOfWeek == _downloadDay)
                        AddItemToListView(item, ref number);
            }
        }

        public void AddItemToListView(TVShow shows, ref int number)
        {
            var item = new ListViewItem(number.ToString());
            var time = shows.Date.Hour <= 9 ? "0" + shows.Date.ToShortTimeString() : shows.Date.ToShortTimeString();
            item.SubItems.Add(time);
            item.SubItems.Add(shows.Name);

            lvShowPrograms.Items.Add(item);
            number++;
        }

        public void ParseProgramm(string filename, int channelId)
        {
            try
            {
                TvDBContext context = new TvDBContext();
                List<TVShow> tvshows = new List<TVShow>();

                //XmlNode searched = null;
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                Channel ivan = context.Channels.Find(channelId);
                foreach (XmlNode node in doc.SelectNodes("/tv/programme"))
                {

                    string title = node.FirstChild.InnerText;
                    string mySqlTimestamp = toDatetime2(node.Attributes["start"].Value);
                    //DateTime time = DateTime.Parse(mySqlTimestamp);
                    DateTime stt = Convert.ToDateTime(mySqlTimestamp);
                    //int index = doc.SelectNodes("/tv/programme").Cast<XmlNode>().ToList().IndexOf(node);

                    context.TvShows.Add(new TVShow()
                    {
                        Name = title,
                        Date = stt,
                        Channel = ivan
                    });

                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    );
            }
        }


        private string toDatetime2(string date)
        {
            if (date.Length != 0)
            {
                string year = date.Substring(0, 4);
                string month = date.Substring(4, 2);
                string day = date.Substring(6, 2);
                string hour = date.Substring(8, 2);
                string minute = date.Substring(10, 2);
                string second = date.Substring(12, 2);

                return day + "-" + month + "-" + year + " " + hour + ":" + minute + ":" + second;
            }
            else
            {
                return "0000-00-00 00:00:00";
            }
        }


    }
}
