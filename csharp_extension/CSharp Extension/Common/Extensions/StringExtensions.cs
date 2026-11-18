using System.Text.RegularExpressions;

namespace CSharp_Extension.Common.Extensions;

/// <summary>
///     Extends <see cref="string"/> class.
/// </summary>
public static partial class StringExtensions {

    /// <summary>
    /// Find Tokens in the given string using a regex pattern.
    /// </summary>
    /// <returns></returns>
    [GeneratedRegex(@"\{[^{}]+\}")]
    private static partial Regex TokenRegex();

    /// <summary>
    ///     Replaces tokens in the given <paramref name="text"/> with the corresponding values from the <paramref name="replacements"/> dictionary.
    ///     Regex pattern used to identify tokens is defined in the <see cref="TokenRegex"/> method, preventing replacement values from 
    ///     being rescanned and replaced again if they match the token pattern.
    /// </summary>
    /// <param name="text"> The text in which to replace tokens. </param>
    /// <param name="replacements"> A dictionary containing the tokens and their corresponding replacement values. </param>
    /// <returns> The text with the tokens replaced by their corresponding values. </returns>
    public static string ReplaceTokens(this string text, IDictionary<string, string> replacements) {
        
        if (string.IsNullOrEmpty(text) || replacements.Count == 0)
            return text;

        foreach (KeyValuePair<string, string> replacement in replacements) {

            if (string.IsNullOrEmpty(replacement.Key))
                continue;

            return TokenRegex().Replace(text, match => {
                    return replacements.TryGetValue(
                        match.Value,
                        out string? value)
                        ? value ?? string.Empty
                        : match.Value;
                });
        }

        return text;
    }
}
