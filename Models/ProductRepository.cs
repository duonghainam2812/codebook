using ASM4.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASM4.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            // Tạo một số dữ liệu mẫu
            _products = new List<Product>
            {
                new Product { Id = 1, Title = "Ăn ít để khoẻ",Author ="Yoshinori Nagumo",
                    Description = "Trong những năm gần đây người ta chứng minh được trạng" +
                    " thái đói bụng là một hoạt động quan trọng đối với cơ thể con người. Điều" +
                    " này trái ngược với “tri thức thông thường” của con người, rằng việc để cơ" +
                    " thể bị đói sẽ gây hại cho sức khỏe. Theo bác sĩ Yoshinori Nagumo, “mỗi lần bụng" +
                    " reo lên vì đói, những điều có lợi cho sức khỏe sẽ được kích hoạt ở mức độ tế bào," +
                    " tạo nên hiệu quả trẻ hóa. Ông đã và đang duy trì chế độ ăn mỗi ngày một bữa suốt 10 năm," +
                    " kể từ khi 45 tuổi. Ông từng bị ung thư, không kiểm soát được cân nặng của mình, sức khỏe" +
                    " cũng xuống cấp trầm trọng. Nhưng kể từ khi giảm lượng thức ăn bằng phương pháp “Bữa ăn" +
                    " cơ bản” thì trọng lượng cơ thể cũng giảm xuống và tình trạng cơ thể cũng sẽ ngày một tốt" +
                    " lên. Nhìn từ góc độ dinh dưỡng, chúng ta hoàn toàn có thể hiểu việc cơ thể trở nên hoạt hóa" +
                    " nhờ được tiếp nhận “dinh dưỡng đầy đủ” gói gọn trong một bữa ăn tưởng chừng đơn giản.",
                    Price = 107000, ImageUrl = "/images/img_2.jpg"},
                new Product { Id = 2, Title = "Tôi Tài Giỏi - Bạn Cũng Thế\n",Author ="Adam Khoo",
                    Description = "Khi bạn cầm trên tay quyển sách này, có nghĩa là bạn đã có chiếc chìa khóa đến sự thành công cùng bảng hướng dẫn sử dụng. \n"+"Trong chúng ta, bất kỳ ai cũng muốn chính bản thân mình trở thành người tài giỏi, có thể giải quyết mọi vấn đề một cách hiệu quả nhất. Và để có được những điều đó quyển sách này sẽ giúp bạn bằng những hướng dẫn học tập chi tiết nhất.",
                    Price = 130950, ImageUrl = "/images/img_1.jpg"},
                new Product { Id = 3, Title = "How to Love (Mindfulness Essentials) - New Cover ",Author ="Thích Nhất Hạnh",
                    Description = "How to Love is the third title in Parallax’s Mindfulness Essentials Series of how-to titles by Zen Master Thich Nhat Hanh, introducing beginners and reminding seasoned practitioners of the essentials of mindfulness practice. This time Nhat Hanh brings his signature clarity, compassion, and humor to the thorny question of how to love. He distills one of our strongest emotions down to four essentials:\n"+
                    "\t- you can only love another when you feel true love for yourself;\n"+
                    "\t- love is understanding;\n"+
                    "\t- understanding brings compassion;\n"+
                    "\t- deep listening and loving speech are key ways of showing our love.\n",
                    Price = 291000, ImageUrl = "/images/img_5.jpg.webp"},
                new Product { Id = 4, Title = "Clean Code – Mã Sạch Và Con Đường Trở Thành Lập Trình Viên Giỏi",Author ="Robert Cecil Martin",
                    Description = "Mã sạch và con đường trở thành lập trình viên giỏi\n"+
                    "Hiện nay, lập trình viên là một trong những nghề nghiệp được nhiều người lựa chọn theo đuổi và gắn bó. Đây là công việc đòi hỏi sự tỉ mỉ, nhiều công sức nhưng mang lại giá trị cao và một tương lai công việc hứa hẹn. Là một trong số những chuyên gia giàu kinh nghiệm, điêu luyện và lành nghề trong ngành, tác giả đã đúc rút từ kinh nghiệm của mình, viết về những tình huống trong thực tế, đôi khi có thể trái ngược với lý thuyết để xây dựng nên cuốn cẩm nang này, nhằm hỗ trợ những người đang muốn trở thành một lập trình viên chuyên nghiệp.\n"+
                    "Cuốn sách được nhiều lập trình viên đánh giá là quyển sách giá trị nhất mà họ từng đọc trong sự nghiệp của mình. Cuốn sách hướng dẫn cách để viết những đoạn mã có thể hoạt động tốt, cũng như truyền tải được ý định của người viết nên chúng.\n",
                    Price = 228000, ImageUrl = "/images/img_6.jpg.webp"},
                // Thêm các sản phẩm khác
            };
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id); if (index != -1)
            {
                _products[index] = product;
            }
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id); if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}