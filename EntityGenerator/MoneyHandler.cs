using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator
{
    public class MoneyHandler
    {
        public MoneyAttributeMetadata Create(AttributeMetadata baseMetadata, double? maxValue, double? minValue, int? precision, int? precisionSource, ImeMode imeMode)
        {
            var moneyAttribute = new MoneyAttributeMetadata
            {
                // Set base properties
                SchemaName = baseMetadata.SchemaName,
                DisplayName = baseMetadata.DisplayName,
                RequiredLevel = baseMetadata.RequiredLevel,
                Description = baseMetadata.Description,
                // Set extended properties
                MaxValue = 1000.00,
                MinValue = 0.00,
                Precision = 1,
                PrecisionSource = 1,
                ImeMode = ImeMode.Disabled
            };
            return moneyAttribute;
        }
    }
}
