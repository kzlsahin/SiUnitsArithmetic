# SI Units library with arithmetic capabilities.

This package defines metric system units and provides related arithmetic operations.


### Definitions

Metric(**double** *value*, **int** *degree*, **SiMetricUnits** *unit*)

**double** *value*: value of the metric.

**int** *degree*: degree is the dimension of the metric (m2, m3, m4)

**SiMetricUnits** *unit*: unit of the metric (micrometre, milimetre, metre)

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
### Operations

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

  
### Examples

![image](https://github.com/kzlsahin/SiUnitsArithmetic/assets/46689277/d407e2b5-b732-4f5c-b835-8f70b8fe418e)

- Metric m1 = 2.m();

2 \<m>

20 \<dm>

200 \<cm>

2000 \<mm>

0,002 \<km>

- Metric m2 = 3.m(2);
3 \<m2>

300 \<dm2>

30000 \<cm2>

3000000 \<mm2>

3E-06 \<km2>

- Metric m3 = (2.mm() * 10.cm() + 4.m(2)).dm();

// output: 40,002 \<dm2\>

- Metric m13 = 2 * m12;
// output: 80,004 \<dm2\>

- Metric m14 = (m12 / 2).m();
// output: 2000,1000000000001 \<m2\>

- Metric m15 = (2 / m12).m();
// output: ,999750012499375 \<1/m2\>

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
