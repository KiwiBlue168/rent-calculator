namespace RentCalculator.Tests;

// Acceptance criteria from Jira TRIAL-1.
public class ProratedRentTests
{
    public static TheoryData<string, decimal, DateOnly, decimal> AcceptanceCases => new()
    {
        { "AC1.1 full month",              3100m, new DateOnly(2026, 3, 1),  3100.00m },
        { "AC1.2 mid-month, 31-day month", 3100m, new DateOnly(2026, 3, 16), 1600.00m },
        { "AC1.3 last day of month",       3100m, new DateOnly(2026, 1, 31), 100.00m },
        { "AC1.4 February, 28 days",       2800m, new DateOnly(2027, 2, 15), 1400.00m },
        { "AC1.5 February, leap year",     2900m, new DateOnly(2028, 2, 15), 1500.00m },
        { "AC1.6 rounding to 2 dp",        1000m, new DateOnly(2026, 4, 2),  966.67m },
    };

    [Theory]
    [MemberData(nameof(AcceptanceCases))]
    public void CalculateProratedRent_ReturnsRentForDaysOccupied(
        string acceptanceCriterion, decimal monthlyRent, DateOnly moveInDate, decimal expected)
    {
        _ = acceptanceCriterion; // labels the case in test output

        var actual = ProratedRent.CalculateProratedRent(monthlyRent, moveInDate);

        Assert.Equal(expected, actual);
    }

    // AC1.7
    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void CalculateProratedRent_NonPositiveRent_ThrowsArgumentException(int monthlyRent)
    {
        Assert.Throws<ArgumentException>(
            () => ProratedRent.CalculateProratedRent(monthlyRent, new DateOnly(2026, 3, 1)));
    }
}
