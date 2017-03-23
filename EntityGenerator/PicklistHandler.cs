using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator
{
    public class PicklistHandler
    {
        public PicklistAttributeMetadata Create(AttributeMetadata baseMetadata, Boolean isGlobal, OptionSetMetadata optionSet, OptionMetadataCollection optionMetadataCollection, int labelLanguage = Global.LANGUAGE)
        {
            var pickListAttribute = new PicklistAttributeMetadata
            {

                // Set base properties
                SchemaName = baseMetadata.SchemaName,
                DisplayName = baseMetadata.DisplayName,
                RequiredLevel = baseMetadata.RequiredLevel,
                Description = baseMetadata.Description,
                // Set extended properties
                // Build local picklist options
                OptionSet = optionSet
            };

            return pickListAttribute;
        }
    }
}
