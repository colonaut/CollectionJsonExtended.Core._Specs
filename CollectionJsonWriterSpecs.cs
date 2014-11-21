using System.Collections.Generic;
using System.Linq;
using System.Net;
using CollectionJsonExtended.Core.Extensions;
using Machine.Fakes;
using Machine.Specifications;
using Machine.Specifications.Model;

// ReSharper disable InconsistentNaming

namespace CollectionJsonExtended.Core._Specs
{
    public abstract class CollectionJsonWriterContext
        : WithFakes
    {
        protected static IEnumerable<UrlInfoBase> UrlInfos;
        protected static CollectionJsonSerializerSettings SerializerSettings;
        protected static SingletonFactory<UrlInfoCollection> SingletonUrlInfoCollection;

        Establish context =
            () =>
            {
                SerializerSettings =
                    new CollectionJsonSerializerSettings
                    {
                        ConversionMethod = ConversionMethod.Data
                    };

                var urlInfoCollectionInstance = new UrlInfoCollection();
                FakeUrlInfo.AddFakeData(urlInfoCollectionInstance);

                SingletonUrlInfoCollection =
                    new SingletonFactory<UrlInfoCollection>(() => urlInfoCollectionInstance);
                    //new SingletonFactory<UrlInfoCollection>(() => new UrlInfoCollection());

            };

        Cleanup stuff =
            () =>
            {
                SingletonUrlInfoCollection =
                    new SingletonFactory<UrlInfoCollection>(() => new UrlInfoCollection());
            };

        //OnEstablish bar
        //OnCleanup foo = () => { sr};
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

                UrlInfos =
                    //SingletonFactory<UrlInfoCollection>.Instance
                    SingletonUrlInfoCollection.GetInstance()
                        .Find(typeof (FakeEntityIntId));
            };

        static CollectionJsonWriter<FakeEntityIntId> subject;
        Because of =
            () =>
            {
                subject = new CollectionJsonWriter<FakeEntityIntId>(new FakeEntityIntId
                                                                    {
                                                                        Id = 7773,
                                                                        SomeString = "some string a"
                                                                    }, SerializerSettings);
            };

        It should_the_urlInfoCollection_have_items =
            () => UrlInfos.Count().ShouldBeGreaterThan(0);

        It should_foo2 = () => UrlInfos.Count().ShouldEqual(3);

        It should_GetVirtualPath_extension_method_return__some_path__ =
            () => subject.Collection.Href.ShouldEqual("some/path");

        It should_the_error_property_be_null =
            () => subject.Error.ShouldBeNull();

        It should_the_collection_property_be_of_type__CollectionRepresentation__ =
            () => subject.Collection.ShouldBeOfType<CollectionRepresentation<FakeEntityIntId>>();

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
        "CollectionJsonWriter for a collection of FakeEntityWithAttributePrimaryKey with 1 item")]
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

                UrlInfos =
                     SingletonUrlInfoCollection.GetInstance()
                     .Find(typeof(FakeEntityWithAttributePrimaryKey));
            };

        static CollectionJsonWriter<FakeEntityWithAttributePrimaryKey> subject;
        Because of =
            () =>
            {
                subject =
                    new CollectionJsonWriter<FakeEntityWithAttributePrimaryKey>(
                        new FakeEntityWithAttributePrimaryKey
                        {
                            PrimaryKey = "ThePrimaryKey",
                            SomeString = "some string"
                        }, SerializerSettings);

            };

        It should_foo = () => UrlInfos.Count().ShouldBeGreaterThan(0);

        It should_foo2 = () => UrlInfos.Count().ShouldEqual(2);

        It the_Collection_Items_0_Href_Property_be__some_path_ThePrimaryKey__ =
            () => subject.Collection.Items.ToList()[0].Href.ShouldEqual("some/path/ThePrimaryKey");

    }

    [Subject(typeof(CollectionJsonWriter<>),
        "CollectionJsonWriter for a collection of FakeEntityWithDenormalizedReference with 1 item")]
    public class
        When_the_CollectionJsonWriter_is_envoked_with_1_FakeEntityWithDenormalizedReference_with_ComversionMethod_Entity
        : CollectionJsonWriterContext
    {
        Establish context =
            () =>
            {
                UrlInfos =
                    SingletonFactory<UrlInfoCollection>.Instance
                        .Find(typeof(FakeEntityWithDenormalizedReference));

                SerializerSettings =
                    new CollectionJsonSerializerSettings
                    {
                        ConversionMethod = ConversionMethod.Entity
                    };
            };

        static CollectionJsonWriter<FakeEntityWithDenormalizedReference> Subject;

        Because of =
            () =>
            {

                var fakeRef =
                    new FakeReferenceEntity
                    {
                        Id = 99,
                        Name = "fakeref",
                        SomeOtherProperty = "other prop"
                    };

                Subject =
                    new CollectionJsonWriter<FakeEntityWithDenormalizedReference>(
                        new FakeEntityWithDenormalizedReference
                        {
                            Id = 1,
                            Reference = fakeRef,
                            SomeProperty = "bam"
                        }, SerializerSettings);
            };

        It should_the_items_not_be_null =
            () => Subject.Collection.Items.ToList()[0].ShouldNotBeNull();
        It should_the_first_item_entities_reference_be_of_type__D__ =
            () => Subject.Collection.Items.ToList()[0]
                .Entity.Reference.ShouldBeOfType(typeof(DenormalizedReference<FakeReferenceEntity>));
        It should_the_first_item_entities_references_name_be__fakeref__ =
            () => Subject.Collection.Items.ToList()[0]
                .Entity.Reference.Name.ShouldEqual("fakeref");

        It should_the_first_item_entities_reference_path_be__some_path_99__ =
            () => Subject.Collection.Items.ToList()[0]
                .Links.ToList()[0].Href.ShouldEqual("some/path/99");
    }

    [Subject(typeof(CollectionJsonWriter<>),
        "CollectionJsonWriter for a collection of FakeEntityWithDerivedDenormalizedReference with 1 item")]
    public class
        When_the_CollectionJsonWriter_is_envoked_with_1_FakeEntityWithDerivedDenormalizedReference_with_ComversionMethod_Entity
        : CollectionJsonWriterContext
    {
        Establish context =
            () =>
            {
                UrlInfos =
                    SingletonFactory<UrlInfoCollection>.Instance
                        .Find(typeof(FakeEntityWithDerivedDenormalizedReference));

                SerializerSettings =
                    new CollectionJsonSerializerSettings
                    {
                        ConversionMethod = ConversionMethod.Entity
                    };
            };

        static CollectionJsonWriter<FakeEntityWithDerivedDenormalizedReference> Subject;

        Because of =
            () =>
            {

                var fakeRef =
                    new FakeReferenceEntity
                    {
                        Id = 55,
                        Name = "fakeref",
                        SomeProperty = "prop ref",
                        SomeOtherProperty = "other prop ref"
                    };

                Subject =
                    new CollectionJsonWriter<FakeEntityWithDerivedDenormalizedReference>(
                        new FakeEntityWithDerivedDenormalizedReference
                        {
                            Id = 1,
                            Reference = fakeRef,
                            SomeProperty = "bam"
                        }, SerializerSettings);
            };

        It should_foo =
            () => Subject.Collection.Items.ToList()[0].ShouldNotBeNull();
        It should_foo2 =
            () => Subject.Collection.Items.ToList()[0]
                .Entity.Reference.ShouldBeOfType(typeof(DenormalizedReference<FakeReferenceEntity>));
        
        It should_foo22 =
            () => Subject.Collection.Items.ToList()[0]
                .Entity.Reference.ShouldBeOfType(typeof(DenormalizedFakeReferenceEntity));
        
        It should_foo3 =
            () => Subject.Collection.Items.ToList()[0]
                .Entity.Reference.Name.ShouldEqual("fakeref");

        It should_foo33 =
            () => Subject.Collection.Items.ToList()[0]
                .Entity.Reference.SomeProperty.ShouldEqual("prop ref");

        It should_the_first_item_entities_reference_path_be__some_path_55__ =
            () => Subject.Collection.Items.ToList()[0]
                .Links.ToList()[0].Href.ShouldEqual("some/path/55");
    }

}
