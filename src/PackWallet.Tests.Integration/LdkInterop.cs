namespace PackWallet.Tests.Integration;

using org.ldk.structs;

class ConsoleLogger : LoggerInterface
{
    public void log(Record record)
    {
        // just don't throw
    }
}

public class LdkInterop
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestLoggerDoesntCrash()
    {
        Logger.new_impl(new ConsoleLogger());
    }
}
