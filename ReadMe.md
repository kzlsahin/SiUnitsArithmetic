# SI Units library with arithmetic capabilities.

There are basic types like milimeter or meter and combined types like square meter or square milimeter.

The project is open for contributions.

### Examples

Metric m1 = 2.m();

2 \<m>

20 \<dm>

200 \<cm>

2000 \<mm>

0,002 \<km>

Metric m2 = 3.m(2);
3 \<m2>

300 \<dm2>

30000 \<cm2>

3000000 \<mm2>

3E-06 \<km2>

Metric m3 = (2.mm() * 10.cm() + 4.m(2)).dm();

// output: 40,002 \<dm2\>

Metric m13 = 2 * m12;
// output: 80,004 \<dm2\>

Metric m14 = (m12 / 2).m();
// output: 2000,1000000000001 \<m2\>

Metric m15 = (2 / m12).m();
// output: ,999750012499375 \<1/m2\>

## Supported Units

yoktometre, [ym]

zeptometre, [zm]

attometre, [am]

femtometre, [fm]

picometre, [pm]

nanometre, [nm]

micrometre, [µm]

milimetre, [mm]

centimetre, [cm]

decimetre, [dm]

metre, [m]

decametre, [dam]

hectometre, [hm]

kilometre, [km]

megametre, [Mm]

gigametre, [Gm]

terametre, [Tm]

petametre, [Pm]

exametre, [Em]

zettametre, [Zm]

yottametre, [Ym]

## NuGet Package

https://www.nuget.org/packages/SIUnitsArithmetic

## Lisance

This package is released under the MIT licence.
