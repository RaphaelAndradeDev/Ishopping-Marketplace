using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Domain.Communs
{
    public static class IsTags
    {
        public static string Join(string tags)
        {
            if (string.IsNullOrEmpty(tags))
                return tags;

            var tag = Trim(tags.Split(',')).ToList();
            var tagFormat = tag.FindAll(x => x.Length > 2 && x.Length <= 16).Distinct();

            return "," + String.Join(",", tagFormat) + ",";
        }

        public static string Format(string tags)
        {
            if (string.IsNullOrEmpty(tags))
                return tags;

            return tags.Trim(',').Replace(",", ", ");
        }

        public static IEnumerable<string> Split(string tags)
        {
            if (string.IsNullOrEmpty(tags))
                return new List<string>();

            return tags.Trim(',').Split(',');
        }

        private static IEnumerable<string> Trim(IEnumerable<string> tag)
        {
            foreach (var item in tag)
            {
                yield return item.Trim();
            }
        }
    }

    public static class IsHtmlTags
    {
        public static string SetTags(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return text
                .Replace("[span]", "<span>")
                .Replace("[/span]", "</span>")
                .Replace("[i]", "<i>")
                .Replace("[/i]", "</i>")
                .Replace("[b]", "<b>")
                .Replace("[/b]", "</b>")
                .Replace("[u]", "<u>")
                .Replace("[/u]", "</u>")
                .Replace("[del]", "<del>")
                .Replace("[/del]", "</del>")
                .Replace("[br/]", "<br/>");
        }

        public static string GetTags(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return text
                .Replace("<span>", "[span]")
                .Replace("</span>", "[/span]")
                .Replace("<i>", "[i]")
                .Replace("</i>", "[/i]")
                .Replace("<b>", "[b]")
                .Replace("</b>", "[/b]")
                .Replace("<u>", "[u]")
                .Replace("</u>", "[/u]")
                .Replace("<del>", "[del]")
                .Replace("</del>", "[/del]")
                .Replace("<br/>", "[br/]");
        }

        public static string RemoveTags(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if(text.Length >= 64)
            {
                text = text.Substring(0, 64);
            }

            return text
                .Replace("[span]", "")
                .Replace("[/span]", "")
                .Replace("[li]", "")
                .Replace("[/li]", "")
                .Replace("[i]", "")
                .Replace("[/i]", "")
                .Replace("[b]", "")
                .Replace("[/b]", "")
                .Replace("[u]", "")
                .Replace("[/u]", "")
                .Replace("[del]", "")
                .Replace("[/del]", "")
                .Replace("[br/]", "");
        }
    }   
}
