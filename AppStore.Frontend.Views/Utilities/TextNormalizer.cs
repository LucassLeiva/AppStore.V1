namespace AppStore.Frontend.Views.Utilities
{

    public static class TextNormalizer
    {

        public static string NullToEmpty(string? value)
            => value ?? "";

        //quitar espacios al inicio/final
        public static string TrimAndCollapseSpaces(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return "";
            var trimmed = value.Trim();
            // colapsa espacios múltiples
            return System.Text.RegularExpressions.Regex.Replace(trimmed, @"\s+", " ");
        }

        //Capitalizar palabras para nombres
        public static string CapitalizeFirstLetter(string? value)
        {
            var v = TrimAndCollapseSpaces(value);
            if (v.Length == 0) return "";

            return char.ToUpper(v[0]) + v.Substring(1);
        }

        //Capitalizar primer palabra y el resto en minuscula.
        public static string CapitalizeWords(string? value)
        {
            var v = TrimAndCollapseSpaces(value);
            if (v.Length == 0) return "";

            var words = v.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                var w = words[i];
                if (w.Length == 0) continue;

                // Primera en mayúscula, resto en minúscula
                words[i] = char.ToUpper(w[0]) + (w.Length > 1 ? w.Substring(1).ToLower() : "");
            }
            return string.Join(" ", words);
        }


       //Códigos en MAYÚSCULA
        public static string UpperInvariant(string? value)
            => TrimAndCollapseSpaces(value).ToUpperInvariant();
    }

}
