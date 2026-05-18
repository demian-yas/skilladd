namespace Skilladd.Domain;

public class Company
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string? Description { get; set; }
    //public string? LogoUrl { get; set; } 
    public string? Website { get; set; }
    public string? Industry { get; set; }
    //public enum? Size { get; set; }
    public string? Location { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
}