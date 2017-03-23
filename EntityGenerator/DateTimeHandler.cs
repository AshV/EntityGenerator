using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator
{
    public class DateTimeHandler
    {
        public DateTimeAttributeMetadata Create(AttributeMetadata baseMetadata, DateTimeFormat dateTimeFormat, ImeMode imeMode)
        {
            // Create a date time attribute ----Object Initialization
            var dateAttribute = new DateTimeAttributeMetadata
            {
                // Set base properties
                SchemaName = baseMetadata.SchemaName,
                DisplayName = baseMetadata.DisplayName,
                RequiredLevel = baseMetadata.RequiredLevel,
                Description = baseMetadata.Description,

                // Set extended properties
                Format = dateTimeFormat,
                ImeMode = imeMode
            };
                        
            return dateAttribute;
        }
    }
}
