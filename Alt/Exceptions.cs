﻿using System;
using System.Text;

namespace Alt
{
    public abstract class SchyntaxException : Exception
    {
        protected SchyntaxException(string message) : base(message) { }
    }

    public sealed class SchyntaxParseException : SchyntaxException
    {
        internal SchyntaxParseException(string message, string input, int index) : base (message + "\n\n" + GetPointerToIndex(input, index))
        {
            Data["Index"] = index;
            Data["Input"] = input;
        }

        internal static string GetPointerToIndex(string input, int index)
        {
            var start = Math.Max(0, index - 20);
            var length = Math.Min(input.Length - start, 50);

            StringBuilder sb = new StringBuilder(73);
            sb.Append(input.Substring(start, length));
            sb.Append("\n");

            for (var i = start; i < index; i++)
                sb.Append(' ');

            sb.Append('^');
            return sb.ToString();
        }
    }

    public sealed class InvalidScheduleException : SchyntaxException
    {
        internal InvalidScheduleException(string message, string input) : base (message)
        {
            Data["Input"] = input;
        }
    }
}