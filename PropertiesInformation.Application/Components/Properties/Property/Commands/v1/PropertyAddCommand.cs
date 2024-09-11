using MediatR;
using PropertiesInformation.Dtos.Components.Properties.Property.Commands.v1;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Application.Components.Properties.Property.Commands.v1
{
    /// <summary>
    ///   <see cref="OrderDetailAddCommand" />
    /// </summary>
    /// <seealso cref="MediatR.IRequest&lt;Farmaonline.Middleware.SGF.Dtos.Components.Adesfa.Queries.v1.int&gt;" />
    /// <seealso cref="MediatR.IRequest&lt;Farmaonline.Middleware.SGF.Dtos.Components.Adesfa.Queries.v1.int&gt;" />
    [ExcludeFromCodeCoverage]
    public class PropertyAddCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the order detail add.
        /// </summary>
        /// <value>
        /// The order detail add.
        /// </value>
        public PropertyDto PropertyDto { get; set; }

        public PropertyAddCommand(PropertyDto PropertyDto) => PropertyDto = PropertyDto;
    }
}
