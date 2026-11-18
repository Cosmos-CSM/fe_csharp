using System.Collections.Generic;
using System.Text;

using CSharp_Extension.Common.Extensions;

namespace Unit_Tests.Extensions;

/// <summary>
///     Tests class for <see cref="StringExtensions"/>.
/// </summary>
public class StringExtensions_UnitTests {
    [Fact(DisplayName = "[ReplaceTokens(IDictionary)]: Correctly replace existing tokens with their corresponding values")]
    public void ReplaceTokens() {
        Dictionary<string, string> replacements = Enumerable
            .Range(1, 5)
            .ToDictionary(
                _ => $"{{{Guid.NewGuid()}}}",
                _ => Guid.NewGuid().ToString());

        string original = string.Join(
            " | ",
            replacements.Keys);

        string expected = string.Join(
            " | ",
            replacements.Values);

        string result = original.ReplaceTokens(replacements);

        Assert.Equal(expected, result);
    }
}
