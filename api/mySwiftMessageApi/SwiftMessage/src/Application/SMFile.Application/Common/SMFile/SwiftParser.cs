using SMFile.Domain.SwiftMessages;
using System.Text.RegularExpressions;

namespace SMFile.Application.Common.SMFile;

public class SwiftParser
{
    private static readonly Regex BlockRegex = new Regex(@"\{(\d):(?<content>.*?)\}", RegexOptions.Singleline);

    public static SwiftMessage Parse(string rawMessage)
    {
        if (string.IsNullOrWhiteSpace(rawMessage)) throw new ArgumentNullException(nameof(rawMessage));


        var blocks = new Dictionary<string, string>();
        // We need to carefully parse blocks because block 4 may contain '}' characters in data. We'll parse by locating '{n:' and matching the closing '}' that pairs to it.
        // Simpler approach: iterate through the message and detect top-level blocks.


        int pos = 0;
        while (pos < rawMessage.Length)
        {
            var openIdx = rawMessage.IndexOf('{', pos);
            if (openIdx == -1) break;
            var colonIdx = rawMessage.IndexOf(':', openIdx + 1);
            if (colonIdx == -1) break;
            var blockNumber = rawMessage.Substring(openIdx + 1, colonIdx - openIdx - 1);
            // find the matching closing '}' for this block at top-level
            int searchPos = colonIdx + 1;
            int braceDepth = 1;
            int i = searchPos;
            for (; i < rawMessage.Length; i++)
            {
                if (rawMessage[i] == '{') braceDepth++;
                else if (rawMessage[i] == '}') braceDepth--;
                if (braceDepth == 0) break;
            }
            if (i >= rawMessage.Length) break; // malformed
            var content = rawMessage.Substring(colonIdx + 1, i - colonIdx - 1);
            blocks[blockNumber] = content;
            pos = i + 1;
        }


        blocks.TryGetValue("1", out var b1);
        blocks.TryGetValue("2", out var b2);
        blocks.TryGetValue("3", out var b3);
        blocks.TryGetValue("4", out var b4);
        blocks.TryGetValue("5", out var b5);


        return new SwiftMessage
        {
            Block1 = new SwiftBlock { Raw = b1 },
            Block2 = new SwiftBlock { Raw = b2 },
            Block3 = new SwiftBlock { Raw = b3 },
            Block4 = new SwiftBlock { Raw = b4 },
            Block5 = new SwiftBlock { Raw = b5 }
        };
    }
}
