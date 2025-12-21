using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace FormAppQuyt.Utils
{
    public static class AvatarCache
    {
        private static readonly ConcurrentDictionary<int, string> _cache =
            new ConcurrentDictionary<int, string>();

        public static void Set(int userId, string avatarBase64)
        {
            if (userId <= 0) return;
            if (string.IsNullOrWhiteSpace(avatarBase64)) return;
            _cache[userId] = avatarBase64;
        }

        public static string Get(int userId)
        {
            if (userId <= 0) return null;
            _cache.TryGetValue(userId, out var v);
            return v;
        }

        public static void Remove(int userId)
        {
            if (userId <= 0) return;
            _cache.TryRemove(userId, out _);
        }
    }
}
