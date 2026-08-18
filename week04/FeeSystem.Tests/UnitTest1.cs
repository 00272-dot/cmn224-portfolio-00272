using NUnit.Framework;                                                       // NUnit framework is used for unit testing in C#.
using FeeSystem;                                                             // Namespace containing the FeeCalculator class.
 
[TestFixture]                                                               // Attribute indicating that this class contains unit tests.
public class FeeCalculatorTests                                            // Class containing unit tests for the FeeCalculator class.
{  //Checklist 1
    [Test]                                                                 // Attribute indicating that this method is a test case.
    public void OutstandingBalance_NoPayments_ReturnsFullFee()             // Test method to check if the outstanding balance is equal to the full fee when no payments have been made.
    { 
        // Arrange 
        var calc = new FeeCalculator();                                   // Create an instance of the FeeCalculator class.
        var payments = new List<decimal>();                               // Create an empty list of payments to simulate no payments made.   
 
        // Act 
        var result = calc.OutstandingBalance(600m, payments);             // Call the OutstandingBalance method with a fee of 600 and no payments.
 
        // Assert 
        Assert.That(result, Is.EqualTo(600m));                            // Assert that the result is equal to the full fee of 600, as no payments have been made.
    } 

    //Checklist 2
    [Test]
    public void OutstandingBalance_OnePartialPayments_ReturnsRemainingBalance()  // Test method to check if the outstanding balance is correctly calculated when one partial payment has been made.
    { 
        // Arrange 
        var calc = new FeeCalculator();                                         // Create an instance of the FeeCalculator class.
        var payments = new List<decimal> { 200m};                            // Create a list of payments containing one payment of 200 to simulate a partial payment made.
 
        // Act 
        var result = calc.OutstandingBalance(600m, payments);               // Call the OutstandingBalance method with a fee of 600 and one partial payment of 200.
        // Assert 
        Assert.That(result, Is.EqualTo(400m));                              // Assert that the result is equal to the remaining balance of 400, as one partial payment of 200 has been made.
    }

    //Checklist 3
    [Test]  
    public void OutstandingBalance_SeveralInstallments_ReturnsRemainingBalance() // Test method to check if the outstanding balance is correctly calculated when several installment payments have been made.   
    { 
        //Arrange
        var calc = new FeeCalculator(); // Create an instance of the FeeCalculator class.
        var payments = new List<decimal> { 200m, 200m, 100m };   // Create a list of payments containing three payments of 200, 200, and 100 to simulate several installment payments made.               
 
        // Act 
        var result = calc.OutstandingBalance(600m, payments);   //   Call the OutstandingBalance method with a fee of 600 and several installment payments of 200, 200, and 100.            
        // Assert 
        Assert.That(result, Is.EqualTo(100m));       //  Assert that the result is equal to the remaining balance of 100, as several installment payments of 200, 200, and 100 have been made.                       
    }

    //Checklist 4
    [Test]
    public void OutstandingBalance_FeeFullyPaid_ReturnsZero()  // Test method to check if the outstanding balance is zero when the fee has been fully paid.
    { 
        // Arrange 
        var calc = new FeeCalculator();                                         // Create an instance of the FeeCalculator class.
        var payments = new List<decimal> { 600m};                            // Create a list of payments containing one payment of 600 to simulate the fee being fully paid.
 
        // Act 
        var result = calc.OutstandingBalance(600m, payments);               // Call the OutstandingBalance method with a fee of 600 and one payment of 600.
        // Assert 
        Assert.That(result, Is.EqualTo(0m));                              // Assert that the result is equal to zero, as the fee has been fully paid.                       
    }
    
    //Checklist 5
    [Test]
    public void OutstandingBalance_Overpayment_ReturnsNegativeBalance()  // Test method to check if the outstanding balance is negative when an overpayment has been made.
    { 
        // Arrange 
        var calc = new FeeCalculator();                                         // Create an instance of the FeeCalculator class.
        var payments = new List<decimal> { 700m };                            // Create a list of payments containing one payment of 700 to simulate an overpayment made.
 
        // Act 
        var result = calc.OutstandingBalance(600m, payments);               // Call the OutstandingBalance method with a fee of 600 and one payment of 700.
        // Assert 
        Assert.That(result, Is.EqualTo(-100m));                              // Assert that the result is equal to -100, as an overpayment of 100 has been made.                       
    }

    //Checklist 6
    [Test]
    public void OutstandingBalance_NegativeFee_ThrowsArgumentException()  // Test method to check if an ArgumentException is thrown when a negative fee is provided.
    { 
        // Arrange 
        var calc = new FeeCalculator();                                         // Create an instance of the FeeCalculator class.
        var payments = new List<decimal> ();                            // Create an empty list of payments to simulate no payments made.
 
        // Act & Assert 
        Assert.Throws<ArgumentException>(() => calc.OutstandingBalance(-1m, payments));  // Assert that an ArgumentException is thrown when the OutstandingBalance method is called with a negative fee of -1 and no payments.                    
    }  

    //Checklist 7
    [Test]  
    public void OutstandingBalance_ExactlyHalfPaid_ReturnsHalfBalance()  // Test method to check if the outstanding balance is correctly calculated when exactly half of the fee has been paid.
    { 
        // Arrange 
        var calc = new FeeCalculator();                                         // Create an instance of the FeeCalculator class.
        var payments = new List<decimal> { 300m };                            // Create a list of payments containing one payment of 300 to simulate exactly half of the fee being paid.
 
        // Act 
        var result = calc.OutstandingBalance(600m, payments);               // Call the OutstandingBalance method with a fee of 600 and one payment of 300.
        // Assert 
        Assert.That(result, Is.EqualTo(300m));                              // Assert that the result is equal to 300, as exactly half of the fee has been paid.                       
    }

    //Checklist 8
    [Test]
    public void OutstandingBalance_OneToeaUnderHalf_ReturnsRemainingBalance()  // Test method to check if the outstanding balance is correctly calculated when one payment is made that is just under half of the fee.
    { 
        // Arrange 
        var calc = new FeeCalculator();                                         // Create an instance of the FeeCalculator class.
        var payments = new List<decimal> { 0.49m };                            // Create a list of payments containing one payment of 0.49 to simulate a payment just under half of the fee being made.
 
        // Act 
        var result = calc.OutstandingBalance(600m, payments);               // Call the OutstandingBalance method with a fee of 600 and one payment of 0.49.
        // Assert 
        Assert.That(result, Is.EqualTo(599.51m));                              // Assert that the result is equal to 599.51, as one payment just under half of the fee has been made.                       
    }
} 