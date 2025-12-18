using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAppQuyt
{
    public static class Global
    {
        public static int UserId = -1;
        public static string Username = "";

        // Thêm biến lưu roomId vừa chơi
        public static string LastPlayedRoomId = "";

        // Method reset khi logout (optional)
        public static void Reset()
        {
            UserId = -1;
            Username = "";
            LastPlayedRoomId = "";
        }
    }
}
