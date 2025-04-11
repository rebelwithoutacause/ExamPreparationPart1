using NUnit.Framework;
using System;
using System.Data.Common;
using TestApp.Product;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string name = "Beer";
        double price = 2.7;
        int quantity = 3;

        // Act
        _inventory.AddProduct(name, price, quantity);
        string inventoryDisplay = _inventory.DisplayInventory();

        // Assert
        string expectedOutput = $"Product Inventory:{Environment.NewLine}Beer - Price: $2.70 - Quantity: 3";
        Assert.AreEqual(expectedOutput, inventoryDisplay);


    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        

        // Act
       
        string inventoryDisplay = _inventory.DisplayInventory();

        // Assert
        string expectedOutput = string.Empty;
        Assert.That(expectedOutput, Is.Empty);
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        string name = "Beer";
        double price = 2.7;
        int quantity = 3;

        // Act
        _inventory.AddProduct(name, price, quantity);
        string inventoryDisplay = _inventory.DisplayInventory();

        // Assert
        string expectedOutput = $"Product Inventory:{Environment.NewLine}Beer - Price: $2.70 - Quantity: 3";
        Assert.AreEqual(expectedOutput, inventoryDisplay);
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        //Arrange

        //Act
        double calculateValue = _inventory.CalculateTotalValue();
        //Assert
        Assert.That(calculateValue, Is.Zero);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        string name = "Basket with fruits";
        double price = 23.23;
        int quantity = 5;

        _inventory.AddProduct(name, price, quantity);

        //Act
        double calculateValue = _inventory.CalculateTotalValue();

        //Assert
        double expectedValue = price * quantity;
        Assert.AreEqual(_inventory.CalculateTotalValue(), expectedValue);
    }
}
