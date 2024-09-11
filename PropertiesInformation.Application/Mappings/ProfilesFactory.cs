using AutoMapper;
using PropertiesInformation.Application.Mappings.Owner;
using PropertiesInformation.Application.Mappings.Property;
using PropertiesInformation.Application.Mappings.PropertyImage;
using PropertiesInformation.Application.Mappings.PropertyTrace;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Application.Mappings
{
    /// <summary>
    ///   <see cref="ProfilesFactory" />
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ProfilesFactory
    {
        /// <summary>
        /// Gets the value owner.
        /// </summary>
        /// <value>
        /// The value owner.
        /// </value>
        public static Profile OwnerProfile => new OwnerProfile();
        /// <summary>
        /// Gets the common property.
        /// </summary>
        /// <value>
        /// The common property.
        /// </value>
        public static Profile PropertyProfile => new PropertyProfile();
        /// <summary>
        /// Gets the Adesfa property Image.
        /// </summary>
        /// <value>
        /// The Adesfa property Image.
        /// </value>
        public static Profile PropertyImageProfile => new PropertyImageProfile();
        /// <summary>
        /// Gets the get Property Trace.
        /// </summary>
        /// <value>
        /// The get Property Trace.
        /// </value>
        public static Profile PropertyTraceProfile => new PropertyTraceProfile();
    }
}
