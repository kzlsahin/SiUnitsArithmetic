# SI Units library with arithmetic capabilities.

SIUnitsArithmetic defines metric system units and provides related arithmetic operations including unit to unit multiplication even with compound units of any combination of basic units, resulting in higher or lower order units (m², 1/m or m/s).

Derived units compund of any combination of basic units (length, time, mass, electric currency) are supported, including Newton and Joule are also included.

The demand for such libraries has grown alongside the development 
of engineering programs that require specific numbers with 
specified units. My solution eliminates the challenge of 
managing units by allowing you to focus on the metric types, 
such as MetricLength or MetricTime. The library takes care of 
the underlying mathematics, seamlessly handling unit conversions 
and enabling operations like unit to unit multiplication, 
resulting in higher or lower order units like m² or 1/m.

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


### Extensiblity

Now custom units can be defined by the users of this library. Example of a Customunit:

```
// Special unit has to be registered
// call this method only once in the application
// derived degree indicates the exponents of length, time and mass unit components of the custom derived unit.
public void CreateCustomSpecialUnit()
        {
            CustomUnit.RegisterSpecialUnit(new DerivedDegree(2, -2, 2,0), CustomUnit.Instance);
            var customUnit = DerivedUnit.New(2.m(2), 3.second(-2), 3.kg(2));
            Assert.IsTrue(customUnit is CustomUnit);
            var custom2 = (400.mm(2) / 9.minute(2)) * 100.g(2);
            Assert.IsTrue(custom2 is CustomUnit);
        }

class CustomUnit : CustomSpecialUnit<CustomUnit>
    {
        public new string Symbol { get; } = "custom";
        CustomUnit(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, double scaler) : base(l_unit, t_unit, m_unit, scaler)
        {

        }

        protected override CustomUnit New(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, Ampere a_unit)
        {
            return new CustomUnit(l_unit, t_unit, m_unit, 1);
        }
        public static CustomUnit Instance(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, Ampere a_unit)
        {
            return new CustomUnit(l_unit, t_unit, m_unit, 1);
        }
    }
```

### **Examples**

```
// now supports derived unit arithmetics and special units Joule and newton.
var speed = 2.km() / 1.hour();
var acc = speed / 1.hour();
var f2 = acc * 80.kg();
var e1 = f2 * 500.mm();
Joule e2 = (Joule)(f1 * 10.m());
Assert.IsTrue(e1 is Joule); //true
Assert.IsTrue(f2 is Newton); //true
Assert.IsTrue(e2 is Joule); //true

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

| Units of Length |Units of Time|Units of Mass           | Eleectric Currency |
|--------------------|-----------------|------------     |__________  |
|yoktometre, [ym]   | picosecond       | picogram, [pg]  |yoktoampere,|
| zeptometre, [zm]  | nanosecond       | nanogram, [ng]  |zeptoampere,|
| attometre, [am]   | microsecond      | microgram, [µg] |attoampere, |
| femtometre, [fm]  | milisecond       | miligram, [mg]  |femtoampere,|
| picometre, [pm]   | second           | centigram, [cg] |picoampere, |
| nanometre, [nm]   | minute           | decigram, [dg]  |nanoampere, |
| micrometre, [µm]  | hour             | gram, [g]       |microampere,|
| milimetre, [mm]   | day              | decagram, [dac] |miliampere, |
| centimetre, [cm]  |                  | hectogram, [hg] |centiampere,|
| decimetre, [dm]   |                  | kilogram, [kg]  |deciampere, |
| metre, [m]        |                  | tonne, [t]      |ampere,     |
| decametre, [dam]  |                  | kilotonne, [kt] |decaampere, |
| hectometre, [hm]  |                  | megatonne, [Mt] |hectoampere,|
| kilometre, [km]   |                  |                 |kiloampere, |
| megametre, [Mm]   |                  |                 |megaampere, |
| gigametre, [Gm]   |                  |                 |gigaampere, |
| terametre, [Tm]   |                  |                 |teraampere, |
| petametre, [Pm]   |                  |                 |petaampere, |
| exametre, [Em]    |                  |                 |exaampere,  |
| zettametre, [Zm]  |                  |                 |zettaampere,|
| yottametre, [Ym]  |                  |                 |yottaampere,|


## NuGet Package

https://www.nuget.org/packages/SIUnitsArithmetic

## Lisance

This package is released under the MIT licence.
