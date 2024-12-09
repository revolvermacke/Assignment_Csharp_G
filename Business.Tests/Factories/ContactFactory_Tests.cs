﻿using Business.Factories;
using Business.Models;

namespace Business.Tests.Factories;

public class ContactFactory_Tests
{
    // Delar av koden är med viss hjälp och förklaring av chatGPT.

    [Fact]
    public void Create_ShouldReturnNewContactRegistrationForm()
    {
        //arrange

        //act = anropar metoden som skall testas
        var result = ContactFactory.create();

        //assert = verifierar att objektet är av rätt typ
        Assert.NotNull(result);
        Assert.IsType<ContactRegistrationForm>(result);
    }

    [Fact]
    public void Create_ShouldReturnContactEntityWithCorrectData()
    {
        //arrange
        var form = new ContactRegistrationForm
        {
            FirstName = "max",
            LastName = "natanaelsson",
            Email = "max.natanaelsson@outlook.com",
            PhoneNumber = "0723370655",
            Address = "bondegatan 8"
        };

        //act
        var result = ContactFactory.Create(form);
        
        //assert
        Assert.NotNull(result);
        Assert.IsType<ContactEntity>(result);
        Assert.Equal("max", result.FirstName);
        Assert.Equal("natanaelsson", result.LastName);
        Assert.Equal("max.natanaelsson@outlook.com", result.Email);
        Assert.Equal("0723370655", result.PhoneNumber);
        Assert.Equal("bondegatan 8", result.Address);
    }
}