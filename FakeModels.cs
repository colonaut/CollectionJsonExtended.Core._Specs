using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CollectionJsonExtended.Core.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CollectionJsonExtended.Core._Specs
{
    public interface IFakeSimpleModel
    {
        
    }
    
    
    /** Abtract **/
    public abstract class FakeAbstractModel
    {
        public abstract string AbstractString { get; set; }
    }

    public class FakeDerivedModel : FakeAbstractModel
    {
        public override string AbstractString { get; set; }

        public string DerivedAdditionalString { get; set; }
    }

    public class FakeDerivedComplexModel : FakeAbstractModel
    {
        public override string AbstractString { get; set; }

        public string DerivedAdditionalString { get; set; }

        public FakeSimpleModel FakeSimpleModel { get; set; }
    }

    public class FakeComplexModelWithAbstract
    {
        public string SomeString { get; set; }
        
        [CollectionJsonConcreteType(typeof(FakeDerivedModel))]
        [CollectionJsonConcreteType(typeof(FakeDerivedComplexModel))]
        public FakeAbstractModel FakeAbstractModel { get; set; }
    }

    public class FakeComplexModelWithEnumerableOfAbstract
    {
        public string SomeString { get; set; }

        [CollectionJsonConcreteType(typeof(FakeDerivedModel))]
        [CollectionJsonConcreteType(typeof(FakeDerivedComplexModel))]
        public IEnumerable<FakeAbstractModel> FakeAbstractModels { get; set; }
    }



    /** Simple **/
    public class FakeSimpleModel : IFakeSimpleModel
    {
        public string SomeString { get; set; }
    }

    public class FakeSimpleGuidModel : IFakeSimpleModel
    {
        public Guid Id { get; set; }
        public string SomeString { get; set; }
    }

    public class FakeSimpleModelWithValueTypes
    {
        [CollectionJsonProperty(Prompt = "Type a number:")]
        public int Int { get; set; }
        public long Long { get; set; }
        public float Float { get; set; }
        public bool Bool { get; set; }
        public char Char { get; set; }
        public decimal Decimal { get; set; }
        public short Short { get; set; }
        public double Double { get; set; }
    }

    public class FakeSimpleModelWithNullableValueTypes
    {
        public int? Int { get; set; }
        public long? Long { get; set; }
        public float? Float { get; set; }
        public bool? Bool { get; set; }
        public char? Char { get; set; }
        public decimal? Decimal { get; set; }
        public short? Short { get; set; }
        public double? Double { get; set; }
    }

    public class FakeSimpleModelWithDateTime
    {
        public DateTime DateTime { get; set; }    
    }

    public class FakeEmptyModel
    {
        
    }

    public class FakeSimpleModelWithEnumAndStringEnum
    {
        public string SomeString { get; set; }
        public FakeEnum FakeEnum { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FakeStringEnum FakeStringEnum { get; set; }

    }


    /** Complex **/
    public class FakeComplexModelWithListOfStrings
    {
        public string SomeString { get; set; }
        public List<string> SomeStrings { get; set; }
    }

    public class FakeComplexModel
    {
        public FakeSimpleModel FakeSimpleModel { get; set; }
    }

    public class FakeComplexModelWithInterfaces
    {
        public IFakeSimpleModel SimpleModel { get; set; }
    }

    public class FakeComplexModelWithArrays
    {
        public string SomeString { get; set; }
        public string[] SomeStrings { get; set; }
        public FakeSimpleModel[] FakeSimpleModels { get; set; }
    }

    public class FakeComplexModelWithEnumerable
    {
        public string SomeString { get; set; }
        public FakeSimpleModel FakeSimpleModel { get; set; }
        public Collection<FakeSimpleModel> FakeSimpleModelCollection { get; set; }
        public IList<FakeSimpleModel> FakeSimpleModelList { get; set; }
        public IEnumerable<FakeSimpleModel> FakeSimpleModels { get; set; }
    }

    public class FakeComplexModelWithDictionaries
    {
        public Dictionary<string, FakeSimpleModel> Dictionary { get; set; }
        public SortedList<string, FakeSimpleModel> SortedList { get; set; }
        public ICollection<KeyValuePair<string, FakeSimpleModel>> CollectionOfKeyValuePair { get; set; }
        public IEnumerable<KeyValuePair<string, FakeSimpleModel>> EnumerableOfKeyValuePair { get; set; }
	

    }

    public struct FakeStruct
    {
        public decimal price;
        public string title;
        public string author;
    }

    public enum FakeStringEnum
    {
        StringVal1 = 1,
        StringVal2 = 0
        //default (not assigning = n would make first item default, which certainly works but is not covered in specs)
    }

    public enum FakeEnum
    {
        Val1 = 1,
        Val2 = 0
    }
}