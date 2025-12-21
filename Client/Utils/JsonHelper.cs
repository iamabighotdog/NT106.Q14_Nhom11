using System;
using System.Text.Json;

namespace FormAppQuyt.Utils
{
    public static class JsonHelper
    {
        public static string GetString(JsonElement root, string name, string def = "")
        {
            if (!root.TryGetProperty(name, out var p)) return def;
            if (p.ValueKind == JsonValueKind.String) return p.GetString() ?? def;
            return p.ToString();
        }

        public static int GetInt(JsonElement root, string name, int def = 0)
        {
            if (!root.TryGetProperty(name, out var p)) return def;

            if (p.ValueKind == JsonValueKind.Number && p.TryGetInt32(out var v)) return v;
            if (p.ValueKind == JsonValueKind.String && int.TryParse(p.GetString(), out v)) return v;

            return def;
        }

        public static bool GetBool(JsonElement root, string name, bool def = false)
        {
            if (!root.TryGetProperty(name, out var p)) return def;

            if (p.ValueKind == JsonValueKind.True) return true;
            if (p.ValueKind == JsonValueKind.False) return false;
            if (p.ValueKind == JsonValueKind.String && bool.TryParse(p.GetString(), out var b)) return b;

            return def;
        }
    }
}
