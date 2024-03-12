using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Project.Proxy
{
    public static class Extenstion
    {
        public static string ConvertStringToSlug(string name, int id)
        {
            var slug = "";
            try
            {
                Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
                 slug = $"{name}-{id}".Normalize(NormalizationForm.FormD).Trim().ToLower();

                slug = regex.Replace(slug, String.Empty)
                  .Replace('\u0111', 'd').Replace('\u0110', 'D')
                  .Replace(",", "-").Replace(".", "-").Replace("!", "")
                  .Replace("(", "").Replace(")", "").Replace(";", "-")
                  .Replace("/", "-").Replace("%", "ptram").Replace("&", "va")
                  .Replace("?", "").Replace('"', '-').Replace(' ', '-');


            }
            catch(Exception e)
            {
                slug = "";
            }
            return slug;
        }
    }
}
