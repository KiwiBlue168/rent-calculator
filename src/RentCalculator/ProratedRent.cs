namespace RentCalculator;

public static class ProratedRent
{
    /// <summary>
    /// Rent for the first (partial) month, charging only from the move-in day (inclusive)
    /// to the end of that month. Rounded to 2 dp, midpoints away from zero.
    /// </summary>
    /// <exception cref="ArgumentException"><paramref name="monthlyRent"/> is zero or negative.</exception>
    public static decimal CalculateProratedRent(decimal monthlyRent, DateOnly moveInDate)
    {
        if (monthlyRent <= 0)
            throw new ArgumentException("Monthly rent must be greater than zero.", nameof(monthlyRent));

        int daysInMonth = DateTime.DaysInMonth(moveInDate.Year, moveInDate.Month);
        int daysOccupied = daysInMonth - moveInDate.Day + 1;

        // Multiply before dividing so a repeating quotient can't shift the rounded cent.
        return Math.Round(monthlyRent * daysOccupied / daysInMonth, 2, MidpointRounding.AwayFromZero);
    }
}
