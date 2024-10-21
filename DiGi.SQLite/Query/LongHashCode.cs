namespace DiGi.SQLite
{
    public static partial class Query
    {

        public static long LongHashCode(string @string)
        {
            if(@string == null)
            {
                return -1;
            }

            long result = 0;
            foreach (char c in @string)
            {
                result = (result * 31) + c;
            }
            return result;
        }
    }
}
