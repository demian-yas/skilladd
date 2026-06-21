using CSharpFunctionalExtensions;
using Skilladd.Domain.Common;

namespace Skilladd.Domain.Hiring.VO;

public sealed record Location
{
    private Location()
    {
    }

    private Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public double Latitude { get; }
    public double Longitude { get; }

    public static Result<Location, Error> Create(double latitude, double longitude)
    {
        if (double.IsNaN(latitude))
            return Errors.General.ValueIsEmpty("latitude");

        if (double.IsNaN(longitude))
            return Errors.General.ValueIsEmpty("longitude");
        
        if (-90 > latitude || 90 < latitude)
            return Errors.General.ValueIsInvalid("latitude");
        
        if (-180 > longitude || 180 < longitude)
            return Errors.General.ValueIsInvalid("longitude");

        return Result.Success<Location, Error>( new Location(latitude, longitude));
    }
}    