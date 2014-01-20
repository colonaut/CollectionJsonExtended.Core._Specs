﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using CollectionJsonExtended.Core.Extensions;
using Machine.Fakes;
using Machine.Specifications;

// ReSharper disable InconsistentNaming

namespace CollectionJsonExtended.Core._Specs
{
    public abstract class CollectionJsonWriterContext
        : WithFakes
    {
        protected static IEnumerable<UrlInfoBase> subjectUrlInfoCollection;
        protected static CollectionJsonSerializerSettings serializerSettings;

        Establish context =
            () =>
            {
                serializerSettings =
                    new CollectionJsonSerializerSettings
                    {
                        ConversionMethod = ConversionMethod.Data
                    };

                var urlInfoCollectionInstance = new UrlInfoCollection();
                    FakeUrlInfo.AddFakeData(urlInfoCollectionInstance);

                var singletonFactory =
                    new SingletonFactory<UrlInfoCollection>(() => urlInfoCollectionInstance);
                
            };
    }
    
    
    [Subject(typeof(CollectionJsonWriter<>),
        "CollectionJsonWriter for an error")]
    public class When_the_CollectionJsonWriter_is_envoked_with_an_error_http_status_code
        : CollectionJsonWriterContext
    {
        
        static CollectionJsonWriter<FakeComplexModelWithListOfStrings> _subject;
        
        Because of = () => _subject
            = new CollectionJsonWriter<FakeComplexModelWithListOfStrings>(HttpStatusCode.InternalServerError);

        It should_the_collection_property_be_null
            = () => _subject.Collection.ShouldBeNull();
        
        It should_the_the_collection_representation_not_be_serialized
            = () => _subject.Serialize().ShouldNotContain("{\"collection");

        It should_the_the_error_representation_be_serialized
            = () => _subject.Serialize().ShouldEqual(
                      "{\"error\":{" +
                        "\"title\":\"InternalServerError\"," +
                        "\"code\":500" +
                      "}}");
    }


    [Subject(typeof(CollectionJsonWriter<>),
        "CollectionJsonWriter for a collection of FakeIdEntity with 1 item")]
    public class When_the_CollectionJsonWriter_is_envoked_with_1_FakeIdEntity_with_ConversionMethod_Data
        : CollectionJsonWriterContext
    {
        Establish context =
            () =>
            {

                //var urlInfoCollectionInstance = new UrlInfoCollection();
                //FakeUrlInfo.AddFakeData(urlInfoCollectionInstance);

                //var anSingletonFactory =
                //    An<SingletonFactory<UrlInfoCollection>>();
                //anSingletonFactory.WhenToldTo(x => x.GetInstance())
                //    .Return(urlInfoCollectionInstance);

                subjectUrlInfoCollection =
                    SingletonFactory<UrlInfoCollection>.Instance
                        .Find(typeof (FakeIntIdEntity));
            };

        static CollectionJsonWriter<FakeIntIdEntity> subject;
        Because of =
            () =>
            {
                subject = new CollectionJsonWriter<FakeIntIdEntity>(new FakeIntIdEntity
                                                                    {
                                                                        Id = 7773,
                                                                        SomeString = "some string a"
                                                                    }, serializerSettings);
            };

        It should_the_urlInfoCollection_have_items =
            () => subjectUrlInfoCollection.Count().ShouldBeGreaterThan(0);

        It should_foo2 = () => subjectUrlInfoCollection.Count().ShouldEqual(3);

        It should_GetVirtualPath_extension_method_return__some_path__ =
            () => subject.Collection.Href.ShouldEqual("some/path");

        It should_the_error_property_be_null =
            () => subject.Error.ShouldBeNull();

        It should_the_collection_property_be_of_type__CollectionRepresentation__ =
            () => subject.Collection.ShouldBeOfType<CollectionRepresentation<FakeIntIdEntity>>();

        It should_the_colletion_property_be_a_collection_of_items_containing_1_item =
            () => subject.Collection.Items.Count().ShouldEqual(1);

        It should_the_the_error_representation_not_be_serialized =
            () => subject.Serialize().ShouldNotContain("{\"error");

        It should_the_Collection_Href_property_be__some_path__ =
            () => subject.Collection.Href.ShouldEqual("some/path");

        It should_the_Collection_Item_Property_contain_1_item =
            () => subject.Collection.Items.Count().ShouldEqual(1);

        It should_the_Collection_Item_0_Href_property_be___some_path_7773___ =
            () => subject.Collection.Items.ToList()[0].Href.ShouldEqual("some/path/7773");
    }


    [Subject(typeof(CollectionJsonWriter<>),
        "CollectionJsonWriter for a collection of FakeAttributePrimaryKeyEntity with 1 item")]
    public class When_the_CollectionJsonWriter_is_envoked_with_1_FakeAttributePrimaryKeyEntity_with_ConversionMethod_Data
        : CollectionJsonWriterContext
    {
        Establish context =
            () =>
            {
                //var urlInfoCollectionInstance = new UrlInfoCollection();
                //FakeUrlInfo.AddFakeData(urlInfoCollectionInstance);

                //var anSingletonFactory =
                //    An<SingletonFactory<UrlInfoCollection>>();
                //anSingletonFactory.WhenToldTo(x => x.GetInstance())
                //    .Return(urlInfoCollectionInstance);

                subjectUrlInfoCollection =
                     SingletonFactory<UrlInfoCollection>.Instance
                     .Find(typeof(FakeAttributePrimaryKeyEntity));
            };

        static CollectionJsonWriter<FakeAttributePrimaryKeyEntity> subject;
        Because of =
            () =>
            {
                subject =
                    new CollectionJsonWriter<FakeAttributePrimaryKeyEntity>(
                        new FakeAttributePrimaryKeyEntity
                        {
                            PrimaryKey = "ThePrimaryKey",
                            SomeString = "some string"
                        }, serializerSettings);

            };

        It should_foo = () => subjectUrlInfoCollection.Count().ShouldBeGreaterThan(0);

        It should_foo2 = () => subjectUrlInfoCollection.Count().ShouldEqual(2);

        It the_Collection_Items_0_Href_Property_be__some_path_ThePrimaryKey__ =
            () => subject.Collection.Items.ToList()[0].Href.ShouldEqual("some/path/ThePrimaryKey");

    }


}
