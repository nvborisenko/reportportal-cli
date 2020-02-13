using System.CommandLine.Rendering;

namespace ReportPortal.Cli.Formatters
{
    static class ConsoleFormatExtensions
    {
        public static Span Underline(this string value)
        {
            return new ContainerSpan(StyleSpan.UnderlinedOn(),
                              new ContentSpan(value),
                              StyleSpan.UnderlinedOff());
        }
    }
}
