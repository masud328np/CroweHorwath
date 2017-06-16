using System;

namespace CroweHorwath.Api
{
    public interface IWriterFactory
    {
        IWriter GetWriter(string writerName);
    }
}