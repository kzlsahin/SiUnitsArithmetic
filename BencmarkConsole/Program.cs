// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using CommandLine;
using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;
using SIUnits;
using static BenchmarkDotNet.Attributes.MarkdownExporterAttribute;


var summary = BenchmarkRunner.Run<OperationsByTypeBench>();
Console.WriteLine(summary);
Console.Read();

//| Method                          | Mean      | Error         | StdDev    | Ratio | RatioSD |
//| ------------------------------- | ---------:| ----------:   | ---------:| -----:| --------:|
//| multiplyDoubleWithBasicUnit     | 1.908 ms  | 0.0184 ms     | 0.0163 ms | 1.00  | 0.00 |
//| multiplyBasicWithBasicUnit      | 12.618 ms | 0.2366 ms     | 0.2213 ms | 6.61  | 0.11 |
//| multiplyBasicWithDerivedUnit    | 22.374 ms | 0.4057 ms     | 0.3596 ms | 11.73 | 0.22 |
//| multiplyDerivedWithDerivedUnit  | 20.424 ms | 0.3167 ms     | 0.2645 ms | 10.70 | 0.16 |

//// * Hints *
//Outliers
//  OperationsByTypeBench.multiplyDoubleWithBasicUnit: Default-> 1 outlier was  removed (2.00 ms)
//  OperationsByTypeBench.multiplyBasicWithDerivedUnit: Default-> 1 outlier was  removed (23.75 ms)
//  OperationsByTypeBench.multiplyDerivedWithDerivedUnit: Default-> 2 outliers were removed (21.34 ms, 21.86 ms)
public class OperationsByTypeBench
{
    double a = 1.5;
    public MetricLength l1;
    public DerivedUnit d1;
    public DerivedUnit d2;
    public int repeat = 100000;
    public OperationsByTypeBench()
    {        

        l1 = 5.km();
        d1 = l1.ToCompositeUnit();
        d2 = new DerivedUnit(5.km());
    }

    [Benchmark(Baseline = true)]
    public void multiplyDoubleWithBasicUnit()
    {
        for (int i = 0; i < repeat; i++)
        {
            var res = a * l1;
        }
    }

    [Benchmark]
    public void multiplyBasicWithBasicUnit()
    {
        for(int i = 0; i < repeat; i++)
        {
            var res = l1 * l1;
        }
    }
    [Benchmark]
    public void multiplyBasicWithDerivedUnit()
    {
        for (int i = 0; i < repeat; i++)
        {
            var res = l1 * d1;
        }
    }
    [Benchmark]
    public void multiplyDerivedWithDerivedUnit()
    {
        for (int i = 0; i < repeat; i++)
        {
            var res = d1 * d2;
        }
    }
}