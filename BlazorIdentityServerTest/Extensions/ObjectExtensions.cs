using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace BlazorIdentityServerTest.Extensions;


public static class ObjectExtensions
{
    public static T DeepClone<T>(this T source)
    {            
        // Don't serialize a null object, simply return the default for that object
        if (ReferenceEquals(source, null)) return default;

        // initialize inner objects individually
        // for example in default constructor some list property initialized with some values,
        // but in 'source' these items are cleaned -
        // without ObjectCreationHandling.Replace default constructor values will be added to result
        var deserializeSettings = new JsonSerializerSettings {ObjectCreationHandling = ObjectCreationHandling.Replace};

        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
    }
}