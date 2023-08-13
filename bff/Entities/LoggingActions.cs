using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bff.Entities
{
    public class LoggingActions
    {
        /// <summary>
        /// Id
        /// </summary>
        /// 
        public string? Id { get; set; }
        /// <summary>
        /// Type Actions
        /// </summary>

        public required string Type { get; set; }

        /// <summary>
        /// Descriptions Actions
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// UserId owner Actions
        /// </summary>

        public required string UserId { get; set; }

        /// <summary>
        /// Date Actions
        /// </summary>
        public string? CreatedAt { get; set; }
    }
}