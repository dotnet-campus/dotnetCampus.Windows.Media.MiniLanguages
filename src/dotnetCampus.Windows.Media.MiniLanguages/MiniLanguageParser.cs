using System;
using System.Collections.Generic;

using dotnetCampus.Windows.Media.MiniLanguages.Syntax;
using dotnetCampus.Windows.Media.MiniLanguages.Visitors;

namespace dotnetCampus.Windows.Media.MiniLanguages
{
    public static class MiniLanguageParser
    {
        private static readonly Dictionary<char, PathSyntax> SegmentParsers = new()
        {
            { 'F', new FSyntax() },
            { 'f', new FSyntax() },
            { 'M', new MSyntax() },
            { 'm', new MSyntax() },
            { 'L', new LSyntax() },
            { 'l', new LSyntax() },
            { 'H', new HSyntax() },
            { 'h', new HSyntax() },
            { 'V', new VSyntax() },
            { 'v', new VSyntax() },
            { 'C', new CSyntax() },
            { 'c', new CSyntax() },
            { 'Q', new QSyntax() },
            { 'q', new QSyntax() },
            { 'S', new SSyntax() },
            { 's', new SSyntax() },
            { 'T', new TSyntax() },
            { 't', new TSyntax() },
            { 'A', new ASyntax() },
            { 'a', new ASyntax() },
            { 'Z', new ZSyntax() },
            { 'z', new ZSyntax() },
        };

        public static void Visit(string pathData, IPathSyntaxVisitor visitor)
        {
            if (visitor is null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            var context = new CommandContext(pathData);
            PathSyntax currentParser = null;
            visitor.Start(in context);

            for (var i = 0; i < pathData.Length;)
            {
                var c = pathData[i];
                context.StartIndex = i;
                context.Length = 0;

                if (SegmentParsers.TryGetValue(c, out var parser))
                {
                    currentParser = parser;

                    // 具有明确命令的语法。
                    i++;
                    context.Command = c;
                    parser.Parse(ref context, ref i, visitor);
                }
                else if (PathSyntax.IsNumberChar(c))
                {
                    // 没有命令的语法，重复上一次的语法。
                    currentParser?.Parse(ref context, ref i, visitor);
                }
                else
                {
                    // 上一命令已结束下一命令尚未开始时，遇到了非重要字符（如 ' ' ',' '\r' '\n'）。
                    i++;
                }
            }

            visitor.Complete();
        }
    }
}
