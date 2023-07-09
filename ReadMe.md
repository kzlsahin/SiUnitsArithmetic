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

Meter [m]

Decimeter [dm] 

Centimeter [cm]

Milimeter [mm] 

SqMeter [m2] 

SqDecimeter[cm2] 

SqCentimeter[cm2] 

SqMilimeter[mm2]

## Project Repository

https://github.com/kzlsahin/SiUnitsArithmetic

## Lisance

This package is released under the MIT licence.
