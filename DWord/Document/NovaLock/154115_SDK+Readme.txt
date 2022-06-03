I. Cấu trúc dữ liệu
	public class CardInfo
	{
		// Loại thẻ, xem enum bên dưới
		public CardType Type { set; get; }
		
		// Mã khách hàng
		public string CustomerID { set; get; }
		
		// Mã toà nhà
		public int BuildingID { set; get; }
		
		// Mã tầng
		public string FloorID { set; get; }
		
		// Mã phòng
		public string RoomID { set; get; }

		// Sử dụng từ lúc
		public DateTime UsageToTime { set; get; }

		// Thời gian hiện tại (lúc ghi thẻ)
		public DateTime CurrentTime { set; get; }
		
		// UID của thẻ
		public long UID { set; get; }
		
		// Checksum, bỏ qua trường này
		public int Checksum { set; get; }
	}

	public enum CardType
	{
		THE_HE_THONG = 1, 
		THE_PHONG = 2, 
		THE_THOI_GIAN = 3, 
		THE_XOA = 4, 
		THE_TANG = 5, 
		THE_TOA_NHA = 6,
		THE_MASTER = 7,
        THE_GHI_DU_LIEU = 8,
	}

II. Các loại thẻ
	1 : Thẻ hệ thống - Dùng để cài đặt các tham số cho khóa
	2 : Thẻ phòng - Dùng để mở phòng (phải cùng tầng, tòa nhà và CustomerID)
	3 : Thẻ thời gian - Dùng để cài đặt thời gian cho khóa
	4 : Thẻ xóa - Dùng để xóa các thông tin đã cài đặt cho khóa
	5 : Thẻ tầng- Dùng để mở tất cả các phòng trong tầng (phải cùng tòa nhà  và CustomerID)
	6 : Thẻ tòa nhà - Dùng để mở tất cả các phòng trong tòa nhà
	7 : Thẻ master - Mở được tất các phòng trong hệ thống (có cùng CustomerID)
	8 : Thẻ ghi dữ liệu - Dùng để lấy dữ liệu của đầu đọc

III. Hướng dẫn thao tác cấu hình cho thẻ
	B1. Cấu hình loại thẻ là thẻ hệ thống (THE_HE_THONG), cấu hình các tham số gồm: phòng, tầng, toà nhà, mã khách hàng cho thẻ.
	B2. Quẹt thẻ vào khoá để khoá nhận cấu hình.
	B3. Cấu hình loại thẻ là thẻ phòng (THE_PHONG), các tham số: phòng, tầng, toà nhà, mã khách hàng giống với B1.
	B4. Quẹt thẻ phòng vào khoá, khoá mở là đã cấu hình thành công.