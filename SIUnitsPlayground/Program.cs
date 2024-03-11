// See https://aka.ms/new-console-template for more information
using SIUnits;



UnitConfig.UnitPrecision = 4;
var a1 = 1.A();
var a2 = 3.A();
Assert.IsTrue(a1 + a2 == 4.Ampere(SiAmpereUnits.ampere, 1));
Assert.IsTrue(a1 - a2 == (-2).Ampere(SiAmpereUnits.ampere, 1));
Assert.IsTrue(4 * a1 - a2 == 1.Ampere(SiAmpereUnits.ampere, 1));
Assert.IsTrue((a2 + 0.A()) == 3.Ampere(SiAmpereUnits.ampere, 1));
Assert.IsTrue((a1 + a2 / 3) == 2.Ampere(SiAmpereUnits.ampere, 1));

var a3 = 2.mA();
var a4 = 15.cA();
Assert.IsTrue(a3 * a4 == 3.cA(2));
a3 = 2.dA();
a4 = 25.cA();
Assert.IsTrue(a3 * a4 == 0.05.A(2));

UnitConfig.UnitPrecision = 6;
var der1 = 1.m() / 1.second(2);
Assert.AreEqual(DerivedUnit.New(1.m(), 1.second(-2), 1.kg(0)), der1);

der1 = (2.5.second() * 100.mm()) / 1.second();
Assert.IsTrue(der1 == 25.cm());

der1 = 2.5.second() * (100.mm() / 1.second());
Assert.IsTrue(der1 == 25.cm());

der1 = 4 * 1.m() / 1.second();
Assert.IsTrue(der1 == 4.m() / 1.second());

der1 = 0.5 * 1.m() / 1.second();
Assert.IsTrue(der1 == 1.8.km() / 1.hour());

der1 = (0.001 * 5.kg()) / 1.m(3);
Assert.IsTrue(der1 == 5.g() / 1.m(3));

der1 = 0.001 * (5.kg() / 1.m(3));
Assert.IsTrue(der1 == 5.g() / 1.m(3));

der1 = 10.second() * (2.5.m() / 1.second(2));
Assert.IsTrue(der1 == 25.m() / 1.second());

der1 = (10.second() * (2.5.m()) / 1.second(2));
Assert.IsTrue(der1 == 25.m() / 1.second());

UnitConfig.UnitPrecision = 6;

Newton f1 = (Newton)((1.kg() * 1.m()) / 1.second(2));
Newton? a = (1.m() / 1.second(2)) as Newton;
Assert.IsTrue(a is Newton);

var speed = 2.km() / 1.hour();
var acc = speed / 1.hour();
var f2 = acc * 80.kg();
var e1 = f2 * 500.mm();
Joule e2 = (Joule)(f1 * 10.m());
Assert.IsTrue(e1 is Joule);
Assert.IsTrue(f2 is Newton);
Assert.IsTrue(e2 is Joule);

Console.Read();

class Assert
{
    public static  bool IsTrue(bool cond)
    {
        Console.WriteLine(cond);
        return cond;
    }

    public static bool AreEqual<T>(T a, T b)
    {
        if (a.Equals(b))
        {
            Console.WriteLine("true");
            return true;
        }
        Console.WriteLine("false");
        return false;
    }
}