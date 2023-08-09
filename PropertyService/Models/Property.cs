namespace PropertyService.Models
{
    /// <summary>
    /// Represents a property listing.
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Gets or sets the unique ID of the property.
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <example>Moradia a venda em Figueiró dos Vinhos</example>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the property (e.g., residential, commercial).
        /// </summary>
        /// <example>Moradia T4</example>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the location of the property.
        /// </summary>
        /// <example>Aguda, Figueiró dos Vinhos</example>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the price of the property.
        /// </summary>
        /// <example>125000</example>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the description of the property.
        /// </summary>
        /// <example>Venha conhecer a moradia dos seus sonhos!</example>
        public string Description { get; set; }
    }
}
