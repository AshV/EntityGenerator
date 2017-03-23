using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator
{
    public class MemoHandler
    {
        public MemoAttributeMetadata Create (AttributeMetadata baseMetadata, StringFormat stringFormat, ImeMode imeMode, int? maxLength)
        {
            var memoAttribute = new MemoAttributeMetadata
            {
                // Set base properties
                SchemaName = baseMetadata.SchemaName,
                DisplayName = baseMetadata.DisplayName,
                RequiredLevel = baseMetadata.RequiredLevel,
                Description = baseMetadata.Description,
                // Set extended properties
                Format = StringFormat.TextArea,
                ImeMode = ImeMode.Disabled,
                MaxLength = 500
            };
            return memoAttribute;
        }  
    }
}
