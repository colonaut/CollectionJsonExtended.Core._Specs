using CollectionJsonExtended.Core.Attributes;

namespace CollectionJsonExtended.Core._Specs
{
    public class FakeEntityIntId
    {
        public int Id { get; set; }
        public string SomeString { get; set; }
    }

    public class FakeEntityWithStringId
    {
        public string Id { get; set; }
        public string SomeString { get; set; }
    }

    public class FakeEntityWithAttributePrimaryKey
    {
        [CollectionJsonProperty(IsPrimaryKey = true)]
        public string PrimaryKey { get; set; }
        public string SomeString { get; set; }
    }

    //TODO Test item: must be serialized, template: may NOT be serialized
    public class FakeEntityWithPropertyAccessRestrictions
    {
        readonly int _readonlyInt;

        public FakeEntityWithPropertyAccessRestrictions() //TODO constructor needs paramless here. we should try to get rid of the new() restriction in all the TEntity Generics
        {

        }

        public FakeEntityWithPropertyAccessRestrictions(int readonlyInt)
        {
            PrivateSetterInt = 10;
            _readonlyInt = readonlyInt;
        }
        
        public int PrivateSetterInt { get; private set; }
        
        public int ReadonlyInt
        {
            get { return _readonlyInt; }            
        }
        
        public int ReadonlyIntGetterOnly {
            get { return 30; }
        }
        public int PublicInt { get; set; }

        public FakeEntityWithPrivateSetterString FakeEntityWithPrivateSetterString { get; set; }
    }

    public class FakeEntityWithPrivateSetterString
    {
        public FakeEntityWithPrivateSetterString()
        {
            PrivateSetterString = "some private string";
        }

        public string PrivateSetterString { get; private set; }
        public string PublicString { get; set; }
    }

    //TODO we should ensure, that if an entity contains another entity, it should be rendered as query link for the item (we try to find a urlinfo for the entity). How to deal with templates then? should we get a list then? it's probably bad design to have another entity in an entity...
    public class FakeEntityWithReadonlyGuiId
    {
        
    }
}