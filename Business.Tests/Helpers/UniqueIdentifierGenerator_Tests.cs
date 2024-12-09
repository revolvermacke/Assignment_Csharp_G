﻿using Business.Helpers;

namespace Business.Tests.Helpers;

public class UniqueIdentifierGenerator_Tests
{
    [Fact]
    public void GenerateUniqueId_ShouldReturnGuidId()
    {
        //arrange

        //act
        var result = UniqueIdentifierGenerator.GenerateUniqueId();

        //assert
        Assert.NotNull(result);

        bool isValidGuid = Guid.TryParse(result, out _);
        Assert.True(isValidGuid);
    }
}