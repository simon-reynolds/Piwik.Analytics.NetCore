namespace Piwik.NETCore.Analytics.Parameters
{
    internal class IdParameter : Parameter
    {
        private readonly int _value;
        public IdParameter(int value)
            : base("idSite")
        {
            _value = value;
        }

        public override string Serialize()
        {
            var parameter = string.Empty;

            if (!(_value == default(int)))
            {
                parameter = "&" + Name + "=" + UrlEncode(_value.ToString());
            }

            return parameter;
        }
    }
}