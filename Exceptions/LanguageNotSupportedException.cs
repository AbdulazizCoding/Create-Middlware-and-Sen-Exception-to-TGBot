namespace Middlware.Exceptions;

public class LanguageNotSupportedException : Exception
{
    public LanguageNotSupportedException() : base("Only `uz`, `en` supported!"){}
}