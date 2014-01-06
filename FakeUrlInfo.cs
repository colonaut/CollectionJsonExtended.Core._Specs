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
        private static readonly List<FakeUrlInfo> TestCollectionOfUrlInfo;

        static FakeUrlInfo()
        {
            var fakeControllerType = new FakeController().GetType();

            TestCollectionOfUrlInfo =
                new List<FakeUrlInfo>
                {
                    new FakeUrlInfo(typeof (FakeIntIdEntity))
                    {
                        Params =
                            fakeControllerType.GetMethod("FakeMethod")
                            .GetParameters(),
                        Kind = Is.Base,
                        //Relation = "fakeMethod",
                        VirtualPath = "some/path"
                    },

                    new FakeUrlInfo(typeof (FakeIntIdEntity))
                    {
                        Params =
                            fakeControllerType.GetMethod(
                                "FakeMethodWithIntIdParam").GetParameters(),
                        Kind = Is.Item,
                        //Relation = "fakeMethodWithParam",
                        VirtualPath = "some/path/{fakeId}"
                    },

                    //this one is double and makes everthing crash! better test for this in extension
                    //    new FakeUrlInfo(typeof (FakeIntIdEntity))
                    //    {
                    //        Params =
                    //            fakeControllerType.GetMethod(
                    //                "FakeMethodWithIntIdParam").GetParameters(),
                    //        Kind = Is.Item,
                    //        //Relation = "fakeMethodWithParam",
                    //        VirtualPath = "some/path/{fakeId}"
                    //    },

                    new FakeUrlInfo(typeof (FakeIntIdEntity))
                    {
                        Params =
                            fakeControllerType.GetMethod("FakeMethod")
                            .GetParameters(),
                        Kind = Is.Query,
                        Relation = "fakeMethod",
                        VirtualPath = "some/path"
                    },

                    new FakeUrlInfo(typeof (FakeStringIdEntity))
                    {
                        Params =
                            fakeControllerType.GetMethod("FakeMethodWithStringIdParam")
                            .GetParameters(),
                        Kind = Is.Item,
                        //Relation = "fakeMethod",
                        VirtualPath = "some/path/{fakeStringId}"
                    },

                    new FakeUrlInfo(typeof (FakeAttributePrimaryKeyEntity))
                    {
                        Params =
                            fakeControllerType.GetMethod("FakeMethodWithStringIdParam")
                            .GetParameters(),
                        Kind = Is.Base,
                        //Relation = "fakeMethodWithParam",
                        VirtualPath = "some/path"
                    },

                    new FakeUrlInfo(typeof (FakeAttributePrimaryKeyEntity))
                    {
                        Params =
                            fakeControllerType.GetMethod("FakeMethodWithStringIdParam")
                            .GetParameters(),
                        Kind = Is.Item,
                        //Relation = "fakeMethodWithParam",
                        VirtualPath = "some/path/{fakeStringId}"
                    }
                };
        }

        public FakeUrlInfo(Type entityType)
            : base(entityType)
        {
        }

        public static void AddFakeData()
        {
            foreach (var fakeUrlInfo in TestCollectionOfUrlInfo)
                fakeUrlInfo.Publish();
        }
       
    }

}