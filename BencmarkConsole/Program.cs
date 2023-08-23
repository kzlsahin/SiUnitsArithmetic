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

//| Method | Mean | Error | StdDev | Ratio | RatioSD |
//| ------------------------------- | ----------:| ----------:| ----------:| ------:| --------:|
//| multiplyDoubleWithBasicUnit | 1.921 ms | 0.0170 ms | 0.0159 ms | 1.00 | 0.00 |
//| multiplyBasicWithBasicUnit | 3.519 ms | 0.0503 ms | 0.0470 ms | 1.83 | 0.04 |
//| multiplyBasicWithDerivedUnit | 44.970 ms | 0.5998 ms | 0.5317 ms | 23.39 | 0.35 |
//| multiplyDerivedWithDerivedUnit | 29.249 ms | 0.3217 ms | 0.2512 ms | 15.22 | 0.22 |

//// * Hints *
//Outliers
//  OperationsByTypeBench.multiplyBasicWithDerivedUnit: Default-> 1 outlier was  removed, 2 outliers were detected (43.73 ms, 46.01 ms)
//  OperationsByTypeBench.multiplyDerivedWithDerivedUnit: Default-> 3 outliers were removed (30.18 ms..30.41 ms)

//// * Legends *
//  Mean: Arithmetic mean of all measurements
//  Error   : Half of 99.9% confidence interval
//  StdDev  : Standard deviation of all measurements
//  Ratio   : Mean of the ratio distribution ([Current]/[Baseline])
//  RatioSD: Standard deviation of the ratio distribution ([Current]/[Baseline])

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
        d2 = DerivedUnit.New(5.km());
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