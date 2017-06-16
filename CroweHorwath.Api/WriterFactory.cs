namespace CroweHorwath.Api
{
    public class WriterFactory : IWriterFactory
    {
        public IWriter GetWriter(string writerName)
        {
            if (writerName == "db")
            {
                return new DatabaseWriter();
            }
            return new ConsoleWriter();

        }
    }
}
