namespace SocialNetwork.Data
{
    using System.Text;

    public static class TagTransformer
    {
        public static string Transform(string tag)
        {
            var sb = new StringBuilder();
            var tagChars = tag.ToCharArray();

            if (!tag.StartsWith('#'))
            {
                sb.Append('#');
            }

            var length = tagChars.Length < 20 ? tagChars.Length : 20;

            for (int i = 0; i < length; i++)
            {
                var ch = tag[i];

                if (ch != ' ')
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }         
    }
}