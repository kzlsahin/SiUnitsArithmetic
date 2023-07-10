# **SI Units library with arithmetic capabilities**

This package defines metric system units and provides related arithmetic operations.

### **Definitions**

Metric(**double** *value*, **int** *degree*, **SiMetricUnits** *unit*)

**double** *value*: value of the metric.

**int** *degree*: degree is the dimension of the metric (m2, m3, m4)

**SiMetricUnits** *unit*: unit of the metric (micrometre, milimetre, metre)

### **Decleration via extension methods**

- [double].km(degree)

- [double].m(degree)

- [double].dm(degree)

- [double].cm(degree)

- [double].mm(degree)

### **Operations**

- '+' ( Metric(n) + Metric(n) ) => Metric(n); where n is degree

- '-' ( Metric(n) - Metric(n) ) => Metric(n); where n is degree

- '*'  ( Metric(n) * Metric(m) ) => Metric(n); where n and m are degrees

- '/'  ( Metric(n) / Metric(m) ) => Metric(n-m); where n and m are degrees

- '*'  ( n *  Metric(m) ) => Metric(m);  where n is double 

- '/'  ( n / Metric(m) ) => Metric(-m); where n is double**

- '*'  ( Metric(m) * n) => Metric(m);  where n is double

- '/'  ( Metric(m)  / n) => Metric(m); where n is double

**Note: zero degree metrics [Metric(0)] are equal to scalers.

### **Conversions**

- [Metric].km(degree)

- [Metric].m(degree)

- [Metric].dm(degree)

- [Metric].cm(degree)

- [Metric].mm(degree)

- [Metric].Metric(SiMetricUnits unit)

### **Examples**

- Metric m1 = 2.m();

// 2 \<m>

// 20 \<dm>

// 200 \<cm>

// 2000 \<mm>

// 0,002 \<km>

- Metric m2 = 3.m(2);

// 3 \<m2>

// 300 \<dm2>

// 30000 \<cm2>

// 3000000 \<mm2>

// 3E-06 \<km2>

- Metric m12 = (2.mm() * 10.cm() + 4.m(2)).dm();

// 400,02000000000004 <dm2>

- Metric m13 = 2 * m12;

// 800,0400000000001 <dm2>

- Metric m14 = (m12 / 2).m();

// 2,0001 <m2>

## **Supported Units**

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


## **Project Repository**

https://github.com/kzlsahin/SiUnitsArithmetic

The project is open for contributions.

## **Lisance**

This package is released under the MIT licence.
