// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using SIUnits;
using SIUnits.Length;

Console.WriteLine("Hello, World!");
var summary = BenchmarkRunner.Run<SIUnitsBenchmark>();
Console.WriteLine(summary);
Console.Read();

public class SIUnitsBenchmark
{
    public double d = 2;
    public MetricLength m = 2.m();
    public MetricLengthClass mc = 2.mc();

    [Benchmark(Baseline = true)]
    public void DoubleType()
    {
        double res = d * 2;
    }

    [Benchmark]
    public void MetricLength()
    {
        MetricLength res = m * 2;
    }
    [Benchmark]
    public void MetricLengthClass()
    {
        MetricLengthClass res = mc * 2;
    }

}
