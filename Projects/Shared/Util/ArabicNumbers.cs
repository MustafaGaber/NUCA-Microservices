namespace NUCA.Projects.Shared.Util
{
    public static class ArabicNumbers
    {
        public static string UseArabicDigits(this double number)
        {
            return ReplaceDigits(number.ToString());
        }

        public static string UseArabicDigits(this int number)
        {
            return ReplaceDigits(number.ToString());
        }

        public static string UseArabicDigits(this string value)
        {
            return ReplaceDigits(value);
        }

        private static string ReplaceDigits(string value)
        {
            return value.Replace('0', '\u0660')
                .Replace('1', '\u0661')
                .Replace('2', '\u0662')
                .Replace('3', '\u0663')
                .Replace('4', '\u0664')
                .Replace('5', '\u0665')
                .Replace('6', '\u0666')
                .Replace('7', '\u0667')
                .Replace('8', '\u0668')
                .Replace('9', '\u0669');
        }
    }
}
