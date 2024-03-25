using System.Numerics;

namespace mag2.BLL.BusinessModels;

public class RandomVector_f
{
    public int Lengh { private set; get; }
    public IEnumerable<Complex> Vector_f { private set; get; }
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
            Vector_f = GetFunctionVector_f(N);
        }
    }
    private IEnumerable<Complex> GetVector_f(int N)
    {
        List<Complex> vector_f = new List<Complex>();
        double realPart = 0;
        double imagPart = 0;
        Random rnd = new Random();
        for (int i = 0; i < N; i++)
        {
            realPart = rnd.Next(-100, 100) + (rnd.Next(0, 100) / 100.0);
            imagPart = rnd.Next(-100, 100) + (rnd.Next(0, 100) / 100.0);
            vector_f.Add(new Complex(Math.Round(realPart, 2), Math.Round(imagPart, 2)));
        }
        return vector_f;
    }
    private IEnumerable<Complex> GetFunctionVector_f(int N)
    {
        List<Complex> vector_f = new List<Complex>();
        double a = -25;
        double b = 25;
        double h = (b-a)/(N-1);
        double realPart = 0;
        double imagPart = 0;
        Random rnd = new Random();
        for (int i = 0; i < N; i++)
        {
            realPart = 0.5*(a+h*i)*Math.Sin(a + h * i);
            vector_f.Add(new Complex(Math.Round(realPart, 2), Math.Round(imagPart, 2)));
        }
        return vector_f;
    }
}
