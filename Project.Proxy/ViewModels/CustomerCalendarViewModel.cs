using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy.ViewModels
{
    public class CustomerCalendarViewModel
    {
        public int Id { get; set; }
        public string HoVaTen { get; set; } = string.Empty;

        public string GioiTinh { get; set; } = string.Empty;

        public string NgayThangNamSinh { get; set; } = string.Empty;

        public string SoCMND { get; set; } = string.Empty;

        public string NoiCuTru { get; set; } = string.Empty;

        public string GiayChungNhanSucKhoe { get; set; } = string.Empty;

        public string DaCoGiayPhepLaiXeHang { get; set; } = string.Empty;

        public string DaCoGiayPhepLaiXeSo { get; set; } = string.Empty;

        public string DaCoGiayPhepLaiXeNgayTrung { get; set; } = string.Empty;

        public string PhanKhaiSoKmLaiXeAnToan { get; set; } = string.Empty;

        public string SoChungChiNgheHoacGiay { get; set; } = string.Empty;

        public string LopKhoa { get; set; } = string.Empty;

        public string HangDuSatHach { get; set; } = string.Empty;

        public string GhiChu { get; set; } = string.Empty;

        public DateTime NgayThi { get; set; }
    }
}
