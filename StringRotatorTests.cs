using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        string input = string.Empty;
        int position = 3;

        string result = StringRotator.RotateRight(input, position);

        Assert.AreEqual(string.Empty, result);

    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        string input = "1 2 3";
        int position = 0;
        string expected = "1 2 3";

        string result = StringRotator.RotateRight(input, position);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "3 3 3";
        int position = 5;
        string expected = "3 3 3";

        // Act
        string result = StringRotator.RotateRight(input, position);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "1 2 3";
        int position = -1;
        string expected = "31 2 "; 

        // Act
        string result = StringRotator.RotateRight(input, position);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        // Arrange
        string input = "1 2 3";
        int position = 7;
        string expected = " 31 2";

        // Act
        string result = StringRotator.RotateRight(input, position);

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }
}
