namespace LMS.Utils
{
    class IdGenerator
    {
        private static int counter = 0;
        public static int GenerateUniqueId()
        {
            int currentSeconds = (int) DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            int uniqueId = currentSeconds + counter;
            counter++;
            return uniqueId;
        }
    }


}