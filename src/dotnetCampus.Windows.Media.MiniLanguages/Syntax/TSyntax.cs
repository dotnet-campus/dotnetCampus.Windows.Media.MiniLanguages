using dotnetCampus.Windows.Media.MiniLanguages.Visitors;

namespace dotnetCampus.Windows.Media.MiniLanguages.Syntax
{
    internal sealed class TSyntax : PathSyntax
    {
        protected internal override void Parse(ref CommandContext context, ref int parsingIndex, IPathSyntaxVisitor visitor)
        {
            var originalText = context.OriginalText;
            var endPoint = ReadPoint(originalText, ref parsingIndex);
            context.Length = parsingIndex - context.StartIndex;
            visitor.T(in context, endPoint);
        }
    }
}
