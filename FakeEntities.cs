using CollectionJsonExtended.Core.Attributes;

namespace CollectionJsonExtended.Core._Specs
{
    public class FakeIntIdEntity
    {
        public int Id { get; set; }
        public string SomeString { get; set; }
    }

    public class FakeStringIdEntity
    {
        public string Id { get; set; }
        public string SomeString { get; set; }
    }

    public class FakeAttributePrimaryKeyEntity
    {
        [CollectionJsonProperty(IsPrimaryKey = true)]
        public string PrimaryKey { get; set; }
        public string SomeString { get; set; }
    }
}