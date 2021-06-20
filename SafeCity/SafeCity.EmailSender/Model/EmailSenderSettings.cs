namespace SafeCity.EmailSender.Model
{
    public class EmailSenderSettings
    {
        public SenderData SenderData { get; set; }
        public SmptServerData SmptServerData { get; set; }
        public Credentials Credentials { get; set; }
    }
}