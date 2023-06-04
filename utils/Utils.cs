namespace LMS.Utils
{
    class IdGenerator
    {
        private static int counter = 0;
        public static int GenerateUniqueId()
        {
            // int uniqueId = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            // uniqueId = uniqueId * 1000 + counter;
            int currentSeconds = (int) DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            int uniqueId = currentSeconds + counter;
            counter++;
            return uniqueId;
        }
    }


}