using CSharpFunctionalExtensions;

namespace Skilladd.Domain.Hiring.VO;

public sealed record Location
{
    private Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public double Latitude { get; }
    public double Longitude { get; }

    public static Result<Location> Create(double latitude, double longitude)
    {
        if (double.IsNaN(latitude))
            return Result.Failure<Location>("latitude is NaN");

        if (double.IsNaN(longitude))
            return Result.Failure<Location>("longitude is NaN");
        
        if (-90 > latitude && 90 < latitude)
            return Result.Failure<Location>("-90 < latitude < 90");
        
        if (-180 > longitude && 180 < longitude)
            return Result.Failure<Location>("-180 < longitude < 180");

        return Result.Success<Location>( new Location(latitude, longitude));
    }
}    