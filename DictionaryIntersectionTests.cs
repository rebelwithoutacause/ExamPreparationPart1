using System.Collections.Generic;
using System.Diagnostics.Tracing;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        Dictionary<string, int> dict2 = new Dictionary<string, int>();

        var expected = new Dictionary<string, int>();

        // Act
        var result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.IsEmpty(result);

    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        Dictionary<string, int> dict2 = new Dictionary<string, int> { { "words", 3 } };
        


        var expected = new Dictionary<string, int>();

        // Act
        var result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> dict1 = new Dictionary<string, int> { { "beers", 3 } };
        Dictionary<string, int> dict2 = new Dictionary<string, int> { { "cigarettes", 3 } };

        var result = DictionaryIntersection.Intersect(dict1, dict2);

        Assert.That(result, Is.EqualTo(new Dictionary<string, int>()));

    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int> { { "cigarettes", 3 }, { "coffee", 2 } };
        Dictionary<string, int> dict2 = new Dictionary<string, int> { { "cigarettes", 3 }, { "beer", 5 } };

        var expected = new Dictionary<string, int> { { "cigarettes", 3 } };

        // Act
        var result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int> { { "cigarettes", 3 } };
        Dictionary<string, int> dict2 = new Dictionary<string, int> { { "cigarettes", 5 } };

        var expected = new Dictionary<string, int>();

        // Act
        var result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
