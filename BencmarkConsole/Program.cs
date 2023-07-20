// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using CommandLine;
using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;
using SIUnits;
using static BenchmarkDotNet.Attributes.MarkdownExporterAttribute;

Console.WriteLine((1 / 1.m()).UnitStr(true));
Console.WriteLine((1 / 1.m()).UnitStr());
var res = 3.kg() / (2.m() * 2.second(2));
Console.WriteLine(res);
res = 3.kg(2) / (2.m() * 2.second());
Console.WriteLine(res);
res = 3.kg(2) / (5.m(2) * 2.second(3));
Console.WriteLine(res);
res = 5.m(2) * 2.second(3) / 3.kg(2);
Console.WriteLine(res);
//var summary = BenchmarkRunner.Run<Bench>();
//Console.WriteLine(summary);
Console.Read();

// Results to keep in github commit history
//** | Method | Mean | Error | StdDev | Ratio | RatioSD |
//** | ------------------ | ---------:| ---------:| ---------:| ------:| --------:|
//** | multiplyBasicUnit | 25.04 ms | 0.306 ms | 0.271 ms | 1.00 | 0.00 |
//** | multiplyCompUnit | 24.75 ms | 0.484 ms | 0.518 ms | 0.99 | 0.03 |
//** // * Hints *
//** Outliers
//**   Bench.multiplyBasicUnit: Default-> 1 outlier was  removed (27.53 ms)
//**   Bench.multiplyCompUnit: Default-> 2 outliers were removed (26.50 ms, 26.50 ms)

public class Bench
{
    public MetricLength l1;
    public DerivedUnit d1;
    public DerivedUnit d2;
    public int repeat = 100000;
    public Bench()
    {        
        l1 = 5.km();
        d1 = l1.ToCompositeUnit();
        d1 = new DerivedUnit(5.km());
    }
    
    [Benchmark(Baseline = true)]
    public void multiplyBasicUnit()
    {
        for(int i = 0; i < repeat; i++)
        {
            var res = l1 * d1;
        }
    }
    [Benchmark]
    public void multiplyCompUnit()
    {
        for (int i = 0; i < repeat; i++)
        {
            var res = l1 * d1;
        }
    }
}