using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Machine.Specifications;

namespace CollectionJsonExtended.Core._Specs
{

    [Subject(typeof(ItemRepresentation<>), "Serialize Type ItemRepresentation.Data representation")]
    public class When_the_item_representaion_with_FakeSimpleModelWithEnumAndStringEnum_is_serialized
    {
        static readonly CollectionJsonSerializerSettings Settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        
        static readonly ItemRepresentation<FakeSimpleModelWithEnumAndStringEnum> Representation =
            new ItemRepresentation<FakeSimpleModelWithEnumAndStringEnum>(new FakeSimpleModelWithEnumAndStringEnum
                                                                             {
                                                                                 SomeString = "some string",
                                                                                 FakeEnum = FakeEnum.Val2,
                                                                                 FakeStringEnum = FakeStringEnum.StringVal1,
                                                                             }, Settings);
        static string _subject;

        Because of = () => _subject = CollectionJsonWriter.Serialize(Representation);

        It should_the_json_property_for_someString_be__some_string__ =
            () => _subject.ShouldContain("{\"name\":\"someString\",\"value\":\"some string\"");

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEndWith("" +//"{\"href\":\"http://www.example.org/fakesimplemodelwithenumandstringenum/[identifier]\"" +

            ",\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"some string\",\"prompt\":\"Some String\"}," +
                "{\"name\":\"fakeEnum\",\"value\":0,\"prompt\":\"Fake Enum\"}," +
                "{\"name\":\"fakeStringEnum\",\"value\":\"StringVal1\",\"prompt\":\"Fake String Enum\"}" +
            "]}");
    }


    [Subject(typeof(ItemRepresentation<>), "Serialize Type ItemRepresentation.Data representation")]
    public class When_the_item_representaion_with_FakeComplexModelWithArrays_is_serialized
    {
        static readonly CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };

        private static readonly ItemRepresentation<FakeComplexModelWithArrays> Representation =
            new ItemRepresentation<FakeComplexModelWithArrays>(new FakeComplexModelWithArrays
                                                               {
                                                                   SomeString = "some string",
                                                                   SomeStrings = new[] {"foo", "bar"},
                                                                   FakeSimpleModels =
                                                                       new FakeSimpleModel[]
                                                                       {
                                                                           new FakeSimpleModel
                                                                           {
                                                                               SomeString = "some string in array model"
                                                                           }
                                                                       }
                                                               }, settings);
        static string _subject;

        Because of = () => _subject = CollectionJsonWriter.Serialize(Representation);

        It should_the_json_options_property_for_someStrings_be_have_array__array_empty__ =
            () => _subject.ShouldContain("\"name\":\"someStrings\",\"values\":[\"foo\",\"bar\"],");

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEndWith("" +//"{\"href\":\"http://www.example.org/fakecomplexmodelwitharrays/[identifier]\"" +

                ",\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"some string\",\"prompt\":\"Some String\"}" +
                ",{\"name\":\"someStrings\",\"values\":[\"foo\",\"bar\"],\"prompt\":\"Some Strings\"}" +
                ",{\"name\":\"fakeSimpleModels\",\"objects\":[{\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"some string in array model\",\"prompt\":\"Some String\"}" +
                    "]}],\"prompt\":\"Fake Simple Models\"}" +
                "]}");
    }


    [Subject(typeof(ItemRepresentation<>), "Serialize Type ItemRepresentation.Data representation")]
    public class When_the_item_representaion_with_FakeComplexModelWithEnumerable_is_serialized
    {
        static readonly CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };

        
        static readonly ItemRepresentation<FakeComplexModelWithEnumerable> representation =
            new ItemRepresentation<FakeComplexModelWithEnumerable>(new FakeComplexModelWithEnumerable
                                        {
                                            SomeString = "some string",
                                            FakeSimpleModel = new FakeSimpleModel(),
                                            FakeSimpleModelCollection
                                                = new Collection<FakeSimpleModel>
                                                        {
                                                            new FakeSimpleModel
                                                                {
                                                                    SomeString
                                                                        =  "string property in collection"
                                                                }
                                                        },
                                            FakeSimpleModelList
                                                =
                                                new List<FakeSimpleModel>
                                                    {
                                                        new FakeSimpleModel
                                                            {
                                                                SomeString
                                                                    = "string property in list"
                                                            }
                                                    },
                                            FakeSimpleModels
                                                =
                                                new List<FakeSimpleModel>
                                                    {
                                                        new FakeSimpleModel
                                                            {
                                                                SomeString
                                                                    = "string property in enumerable"
                                                            }
                                                    }
                                        }, settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter.Serialize(representation);

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEndWith(""+//"{\"href\":\"http://www.example.org/fakecomplexmodelwithenumerable/[identifier]\"" +

            ",\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"some string\",\"prompt\":\"Some String\"}" +
                ",{\"name\":\"fakeSimpleModel\",\"object\":{\"data\":[" +
                    "{\"name\":\"someString\",\"value\":null,\"prompt\":\"Some String\"}" +
                "]},\"prompt\":\"Fake Simple Model\"}" +
                ",{\"name\":\"fakeSimpleModelCollection\",\"objects\":[{\"data\":[" +
                    "{\"name\":\"someString\",\"value\":\"string property in collection\",\"prompt\":\"Some String\"}" +
                "]}],\"prompt\":\"Fake Simple Model Collection\"}" +
                ",{\"name\":\"fakeSimpleModelList\",\"objects\":[{\"data\":[" +
                    "{\"name\":\"someString\",\"value\":\"string property in list\",\"prompt\":\"Some String\"}" +
                "]}],\"prompt\":\"Fake Simple Model List\"}" +
                ",{\"name\":\"fakeSimpleModels\",\"objects\":[{\"data\":[" +
                    "{\"name\":\"someString\",\"value\":\"string property in enumerable\",\"prompt\":\"Some String\"}" +
                "]}],\"prompt\":\"Fake Simple Models\"}" +
            "]}");
    }


    [Subject(typeof(ItemRepresentation<>), "Serialize Type ItemRepresentation.Data representation")]
    public class When_the_item_representaion_with_the_FakeComplexModel_is_serialized
    {
        private static readonly CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Data
            };

        static readonly ItemRepresentation<FakeComplexModel> Representation = 
            new ItemRepresentation<FakeComplexModel>(new FakeComplexModel{}, Settings);

        static string _subject;

        Because of = () => _subject = CollectionJsonWriter.Serialize(Representation);

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEndWith("" +//"{\"href\":\"http://www.example.org/fakecomplexmodel/[identifier]\"" +

            ",\"data\":[" +
                "{\"name\":\"fakeSimpleModel\",\"object\":null" +
                ",\"prompt\":\"Fake Simple Model\"}" +
            "]}");
    }


    [Subject(typeof(ItemRepresentation<>), "Serialize Type ItemRepresentation.Data representation")]
    public class When_the_item_representaion_with_FakeSimpleModelWithValueTypes_is_serialized
    {
        private static readonly CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Data
            };

        
        static readonly ItemRepresentation<FakeSimpleModelWithValueTypes> Representation =
            new ItemRepresentation<FakeSimpleModelWithValueTypes>(new FakeSimpleModelWithValueTypes
                                                                      {
                                                                          Int = 123,
                                                                          Char = Convert.ToChar("s")
                                                                      }, Settings);
        static string _subject;

        Because of = () => _subject = CollectionJsonWriter.Serialize(Representation);

        It should_the_properties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEndWith(""+//"{\"href\":\"http://www.example.org/fakesimplemodelwithvaluetypes/[identifier]\"" +

            ",\"data\":[" +
                "{\"name\":\"int\",\"value\":123,\"prompt\":\"Type a number:\"}" +
                ",{\"name\":\"long\",\"value\":0,\"prompt\":\"Long\"}" +
                ",{\"name\":\"float\",\"value\":0.0,\"prompt\":\"Float\"}" +
                ",{\"name\":\"bool\",\"value\":false,\"prompt\":\"Bool\"}" +
                ",{\"name\":\"char\",\"value\":\"s\",\"prompt\":\"Char\"}" +
                ",{\"name\":\"decimal\",\"value\":0.0,\"prompt\":\"Decimal\"}" +
                ",{\"name\":\"short\",\"value\":0,\"prompt\":\"Short\"}" +
                ",{\"name\":\"double\",\"value\":0.0,\"prompt\":\"Double\"}" +
            "]}");
    }


    [Subject(typeof(ItemRepresentation<>), "Serialize Type ItemRepresentation.Data representation")]
    public class When_the_item_representaion_with_FakeSimpleModelWithNullableValueTypes_is_serialized
    {
        private static readonly CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Data
            };

        
        static readonly ItemRepresentation<FakeSimpleModelWithNullableValueTypes> Representation =
            new ItemRepresentation<FakeSimpleModelWithNullableValueTypes>(new FakeSimpleModelWithNullableValueTypes
            {
                Int = 123,
                Decimal = 5
            }, Settings);

        static string _subject;

        Because of = () => _subject = CollectionJsonWriter.Serialize(Representation);

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEndWith("" +//"{\"href\":\"http://www.example.org/fakesimplemodelwithnullablevaluetypes/[identifier]\"" +

            ",\"data\":[" +
                "{\"name\":\"int\",\"value\":123,\"prompt\":\"Int\"}" +
                ",{\"name\":\"long\",\"value\":null,\"prompt\":\"Long\"}" +
                ",{\"name\":\"float\",\"value\":null,\"prompt\":\"Float\"}" +
                ",{\"name\":\"bool\",\"value\":null,\"prompt\":\"Bool\"}" +
                ",{\"name\":\"char\",\"value\":null,\"prompt\":\"Char\"}" +
                ",{\"name\":\"decimal\",\"value\":5.0,\"prompt\":\"Decimal\"}" +
                ",{\"name\":\"short\",\"value\":null,\"prompt\":\"Short\"}" +
                ",{\"name\":\"double\",\"value\":null,\"prompt\":\"Double\"}" +
            "]}");
    }



    [Subject(typeof(ItemRepresentation<>), "Serialize Type ItemRepresentation.Entity representation")]
    public class When_the_item_representaion_as_entity_with_FakeSimpleModelWithEnumAndStringEnum_is_serialized
    {
        static readonly CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Entity
            };
        
        static readonly ItemRepresentation<FakeSimpleModelWithEnumAndStringEnum> Representation =
            new ItemRepresentation<FakeSimpleModelWithEnumAndStringEnum>(new FakeSimpleModelWithEnumAndStringEnum
            {
                SomeString = "some string",
                FakeEnum = FakeEnum.Val2,
                FakeStringEnum = FakeStringEnum.StringVal1,
            }, Settings);

        static string _subject;

        Because of = () => _subject = CollectionJsonWriter.Serialize(Representation);

        It should_the_json_property_for_someString_be__some_string__ =
            () => _subject.ShouldContain("{\"someString\":\"some string\"");

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEndWith(""+//"{\"href\":\"http://www.example.org/fakesimplemodelwithenumandstringenum/[identifier]\"" +

            ",\"entity\":{" +
                "\"someString\":\"some string\"" +
                ",\"fakeEnum\":0" +
                ",\"fakeStringEnum\":\"StringVal1\"" +
            "}}");
    }

}
