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
    public class StringHandler
    {
        public StringAttributeMetadata Create(AttributeMetadata baseMetadata, int? maxLength)
        {
            var stringAttribute = new StringAttributeMetadata
            {
                // Set base properties
                SchemaName = baseMetadata.SchemaName,
                DisplayName = baseMetadata.DisplayName,
                RequiredLevel = baseMetadata.RequiredLevel,
                Description = baseMetadata.Description,

                // Set extended properties
                MaxLength = maxLength
            };

            return stringAttribute;
        }
    }
}