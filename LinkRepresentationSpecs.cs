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
            new FakeUrlInfo(typeof (FakeIntIdEntity))
            {
                Kind = Is.LinkForBase,
                Relation = "relates to whatever",
                Render = "image",
                VirtualPath = "some/path"
            };

        static string _subject;

        Because of = () => _subject =
            new LinkRepresentation<FakeIntIdEntity>(UrlInfo, SerializerSettings).Serialize();

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
            new FakeUrlInfo(typeof(FakeIntIdEntity))
            {
                Kind = Is.LinkForBase,
                Relation = "relates to whatever",
                Render = "image",
                VirtualPath = "some/path/{id}",
                PrimaryKeyTemplate = "{id}",
                PrimaryKeyProperty = typeof(FakeIntIdEntity).GetProperty("Id")
            };

        private static readonly FakeIntIdEntity _entity
            = new FakeIntIdEntity {Id = 586};

        static string _subject;

        Because of = () => _subject =
            new LinkRepresentation<FakeIntIdEntity>(_entity, UrlInfo, SerializerSettings).Serialize();

        It should_the_json_representation_be_serialized_for_the_item =
            () => _subject.ShouldEqual(
                "{" +
                    "\"rel\":\"relates to whatever\"" +
                    ",\"href\":\"some/path/586\"" +
                    ",\"render\":\"image\"" +
                "}");
    }
}
