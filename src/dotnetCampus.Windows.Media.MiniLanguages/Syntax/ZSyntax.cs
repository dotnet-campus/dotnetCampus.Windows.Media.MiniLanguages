using dotnetCampus.Windows.Media.MiniLanguages.Visitors;

namespace dotnetCampus.Windows.Media.MiniLanguages.Syntax
{
    internal sealed class ZSyntax : PathSyntax
    {
        protected internal override void Parse(ref CommandContext context, ref int parsingIndex, IPathSyntaxVisitor visitor)
        {
            context.Length = 1;
            visitor.Z(in context);
        }
    }
}
