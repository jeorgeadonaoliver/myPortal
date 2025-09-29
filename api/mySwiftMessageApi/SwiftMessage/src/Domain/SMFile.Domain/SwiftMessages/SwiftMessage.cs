using System.Text.RegularExpressions;

namespace SMFile.Domain.SwiftMessages;

public class SwiftMessage
{
    public SwiftBlock Block1 { get; init; }
    public SwiftBlock Block2 { get; init; }
    public SwiftBlock Block3 { get; init; }
    public SwiftBlock Block4 { get; init; }
    public SwiftBlock Block5 { get; init; }

    public List<SwiftTag> Tags => ParseTags(Block4?.Raw ?? string.Empty);

    public static List<SwiftTag> ParseTags(string block4Raw)
    {
        // Remove opening and trailing newlines/spaces and final '-' (end of block 4)
        // The block4 content often begins with a newline after the '{4:' token
        var content = block4Raw;
        // Ensure consistent newlines
        content = content.Replace("\r\n", "\n").Trim();


        // If block 4 starts with a leading colon or with a leading newline, keep it
        // Tag pattern: a line starting with ':' followed by tag code (e.g. 16R, 20C, 98A), then ':' then value possibly multi-line until next line that starts with ':' + two digits or '-' end


        var tags = new List<SwiftTag>();


        // Build regex to find positions of tag starts. We will find indices of lines that start with :\d{2,3}[A-Z]?: or :16R: etc.
        // Use multiline mode - match beginning of line
        var tagStartRegex = new Regex(@"(?m)^:(\d{2,3}[A-Z]?):");
        var matches = tagStartRegex.Matches(content);
        if (matches.Count == 0)
        {
            return tags;
        }


        var indices = new List<int>();
        var codes = new List<string>();
        foreach (Match m in matches)
        {
            indices.Add(m.Index);
            codes.Add(m.Groups[1].Value);
        }


        for (int i = 0; i < indices.Count; i++)
        {
            var start = indices[i];
            var end = (i + 1 < indices.Count) ? indices[i + 1] : content.Length;
            var rawTag = content.Substring(start, end - start);


            // rawTag begins with ':CODE:...'
            var firstColon = rawTag.IndexOf(':', 1); // second colon position
            if (firstColon == -1)
                continue;
            // Extract code between initial ':' and the second ':'
            var code = rawTag.Substring(1, firstColon - 1);
            // Value is everything after the second ':' up to end, trim trailing newlines and any trailing '-' if this is the last tag
            var value = rawTag.Substring(firstColon + 1).TrimEnd('\n', '\r');
            value = value.Trim();


            // In block 4, sometimes the block terminator '-' appears alone on a line; ensure it's removed
            if (value.EndsWith("-"))
                value = value[..^1].TrimEnd();


            tags.Add(new SwiftTag(code, value));
        }

        return tags;
    }

}
