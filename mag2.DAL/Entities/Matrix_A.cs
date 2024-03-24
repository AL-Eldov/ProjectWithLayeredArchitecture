using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mag2.DAL.Entities;

public class Matrix_A
{
    public int Id { get; set; }
    public int Column {  get; set; }
    public int Row { get; set; }
    public double RealPart { get; set; }
    public double ImaginaryPart { get; set; }
}
