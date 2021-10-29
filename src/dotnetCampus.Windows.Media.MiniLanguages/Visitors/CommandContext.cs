using System;

namespace dotnetCampus.Windows.Media.MiniLanguages.Visitors
{
    public ref struct CommandContext
    {
        public CommandContext(string originalText) : this()
        {
            OriginalText = originalText ?? throw new ArgumentNullException(nameof(originalText));
        }

        public string OriginalText { get; }

        public int StartIndex { get; internal set; }

        public int Length { get; internal set; }

        public char Command { get; internal set; }
    }
}
