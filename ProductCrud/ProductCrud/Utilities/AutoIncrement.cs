namespace ProductCrud.Utilities
{
    public class AutoIncrement
    {
        private static int _id = 1;

        public static int IncrementId()
        {
            return _id++;
        }
    }
}
