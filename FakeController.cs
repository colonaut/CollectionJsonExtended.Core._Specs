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
}