using System.Numerics;

namespace mag2.BLL.DTO;

public class Vector_c_DTO
{
    public int Id { get; set; }
    public double RealPart { get; set; }
    public double ImaginaryPart { get; set; }
    public double GetAbsolute()
    {
        return new Complex(RealPart, ImaginaryPart).Magnitude;
    }
}
