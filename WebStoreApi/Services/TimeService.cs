namespace WebStoreApi.Services
{
    public class TimeService
    {
        public string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public string GetTime()
        {
            return DateTime.Now.ToString("h:mm:ss tt");
        }
    }
}
