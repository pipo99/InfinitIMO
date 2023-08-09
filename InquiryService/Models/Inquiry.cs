using System.ComponentModel.DataAnnotations;

namespace InquiryService.Models
{
    /// <summary>
    /// Represents an inquiry related to a property listing.
    /// </summary>
    public class Inquiry
    {
        /// <summary>
        /// Gets or sets the unique ID of the inquiry.
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date of the inquiry.
        /// </summary>
        /// <example>2023-08-09</example>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated property.
        /// </summary>
        /// <example>123</example>
        public int PropertyID { get; set; }

        /// <summary>
        /// Gets or sets the email address of the person making the inquiry.
        /// </summary>
        /// <example>john.doe@example.com</example>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the person making the inquiry.
        /// </summary>
        /// <example>John Doe</example>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the message or question associated with the inquiry.
        /// </summary>
        /// <example>I'm interested in this property. Can you provide more details?</example>
        public string Message { get; set; }
    }
}
