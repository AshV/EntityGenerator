using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator
{
    public class DecimalHandler
    {
        public DecimalAttributeMetadata Create(AttributeMetadata baseMetadata , int? maxvalue, int? minvalue, int? precision)
        {
            // Create a decimal attribute	
            var decimalAttribute = new DecimalAttributeMetadata
            {
                // Set base properties
                SchemaName = baseMetadata.SchemaName,
                DisplayName = baseMetadata.DisplayName,
                RequiredLevel = baseMetadata.RequiredLevel,
                Description = baseMetadata.Description,

                // Set extended properties
                MaxValue = maxvalue,
                MinValue = minvalue,
                Precision = precision
            };
            return decimalAttribute;
        }
    }
}