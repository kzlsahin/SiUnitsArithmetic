# **SI Units library with arithmetic capabilities**

SIUnitsArithmetic defines metric system units and provides related arithmetic operations including unit to unit multiplication even with compound units, resulting in higher or lower order units (m², 1/m or m/s).
Supports length, mass and time units.

Derived units consisting of multiple basic units (length, time, mass) are also supported.
Newton and Joule are added as special units which are also derived unit types.

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

### Extensiblity

Now custom units can be defined by the users of this library. Example of a Customunit:

```

// This unit has to be registered
// call this method only once in the application
CustomUnit.RegisterSpecialUnit(new DerivedDegree(2, -2, 2), CustomUnit.Instance);

class CustomUnit : CustomSpecialUnit<CustomUnit>
{
    // use new modifier
    public new string Symbol { get; } = "custom";
    CustomUnit(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, double scaler) : base(l_unit, t_unit, m_unit, scaler)
    
    }
    // override this method
    protected override CustomUnit New(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit)
    {
        return new CustomUnit(l_unit, t_unit, m_unit, 1);
    }
    // define a static Instance method
    public static CustomUnit Instance(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit)
    {
        return new CustomUnit(l_unit, t_unit, m_unit, 1);
    }
}
```
### **Examples**

```
// now supports derived unit arithmetics
var speed = 1.m() / 1.second()
// 1 m/s

3.kg() / (2.m() * 2.second(2));
// 0,75 kg/m.s²

5.m(2) * 2.second(3) / 3.kg(2);
//10,000000000000002 m².s³/kg²

var m1 = 2.m();
// 2 m

m1.dcm()
// 200 cm

var s1 = 3.hour();
// 3 s

s1.minute()
// 180 m

s1.second()
// 10800 s

var m12 = (2.mm() * 10.cm() + 4.m(2)).dm();
// 400,02000000000004 dm2

var m13 = 2 * m12;
// 800,0400000000001 dm2

var m14 = (m12 / 2).m();
// 2,0001 m²

```



| Operations      |  Operants      |  Result  |          |
|-----------------|----------------|----------|----------|
| + |Metric(n) + Metric(n)   |=> Metric(n)   |where n is degree         | 
| - |Metric(n) - Metric(n)   |=> Metric(n)   |where n is degree          | 
| * |Metric(n) * Metric(m)   |=> Metric(n)   |where n and m are degrees | 
| / |Metric(n) / Metric(m)   |=> Metric(n-m) |where n and m are degrees | 
| * |n * Metric(m)           |=> Metric(m)   |where n is double         | 
| / |n / Metric(m)           |=> Metric(-m)  |where n is double         | 
| * |Metric(m) * n           |=> Metric(m)   |where n is double         | 
| / |Metric(m) / n           |=> Metric(m)   |where n is double         | 

Note: zero degree metrics [Metric(0)] are equal to scalers.

### **Conversions**

| MetricLength  | MetricMass | MetricTime |
|--------------|-------------|------------|
|[MetricLength].km(degree)|[MetricMass].mg()|[MetricTime].msec()|
|[MetricLength].m(degree)|[MetricMass].g()|[MetricTime].milisecond()|
|[MetricLength].dm(degree)|[MetricMass].kg()|[MetricTime].second()|
|[MetricLength].cm(degree)|[MetricMass].tonne()|[MetricTime].minute()|
|[MetricLength].mm(degree)|[MetricMass].t()|[MetricTime].hour()|
|[MetricLength].MetricLength(SiMetricUnits unit)|[MetricMass].MetricMass(SiMassUnit)|[MetricTime].MetricTime()|


## **Supported Units**

| Units of Length |Units of Time|Units of Mass
|--------------------|-----------------|------------     |
|yoktometre, [ym]   | picosecond       | picogram, [pg]  |
| zeptometre, [zm]  | nanosecond       | nanogram, [ng]  |
| attometre, [am]   | microsecond      | microgram, [µg] |
| femtometre, [fm]  | milisecond       | miligram, [mg]  |
| picometre, [pm]   | second           | centigram, [cg] |
| nanometre, [nm]   | minute           | decigram, [dg]  |
| micrometre, [µm]  | hour             | gram, [g]       |
| milimetre, [mm]   | day              | decagram, [dac] |
| centimetre, [cm]  |                  | hectogram, [hg] |
| decimetre, [dm]   |                  | kilogram, [kg]  |
| metre, [m]        |                  | tonne, [t]      |
| decametre, [dam]  |                  | kilotonne, [kt] |
| hectometre, [hm]  |                  | megatonne, [Mt] |
| kilometre, [km]   |                  |                 |
| megametre, [Mm]   |                  |                 |
| gigametre, [Gm]   |                  |                 |
| terametre, [Tm]   |                  |                 |
| petametre, [Pm]   |                  |                 |
| exametre, [Em]    |                  |                 |
| zettametre, [Zm]  |                  |                 |
| yottametre, [Ym]  |                  |                 |




## **Project Repository**

https://github.com/kzlsahin/SiUnitsArithmetic

Contributions are welcome.

## **Lisance**

This package is released under the MIT licence.
