using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telebackup
{
    public partial class InformationControl : UserControl
    {
        Conversation conversation;
        
        public InformationControl()
        {
            InitializeComponent();

            ResetRange();

            calendar.DaySelected += Calendar_DaySelected;
            calendar.MonthSelected += Calendar_MonthSelected;

            calendar.MonthChanged += FillCalendar;
        }

        bool reseting;
        void ResetRange()
        {
            reseting = true;
            calendar.Year = -1;
            calendar.Month = -1;
            fromDateDT.SelectedDate = new DateTime(2000, 1, 1);
            toDateDT.SelectedDate = DateTime.Now;
            reseting = false;

            FillCalendar();
            LoadInformation();
        }
        
        DateTime _fromDate
        { get {
            return new DateTime(
                fromDateDT.SelectedDate.Value.Year,
                fromDateDT.SelectedDate.Value.Month,
                fromDateDT.SelectedDate.Value.Day,
                0, 0, 0, 0);
        } }
        DateTime _toDate
        { get {
            return new DateTime(
                toDateDT.SelectedDate.Value.Year,
                toDateDT.SelectedDate.Value.Month,
                toDateDT.SelectedDate.Value.Day,
                23, 59, 59, 999);
        } }
        DateTime fromDate, toDate;

        private void Calendar_DaySelected(DateTime day)
        {
            fromDateDT.SelectedDate = day;
            toDateDT.SelectedDate = day;
            LoadInformation();
        }

        private void Calendar_MonthSelected(DateTime month)
        {
            fromDateDT.SelectedDate = new DateTime(month.Year, month.Month, 1);
            toDateDT.SelectedDate = new DateTime(month.Year, month.Month, DateTime.DaysInMonth(month.Year, month.Month));
            
            LoadInformation();
        }

        void RefreshDateRange() {
            fromDate = _fromDate;
            toDate = _toDate;
        }
        public bool InDateRange(DateTime date)
        { return date >= fromDate && date <= toDate; }

        public async Task LoadInformation(Conversation convo)
        {
            await Task.Factory.StartNew(() =>
            {
                conversation = convo;

                var msgs = conversation.GetMessages().ToList();
                if (msgs.Count == 0) return;

                var firstMsg = msgs[0];
                calendar.Year = firstMsg.Date.Year;
                calendar.Month = firstMsg.Date.Month;

                FillCalendar(msgs);
                LoadInformation(msgs);
            });
        }

        void FillCalendar() {
            if (conversation == null) return;
            FillCalendar(conversation.GetMessages().ToList());
        }
        void FillCalendar(List<Msg> msgs)
        {
            if (reseting) return;
            
            if (calendar.Year == -1)
            { // not init yet
                calendar.Year = msgs[0].Date.Year;
                calendar.Month = msgs[0].Date.Month;
            }
            calendar.FillDays();

            // Fill calendar
            foreach (var msg in msgs)
                if (msg.Date.Month == calendar.Month && msg.Date.Year == calendar.Year)
                    calendar.AddDay(msg.Date.Day);
            
            calendar.RepaintDays();
        }

        void LoadInformation() {
            if (conversation == null) return;
            LoadInformation(conversation.GetMessages().ToList());
        }
        void LoadInformation(List<Msg> msgs)
        {
            if (reseting) return;

            chart.ClearData();
            chart.StopRepainting();

            int st = 0; // search type

            Dispatcher.Invoke(() =>
            {
                if (msgsRB.IsChecked.Value) st = 0; // 0 = msgs
                else if (wordsRB.IsChecked.Value) st = 1; // 1 = words
                else if (charsRB.IsChecked.Value) st = 2; // 2 = chars

                RefreshDateRange();
            });

            foreach (var msg in msgs)
            {
                // Fill chart
                if (InDateRange(msg.Date) && !string.IsNullOrEmpty(msg.Sender))
                    switch (st)
                    {
                        case 0: // msgs
                            chart.AddData(msg.Sender, 1);
                            break;
                        case 1: // words
                            chart.AddData(msg.Sender, msg.Content.Split(' ').Length);
                            break;
                        case 2: // chars
                            chart.AddData(msg.Sender, msg.Content.Length);
                            break;
                    }
            }
            chart.ReloadDataImportants();
            chart.StartRepainting();

            Dispatcher.Invoke(() => totalL.Content = "Total: " + chart.GetTotal());
        }

        void typeRB_Checked(object sender, RoutedEventArgs e) { LoadInformation(); }
        void dateRangeChanged(object sender, SelectionChangedEventArgs e) { LoadInformation(); }

        private void resetRange_Click(object sender, RoutedEventArgs e)
        {
            ResetRange();
            LoadInformation();
        }
    }
}
