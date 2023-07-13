// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using SIUnits;
using SIUnits.Length;


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
        for(int i = 0;i < 10000000; i++)
        {
            d = d + 1;
        } 
    }

    [Benchmark]
    public void MetricLength()
    {
        for (int i = 0; i < 10000000; i++)
        {
            m = m + 1.m();

        }
    }
    [Benchmark]
    public void MetricLengthClass()
    {
        for (int i = 0; i < 10000000; i++)
        {
           mc = mc + 1.mc();
        }
    }

}
