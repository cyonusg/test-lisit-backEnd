namespace bff.Entities
{
    public class Beneficiary
    {
        /// <summary>
        /// Beneficiary Relation Id
        /// </summary>
        /// 
        public required string Id { get; set; }

        /// <summary>
        /// Beneficiary Id
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Social Help Id
        /// </summary>
        public required string SocialHelpId { get; set; }

        /// <summary>
        /// Create Date
        /// </summary>
        public required DateTime CreatedAt { get; set; }

        /// <summary>
        /// Update Date
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Delete Date
        /// </summary>
        public DateTime DeletedAt { get; set; }
    }
}