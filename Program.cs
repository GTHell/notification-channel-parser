/**
 * Notification channel parser program
 *
 * Parse the the notification input to get the relevant tag
 *
 * @author Oudamsith Samin
 */
using System.Text.RegularExpressions;

// Case 1
Console.WriteLine("Case 1");
var input1 = "[BE][FE][Urgent] there is error";
var result1 = ParseNotificationChannel(input1);
Console.WriteLine("Receive channels: " + string.Join(",", result1));

// Case 2
Console.WriteLine("Case 2");
var input2 = "[BE][QA][HAHA][Urgent] there is error";
var result2 = ParseNotificationChannel(input2);
Console.WriteLine("Receive channels: " + string.Join(",", result2));

List<string> ParseNotificationChannel(string input)
{
    var channels = new List<string>();

    // tags candidate list
    var tags = new List<string> { "BE", "FE", "Urgent", "QA" };

    // Use regular expression to match the pattern
    // use https://regex101.com/ or python repl to test the pattern
    var pattern = @"\[(.*?)\]";

    MatchCollection matches = Regex.Matches(input, pattern);

    foreach (Match match in matches)
    {
        // Match group 1
        // Match 1 is [BE] Match Groups 1 is BE
        var tag = match.Groups[1].Value;

        if (tags.Contains(tag))
        {
            channels.Add(tag);
        }
    }

    return channels;
}
