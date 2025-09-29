namespace SMFile.Domain.SwiftMessages;

internal class InstrumentDetails
{
    public string Scheme { get; init; }   // ISIN, SEDOL, CUSIP
    public string Country { get; init; }  // e.g. GB, US
    public string Value { get; init; }    // e.g. 1234567890
}
