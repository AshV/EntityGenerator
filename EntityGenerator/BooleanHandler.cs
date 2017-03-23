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
    public class BooleanHandler
    {
        public BooleanAttributeMetadata Create(AttributeMetadata baseMetadata, string trueLabel="Yes", string falseLabel="No",int labelLanguage=Global.LANGUAGE)
        {
            var  boolAttribute = new BooleanAttributeMetadata
            {
                // Set base properties
                SchemaName = baseMetadata.SchemaName,
                DisplayName = baseMetadata.DisplayName,
                RequiredLevel = baseMetadata.RequiredLevel,
                Description = baseMetadata.Description,

                // Set extended properties
                OptionSet = new BooleanOptionSetMetadata
                {
                    TrueOption = new OptionMetadata(new Label(trueLabel, labelLanguage), 1),
                    FalseOption = new OptionMetadata(new Label(falseLabel, labelLanguage), 0)
                }
            };
                        
            return boolAttribute;
        }
    }
}
