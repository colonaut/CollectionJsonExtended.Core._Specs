using System;
using System.Collections.Generic;
using System.Reflection;

namespace CollectionJsonExtended.Core._Specs
{

    public class FakeController
    {
        public string FakeMethodWithParam(int fakeId, string fakeString)
        {
            return "returns FakeMethodWithParam";
        }

        public string FakeMethod()
        {
            return "returns FakeMethod";
        }
    }
    
    
    public class FakeUrlInfo : UrlInfoProvider
    {
        public FakeUrlInfo(Type entityType)
            : base(entityType)
        {
        }

        public static IEnumerable<FakeUrlInfo> Find(Type entityType)
        {
            var fakeControllerType = new FakeController().GetType();
            var list = new List<FakeUrlInfo>();
            list.Add(new FakeUrlInfo(typeof(FakeIntIdEntity))
            {
                Params = fakeControllerType.GetMethod("FakeMethod").GetParameters(),
                Kind = Is.Base,
                //Relation = "fakeMethod",
                VirtualPath = "some/route"
            });

            list.Add(new FakeUrlInfo(typeof(FakeIntIdEntity))
            {
                Params = fakeControllerType.GetMethod("FakeMethodWithParam").GetParameters(),
                Kind = Is.Item,
                //Relation = "fakeMethodWithParam",
                VirtualPath = "some/route/{fakeId}/{fakeString}"
            });

            list.Add(new FakeUrlInfo(typeof(FakeIntIdEntity))
            {
                Params = fakeControllerType.GetMethod("FakeMethod").GetParameters(),
                Kind = Is.Query,
                Relation = "fakeMethod",
                VirtualPath = "some/route"
            });
            return list;
        }

    }
    
}