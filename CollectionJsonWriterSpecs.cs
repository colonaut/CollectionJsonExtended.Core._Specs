using System;
using System.Collections.Generic;
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


    [Subject(typeof(CollectionJsonWriter<>), "CollectionJsonWriter for a collection of FakeIdEntity with 1 item")]
    public class When_the_CollectionJsonWriter_is_envoked_with_1_FakeIdEntity_and_fakerequesturi_with_ConversionMethod_Data
    {
        //TODO: fill into behavior
        
        static readonly CollectionJsonSerializerSettings settings =
            new CollectionJsonSerializerSettings
            {
                ConversionMethod = ConversionMethod.Data
            };

        static readonly Uri requestUri = new Uri("http://www.example.org/fakerequesturi/1");

        static readonly Type fakeControllerType = new FakeController().GetType();

        static readonly IEnumerable<UrlInfo> urlInfoCollection =
            new List<UrlInfo>
            {
                new UrlInfo(typeof (FakeIntIdEntity))
                {
                    Params =
                        fakeControllerType.GetMethod("FakeMethod")
                        .GetParameters(),
                    Kind = Is.Base,
                    //Relation = "fakeMethod",
                    VirtualPath = "some/route"
                },
                new UrlInfo(typeof (FakeIntIdEntity))
                {
                    Params =
                        fakeControllerType.GetMethod(
                            "FakeMethodWithParam").GetParameters(),
                    Kind = Is.Item,
                    //Relation = "fakeMethodWithParam",
                    VirtualPath = "some/route/{fakeId}/{fakeString}"
                },
                new UrlInfo(typeof (FakeIntIdEntity))
                {
                    Params =
                        fakeControllerType.GetMethod("FakeMethod")
                        .GetParameters(),
                    Kind = Is.Query,
                    Relation = "fakeMethod",
                    VirtualPath = "some/route"
                }
            };

        static CollectionJsonWriter<FakeIntIdEntity> _subject;
           
        Because of = () => _subject
            = new CollectionJsonWriter<FakeIntIdEntity>(new FakeIntIdEntity
                                                        {
                                                            Id = 1,
                                                            SomeString = "some string a"
                                                        }, urlInfoCollection, settings);


        It should_the_error_property_be_null = () => _subject.Error.ShouldBeNull();

        It should_the_collection_property_be_of_type__CollectionRepresentation__ =
            () => _subject.Collection.ShouldBeOfType<CollectionRepresentation<FakeIntIdEntity>>();

        It should_the_colletion_property_be_a_collection_of_items_containing_1_item =
            () => _subject.Collection.Items.Count.ShouldEqual(1);

        It should_the_the_error_representation_not_be_serialized =
            () => CollectionJsonWriter.Serialize(_subject, settings).ShouldNotContain("{\"error");

        It should_the_Collection_Href_property_be__some_route__ =
            () => _subject.Collection.Href.ShouldEqual("some/route");

        It should_the_Collection_Item_Href_property_be__some_route_bla_blub___ =
            () => _subject.Collection.Items[0].Href.ShouldEqual("some/route/bla/blub");

    }

}
