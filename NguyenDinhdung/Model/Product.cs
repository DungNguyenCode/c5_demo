using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Model
{
    public class Product
    {
        [Key]
        [MaxLength(4,ErrorMessage ="Mã chỉ được nhập tối đa 4 kí tự ")]
        public string Ma { get; set; }
        [MaxLength(15,ErrorMessage ="Chỉ được nhập tối đa 15 kí tự")]
        public string? Name { get; set; }
        [Range(1000,30000000,ErrorMessage ="Vượt quá mức tiền cho phép ")]
        public int Price  { get; set; }
        public string ?NhaSanXuat { get; set; }
        public string? ThuongHieu { get; set; }
        public int SoTonKho { get; set; }
    }
}
