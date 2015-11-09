/* Made by  Lonami Exo
 *    LonamiWebs.TK   
 * Date: 20-10-2015 */

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Charts
{
    public partial class ColumnChart : UserControl
    {
        #region Variables

        // Y axes related
        double topPosition; // top position of the Y axes
        double botPosition; // bottom position of the Y axes
        double yHeight; // Y axes height

        // padding related
        double padding = 5; // padding from any side
        double bottomPadding = 60; // padding from the bottom
        double leftPadding = 50; // padding from the left

        // column related
        double columnsWidth; // the columnds width, based on the amount and control size
        double columnsAvailableWidth; // the remaining width available for columns

        int valueLinesCount = 5; // number of lines indicating value
        double valueLinesSize = 4; // size of these lines

        List<Rectangle> columns = new List<Rectangle>(); // the added columns

        // data related
        Dictionary<string, int> data = new Dictionary<string, int>();
        int dataMaxValue;
        int dataMinValue;

        ToolTip tooltip = new ToolTip();

        // colours
        Stack<SolidColorBrush> randomBrushes = new Stack<SolidColorBrush>();
        readonly string[] materialAccents = new string[] {
            "#f44336", "#e91e63", "#9c27b0",
            "#673ab7", "#3f51b5", "#2196f3",
            "#03a9f4", "#00bcd4", "#009688",
            "#4caf50", "#8bc34a", "#cddc39",
            "#ffeb3b", "#ffc107", "#ff9800",
            "#ff5722", "#795548", "#9e9e9e", "#607d8b"
        };
        Random r = new Random();
        bool painting = true;

        // effects related
        double fadeDuration = 200;
        double fadedValue = 0.4;

        // controls
        Grid grid = new Grid();

        #endregion

        #region Constructor and destructor

        public ColumnChart()
        {
            AddChild(grid);

            grid.ToolTip = tooltip;
            Loaded += (s, e) => tooltip.IsOpen = false;
        }

        #endregion

        #region Data

        public void ClearData()
        {
            data.Clear();
            Repaint();
        }

        public void SetData(string name, int value)
        {
            if (data.ContainsKey(name))
                data[name] = value;
            else
                data.Add(name, value);
        }

        public void AddData(string name, int value)
        {
            if (data.ContainsKey(name))
                data[name] += value;
            else
                data.Add(name, value);
        }

        public void ReloadDataImportants()
        {
            dataMaxValue = 0;
            dataMinValue = int.MaxValue;
            foreach (var datum in data)
            {
                if (datum.Value > dataMaxValue)
                    dataMaxValue = datum.Value;

                if (datum.Value < dataMinValue)
                    dataMinValue = datum.Value;
            }

            Repaint();
        }

        public int GetTotal()
        {
            int total = 0;
            foreach (var datum in data)
                total += datum.Value;
            return total;
        }

        #endregion

        #region Override

        protected override void OnRender(DrawingContext drawingContext)
        {
            Repaint();
        }

        #endregion

        #region Painting

        public void StopRepainting()
        {
            painting = false;
        }

        public void StartRepainting()
        {
            painting = true;
            Repaint();
        }

        void Repaint()
        {
            if (!painting) return;

            Dispatcher.Invoke(() =>
            {
                grid.Children.Clear();

                DrawYAxes(); // We call Y first because it sets some values
                DrawXAxes();
            });
        }

        #region Axis

        void DrawXAxes()
        {
            var line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = leftPadding;
            line.Y1 = ActualHeight - bottomPadding;
            line.X2 = ActualWidth - padding;
            line.Y2 = ActualHeight - bottomPadding;

            var x1 = leftPadding;
            var x2 = ActualWidth - padding;

            var res = x2 - x1;

            columnsAvailableWidth = line.X2 - line.X1 - padding * (data.Count + 1);
            columnsWidth = columnsAvailableWidth / data.Count;

            columns.Clear();
            ResetRandomColors();
            int i = 0;
            foreach (var datum in data)
            {
                var rect = new Rectangle();
                rect.Name = "c_" + Math.Abs(datum.Key.GetHashCode()) + "_" + datum.Value;
                rect.Fill = GetColor();
                rect.Margin = new Thickness(
                    line.X1 + padding * (i + 1) + columnsWidth * i,
                    GetColumnTop(datum.Value),
                    0,
                    bottomPadding
                    );
                rect.MouseEnter += Rect_MouseEnter;
                rect.MouseLeave += Rect_MouseLeave;

                if (columnsWidth < 0) return; // Not enough big!
                rect.Width = columnsWidth;
                rect.HorizontalAlignment = HorizontalAlignment.Left;

                columns.Add(rect);

                var l = new Label();
                l.Content = datum.Key;
                l.RenderTransform = new SkewTransform(0, 24);

                l.Margin = new Thickness(
                    line.X1 + padding * (i + 1) + columnsWidth * i,
                    line.Y1,
                    0,
                    0
                    );

                grid.Children.Add(rect);
                grid.Children.Add(l);
                ++i;
            }

            grid.Children.Add(line);
        }

        // Columns data show
        private void Rect_MouseEnter(object sender, MouseEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(fadeDuration));
            DoubleAnimation anim = new DoubleAnimation(fadedValue, duration);
            var rct = ((Rectangle)sender);
            foreach (var col in columns)
            {
                if (col.Name == rct.Name) continue;
                col.BeginAnimation(OpacityProperty, anim);
            }
            tooltip.Content = rct.Name.Split('_')[2];
            tooltip.IsOpen = true;
        }

        private void Rect_MouseLeave(object sender, MouseEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(fadeDuration));
            DoubleAnimation anim = new DoubleAnimation(1, duration);

            foreach (var col in columns)
                col.BeginAnimation(OpacityProperty, anim);

            tooltip.IsOpen = false;
        }

        void DrawYAxes()
        {
            var line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = leftPadding;
            line.Y1 = padding;
            line.X2 = leftPadding;
            line.Y2 = ActualHeight - bottomPadding;

            yHeight = line.Y2 - line.Y1;

            var tv = GetTopValue(dataMaxValue);
            var smallChange = tv / valueLinesCount;
            var distance = yHeight / valueLinesCount;

            for (int i = 1; i <= valueLinesCount; i++)
            {
                var cline = new Line();
                cline.Stroke = Brushes.Black;
                cline.X1 = leftPadding - valueLinesSize / 2;
                cline.Y1 = cline.Y2 = line.Y2 - distance * i;
                cline.X2 = leftPadding + valueLinesSize / 2;

                int fsize = 10;
                var l = new Label();
                l.Content = (smallChange * i).ToString();
                l.Margin = new Thickness(0, cline.Y1 - fsize, ActualWidth - cline.X1, 0);
                l.HorizontalContentAlignment = HorizontalAlignment.Right;
                l.FontSize = fsize;

                grid.Children.Add(cline);
                grid.Children.Add(l);
            }

            topPosition = line.Y2 - distance * valueLinesCount;
            botPosition = line.Y2 - distance;


            grid.Children.Add(line);
        }

        // Get top margin for a given column value
        double GetColumnTop(int value)
        {
            double percentage = ((double)value / (double)GetTopValue(dataMaxValue));
            return topPosition + yHeight * (1d - percentage);
        }

        // Get an higher value for the maximum value
        // (if max data value is 96, top should be 100, etc)
        int GetTopValue(int value)
        {
            int ciphers = value.ToString().Length;
            return (int)((int.Parse(value.ToString()[0].ToString()) + 1)
                * Math.Pow(10, ciphers - 1));
        }

        #endregion

        #region Random colours

        void ResetRandomColors()
        {
            randomBrushes.Clear();

            var added = new HashSet<int>();
            var r = new Random();
            while (added.Count < materialAccents.Length)
            {
                var am = r.Next(0, materialAccents.Length); // added material
                if (added.Add(am))
                    randomBrushes.Push(new SolidColorBrush((Color)
                        ColorConverter.ConvertFromString(materialAccents[am])));
            }

        }

        SolidColorBrush GetColor()
        {
            if (randomBrushes.Count > 0)
                return randomBrushes.Pop(); // Pop? Rock and roll!

            var cv = new byte[3];
            r.NextBytes(cv);
            return new SolidColorBrush(Color.FromRgb(cv[0], cv[1], cv[2]));
        }

        #endregion

        #endregion
    }
}
