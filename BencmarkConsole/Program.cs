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

//| Method                          | Mean      | Error     | StdDev    | Ratio | RatioSD |
//| ------------------------------- | ---------:| ---------:| ---------:| -----:| -------:|
//| multiplyDoubleWithBasicUnit     | 1.941 ms  | 0.0047 ms | 0.0042 ms | 1.00  | 0.00  |
//| multiplyBasicWithBasicUnit      | 2.552 ms  | 0.0371 ms | 0.0347 ms | 1.32  | 0.02  |
//| multiplyBasicWithDerivedUnit    | 11.202 ms | 0.1071 ms | 0.0949 ms | 5.77  | 0.06  |
//| multiplyDerivedWithDerivedUnit  | 9.447 ms  | 0.1872 ms | 0.2624 ms | 4.81  | 0.15  |

//// * Hints *
//Outliers
//  OperationsByTypeBench.multiplyDoubleWithBasicUnit: Default-> 1 outlier was  removed (1.96 ms)
//  OperationsByTypeBench.multiplyBasicWithDerivedUnit: Default-> 1 outlier was  removed (11.76 ms)

//// * Legends *
//  Mean: Arithmetic mean of all measurements
//  Error   : Half of 99.9% confidence interval
//  StdDev  : Standard deviation of all measurements
//  Ratio   : Mean of the ratio distribution ([Current]/[Baseline])
//  RatioSD: Standard deviation of the ratio distribution ([Current]/[Baseline])
//  1 ms: 1 Millisecond(0.001 sec)

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