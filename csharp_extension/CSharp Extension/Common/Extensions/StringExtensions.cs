namespace CSharp_Extension.Common.Extensions;

/// <summary>
///     Extends <see cref="string"/> class.
/// </summary>
public static class StringExtensions {

    /// <summary>
    ///     Replaces tokens in the given <paramref name="text"/> with the corresponding values from the <paramref name="replacements"/> dictionary.
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

            text = text.Replace(
                replacement.Key,
                replacement.Value ?? string.Empty,
                StringComparison.OrdinalIgnoreCase);
        }

        return text;
    }

   
}
