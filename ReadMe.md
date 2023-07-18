# SI Units library with arithmetic capabilities.

This package defines metric system units and provides related arithmetic operations including unit to unit multiplication even with compound units, resulting in higher or lower order units (m², 1/m or m/s)..

The need for such a library arises from the development of engineering programs that have methods requiring specific numbers with specified units.
 By using this library, the unit of the input will no longer be important. 
 The method will only require metric types, and will do whatever is necessary to handle the mathematics behind them, 
 including unit to unit multiplication, resulting in higher or lower order units (m² or 1/m).

Consider the Square class below:

```
Square sq = new Square(2.5.km(), 4.3.km(), 10.005.m());
Console.WriteLine(sq.Volume());

class Square
{
    MetricLength _length;
    MetricLength _width;
    MetricLength -height;

    public Square(MetricLength l, MetricLength w, MetricLength h)
    {
        _length = l; _width = w; _height = h;
    }
    public Metric Volume()
    {
        return _length * _width * _height;
    }
}
```

The units of the inputs of the constructor won't be a problem anymore.
The same class can handle the values with various units (mm, m, cm) and return the same result with correct unit.



### **Examples**

```
// now supports derived unit arithmetics
var speed = 1.m() / 1.second()
// 1 m¹/s¹

var m1 = 2.m();
// 2 <m>

m1.dcm()
// 200 <cm>

var s1 = 3.hour();
// 3 <s>

s1.minute()
// 180 <m>

s1.second()
// 10800 <s>

var m12 = (2.mm() * 10.cm() + 4.m(2)).dm();
// 400,02000000000004 <dm2>

var m13 = 2 * m12;
// 800,0400000000001 <dm2>

var m14 = (m12 / 2).m();
// 2,0001 <m2>

```

### **Decleration via extension methods**

<table>
  <tr>
    <td>
      
- [double].km(degree)

- [double].m(degree)

- [double].dm(degree)

- [double].cm(degree)

- [double].mm(degree)
</td>
<td>
  
- [int].km(degree)

- [int].m(degree)

- [int].dm(degree)

- [int].cm(degree)

- [int].mm(degree)
</td>
</tr>
</table>
### Operations of Basic Units

- '+' ( Metric(n) + Metric(n) ) => Metric(n); where n is degree

- '-' ( Metric(n) - Metric(n) ) => Metric(n); where n is degree

- '*'  ( Metric(n) * Metric(m) ) => Metric(n); where n and m are degrees

- '/'  ( Metric(n) / Metric(m) ) => Metric(n-m); where n and m are degrees

- '*'  ( n *  Metric(m) ) => Metric(m);  where n is double 

- '/'  ( n / Metric(m) ) => Metric(-m); where n is double**

- '*'  ( Metric(m) * n) => Metric(m);  where n is double

- '/'  ( Metric(m)  / n) => Metric(m); where n is double

**Note: zero degree metrics [Metric(0)] are equal to scalers.

### Conversions

- [Metric].km(degree)

- [Metric].m(degree)

- [Metric].dm(degree)

- [Metric].cm(degree)

- [Metric].mm(degree)

- [Metric].Metric(SiMetricUnits unit)

  
## Supported Units

- yoktometre, [ym]

- zeptometre, [zm]

- attometre, [am]

- femtometre, [fm]

- picometre, [pm]

- nanometre, [nm]

- micrometre, [µm]

- milimetre, [mm]

- centimetre, [cm]

- decimetre, [dm]

- metre, [m]

- decametre, [dam]

- hectometre, [hm]

- kilometre, [km]

- megametre, [Mm]

- gigametre, [Gm]

- terametre, [Tm]

- petametre, [Pm]

- exametre, [Em]

- zettametre, [Zm]

- yottametre, [Ym]

## NuGet Package

https://www.nuget.org/packages/SIUnitsArithmetic

## Lisance

This package is released under the MIT licence.
