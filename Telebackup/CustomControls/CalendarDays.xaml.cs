using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Telebackup
{
    public partial class CalendarDays : UserControl
    {
        public delegate void VoidDelegate();
        public delegate void DaySelectedDelegate(DateTime day);

        public event DaySelectedDelegate DaySelected;
        public event DaySelectedDelegate MonthSelected;

        public event VoidDelegate MonthChanged; // Please feed me new content!

        public CalendarDays()
        {
            InitializeComponent();
            DayCount = new Dictionary<int, int>();

            int size = 24;
            int margin = 10;
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    int id = y * 7 + x;

                    var b = new Button
                    {
                        Name = "d" + id,

                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,

                        Height = size,
                        Width = size,

                        Margin = new Thickness(
                            margin + x * size + x * margin,
                            margin + y * size + y * margin,
                            0, 0),
                        BorderThickness = new Thickness(0)
                    };
                    b.MouseEnter += B_MouseEnter;
                    b.Click += B_Click;

                    daysGrid.Children.Add(b);
                }
            }
        }

        private void B_MouseEnter(object sender, MouseEventArgs e)
        {
            var b = (Button)sender;
            if (string.IsNullOrEmpty((string)b.Content)) return;

            var day = int.Parse((string)b.Content);

            DateTime dt = new DateTime(Year, Month, day);

            info.Content = dt.DayOfWeek + " - Message count: " + DayCount[day].ToString();
        }

        private void daysGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            info.Content = "Hover a day to see message count";
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            var id = int.Parse((string)b.Content);

            OnDaySelected(id);
        }

        void OnDaySelected(int day)
        {
            if (DaySelected != null)
                DaySelected(new DateTime(Year, Month, day));
        }

        void OnMonthSelected(int month)
        {
            if (MonthSelected != null)
                MonthSelected(new DateTime(Year, month, 1));
        }

        // WARNING SET BEFORE USE
        public int Year = -1;
        public int Month = -1;

        DayOfWeek StartDay;

        Dictionary<int, int> DayCount;

        public void FillDays()
        {
            if (Year < 0) return;

            DayCount.Clear();

            var dim = DateTime.DaysInMonth(Year, Month);
            for (int i = 1; i <= dim; i++)
                DayCount.Add(i, 0);

            var dt = new DateTime(Year, Month, 1);
            StartDay = dt.DayOfWeek;

            Dispatcher.Invoke(() => monthB.Content = dt.ToString("MMMM yyyy"));
        }

        public void SetDay(int day, int msgCount)
        { DayCount[day] = msgCount; }

        public void AddDay(int day)
        { ++DayCount[day]; }

        public int MonthDaysCount
        {
            get
            {
                int count = 0;
                foreach (var dc in DayCount) ++count;
                return count;
            }
        }
        public int MaxDayCount
        {
            get
            {
                int max = 0;
                foreach (var dc in DayCount)
                    if (dc.Value > max)
                        max = dc.Value;
                return max;
            }
        }
        public int MinDayCount
        {
            get
            {
                int min = int.MaxValue;
                foreach (var dc in DayCount)
                    if (dc.Value < min)
                        min = dc.Value;
                return min;
            }
        }

        public void RepaintDays()
        {
            Dispatcher.Invoke(() =>
            {
                for (int i = 0; i < 7 * 6; i++)
                    daysGrid.Children[i].Visibility = Visibility.Hidden;

                var mdc = MonthDaysCount + (int)StartDay;
                var min = MinDayCount;
                var max = MaxDayCount;
                for (int i = (int)StartDay; i < mdc; i++)
                {
                    int dayNumber = i - (int)StartDay + 1; // This day number (the n'th)
                    var dayCount = DayCount[dayNumber]; // This day count (m messages the n'th)

                    var inte = GetIntensity(min, max, dayCount);

                    var b = (Button)daysGrid.Children[i];

                    b.Visibility = Visibility.Visible;
                    b.Content = dayNumber.ToString();
                    b.Background = new SolidColorBrush(Color.FromArgb(120, 0, inte, inte));
                }
            });
        }

        byte GetIntensity(int min, int max, int value)
        {
            value -= min;
            var percentage = (float)value / (float)max;

            return (byte)(percentage * (float)byte.MaxValue);
        }

        private void prevMonth_Click(object sender, RoutedEventArgs e)
        {
            var dt = new DateTime(Year, Month, 1).AddMonths(-1);
            Year = dt.Year;
            Month = dt.Month;
            OnMonthChanged();
        }

        private void nextMonth_Click(object sender, RoutedEventArgs e)
        {
            var dt = new DateTime(Year, Month, 1).AddMonths(+1);
            Year = dt.Year;
            Month = dt.Month;
            OnMonthChanged();
        }

        void OnMonthChanged()
        {
            if (MonthChanged != null)
                MonthChanged();
        }

        private void monthB_Click(object sender, RoutedEventArgs e)
        {
            OnMonthSelected(Month);
        }
    }
}
