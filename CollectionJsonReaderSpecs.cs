using System.Collections.Generic;
using System.Collections.ObjectModel;
//using Machine.Fakes;
using System.Linq;
using Machine.Specifications;

// ReSharper disable InconsistentNaming

namespace CollectionJsonExtended.Core._Specs
{
    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeSimpleModel_with_empty_template
    {
        static CollectionJsonReader<FakeSimpleModel> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeSimpleModel>.Deserialize(
                "{\"template\":{}}");

        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeSimpleModel>));

        It should_the_subject_Entity_property_be_null = () => _subject.Entity.ShouldBeNull();
    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReaderr")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeSimpleModel_with_valid_json
    {
        static CollectionJsonReader<FakeSimpleModel> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeSimpleModel>.Deserialize(
                "{\"template\":{\"data\":[{\"name\":\"someString\",\"value\":\"foo bar\"}]}}");

        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeSimpleModel>));

        It should_the_subject_Template_data_property_contain_one_element_of_type = () => _subject.Data.Count().ShouldEqual(1);

        It should_the_subject_Template_data_0_name_be__someString__ = () => _subject.Data.ToList()[0].Name.ShouldEqual("someString");

        It should_the_subject_Template_entity_property_be_null = () => _subject.Entity.ShouldNotBeNull();

        It should_the_subject_Template_entity_property__someString__be__foo_bar__ = () => _subject.Entity.SomeString.ShouldEqual("foo bar");

    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeSimpleModelWithEnumAndStringEnum_with_valid_json
    {
        static CollectionJsonReader<FakeSimpleModelWithEnumAndStringEnum> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeSimpleModelWithEnumAndStringEnum>.Deserialize(
                "{\"template\":{\"data\":[" +
                    "{\"name\":\"someString\",\"value\":\"foo bar\"}" +
                    ",{\"name\":\"fakeEnum\",\"value\":1}" +
                    ",{\"name\":\"fakeStringEnum\",\"value\":\"StringVal2\"}" +
                "]}}");

        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeSimpleModelWithEnumAndStringEnum>));

        It should_the_subject_entity_property_be_of_type_fakeSimpleModel = () => _subject.Entity.ShouldNotBeNull();

        It should_the_property_someString_be__foo_bar__ = () => _subject.Entity.SomeString.ShouldEqual("foo bar");

        It should_the_property_fakeEnum_be__FakeEnum_Val1__ = () => _subject.Entity.FakeEnum.ShouldEqual(FakeEnum.Val1);

        It should_the_property_fakeStringEnum_be__FakeStringEnum_StringVal2__ = () => _subject.Entity.FakeStringEnum.ShouldEqual(FakeStringEnum.StringVal2);
    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeSimpleModelWithListOfStrings_with_valid_json
    {
        static CollectionJsonReader<FakeComplexModelWithListOfStrings> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeComplexModelWithListOfStrings>.Deserialize(
                "{\"template\":{\"data\":[" +
                    "{\"name\":\"someString\",\"value\":\"foo bar\"}" +
            //",{\"name\":\"fakeEnum\",\"value\":1}" + another test for ignoring not found values. this should go somewhere else.
                    ",{\"name\":\"someStrings\",\"values\":[\"foo\",\"bar\"]}" +
              "]}}");


        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeComplexModelWithListOfStrings>));

        It should_the_property_someStrings_be_of_type__ilist_of_string__ = () => _subject.Entity.SomeStrings.ShouldBeOfType<List<string>>();

        It should_the_property_someStrings_have_two_entries = () => _subject.Entity.SomeStrings.Count.ShouldEqual(2);

        It should_the_property_someStrings_a_second_entriy__bar__ = () => _subject.Entity.SomeStrings[1].ShouldEqual("bar");
    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeSimpleModelWithValueTypes_with_null_values
    {
        static CollectionJsonReader<FakeSimpleModelWithValueTypes> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeSimpleModelWithValueTypes>.Deserialize(
                "{\"template\":{\"data\":[" +
                    "{\"name\":\"int\",\"value\":1}" +
                    ",{\"name\":\"long\",\"value\":1}" +
                    ",{\"name\":\"float\",\"value\":1}" +
                    ",{\"name\":\"bool\",\"value\":true}" +
                    ",{\"name\":\"char\",\"value\":\"s\"}" +
                    ",{\"name\":\"decimal\",\"value\":\"1.1999999\"}" +
                    ",{\"name\":\"short\",\"value\":-123}" +
                    ",{\"name\":\"double\",\"value\":-123}" +
                "]}}");

        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeSimpleModelWithValueTypes>));

        It should_the_subject_Template_entity_property_not_be_null = () => _subject.Entity.ShouldNotBeNull();

        It should_the_property_int_be__1__ = () => _subject.Entity.Int.ShouldEqual(1);
        It should_the_property_long_be__1__ = () => _subject.Entity.Long.ShouldEqual(1);
        It should_the_property_float_be__1F__ = () => _subject.Entity.Float.ShouldEqual(1F);
        It should_the_property_bool_be__true__ = () => _subject.Entity.Bool.ShouldEqual(true);
        It should_the_property_char_be__s__ = () => _subject.Entity.Char.ShouldEqual('s');
        It should_the_property_decimal_be__1_19m__ = () => _subject.Entity.Decimal.ShouldEqual(1.1999999m);
        It should_the_property_short_be__negative_123__ = () => _subject.Entity.Short.ShouldEqual<short>(-123);
        It should_the_property_double_be__negative_123__ = () => _subject.Entity.Double.ShouldEqual(-123D);

    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeSimpleModelWithValueTypes_with_valid_json
    {
        static CollectionJsonReader<FakeSimpleModelWithValueTypes> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeSimpleModelWithValueTypes>.Deserialize(
                "{\"template\":{\"data\":[" +
                    "{\"name\":\"int\",\"value\":1}" +
                    ",{\"name\":\"long\",\"value\":1}" +
                    ",{\"name\":\"float\",\"value\":1}" +
                    ",{\"name\":\"bool\",\"value\":true}" +
                    ",{\"name\":\"char\",\"value\":\"s\"}" +
                    ",{\"name\":\"decimal\",\"value\":\"1.1999999\"}" +
                    ",{\"name\":\"short\",\"value\":-123}" +
                    ",{\"name\":\"double\",\"value\":-123}" +
                "]}}");

        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeSimpleModelWithValueTypes>));

        It should_the_subject_Template_entity_property_not_be_null = () => _subject.Entity.ShouldNotBeNull();

        It should_the_property_int_be__1__ = () => _subject.Entity.Int.ShouldEqual(1);
        It should_the_property_long_be__1__ = () => _subject.Entity.Long.ShouldEqual(1);
        It should_the_property_float_be__1F__ = () => _subject.Entity.Float.ShouldEqual(1F);
        It should_the_property_bool_be__true__ = () => _subject.Entity.Bool.ShouldEqual(true);
        It should_the_property_char_be__s__ = () => _subject.Entity.Char.ShouldEqual('s');
        It should_the_property_decimal_be__1_19m__ = () => _subject.Entity.Decimal.ShouldEqual(1.1999999m);
        It should_the_property_short_be__negative_123__ = () => _subject.Entity.Short.ShouldEqual<short>(-123);
        It should_the_property_double_be__negative_123__ = () => _subject.Entity.Double.ShouldEqual(-123D);

    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeComplexModel_with_valid_json
    {
        static CollectionJsonReader<FakeComplexModel> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeComplexModel>.Deserialize(
                "{\"template\":{\"data\":[" +
                    "{\"name\":\"fakeSimpleModel\",\"object\":{\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"foo bar\"}" +
                    "]}}" +
                "]}}");


        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeComplexModel>));

        It should_the_property_fakeSimpleModel_be_of_type_fakeSimpleModel = () => _subject.Entity.FakeSimpleModel.ShouldBeOfType<FakeSimpleModel>();

        It should_the_property_someString_of_fakeSompleModel_be__foo_bar__ = () => _subject.Entity.FakeSimpleModel.SomeString.ShouldEqual("foo bar");

    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeComplexModelWithArrays_with_valid_json
    {
        static CollectionJsonReader<FakeComplexModelWithArrays> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeComplexModelWithArrays>.Deserialize(
                "{\"template\":{\"data\":[" +
                    "{\"name\":\"someString\",\"value\":\"foo bar\"}" +
                    ",{\"name\":\"someStrings\",\"values\":[\"foo\",\"bar\"]}" +
                    ",{\"name\":\"fakeSimpleModels\",\"objects\":[{\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"the second\"}" +
                    "]}]}" +
                "]}}");


        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeComplexModelWithArrays>));

        It should_the_property_someStrings_be_of_type_array_of_string__ = () => _subject.Entity.SomeStrings.ShouldBeOfType<string[]>();

        It should_the_property_someStrings_have_two_entries = () => _subject.Entity.SomeStrings.Length.ShouldEqual(2);

        It should_the_property_someStrings_a_second_entriy__bar__ = () => _subject.Entity.SomeStrings[1].ShouldEqual("bar");

        It should_the_property_fakeSimpleModels_be_of_type__array_of_FakeSimpleModel__ = () => _subject.Entity.FakeSimpleModels.ShouldBeOfType(typeof(FakeSimpleModel[]));


    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeComplexModelWithEnumerable_with_valid_json
    {
        static CollectionJsonReader<FakeComplexModelWithEnumerable> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeComplexModelWithEnumerable>.Deserialize(
                "{\"template\":{\"data\":[" +
                    "{\"name\":\"someString\",\"value\":\"foo bar\"}" +
                    ",{\"name\":\"fakeSimpleModelCollection\",\"objects\":[{\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"the first\"}" +
                    "]}]}" +
                    ",{\"name\":\"fakeSimpleModelList\",\"objects\":[{\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"the first\"}" +
                    "]}]}" +
                    ",{\"name\":\"fakeSimpleModels\",\"objects\":[{\"data\":[" +
                        "{\"name\":\"someString\",\"value\":\"the first\"}" +
                    "]}]}" +
                "]}}");


        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeComplexModelWithEnumerable>));

        It should_the_property_fakeSimpleModelCollection_be_of_type__collection_of_fakeSimpleModel__ = () => _subject.Entity.FakeSimpleModelCollection.ShouldBeOfType<Collection<FakeSimpleModel>>();

        It should_the_property_fakeSimpleModelCollection_have_1_entry = () => _subject.Entity.FakeSimpleModelCollection.Count.ShouldEqual(1);

        It should_the_property_fakeSimpleModelList_be_of_type__list_of_fakesimplemodel__ = () => _subject.Entity.FakeSimpleModelList.ShouldBeOfType<List<FakeSimpleModel>>();

        It should_the_property_fakeSimpleModelList_have_1_entry = () => _subject.Entity.FakeSimpleModelList.Count.ShouldEqual(1);

        It should_the_property_fakeSimpleModelList_0_someString_must_be__the_first__ = () => _subject.Entity.FakeSimpleModelList[0].SomeString.ShouldEqual("the first");

    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeComplexModelWithAbstract_with_valid_json
    {
        private static CollectionJsonReader<FakeComplexModelWithAbstract> _subject;

        private Because of =
            () => _subject = CollectionJsonReader<FakeComplexModelWithAbstract>.Deserialize(
            "{\"template\":{\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"foo bar\"}" +
                ",{\"name\":\"fakeAbstractModel\",\"abstract\":{\"data\":[" +
                    "{\"name\":\"abstractString\",\"value\":\"abstract foo\"}" +
                    ",{\"name\":\"derivedAdditionalString\",\"value\":\"abstract bar\"}" +
                "],\"type\":\"FakeDerivedComplexModel\"}}" +
            "]}}");


        private It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        private It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeComplexModelWithAbstract>));

        private It should_the_property__someString___be__foo_bar__ = () => _subject.Entity.SomeString.ShouldEqual("foo bar");

        private It should_the__FakeAbstractModel__property_be__FakeDerivedComplexModel__ = () => _subject.Entity.FakeAbstractModel.ShouldBeOfType<FakeDerivedComplexModel>();

        private It should_the_property_of_the_subclass__abstractString___be__the_second__
            = () => _subject.Entity.FakeAbstractModel.AbstractString.ShouldEqual("abstract foo");

        private It should_the_subclass_castable_to_FakeDerivedComplexModel
            = () => (_subject.Entity.FakeAbstractModel as FakeDerivedComplexModel).ShouldNotBeNull();

        private It should_the_property_of_the_subclass__derivedAstractString___be__the_second__
            = () => (_subject.Entity.FakeAbstractModel as FakeDerivedComplexModel).DerivedAdditionalString.ShouldEqual("abstract bar");

    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeComplexModelWithEnumerableOfAbstract_with_valid_json
    {
        private static CollectionJsonReader<FakeComplexModelWithEnumerableOfAbstract> _subject;

        private Because of =
            () => _subject = CollectionJsonReader<FakeComplexModelWithEnumerableOfAbstract>.Deserialize(
            "{\"template\":{\"data\":[" +
                "{\"name\":\"someString\",\"value\":\"foo bar\"}" +
                ",{\"name\":\"fakeAbstractModels\",\"abstracts\":[" +
                    "{\"data\":[" +
                        "{\"name\":\"abstractString\",\"value\":\"abstract foo\"}" +
                        ",{\"name\":\"derivedAdditionalString\",\"value\":\"abstract bar\"}" +
                    "],\"type\":\"FakeDerivedComplexModel\"}" +
                "]}" +
            "]}}");


        private It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        private It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeComplexModelWithEnumerableOfAbstract>));

        private It should_the_property__someString___be__foo_bar__ = () => _subject.Entity.SomeString.ShouldEqual("foo bar");

        private It should_the_property = () => _subject.Entity.FakeAbstractModels.ShouldBeOfType<IEnumerable<FakeAbstractModel>>();

        private It should_the_type = () => _subject.Entity.FakeAbstractModels.ToList()[0].ShouldBeOfType<FakeDerivedComplexModel>();
    }

    [Subject(typeof(CollectionJsonReader<>), "Deserialize template json for CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeComplexModelWithAbstract_with_valid_json_and_null_for_class_and_abstract
    {
        private static CollectionJsonReader<FakeComplexModelWithAbstract> _subject;

        private Because of =
            () => _subject = CollectionJsonReader<FakeComplexModelWithAbstract>.Deserialize(
                "{\"template\":{\"data\":[" +
                    "{\"name\":\"someString\",\"value\":\"foo bar\"}" +
                    ",{\"name\":\"fakeAbstractModel\",\"abstract\":null}" +
                "]}}");

        private It should_the_entities_property_FakeAbstractModel_be_null = () => _subject.Entity.FakeAbstractModel.ShouldBeNull();

    }

    //TODO array of abstracts




    [Subject(typeof(CollectionJsonReader<>), "Deserialize template of CollectionJsonReader")]
    public class When_the_CollectionJsonTemplate_is_envoked_for_FakeSimpleModel_with_valid_json_for_entity
    {
        static CollectionJsonReader<FakeSimpleModel> _subject;

        private Because of = () => _subject = CollectionJsonReader<FakeSimpleModel>.Deserialize(
                "{\"template\":{\"entity\":{\"someString\":\"foo bar\"}}}");

        It should_the_subject_not_be_null = () => _subject.ShouldNotBeNull();

        It should_the_subject_be_of_type = () => _subject.ShouldBeOfType(typeof(CollectionJsonReader<FakeSimpleModel>));

        It should_the_subject_Template_data_property_contain_no_items = () => _subject.Data.Any().ShouldBeFalse(); //we could rework this test to evaluate to null for Data. currently we always have an empty list. This CAN be good. Don't know yet.

        It should_the_subject_Template_entity_property_not_be_null = () => _subject.Entity.ShouldNotBeNull();

        It should_the_subject_Template_entity_property__someString__be__foo_bar__ = () => _subject.Entity.SomeString.ShouldEqual("foo bar");

    }


}
