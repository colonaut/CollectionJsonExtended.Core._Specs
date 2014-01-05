using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CollectionJsonExtended.Core.Extensions;
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
        
        Establish context =
            () =>
            {
                FakeUrlInfo.BuildCache();
               
            };
        Cleanup stuff =
            () =>
            {
                FakeUrlInfo.ClearCache();
            };


        static IEnumerable<UrlInfoBase> urlInfoCollection;
        static CollectionJsonSerializerSettings settings;
        static CollectionJsonWriter<FakeIntIdEntity> subject;

        private Because of =
            () =>
            {
                urlInfoCollection = UrlInfoBase.Find(typeof(FakeIntIdEntity));
                settings = new CollectionJsonSerializerSettings
                           {
                               ConversionMethod = ConversionMethod.Data
                           };

                subject = new CollectionJsonWriter<FakeIntIdEntity>(new FakeIntIdEntity
                                                          {
                                                              Id = 1,
                                                              SomeString = "some string a"
                                                          }, settings);
            };

        It should_the_urlInfoCollection_have_items =
            () => urlInfoCollection.Count().ShouldBeGreaterThan(0);

        It should_foo =
            () => subject.Collection.GetVirtualPath<FakeIntIdEntity>().ShouldEqual("some/path");

        It should_the_error_property_be_null =
            () => subject.Error.ShouldBeNull();

        It should_the_collection_property_be_of_type__CollectionRepresentation__ =
            () => subject.Collection.ShouldBeOfType<CollectionRepresentation<FakeIntIdEntity>>();

        It should_the_colletion_property_be_a_collection_of_items_containing_1_item =
            () => subject.Collection.Items.Count.ShouldEqual(1);

        It should_the_the_error_representation_not_be_serialized =
            () => CollectionJsonWriter.Serialize(subject, settings).ShouldNotContain("{\"error");

        It should_the_Collection_Href_property_be__some_route__ =
            () => subject.Collection.Href.ShouldEqual("some/path");

        //TODO current!!!
        //we must find out how to clear thing after test (Cleanup) as for the testwith route info we want to use the real UrlInfo via our extension methods
        //Establish context.... and Cleanup.. or behaviour?
        //we can then get rid of the passing of the collection.... but is this performant? passing is cheaper... NA it'S cached!

        //It should_the_Collection_Item_Href_property_be__some_route_bla_blub___ =
        //    () => _subject.Collection.Items[0].Href.ShouldEqual("some/route/bla/blub");

    }

}
