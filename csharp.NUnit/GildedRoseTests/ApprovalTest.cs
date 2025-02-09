using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GildedRoseKata;
using NUnit.Framework;
using VerifyNUnit;

namespace GildedRose.Tests;

public class ApprovalTest
{
    [Test]
    public Task ThirtyDays()
    {
        var fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        Program.Main(new string[] { "30" });
        var output = fakeOutput.ToString();

        return Verifier.Verify(output);
    }
}
