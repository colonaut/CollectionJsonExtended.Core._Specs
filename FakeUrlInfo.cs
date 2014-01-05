using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CollectionJsonExtended.Core._Specs
{

    public class FakeController
    {
        public string FakeMethodWithIntIdParam(int fakeIntId)
        {
            return "returns FakeMethodWithIntIdParam";
        }

        public string FakeMethodWithStringIdParam(string fakeStringId)
        {
            return "returns FakeMethodWithStringIdParam";
        }

        public string FakeMethod()
        {
            return "returns FakeMethod";
        }
    }


    public class FakeUrlInfo : UrlInfoBase
    {
        public FakeUrlInfo(Type entityType)
            : base(entityType)
        {
        }

        public static IEnumerable<FakeUrlInfo> Find(Type entityType)
        {
            return Cache.Where(c => c.EntityType == entityType) as IEnumerable<FakeUrlInfo>;

        }

        public static void BuildCache()
        {
            var fakeControllerType = new FakeController().GetType();

            new FakeUrlInfo(typeof (FakeIntIdEntity))
            {
                Params =
                    fakeControllerType.GetMethod("FakeMethod")
                    .GetParameters(),
                Kind = Is.Base,
                //Relation = "fakeMethod",
                VirtualPath = "some/path"
            }.Publish();

            new FakeUrlInfo(typeof (FakeIntIdEntity))
            {
                Params =
                    fakeControllerType.GetMethod(
                        "FakeMethodWithIntIdParam").GetParameters(),
                Kind = Is.Item,
                //Relation = "fakeMethodWithParam",
                VirtualPath = "some/path/{fakeId}"
            }.Publish();

            //this one is double and makes everthing crash! better test for this in extension
            //    new FakeUrlInfo(typeof (FakeIntIdEntity))
            //    {
            //        Params =
            //            fakeControllerType.GetMethod(
            //                "FakeMethodWithIntIdParam").GetParameters(),
            //        Kind = Is.Item,
            //        //Relation = "fakeMethodWithParam",
            //        VirtualPath = "some/path/{fakeId}"
            //    }.Publish;

            new FakeUrlInfo(typeof (FakeIntIdEntity))
            {
                Params =
                    fakeControllerType.GetMethod("FakeMethod")
                    .GetParameters(),
                Kind = Is.Query,
                Relation = "fakeMethod",
                VirtualPath = "some/path"
            }.Publish();

            new FakeUrlInfo(typeof (FakeStringIdEntity))
            {
                Params = fakeControllerType.GetMethod("FakeMethodWithStringIdParam").GetParameters(),
                Kind = Is.Item,
                //Relation = "fakeMethod",
                VirtualPath = "some/path/{fakeStringId}"
            }.Publish();

            new FakeUrlInfo(typeof (FakeAttributePrimaryKeyEntity))
            {
                Params = fakeControllerType.GetMethod("FakeMethodWithStringIdParam").GetParameters(),
                Kind = Is.Item,
                //Relation = "fakeMethodWithParam",
                VirtualPath = "some/path/{fakeId}/{fakeString}"
            }.Publish();
        }

        public static void ClearCache()
        {
            Cache.Clear();
            EntityUrlInfoBaseCache.Clear();
        }
    }

}