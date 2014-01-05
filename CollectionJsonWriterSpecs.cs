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

    //conflic because cache is static and not mockable...
    [Subject(typeof(CollectionJsonWriter<>), "CollectionJsonWriter for a collection of FakeIdEntity with 1 item")]
    public class When_the_CollectionJsonWriter_is_envoked_with_1_FakeIdEntity_with_ConversionMethod_Data
    {
        //TODO: fill into behavior and this does not work... how to cleanup???

        Establish context =
            () =>
            {
                //that'S all crap we need a mockable singleton This tes flickers and gets worse when trying to setup other tests with same context
                FakeUrlInfo.CleanUpCache();
                FakeUrlInfo.BuildCache();

            };

        static IEnumerable<UrlInfoBase> urlInfoCollection;
        static CollectionJsonSerializerSettings settings;
        static CollectionJsonWriter<FakeIntIdEntity> subject;

        Because of =
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

        It should_foo2 = () => urlInfoCollection.Count().ShouldEqual(3);

        It should_GetVirtualPath_extension_method_return__some_path__ =
            () => subject.Collection.GetVirtualPath<FakeIntIdEntity>().ShouldEqual("some/path");

        It should_the_error_property_be_null =
            () => subject.Error.ShouldBeNull();

        It should_the_collection_property_be_of_type__CollectionRepresentation__ =
            () => subject.Collection.ShouldBeOfType<CollectionRepresentation<FakeIntIdEntity>>();

        It should_the_colletion_property_be_a_collection_of_items_containing_1_item =
            () => subject.Collection.Items.Count.ShouldEqual(1);

        It should_the_the_error_representation_not_be_serialized =
            () => CollectionJsonWriter.Serialize(subject, settings).ShouldNotContain("{\"error");

        It should_the_Collection_Href_property_be__some_path__ =
            () => subject.Collection.Href.ShouldEqual("some/path");

        It should_the_Collection_Item_Property_contain_1_item =
            () => subject.Collection.Items.Count.ShouldEqual(1);

        It should_the_Collection_Item_0_Href_property_be___some_path_fakeId___ =
            () => subject.Collection.Items[0].Href.ShouldEqual("some/path/{fakeId}");


        Cleanup stuff =
            () =>
            {
                FakeUrlInfo.CleanUpCache();
            };


    }


    //[Subject(typeof(CollectionJsonWriter<>), "CollectionJsonWriter for a collection of FakeAttributePrimaryKeyEntity with 1 item")]
    //public class When_the_CollectionJsonWriter_is_envoked_with_1_FakeAttributePrimaryKeyEntity_with_ConversionMethod_Data
    //{
    //    //TODO: fill into behavior

    //    private Establish context =
    //        () =>
    //        {
    //            FakeUrlInfo.BuildCache();
    //        };


    //    static IEnumerable<UrlInfoBase> urlInfoCollection;
    //    static CollectionJsonSerializerSettings settings;
    //    static CollectionJsonWriter<FakeAttributePrimaryKeyEntity> subject;

    //    Because of =
    //        () =>
    //        {
    //            //FakeUrlInfo.CleanUpCache();
                
    //            urlInfoCollection = UrlInfoBase.Find(typeof(FakeAttributePrimaryKeyEntity));
    //            settings =
    //                new CollectionJsonSerializerSettings
    //                {
    //                    ConversionMethod = ConversionMethod.Data
    //                };
    //            subject =
    //                new CollectionJsonWriter<FakeAttributePrimaryKeyEntity>(
    //                    new FakeAttributePrimaryKeyEntity
    //                    {
    //                        PrimaryKey = "ThePrimaryKey",
    //                        SomeString = "some string"
    //                    }, settings);

    //        };

    //    It should_foo = () => urlInfoCollection.Count().ShouldBeGreaterThan(0);

    //    It should_foo2 = () => urlInfoCollection.Count().ShouldEqual(2);

    //    //It should_GetVirtualPath_extension_method_return__some_path__ =
    //    //    () => subject.Collection.Items[0].GetVirtualPath().ShouldEqual("some/path");

    //    //private It should_foo3 =
    //    //    () => subject.Collection.Items[0].Href.ShouldEqual("to be done");


    //    private Cleanup stuff =
    //        () =>
    //        {
    //            FakeUrlInfo.CleanUpCache();
    //        };
    
    //}


}
