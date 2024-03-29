﻿using dotnetCampus.Windows.Media.MiniLanguages.Visitors;

namespace dotnetCampus.Windows.Media.MiniLanguages.Syntax
{
    internal sealed class VSyntax : PathSyntax
    {
        protected internal override void Parse(ref CommandContext context, ref int parsingIndex, IPathSyntaxVisitor visitor)
        {
            var originalText = context.OriginalText;
            var y = ReadDouble(originalText, ref parsingIndex);
            context.Length = parsingIndex - context.StartIndex;
            visitor.V(in context, y);
        }
    }
}
