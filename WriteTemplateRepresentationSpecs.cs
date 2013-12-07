using Machine.Specifications;

namespace CollectionJsonExtended.Core._Specs
{
    [Subject(typeof(WriteTemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    public class When_the_template_representaion_entitydata_type_is_serialized_with_the_FakeSimpleModelWithEnumAndStringEnum
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static WriteTemplateRepresentation<FakeSimpleModelWithEnumAndStringEnum> representation = new WriteTemplateRepresentation<FakeSimpleModelWithEnumAndStringEnum>(settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter.Serialize(representation);

        It should_the_json_options_property_for_fakeEnum_be__array_0_1__ =
            () => subject.ShouldContain("\"options\":[0,1],");

        It should_the_json_options_property_for_fakeStringEnum_be__array_StringVal2_StringVal1__ =
            () => subject.ShouldContain("\"options\":[\"StringVal2\",\"StringVal1\"],");

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"serialize\":\"Data\",\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}," +
                "{\"name\":\"fakeEnum\",\"value\":0,\"options\":[0,1],\"prompt\":\"Fake Enum\",\"type\":\"FakeEnum\"}," +
                "{\"name\":\"fakeStringEnum\",\"value\":\"StringVal2\",\"options\":[\"StringVal2\",\"StringVal1\"],\"prompt\":\"Fake String Enum\",\"type\":\"FakeStringEnum\"}" +
            "]}");
    }


    [Subject(typeof(WriteTemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    public class When_the_template_representaion_entitydata_type_is_serialized_with_the_FakeComplexModelWithArrays
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static WriteTemplateRepresentation<FakeComplexModelWithArrays> representation = new WriteTemplateRepresentation<FakeComplexModelWithArrays>(settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter.Serialize(representation);

        //It should_the_json_options_property_for_someStrings_be_have_array__array_empty__ =
        //    () => subject.ShouldContain("\"name\":\"someStrings\",\"values\":[],");

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"serialize\":\"Data\",\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                ",{\"name\":\"someStrings\",\"values\":[],\"prompt\":\"Some Strings\",\"type\":\"String[]\"}" +
                ",{\"name\":\"fakeSimpleModels\",\"objects\":[],\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                    "],\"prompt\":\"Fake Simple Models\",\"type\":\"FakeSimpleModel[]\"}" +
                "]}");
    }


    [Subject(typeof(WriteTemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    public class When_the_template_representaion_entitydata_type_is_serialized_with_the_FakeComplexModelWithEnumerable
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static WriteTemplateRepresentation<FakeComplexModelWithEnumerable> representation = new WriteTemplateRepresentation<FakeComplexModelWithEnumerable>(settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter.Serialize(representation);

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"serialize\":\"Data\",\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                ",{\"name\":\"fakeSimpleModel\",\"object\":null,\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                    "],\"prompt\":\"Fake Simple Model\",\"type\":\"FakeSimpleModel\"}" +
                ",{\"name\":\"fakeSimpleModelCollection\",\"objects\":[],\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                    "],\"prompt\":\"Fake Simple Model Collection\",\"type\":\"Collection`1[FakeSimpleModel]\"}" +
                ",{\"name\":\"fakeSimpleModelList\",\"objects\":[],\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                    "],\"prompt\":\"Fake Simple Model List\",\"type\":\"IList`1[FakeSimpleModel]\"}" +
                ",{\"name\":\"fakeSimpleModels\",\"objects\":[],\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                    "],\"prompt\":\"Fake Simple Models\",\"type\":\"IEnumerable`1[FakeSimpleModel]\"}" +
                "]}");
    }


    [Subject(typeof(WriteTemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    public class When_the_template_representaion_entitydata_type_is_serialized_with_the_FakeComplexModel
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static WriteTemplateRepresentation<FakeComplexModel> representation = new WriteTemplateRepresentation<FakeComplexModel>(settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter.Serialize(representation);

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"serialize\":\"Data\",\"data\":[" +
                "{\"name\":\"fakeSimpleModel\",\"object\":null,\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                    "],\"prompt\":\"Fake Simple Model\",\"type\":\"FakeSimpleModel\"}" +
                "]}");
    }


    [Subject(typeof(WriteTemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    public class When_the_template_representaion_entitydata_type_is_serialized_with_FakeSimpleModelWithValueTypes
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static WriteTemplateRepresentation<FakeSimpleModelWithValueTypes> representation = new WriteTemplateRepresentation<FakeSimpleModelWithValueTypes>(settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter.Serialize(representation);

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"serialize\":\"Data\",\"data\":[" +
                "{\"name\":\"int\",\"value\":0,\"prompt\":\"Type a number:\",\"type\":\"Int32\"}" +
                ",{\"name\":\"long\",\"value\":0,\"prompt\":\"Long\",\"type\":\"Int64\"}" +
                ",{\"name\":\"float\",\"value\":0.0,\"prompt\":\"Float\",\"type\":\"Single\"}" +
                ",{\"name\":\"bool\",\"value\":false,\"prompt\":\"Bool\",\"type\":\"Boolean\"}" +
                ",{\"name\":\"char\",\"value\":\"\\u0000\",\"prompt\":\"Char\",\"type\":\"Char\"}" +
                ",{\"name\":\"decimal\",\"value\":0.0,\"prompt\":\"Decimal\",\"type\":\"Decimal\"}" +
                ",{\"name\":\"short\",\"value\":0,\"prompt\":\"Short\",\"type\":\"Int16\"}" +
                ",{\"name\":\"double\",\"value\":0.0,\"prompt\":\"Double\",\"type\":\"Double\"}" +
            "]}");
    }


    [Subject(typeof(WriteTemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    public class When_the_template_representaion_entitydata_type_is_serialized_with_FakeSimpleModelWithNullableValueTypes
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Data
        };
        readonly static WriteTemplateRepresentation<FakeSimpleModelWithNullableValueTypes> representation = new WriteTemplateRepresentation<FakeSimpleModelWithNullableValueTypes>(settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter.Serialize(representation);

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"serialize\":\"Data\",\"data\":[" +
                "{\"name\":\"int\",\"value\":null,\"prompt\":\"Int\",\"type\":\"Nullable`1\"}" +
                ",{\"name\":\"long\",\"value\":null,\"prompt\":\"Long\",\"type\":\"Nullable`1\"}" +
                ",{\"name\":\"float\",\"value\":null,\"prompt\":\"Float\",\"type\":\"Nullable`1\"}" +
                ",{\"name\":\"bool\",\"value\":null,\"prompt\":\"Bool\",\"type\":\"Nullable`1\"}" +
                ",{\"name\":\"char\",\"value\":null,\"prompt\":\"Char\",\"type\":\"Nullable`1\"}" +
                ",{\"name\":\"decimal\",\"value\":null,\"prompt\":\"Decimal\",\"type\":\"Nullable`1\"}" +
                ",{\"name\":\"short\",\"value\":null,\"prompt\":\"Short\",\"type\":\"Nullable`1\"}" +
                ",{\"name\":\"double\",\"value\":null,\"prompt\":\"Double\",\"type\":\"Nullable`1\"}" +
            "]}");
    }


    [Subject(typeof(WriteTemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    public class When_the_template_representaion_entitydata_type_is_serialized_with_FakeComplexModelWithAbstract
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Entity
            };
        readonly static WriteTemplateRepresentation<FakeComplexModelWithAbstract> representation = new WriteTemplateRepresentation<FakeComplexModelWithAbstract>(settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter.Serialize(representation);

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"serialize\":\"Entity\",\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                ",{\"name\":\"fakeAbstractModel\",\"abstract\":null,\"concretes\":[" +
                    "{\"concrete\":\"FakeDerivedComplexModel\",\"data\":[" +
                        "{\"name\":\"abstractString\",\"value\":\"\",\"prompt\":\"Abstract String\",\"type\":\"String\"}" +
                        ",{\"name\":\"derivedAdditionalString\",\"value\":\"\",\"prompt\":\"Derived Additional String\",\"type\":\"String\"}" +
                        ",{\"name\":\"fakeSimpleModel\",\"object\":null,\"data\":[" +
                            "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                        "],\"prompt\":\"Fake Simple Model\",\"type\":\"FakeSimpleModel\"}" +
                    "]}" +
                    ",{\"concrete\":\"FakeDerivedModel\",\"data\":[" +
                        "{\"name\":\"abstractString\",\"value\":\"\",\"prompt\":\"Abstract String\",\"type\":\"String\"}" +
                        ",{\"name\":\"derivedAdditionalString\",\"value\":\"\",\"prompt\":\"Derived Additional String\",\"type\":\"String\"}" +
                    "]}" +
                "],\"prompt\":\"Fake Abstract Model\",\"type\":\"FakeAbstractModel\"}" +
               
            "]}");
    }


    [Subject(typeof(WriteTemplateRepresentation<>), "Serialize Type TemplateRepresentation.Data representation")]
    public class When_the_template_representaion_entitydata_type_is_serialized_with_FakeComplexModelWithEnumerableOfAbstract
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Entity
        };
        readonly static WriteTemplateRepresentation<FakeComplexModelWithEnumerableOfAbstract> representation = new WriteTemplateRepresentation<FakeComplexModelWithEnumerableOfAbstract>(settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter<FakeComplexModelWithEnumerableOfAbstract>.Serialize(representation);

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"serialize\":\"Entity\",\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                ",{\"name\":\"fakeAbstractModels\",\"abstracts\":[],\"concretes\":[" +
                    "{\"concrete\":\"FakeDerivedComplexModel\",\"data\":[" +
                        "{\"name\":\"abstractString\",\"value\":\"\",\"prompt\":\"Abstract String\",\"type\":\"String\"}" +
                        ",{\"name\":\"derivedAdditionalString\",\"value\":\"\",\"prompt\":\"Derived Additional String\",\"type\":\"String\"}" +
                        ",{\"name\":\"fakeSimpleModel\",\"object\":null,\"data\":[" +
                            "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}" +
                        "],\"prompt\":\"Fake Simple Model\",\"type\":\"FakeSimpleModel\"}" +
                    "]}" +
                    ",{\"concrete\":\"FakeDerivedModel\",\"data\":[" +
                        "{\"name\":\"abstractString\",\"value\":\"\",\"prompt\":\"Abstract String\",\"type\":\"String\"}" +
                        ",{\"name\":\"derivedAdditionalString\",\"value\":\"\",\"prompt\":\"Derived Additional String\",\"type\":\"String\"}" +
                    "]}" +
                "],\"prompt\":\"Fake Abstract Models\",\"type\":\"IEnumerable`1[FakeAbstractModel]\"}" +

            "]}");
    }

    //TODO array of abstracts



    [Subject(typeof(WriteTemplateRepresentation<>), "Serialize Type TemplateRepresentation.Entity")]
    public class When_the_template_representaion_entitydata_type_is_serialized_with_the_FakeSimpleModelWithEnumAndStringEnum_as_entity
    {
        readonly static CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
        {
            ConversionMethod = ConversionMethod.Entity
        };
        readonly static WriteTemplateRepresentation<FakeSimpleModelWithEnumAndStringEnum> representation
            = new WriteTemplateRepresentation<FakeSimpleModelWithEnumAndStringEnum>(settings);
        static string subject;

        Because of = () => subject = CollectionJsonWriter.Serialize(representation);

        It should_the_json_options_property_for_fakeEnum_be__array_0_1__ =
            () => subject.ShouldContain("\"options\":[0,1],");

        It should_the_json_options_property_for_fakeStringEnum_be__array_StringVal2_StringVal1__ =
            () => subject.ShouldContain("\"options\":[\"StringVal2\",\"StringVal1\"],");

        It should_the_peoperties_of_the_type_be_reflected_in_json =
            () => subject.ShouldEqual("{\"serialize\":\"Entity\",\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"\",\"prompt\":\"Some String\",\"type\":\"String\"}," +
                "{\"name\":\"fakeEnum\",\"value\":0,\"options\":[0,1],\"prompt\":\"Fake Enum\",\"type\":\"FakeEnum\"}," +
                "{\"name\":\"fakeStringEnum\",\"value\":\"StringVal2\",\"options\":[\"StringVal2\",\"StringVal1\"],\"prompt\":\"Fake String Enum\",\"type\":\"FakeStringEnum\"}" +
            "]}");
    }

}
