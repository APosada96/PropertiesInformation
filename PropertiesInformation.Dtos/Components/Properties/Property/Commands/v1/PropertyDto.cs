using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Dtos.Components.Properties.Property.Commands.v1
{
    /// <summary>
    /// <see cref="PropertyDto"/>
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PropertyDto
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        /// <value>
        /// The Address.
        /// </value>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        /// <value>
        /// The Price.
        /// </value>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>
        /// The Code.
        /// </value>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        /// <value>
        /// The Year.
        /// </value>
        public int Year { get; set; }
    }
}
