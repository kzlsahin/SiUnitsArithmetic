// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using CommandLine;
using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;
using SIUnits;
using static BenchmarkDotNet.Attributes.MarkdownExporterAttribute;


var summary = BenchmarkRunner.Run<Bench>();
Console.WriteLine(summary);
Console.Read();

//| Method                          | Mean          | Error         | StdDev        | Ratio     | RatioSD   |
//| ------------------------------- | -------------:| -----------:  | -----------:  | -------:  | --------: |
//| multiplyDoubleWithBasicUnit     | 28.60 us      | 0.308 us      | 0.288 us      | 1.00      | 0.00      |
//| multiplyBasicWithBasicUnit      | 14,929.94 us  | 121.174 us    | 107.418 us    | 521.98    | 8.46      |
//| multiplyBasicWithDerivedUnit    | 25,000.78 us  | 497.840 us    | 532.683 us    | 871.14    | 17.09     |
//| multiplyDerivedWithDerivedUnit  | 23,547.13 us  | 389.963 us    | 364.772 us    | 823.44    | 17.30     |

//// * Hints *
//Outliers
//  Bench.multiplyBasicWithBasicUnit: Default-> 1 outlier was  removed (15.24 ms)

public class Bench
{
    double a = 1.5;
    public MetricLength l1;
    public DerivedUnit d1;
    public DerivedUnit d2;
    public int repeat = 100000;
    public Bench()
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