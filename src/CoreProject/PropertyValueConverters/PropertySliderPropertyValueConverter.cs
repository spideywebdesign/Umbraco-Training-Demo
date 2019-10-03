using CoreProject.Models;
using Newtonsoft.Json.Linq;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace CoreProject.PropertyValueConverters
{
    /// <summary>
    /// Converts MarketPicker property values from object to typeof HtmlString
    /// https://our.umbraco.com/Documentation/Extending/Property-Editors/value-converters
    /// https://our.umbraco.com/Documentation/Extending/Property-Editors/value-converters-full-example-attributes
    /// </summary>
    [PropertyValueType(typeof(MyAwesomePropertyEditor))]
    [PropertyValueCache(PropertyCacheValue.Source, PropertyCacheLevel.Content)]
    [PropertyValueCache(PropertyCacheValue.Object, PropertyCacheLevel.ContentCache)]
    [PropertyValueCache(PropertyCacheValue.XPath, PropertyCacheLevel.Content)]
    public class PropertySliderPropertyValueConverter : IPropertyValueConverter
    {
        public bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType
                       .PropertyEditorAlias
                       .Equals("myAwesomePropertyEditor.PropertySlider") 
                    || 
                   propertyType
                       .PropertyEditorAlias
                       .Equals("myAwesomePropertyEditorWithConfig.PropertySlider");
        }

        public object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            //This method should convert the raw data value into an appropriate type, for example, a nodeId stored as a String should be converted to an Int.
            //This method returns the "Source". Include a using Umbraco.Core to be able to use the TryConvertTo extension method.

            return source;
        }

        public object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            //This method converts the Source to an Object, the returned value is used by the GetPropertyValue<T> method of IPublishedContent.

            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<MyAwesomePropertyEditor>(source as string);

            return model;
        }

        public object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview)
        {
            //This method converts the Source to XPath, the return value should generally be of type String or XPathNodeIterator.
            return source.ToString();
        }
    }
}
