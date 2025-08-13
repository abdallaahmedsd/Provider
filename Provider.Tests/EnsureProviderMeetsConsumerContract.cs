using PactNet;
using PactNet.Infrastructure.Outputters;
using PactNet.Output.Xunit;
using PactNet.Verifier;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.IO;
using System;

public class MathProviderTests
{
    private readonly ITestOutputHelper _output;

    public MathProviderTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void EnsureProviderHonoursPactWithConsumer()
    {
        // This relative path is correct and portable
        var pactFile = "Pacts/MathConsumer-MathProvider.json";

        // The URI for the running provider API
        var providerUri = "https://localhost:5005";

        var config = new PactVerifierConfig
        {
            Outputters = new List<IOutput>
            {
                // Logs verifier output to the xUnit test output
                new XunitOutput(_output)
            },
            LogLevel = PactLogLevel.Debug
        };

        // Act & Assert
        new PactVerifier("MathProvider", config)
            .WithHttpEndpoint(new Uri(providerUri))
            .WithFileSource(new FileInfo(pactFile))
            // This is often pointed to a specific endpoint for managing provider states
            .WithProviderStateUrl(new Uri(providerUri + "/math/sum"))
            .Verify();
    }
}