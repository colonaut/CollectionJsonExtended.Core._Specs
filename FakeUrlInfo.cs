using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CollectionJsonExtended.Core.Attributes;

namespace CollectionJsonExtended.Core._Specs
{
    public class FakeUrlInfo : UrlInfoBase
    {
        static readonly List<FakeUrlInfo> TestCollectionData;

        static FakeUrlInfo()
        {
            var fakeControllerType = new FakeController().GetType();

            TestCollectionData =
                new List<FakeUrlInfo>
                {
                    new FakeUrlInfo(typeof (FakeEntityIntId))
                    {
                        Kind = Is.Base,
                        //Relation = "fakeMethod",
                        VirtualPath = "some/path"
                    },

                    new FakeUrlInfo(typeof (FakeEntityIntId))
                    {
                        PrimaryKeyProperty = typeof (FakeEntityIntId).GetProperty("Id", BindingFlags.Instance
                                                                                        | BindingFlags.IgnoreCase
                                                                                        | BindingFlags.Public),
                        PrimaryKeyTemplate = "{fakeId}",
                        Kind = Is.Item,
                        //Relation = "fakeMethodWithParam",
                        VirtualPath = "some/path/{fakeId}"
                    },

                    //this one is double and makes everthing crash! better test for this in extension
                    //    new FakeUrlInfo(typeof (FakeEntityIntId))
                    //    {
                    //        PrimaryKeyProperty = typeof (FakeEntityIntId).GetProperty("Id", BindingFlags.Instance
                    //              | BindingFlags.IgnoreCase
                    //              | BindingFlags.Public),
                    //        PrimaryKeyTemplate = "{fakeId}",
                    //        Kind = Is.Item,
                    //        //Relation = "fakeMethodWithParam",
                    //        VirtualPath = "some/path/{fakeId}"
                    //    },

                    new FakeUrlInfo(typeof (FakeEntityIntId))
                    {
                        Kind = Is.Query,
                        Relation = "fakeMethod",
                        VirtualPath = "some/path"
                    },

                    new FakeUrlInfo(typeof (FakeEntityWithStringId))
                    {
                        PrimaryKeyProperty = typeof (FakeEntityWithStringId).GetProperty("Id", BindingFlags.Instance
                                                                                               | BindingFlags.IgnoreCase
                                                                                               | BindingFlags.Public),
                        PrimaryKeyTemplate = "{fakeStringId}",
                        Kind = Is.Item,
                        //Relation = "fakeMethod",
                        VirtualPath = "some/path/{fakeStringId}"
                    },

                    new FakeUrlInfo(typeof (FakeEntityWithAttributePrimaryKey))
                    {
                        Kind = Is.Base,
                        //Relation = "fakeMethodWithParam",
                        VirtualPath = "some/path"
                    },

                    new FakeUrlInfo(typeof (FakeEntityWithAttributePrimaryKey))
                    {
                        PrimaryKeyProperty = typeof (FakeEntityWithAttributePrimaryKey).GetProperties()
                            .SingleOrDefault(p =>
                                             {
                                                 var a =
                                                     CustomAttributeExtensions
                                                         .GetCustomAttribute<CollectionJsonPropertyAttribute>(
                                                             (MemberInfo) p);
                                                 return a != null && a.IsPrimaryKey;
                                             }),
                        PrimaryKeyTemplate = "{fakeStringId}",
                        Kind = Is.Item,
                        //Relation = "fakeMethodWithParam",
                        VirtualPath = "some/path/{fakeStringId}"
                    },

                    new FakeUrlInfo(typeof (FakeReferenceEntity))
                    {
                        PrimaryKeyProperty = typeof (FakeReferenceEntity).GetProperty("Id", BindingFlags.Instance
                                                                                            | BindingFlags.IgnoreCase
                                                                                            | BindingFlags.Public),
                        PrimaryKeyTemplate = "{fakeReferenceId}",
                        Kind = Is.Item,
                        VirtualPath = "some/path/{fakeReferenceId}"
                    },

                };
        }


        public FakeUrlInfo(Type entityType)
            : base(entityType)
        {
        }

       
        public static void AddFakeData(UrlInfoCollection urlInfoCollectionInstance)
        {
            foreach (var fakeUrlInfo in TestCollectionData.ToList())
                urlInfoCollectionInstance.Add(fakeUrlInfo);
        }
    }
}