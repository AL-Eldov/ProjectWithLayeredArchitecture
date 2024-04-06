using System.Numerics;

namespace mag2.BLL.BusinessModels;

public class RandomVector_f
{
    public int Lengh { private set; get; }
    public IEnumerable<Complex> Vector_f { private set; get; }
    public IEnumerable<double>? Vector_x_k;
    public IEnumerable<double>? Vector_X_k
    {
        get
        {
            return Vector_x_k;
        }
    }
    public RandomVector_f(int N, bool toggle = true)
    {
        if (toggle)
        {
            this.Lengh = (N) * (N);
            Vector_f = GetVector_f(N);
        }
        else
        {
            this.Lengh = (N) * (N);
            Vector_f = GetFunctionVector_f(N, out Vector_x_k);
        }
    }
    private IEnumerable<Complex> GetVector_f(int N)
    {
        List<Complex> vector_f = new List<Complex>();
        double realPart = 0;
        double imagPart = 0;
        Random rnd = new Random();
        Complex tempComplex = new Complex(0, 0);
        for (int i = 0; i < N; i++)
        {
            realPart = rnd.Next(-100, 100) + (rnd.Next(0, 100) / 100.0);
            imagPart = rnd.Next(-100, 100) + (rnd.Next(0, 100) / 100.0);
            tempComplex = new Complex(Math.Round(realPart, 2), Math.Round(imagPart, 2));
            if (tempComplex.Magnitude > 50)
            {
                i--;
                continue;
            }
            vector_f.Add(tempComplex);
        }
        return vector_f;
    }
    private IEnumerable<Complex> GetFunctionVector_f(int N, out IEnumerable<double>? Vector_x_k)
    {
        List<Complex> vector_f = new List<Complex>();
        List<double> vector_x_k = new List<double>();
        double a = -10;//менять интервал тут
        double b = 10;//менять интервал тут
        double h = (b - a) / (N - 1);
        double realPart = 0;
        double imagPart = 0;
        Random rnd = new Random();
        for (int i = 0; i < N; i++)
        {
            realPart = (a + h * i) * (a + h * i) * (a + h * i);//менять функцию тут   0.5 * (a + h * i) * Math.Sin(a + h * i)
            vector_x_k.Add(a + h * i);
            vector_f.Add(new Complex(Math.Round(realPart, 2), Math.Round(imagPart, 2)));
        }
        Vector_x_k = vector_x_k;
        return vector_f;
    }
}
