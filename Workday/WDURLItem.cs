namespace ERPHelper
{
    class WDURLItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public WDURLItem(string key, string value)
        {
            Key = key; Value = value;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
