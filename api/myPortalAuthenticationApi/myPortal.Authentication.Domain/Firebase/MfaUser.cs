namespace myPortal.Authentication.Domain.Firebase;

public class MfaUser
{
    public Guid Id { get; set; }
    public string FirebaseUid { get; set; } = default!;
    public string SecretKey { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
