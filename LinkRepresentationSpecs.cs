using Machine.Specifications;

namespace CollectionJsonExtended.Core._Specs
{
    
    [Subject(typeof(CollectionJsonWriter<>), "Serialize link representaion")]
    public class When_the_link_representaion_is_serialized
    {
        static string subject;

        private Because of = () => subject = CollectionJsonWriter<FakeComplexModelWithListOfStrings>.Serialize(new LinkRepresentation());

        private It should_the_json_representation_have_rel__rss__href_null_render__href__ =
            () =>
           subject.ShouldEqual(
                       "{" +
                            "\"rel\":\"rss\"," +
                            "\"href\":null," +
                            "\"render\":\"href\"" +
                       "}");
    }

}
