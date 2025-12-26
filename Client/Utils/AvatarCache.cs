using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAppQuyt.Utils
{
    public static class AvatarCache
    {
        private static readonly ConcurrentDictionary<int, string> _cache =
           new ConcurrentDictionary<int, string>();

        private static string _defaultBase64; 

        public static void SetDefaultFromImage(Image img)
        {
            if (img == null) return;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                _defaultBase64 = Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string GetDefault()
        {
            if (!string.IsNullOrWhiteSpace(_defaultBase64))
                return _defaultBase64;

            using (var bmp = new Bitmap(128, 128))
            using (var g = Graphics.FromImage(bmp))
            using (var ms = new MemoryStream())
            {
                g.Clear(Color.LightGray);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.Gainsboro))
                    g.FillEllipse(brush, 8, 8, 112, 112);

                using (var pen = new Pen(Color.Gray, 2))
                    g.DrawEllipse(pen, 8, 8, 112, 112);

                using (var f = new Font("Segoe UI", 36, FontStyle.Bold))
                using (var br = new SolidBrush(Color.Gray))
                {
                    var s = "?";
                    var sz = g.MeasureString(s, f);
                    g.DrawString(s, f, br, (128 - sz.Width) / 2, (128 - sz.Height) / 2);
                }

                bmp.Save(ms, ImageFormat.Png);
                _defaultBase64 = Convert.ToBase64String(ms.ToArray());
            }

            return _defaultBase64;
        }

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
    }
}
