using System;
using System.Net;
using Machine.Specifications;

// ReSharper disable InconsistentNaming

namespace CollectionJsonExtended.Core._Specs
{
    [Subject(typeof(CollectionJsonWriter<>), "CollectionJsonWriter for an error")]
    public class When_the_CollectionJsonWriter_is_envoked_with_an_error_http_status_code
    {
        static readonly CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Data
            };

        static CollectionJsonWriter<FakeComplexModelWithListOfStrings> _subject;
            
        
        Because of = () => _subject
            = new CollectionJsonWriter<FakeComplexModelWithListOfStrings>(HttpStatusCode.InternalServerError);

        It should_the_collection_property_be_null
            = () => _subject.Collection.ShouldBeNull();
        
        It should_the_the_collection_representation_not_be_serialized
            = () => CollectionJsonWriter.Serialize(_subject, settings).ShouldNotContain("{\"collection");

        It should_the_the_error_representation_be_serialized
            = () => CollectionJsonWriter.Serialize(_subject, settings).ShouldEqual(
                      "{\"error\":{" +
                        "\"title\":\"InternalServerError\"," +
                        "\"code\":500" +
                      "}}");
    }

    [Subject(typeof(CollectionJsonWriter<>), "CollectionJsonWriter for a collection with 1 item")]
    public class When_the_CollectionJsonWriter_is_envoked_with_1_FakeIdEntity_and_fakerequesturi
    {
        static readonly CollectionJsonSerializerSettings settings = new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Data
            };

        static readonly Uri requestUri = new Uri("http://www.example.org/fakerequesturi/1");

        static CollectionJsonWriter<FakeIntIdEntity> _subject;
           

        Because of = () => _subject
            = new CollectionJsonWriter<FakeIntIdEntity>(new FakeIntIdEntity
                                                        {
                                                            Id = 1,
                                                            SomeString = "some string a"
                                                        }, requestUri, settings);


        It should_the_error_property_be_null = () => _subject.Error.ShouldBeNull();

        It should_the_collection_property_be_of_type__CollectionRepresentation__ = () => _subject.Collection.ShouldBeOfType<CollectionRepresentation<FakeIntIdEntity>>();

        It should_the_colletion_property_be_a_collection_of_items_containing_1_item = () => _subject.Collection.Items.Count.ShouldEqual(1);

        It should_the_the_collection_representation_not_be_serialized
            = () => CollectionJsonWriter.Serialize(_subject, settings).ShouldNotContain("{\"error");

        It should_the_the_error_representation_be_serialized
            = () => CollectionJsonWriter.Serialize(_subject, settings).ShouldEqual(
                    "{\"collection\":{" +
                        "\"version\":\"1.0\"," +
                        "\"href\":\"http://www.example.org/fakerequesturi/1\"," +
                        "\"items\":[{" +
                            "\"href\":\"http://www.example.org/fakerequesturi/1\"," +
                            "\"data\":[" +
                                "{\"name\":\"id\",\"value\":1,\"prompt\":\"Id\"}" +
                                ",{\"name\":\"someString\",\"value\":\"some string a\",\"prompt\":\"Some String\"}" +
                            "]" +
                        "}]" +
                    "}}");
    }

}
