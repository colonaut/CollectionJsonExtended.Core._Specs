using System.Linq;
using System.Reflection;
using CollectionJsonExtended.Core.Extensions;
using Machine.Specifications;

namespace CollectionJsonExtended.Core._Specs
{

    internal abstract class LinkRepresentationContext
    {
        protected static readonly CollectionJsonSerializerSettings SerializerSettings =
            new CollectionJsonSerializerSettings();
    }

    [Subject(typeof(LinkRepresentation<>), "Serialize link representaion")]
    internal class When_the_link_representaion_is_serialized_for_base
        : LinkRepresentationContext
    {
        static readonly UrlInfoBase UrlInfo =
            new FakeUrlInfo(typeof (FakeEntityIntId))
            {
                Kind = Is.BaseLink,
                Relation = "relates to whatever",
                Render = "image",
                VirtualPath = "some/path"
            };

        static string _subject;

        Because of = () => _subject =
            new LinkRepresentation<FakeEntityIntId>(UrlInfo, SerializerSettings).Serialize();

        It should_the_json_representation_have___ =
            () =>
           _subject.ShouldEqual(
                       "{" +
                            "\"rel\":\"relates to whatever\"" +
                            ",\"href\":\"some/path\"" +
                            ",\"render\":\"image\"" +
                       "}");
    }

    [Subject(typeof(LinkRepresentation<>), "Serialize link representaion")]
    internal class When_the_link_representaion_is_serialized_for_item
        : LinkRepresentationContext
    {
        static readonly UrlInfoBase UrlInfo =
            new FakeUrlInfo(typeof(FakeEntityIntId))
            {
                Kind = Is.BaseLink,
                Relation = "relates to whatever",
                Render = "image",
                VirtualPath = "some/path/{id}",
                PrimaryKeyTemplate = "{id}",
                PrimaryKeyProperty = typeof(FakeEntityIntId).GetProperty("Id")
            };

        private static readonly FakeEntityIntId _entity
            = new FakeEntityIntId {Id = 586};

        static string _subject;

        Because of = () => _subject =
            new LinkRepresentation<FakeEntityIntId>(_entity, UrlInfo, SerializerSettings).Serialize();

        It should_the_json_representation_be_serialized_for_the_item =
            () => _subject.ShouldEqual(
                "{" +
                    "\"rel\":\"relates to whatever\"" +
                    ",\"href\":\"some/path/586\"" +
                    ",\"render\":\"image\"" +
                "}");
    }

}
