namespace CroweHorwath.Api
{
    public class WritingService : IWritingService
    {
        ISettings _settings;

        const string WRITER_KEY = "writer";

        public WritingService(ISettings settings)
        {
            _settings = settings;
        }

        public void RequestToWrite(string txt)
        {
            var writerName = _settings.GetValueByKey(WRITER_KEY);
            
        }
    }
}
