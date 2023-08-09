using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
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
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the property (e.g., residential, commercial).
        /// </summary>
        /// <example>Moradia T4</example>
        [Required(ErrorMessage = "O campo tipo de imóvel é obrigatório.")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the location of the property.
        /// </summary>
        /// <example>Aguda, Figueiró dos Vinhos</example>
        [Required(ErrorMessage = "O campo Localização do Imóvel é obrigatório.")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the price of the property.
        /// </summary>
        /// <example>125000</example>
        [Required(ErrorMessage = "O campo preço é obrigatório.")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the description of the property.
        /// </summary>
        /// <example>Venha conhecer a moradia dos seus sonhos!</example>
        [Required(ErrorMessage = "O campo Descrição do Imóvel é obrigatório.")]
        public string Description { get; set; }
    }
}
