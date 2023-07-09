# SI Units library with arithmetic capabilities.

There are basic types like milimeter or meter and combined types like square meter or square milimeter.

The project is open for contributions.

### Example

Metric m1 = 2.m();

// output: 2 \<m\>

Metric m2 = 3.m(2);

// output: 3 \<m2\>

Metric m3 = (2.mm() * 10.cm() + 4.m(2)).dm();

// output: 40,002 \<dm2\>

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
