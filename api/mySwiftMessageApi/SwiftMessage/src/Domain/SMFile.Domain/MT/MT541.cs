using SMFile.Domain.SwiftMessages;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.RegularExpressions;

namespace SMFile.Domain.MT;

public class MT541
{
    private readonly SwiftMessage _msg;
    public MT541(SwiftMessage msg)
    {
        _msg = msg;
    }


    private string GetTagValue(string code, Func<string, bool> predicate = null)
    {
        var tag = predicate == null
        ? _msg.Tags.FirstOrDefault(t => t.Code == code)
        : _msg.Tags.FirstOrDefault(t => t.Code == code && predicate(t.Value));
        return tag?.Value;
    }


    public IEnumerable<(string GroupStartTag, string GroupEndTag)> GetGroups()
    {
        // Very simple: returns pairs of 16R/16S group codes in sequence
        var seq = _msg.Tags.Where(t => t.Code == "16R" || t.Code == "16S").Select(t => t.Value.Trim()).ToList();
        for (int i = 0; i < seq.Count; i += 2)
        {
            var start = seq[i];
            var end = (i + 1 < seq.Count) ? seq[i + 1] : string.Empty;
            yield return (start, end);
        }
    }


    // Example typed accessors (parses qualifiers like :98A::PREP//20250927)
    public string SenderReference => GetTagValue("20C", v => v.Contains("SEME") || v.StartsWith(":SEME")) ?? GetTagValue("20");


    public string FunctionOfMessage => GetTagValue("23G");


    public DateTime? PreparationDate
    {
        get
        {
            // Find 98A tag where content contains PREP
            var tag = _msg.Tags.FirstOrDefault(t => t.Code == "98A" && t.Value.Contains("PREP"));
            if (tag == null) return null;
            // Value example: ":PREP//20250927" or "::PREP//20250927" depending on message
            var m = Regex.Match(tag.Value, @"(?:PREP//)(\d{8})");
            if (!m.Success) return null;
            if (DateTime.TryParseExact(m.Groups[1].Value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var dt))
                return dt;
            return null;
        }
    }

    public string ChainEvent => GetTagValue("22F");

    public string TradeType => GetTagValue("94B");

    public DateTime? TradeDate
    {
        get
        {
            var tag = _msg.Tags.FirstOrDefault(t => t.Code == "98A" && t.Value.Contains("TRAD"));
            if (tag == null) return null;
            var m = Regex.Match(tag.Value, @"TRAD//(\d{8})");
            if (!m.Success) return null;
            if (DateTime.TryParseExact(m.Groups[1].Value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var dt))
                return dt;
            return null;
        }
    }


    //public string ISIN => GetTagValue("35B");

    public string CUSIP => GetInstrument().Value;

    public string CUSIPSCHEME => GetInstrument().Scheme;

    public string SEDOL => GetInstrument().Value;

    public string ISIN => GetInstrument().Value;


    private InstrumentDetails GetInstrument() {


        var raw = GetTagValue("35B");
            if (string.IsNullOrWhiteSpace(raw)) return null;

            // Trim spaces/newlines
            raw = raw.Trim();

            // Case 1: ISIN 1234567890
            if (raw.StartsWith("ISIN", StringComparison.OrdinalIgnoreCase))
            {
                var parts = raw.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                return new InstrumentDetails
                {
                    Scheme = "ISIN",
                    Value = parts.Length > 1 ? parts[1] : null,
                    Country = null
                };
            }

            // Case 2/3: /XX/123456... (SEDOL, CUSIP, etc.)
            var match = Regex.Match(raw, @"^/(?<cc>[A-Z]{2})/(?<val>.+)$");
            if (match.Success)
            {
                var country = match.Groups["cc"].Value;
                var value = match.Groups["val"].Value;

                return new InstrumentDetails
                {
                    Scheme = country switch
                    {
                        "GB" => "SEDOL",
                        "US" => "CUSIP",
                        _ => "UNKNOWN"
                    },
                    Value = value,
                    Country = country
                };

            }
            else
            {
            return new InstrumentDetails
            {
                Scheme = "UNKNOWN",
                Value = string.Empty,
                Country = string.Empty
            };             
        }
    }


    public decimal? Units
    {
        get
        {
            // 36B::SETT//UNIT/1000,
            var tag = _msg.Tags.FirstOrDefault(t => t.Code == "36B");
            if (tag == null) return null;
            var m = Regex.Match(tag.Value, @"UNIT/(\d+[\d,]*)");
            if (!m.Success) return null;
            var raw = m.Groups[1].Value.Replace(",", "");
            if (decimal.TryParse(raw, out var d)) return d;
            return null;
        }
    }

    public string SafekeepingAccount => GetTagValue("97A");
}
