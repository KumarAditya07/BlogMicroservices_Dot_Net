namespace BlogMicroservice.AuthService.DTOs
{
    public class RegisterRequest
    {

        /*
         * init allows setting a property only during object creation but prevents modification afterward.
         * 🔹 set allows modifications, but init locks the property after initialization.
         *  set allows modification anytime after object creation.
         ✔ init locks properties after initialization, preventing accidental changes.
         ✔ set is useful for properties like Role that may change later.
         ✔ init is best for immutable data, like UserName, Email, and Password.
         */
        public string UserName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;

        public string Password { get; init; } = string.Empty;

        public string Role { get; set; } = "Reader";
        
    }
}
