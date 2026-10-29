using Soenneker.Klaviyo.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Klaviyo.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class KlaviyoOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IKlaviyoOpenApiHttpClient _httpclient;

    public KlaviyoOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IKlaviyoOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
