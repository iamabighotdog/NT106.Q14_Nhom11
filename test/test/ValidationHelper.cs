using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace test
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            var pattern = @"^[\w\.\-]+@([\w\-]+\.)+[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        public static bool IsStrongPassword(string pwd)
        {
            if (string.IsNullOrWhiteSpace(pwd)) return false;

            // Sửa lỗi: bỏ ký tự \ trước dấu chấm và một số ký tự khác
            var pattern = @"^(?=.*[A-Z])(?=.*[@#$%^&*!.,:;_\-]).{10,}$";
            return Regex.IsMatch(pwd, pattern);
        }

        // Thêm method để kiểm tra chi tiết mật khẩu
        public static string GetPasswordValidationMessage(string pwd)
        {
            if (string.IsNullOrWhiteSpace(pwd))
                return "Mật khẩu không được để trống";

            var issues = new List<string>();

            if (pwd.Length < 10)
                issues.Add($"Cần ít nhất 10 ký tự (hiện tại: {pwd.Length})");

            if (!Regex.IsMatch(pwd, @"[A-Z]"))
                issues.Add("Cần có ít nhất 1 chữ hoa");

            if (!Regex.IsMatch(pwd, @"[a-z]"))
                issues.Add("Cần có ít nhất 1 chữ thường");

            if (!Regex.IsMatch(pwd, @"[@#$%^&*!.,:;_\-]"))
                issues.Add("Cần có ít nhất 1 ký tự đặc biệt (@#$%^&*!.,:;_-)");

            return issues.Count == 0 ? "Mật khẩu hợp lệ" : string.Join(", ", issues);
        }
    }
}