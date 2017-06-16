namespace CroweHorwath.Api
{
    public class WritingService : IWritingService
    {
        ISettings _settings;
        IWriterFactory _factory;

        const string WRITER_KEY = "writer";

        public WritingService() : this(new ApiSettings(), new WriterFactory())
        {
        }
        public WritingService(ISettings settings, IWriterFactory factory)
        {
            _settings = settings;
            _factory = factory;
        }

        public void RequestToWrite(string txt)
        {
            var writerName = _settings.GetValueByKey(WRITER_KEY);
            var writer = _factory.GetWriter(writerName);
            writer.Write(txt);
        }
    }
}
