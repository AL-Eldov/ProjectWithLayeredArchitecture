using ScottPlot;

namespace mag2.BLL.BusinessModels;

public static class CreatorPicture
{
    public static void GetSinglPicture(List<double> x, List<double> y)
    {
        //ScottPlot.Version.ShouldBe(4, 1, 71);
        var plt = new ScottPlot.Plot();
        plt.Add.VerticalLine(0, color: Colors.Black);
        plt.Add.HorizontalLine(0, color: Colors.Black);
        // plot the data
        var grafic1 = plt.Add.Markers(x, y, color: Colors.Blue);
        grafic1.Label = "Изначальный вектор f";
        plt.Legend.IsVisible = true;
        plt.Legend.Orientation = Orientation.Horizontal;
        // customize the axis labels
        plt.Title("Современные компьютерные технологии");
        plt.XLabel("Действительная ось");
        plt.YLabel("Мнимая ось");
        // create a static function containing the string formatting logic
        static string CustomFormatter(double position)
        {
            if (position == 0)
                return "0";
            else if (position > 0)
                return $"+{position}";
            else
                return $"-{-position}";
        }
        // create a custom tick generator using your custom label formatter
        ScottPlot.TickGenerators.NumericAutomatic myTickGenerator = new()
        {
            LabelFormatter = CustomFormatter
        };
        // tell an axis to use the custom tick generator
        plt.Axes.Bottom.TickGenerator = myTickGenerator;
        plt.SavePng("D:\\LearningPath\\University\\2023-2024учеба\\1М курс\\2 семестр\\Современные компьютерные технологии\\mag2\\mag2.WEB\\wwwroot\\Picture\\StartVector_f.png", 1200, 900);
    }
    public static void GetBothPicture(List<double> x1, List<double> y1, List<double> x2, List<double> y2)
    {
        //ScottPlot.Version.ShouldBe(4, 1, 71);
        var plt = new ScottPlot.Plot();
        plt.Add.VerticalLine(0, color: Colors.Black);
        plt.Add.HorizontalLine(0, color: Colors.Black);
        // plot the data
        var grafic1 = plt.Add.Markers(x1, y1, color: Colors.Blue);
        grafic1.Label = "Изначальный вектор f";
        var grafic2 = plt.Add.Markers(x2, y2, color: Colors.Red);
        grafic2.Label = "Новый вектор f";
        plt.Legend.IsVisible = true;
        plt.Legend.Orientation = Orientation.Horizontal;
        // customize the axis labels
        plt.Title("Современные компьютерные технологии");
        plt.XLabel("Действительная ось");
        plt.YLabel("Мнимая ось");
        // create a static function containing the string formatting logic
        static string CustomFormatter(double position)
        {
            if (position == 0)
                return "0";
            else if (position > 0)
                return $"+{position}";
            else
                return $"-{-position}";
        }
        // create a custom tick generator using your custom label formatter
        ScottPlot.TickGenerators.NumericAutomatic myTickGenerator = new()
        {
            LabelFormatter = CustomFormatter
        };
        // tell an axis to use the custom tick generator
        plt.Axes.Bottom.TickGenerator = myTickGenerator;
        plt.SavePng("D:\\LearningPath\\University\\2023-2024учеба\\1М курс\\2 семестр\\Современные компьютерные технологии\\mag2\\mag2.WEB\\wwwroot\\Picture\\BothVector_f.png", 1200, 900);
    }
}
