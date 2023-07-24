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

//| Method                          | Mean      | Error     | StdDev    | Ratio     | RatioSD   |
//| ------------------------------- | ---------:| ---------:| ---------:| ------:   | --------: |
//| multiplyBasicWithBasicUnit               | 15.11 ms  | 0.274 ms   | 0.257 ms  | 1.00      | 0.00      |
//| multiplyBasicWithDerivedUnit    | 24.71 ms  | 0.471 ms   | 0.463 ms  | 1.63      | 0.03      |
//| multiplyDerivedWithDerivedUnit  | 23.92 ms  | 0.473 ms   | 0.464 ms  | 1.59      | 0.04      |

//// * Legends *
//  Mean    : Arithmetic mean of all measurements
//  Error   : Half of 99.9% confidence interval
//  StdDev  : Standard deviation of all measurements
//  Ratio   : Mean of the ratio distribution ([Current]/[Baseline])
//  RatioSD: Standard deviation of the ratio distribution ([Current]/[Baseline])
//  1 ms: 1 Millisecond(0.001 sec)

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
        d2 = new DerivedUnit(5.km());
    }
    
    [Benchmark(Baseline = true)]
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