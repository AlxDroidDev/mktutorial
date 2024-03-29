/*
 * Case Conversion API
 *
 * This is a simple API that is meant to be used only as an example
 *
 * OpenAPI spec version: 0.1
 * Contact: you@your-company.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CaseConversion.API.Models
{
    /// <summary>
    /// Type of convertion to be applied to the input sentence
    /// </summary>
    /// <value>Type of convertion to be applied to the input sentence</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ConversionCaseType
        {
            
            /// <summary>
            /// Enum LowerEnum for lower
            /// </summary>
            [EnumMember(Value = "lower")]
            LOWER = 1,
            
            /// <summary>
            /// Enum UpperEnum for upper
            /// </summary>
            [EnumMember(Value = "upper")]
            UPPER = 2,
            
            /// <summary>
            /// Enum CamelEnum for camel
            /// </summary>
            [EnumMember(Value = "camel")]
            CAMEL = 3,
            
            /// <summary>
            /// Enum PascalEnum for pascal
            /// </summary>
            [EnumMember(Value = "pascal")]
            PASCAL = 4,
            
            /// <summary>
            /// Enum SnakeEnum for snake
            /// </summary>
            [EnumMember(Value = "snake")]
            SNAKE = 5,
            
            /// <summary>
            /// Enum KebabEnum for kebab
            /// </summary>
            [EnumMember(Value = "kebab")]
            KEBAB = 6,
        
            /// <summary>
            /// Enum KebabEnum for kebab
            /// </summary>
            [EnumMember(Value = "leet")]
            LEET = 7,

            /// <summary>
            /// enum for fatorial
            /// </summary>
            [EnumMember(Value = "fatorial")]
            FATORIAL = 8

    }
}
