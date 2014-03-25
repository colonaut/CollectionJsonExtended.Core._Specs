using CollectionJsonExtended.Core.Extensions;
using Machine.Specifications;

namespace CollectionJsonExtended.Core._Specs
{

    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_is_serialized_with_the_FakeSimpleModelWithEnumAndStringEnum
    {
        private static readonly CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Data
            };
        readonly static TemplateRepresentation<FakeSimpleModelWithEnumAndStringEnum> Representation = 
            new TemplateRepresentation<FakeSimpleModelWithEnumAndStringEnum>(Settings);
        static string _subject;

        Because of = () => _subject = Representation.Serialize();

        It should_the_json_options_property_for_fakeEnum_be__array_0_1__ =
            () => _subject.ShouldContain("\"options\":[0,1],");

        It should_the_json_options_property_for_fakeStringEnum_be__array_StringVal2_StringVal1__ =
            () => _subject.ShouldContain("\"options\":[\"StringVal2\",\"StringVal1\"],");

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}," +
                "{\"name\":\"fakeEnum\",\"value\":0,\"options\":[0,1],\"prompt\":\"Fake Enum\",\"type\":\"FakeEnum\"}," +
                "{\"name\":\"fakeStringEnum\",\"value\":\"StringVal2\",\"options\":[\"StringVal2\",\"StringVal1\"],\"prompt\":\"Fake String Enum\",\"type\":\"FakeStringEnum\"}" +
            "]}");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_entitydata_type_is_serialized_with_the_FakeComplexModelWithArrays
    {
        readonly static CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static TemplateRepresentation<FakeComplexModelWithArrays> Representation = new TemplateRepresentation<FakeComplexModelWithArrays>(Settings);
        static string _subject;

        Because of = () => _subject = Representation.Serialize();

        //It should_the_json_options_property_for_someStrings_be_have_array__array_empty__ =
        //    () => subject.ShouldContain("\"name\":\"someStrings\",\"values\":[],");

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                ",{\"name\":\"someStrings\",\"values\":[],\"prompt\":\"Some Strings\",\"type\":\"string[]\"}" +
                ",{\"name\":\"fakeSimpleModels\",\"objects\":[],\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                    "],\"prompt\":\"Fake Simple Models\",\"type\":\"FakeSimpleModel[]\"}" +
                "]}");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_entitydata_type_is_serialized_with_the_FakeComplexModelWithEnumerable
    {
        readonly static CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static TemplateRepresentation<FakeComplexModelWithEnumerable> Representation =
            new TemplateRepresentation<FakeComplexModelWithEnumerable>(Settings);
        static string _subject;

        Because of = () => _subject = Representation.Serialize();

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                ",{\"name\":\"fakeSimpleModel\",\"object\":null,\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                    "],\"prompt\":\"Fake Simple Model\",\"type\":\"FakeSimpleModel\"}" +
                ",{\"name\":\"fakeSimpleModelCollection\",\"objects\":[],\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                    "],\"prompt\":\"Fake Simple Model Collection\",\"type\":\"FakeSimpleModel[]\"}" +
                ",{\"name\":\"fakeSimpleModelList\",\"objects\":[],\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                    "],\"prompt\":\"Fake Simple Model List\",\"type\":\"FakeSimpleModel[]\"}" +
                ",{\"name\":\"fakeSimpleModels\",\"objects\":[],\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                    "],\"prompt\":\"Fake Simple Models\",\"type\":\"FakeSimpleModel[]\"}" +
                "]}");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_entitydata_type_is_serialized_with_the_FakeComplexModel
    {
        static readonly CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Data
            };
        readonly static TemplateRepresentation<FakeComplexModel> Representation =
            new TemplateRepresentation<FakeComplexModel>(Settings);
        static string _subject;

        Because of = () => _subject = Representation.Serialize();

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"fakeSimpleModel\",\"object\":null,\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                    "],\"prompt\":\"Fake Simple Model\",\"type\":\"FakeSimpleModel\"}" +
                "]}");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_entitydata_type_is_serialized_with_FakeSimpleModelWithValueTypes
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static TemplateRepresentation<FakeSimpleModelWithValueTypes> representation = new TemplateRepresentation<FakeSimpleModelWithValueTypes>(settings);
        static string subject;

        Because of = () => subject = representation.Serialize();

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"int\",\"value\":0,\"prompt\":\"Type a number:\",\"type\":\"int\"}" +
                ",{\"name\":\"long\",\"value\":0,\"prompt\":\"Long\",\"type\":\"long\"}" +
                ",{\"name\":\"float\",\"value\":0.0,\"prompt\":\"Float\",\"type\":\"float\"}" +
                ",{\"name\":\"bool\",\"value\":false,\"prompt\":\"Bool\",\"type\":\"bool\"}" +
                ",{\"name\":\"char\",\"value\":\"\\u0000\",\"prompt\":\"Char\",\"type\":\"char\"}" +
                ",{\"name\":\"decimal\",\"value\":0.0,\"prompt\":\"Decimal\",\"type\":\"decimal\"}" +
                ",{\"name\":\"short\",\"value\":0,\"prompt\":\"Short\",\"type\":\"short\"}" +
                ",{\"name\":\"double\",\"value\":0.0,\"prompt\":\"Double\",\"type\":\"double\"}" +
            "]}");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_entitydata_type_is_serialized_with_FakeSimpleModelWithNullableValueTypes
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static TemplateRepresentation<FakeSimpleModelWithNullableValueTypes> Representation = new TemplateRepresentation<FakeSimpleModelWithNullableValueTypes>(settings);
        static string subject;

        Because of = () => subject = Representation.Serialize();

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"int\",\"value\":null,\"prompt\":\"Int\",\"type\":\"int?\"}" +
                ",{\"name\":\"long\",\"value\":null,\"prompt\":\"Long\",\"type\":\"long?\"}" +
                ",{\"name\":\"float\",\"value\":null,\"prompt\":\"Float\",\"type\":\"float?\"}" +
                ",{\"name\":\"bool\",\"value\":null,\"prompt\":\"Bool\",\"type\":\"bool?\"}" +
                ",{\"name\":\"char\",\"value\":null,\"prompt\":\"Char\",\"type\":\"char?\"}" +
                ",{\"name\":\"decimal\",\"value\":null,\"prompt\":\"Decimal\",\"type\":\"decimal?\"}" +
                ",{\"name\":\"short\",\"value\":null,\"prompt\":\"Short\",\"type\":\"short?\"}" +
                ",{\"name\":\"double\",\"value\":null,\"prompt\":\"Double\",\"type\":\"double?\"}" +
            "]}");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_entitydata_type_is_serialized_with_FakeComplexModelWithAbstract
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Entity
            };
        readonly static TemplateRepresentation<FakeComplexModelWithAbstract> Representation = new TemplateRepresentation<FakeComplexModelWithAbstract>(settings);
        static string _subject;

        Because of = () => _subject = Representation.Serialize();

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                ",{\"name\":\"fakeAbstractModel\",\"object\":null,\"select\":[" +
                    "{\"type\":\"FakeDerivedComplexModel\",\"data\":[" +
                        "{\"name\":\"abstractString\",\"value\":\"\",\"prompt\":\"Abstract String\",\"type\":\"string\"}" +
                        ",{\"name\":\"derivedAdditionalString\",\"value\":\"\",\"prompt\":\"Derived Additional String\",\"type\":\"string\"}" +
                        ",{\"name\":\"fakeSimpleModel\",\"object\":null,\"data\":[" +
                            "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                        "],\"prompt\":\"Fake Simple Model\",\"type\":\"FakeSimpleModel\"}" +
                    "]}" +
                    ",{\"type\":\"FakeDerivedModel\",\"data\":[" +
                        "{\"name\":\"abstractString\",\"value\":\"\",\"prompt\":\"Abstract String\",\"type\":\"string\"}" +
                        ",{\"name\":\"derivedAdditionalString\",\"value\":\"\",\"prompt\":\"Derived Additional String\",\"type\":\"string\"}" +
                    "]}" +
                "],\"prompt\":\"Fake Abstract Model\",\"type\":\"FakeAbstractModel\"}" +
               
            "]}");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_entityType_of_data_property_is_serialized_with_FakeComplexModelWithEnumerableOfAbstract
    {
        private static readonly CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Entity
            };
        readonly static TemplateRepresentation<FakeComplexModelWithEnumerableOfAbstract> Representation =
            new TemplateRepresentation<FakeComplexModelWithEnumerableOfAbstract>(Settings);
        static string _subject;

        Because of = () => _subject = Representation.Serialize();

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                ",{\"name\":\"fakeAbstractModels\",\"objects\":[],\"select\":[" +
                    "{\"type\":\"FakeDerivedComplexModel\",\"data\":[" +
                        "{\"name\":\"abstractString\",\"value\":\"\",\"prompt\":\"Abstract String\",\"type\":\"string\"}" +
                        ",{\"name\":\"derivedAdditionalString\",\"value\":\"\",\"prompt\":\"Derived Additional String\",\"type\":\"string\"}" +
                        ",{\"name\":\"fakeSimpleModel\",\"object\":null,\"data\":[" +
                            "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}" +
                        "],\"prompt\":\"Fake Simple Model\",\"type\":\"FakeSimpleModel\"}" +
                    "]}" +
                    ",{\"type\":\"FakeDerivedModel\",\"data\":[" +
                        "{\"name\":\"abstractString\",\"value\":\"\",\"prompt\":\"Abstract String\",\"type\":\"string\"}" +
                        ",{\"name\":\"derivedAdditionalString\",\"value\":\"\",\"prompt\":\"Derived Additional String\",\"type\":\"string\"}" +
                    "]}" +
                "],\"prompt\":\"Fake Abstract Models\",\"type\":\"FakeAbstractModel[]\"}" +

            "]}");
    }

    //TODO array of abstracts



    [Subject(typeof(TemplateRepresentation<>), "Serialize TemplateRepresentation with ConversionMethod.Entity")]
    internal class When_the_template_representaion_serialized_with_the_FakeSimpleModelWithEnumAndStringEnum_as_entity
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Entity
        };
        readonly static TemplateRepresentation<FakeSimpleModelWithEnumAndStringEnum> representation
            = new TemplateRepresentation<FakeSimpleModelWithEnumAndStringEnum>(settings);
        static string subject;

        Because of = () => subject = representation.Serialize();

        It should_the_json_options_property_for_fakeEnum_be__array_0_1__ =
            () => subject.ShouldContain("\"options\":[0,1],");

        It should_the_json_options_property_for_fakeStringEnum_be__array_StringVal2_StringVal1__ =
            () => subject.ShouldContain("\"options\":[\"StringVal2\",\"StringVal1\"],");

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"string\"}," +
                "{\"name\":\"fakeEnum\",\"value\":0,\"options\":[0,1],\"prompt\":\"Fake Enum\",\"type\":\"FakeEnum\"}," +
                "{\"name\":\"fakeStringEnum\",\"value\":\"StringVal2\",\"options\":[\"StringVal2\",\"StringVal1\"],\"prompt\":\"Fake String Enum\",\"type\":\"FakeStringEnum\"}" +
            "]}");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize TemplateRepresentation with ConversionMethod.Entity")]
    internal class When_the_template_representaion_serialized_with_the_FakeIdentifierAttriuteEntitys_as_entity
    {
        private static readonly CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Entity
            };
        readonly static TemplateRepresentation<FakeComplexModelWithEnumerableOfAbstract> Representation =
            new TemplateRepresentation<FakeComplexModelWithEnumerableOfAbstract>(Settings);
        static string _subject;

        Because of = () => _subject = Representation.Serialize();

        //It should_the_json_property_still_be serialized_as_data_ =
        //    () => _subject.ShouldContain("\"entity\":{\"indentifier\":\"TheStringIdentifier1\",\"identifier\":true");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_entityType_of_data_property_is_serialized_with_multiple_levels_of_FakeEntityWithPropertyAccessRestrictions
    {
        static readonly CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Entity
            };
        readonly static TemplateRepresentation<FakeEntityWithPropertyAccessRestrictions> Representation =
            new TemplateRepresentation<FakeEntityWithPropertyAccessRestrictions>(Settings);

        static string _subject;

        Because of = () => _subject = Representation.Serialize();

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEqual("{\"data\":[" +
                "{\"name\":\"publicInt\",\"value\":0,\"prompt\":\"Public Int\",\"type\":\"int\"}" +
                ",{\"name\":\"fakeEntityWithPrivateSetterString\",\"object\":null,\"data\":[" +
                    "{\"name\":\"publicString\",\"value\":\"\",\"prompt\":\"Public String\",\"type\":\"string\"}" +
                "],\"prompt\":\"Fake Entity With Private Setter String\",\"type\":\"FakeEntityWithPrivateSetterString\"}" +
            "]}");
    }


    [Subject(typeof(TemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    internal class When_the_template_representaion_entitydata_type_is_serialized_with_FakeComplexModelWithCollectionJsonProperties
    {
        readonly static CollectionJsonSerializerSettings Settings =
            new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Entity
        };
        readonly static TemplateRepresentation<FakeComplexModelWithCollectionJsonProperties> Representation =
            new TemplateRepresentation<FakeComplexModelWithCollectionJsonProperties>(Settings);
        static string _subject;

        Because of = () => _subject = Representation.Serialize();

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => _subject.ShouldEqual("{\"data\":[" +
                //"{\"name\":\"someStringWithTemplateValueHandlingIgnore\",\"value\":\"\",\"prompt\":\"Some String With Template Value Handling Ignore\",\"type\":\"string\"}" +
                "{\"name\":\"someStringWithItemValueHandlingIgnore\",\"value\":\"\",\"prompt\":\"Some String With Item Value Handling Ignore\",\"type\":\"string\"}" +
                ",{\"name\":\"someStringWithPrompt\",\"value\":\"\",\"prompt\":\"I am the prompt\",\"type\":\"string\"}" +
            "]}");
    }

}

