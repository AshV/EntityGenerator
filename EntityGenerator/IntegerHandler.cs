using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator
{
    public class IntegerHandler
    {
        public IntegerAttributeMetadata Create(AttributeMetadata baseMetadata, IntegerFormat integetFormat, int? maxvalue, int? minvalue)
        {
            var integerAttribute = new IntegerAttributeMetadata
            {
                // Set base properties
                SchemaName = baseMetadata.SchemaName,
                DisplayName = baseMetadata.DisplayName,
                RequiredLevel = baseMetadata.RequiredLevel,
                Description = baseMetadata.Description,
                // Set extended properties
                Format = IntegerFormat.None,
                MaxValue = 100,
                MinValue = 0
            };

            return integerAttribute;
        }
    }
}
