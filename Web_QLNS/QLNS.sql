USE [QLNS]
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[Ngay] [date] NOT NULL,
	[IDNV] [int] NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[Ngay] ASC,
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[IDCV] [int] IDENTITY(1,1) NOT NULL,
	[TenCV] [nvarchar](50) NULL,
	[HeSo] [float] NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[IDCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDongLaoDong]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDongLaoDong](
	[IDNV] [int] NOT NULL,
	[LuongCB] [int] NULL,
	[NgayKy] [date] NULL,
 CONSTRAINT [PK_HopDongLaoDong_1] PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhenThuong]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhenThuong](
	[IDKT] [int] IDENTITY(1,1) NOT NULL,
	[IDLoaiKT] [int] NULL,
	[Ngay] [date] NULL,
	[IDNV] [int] NULL,
 CONSTRAINT [PK_KhenThuong] PRIMARY KEY CLUSTERED 
(
	[IDKT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KyLuat]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KyLuat](
	[IDKL] [int] IDENTITY(1,1) NOT NULL,
	[IDLoaiKL] [int] NULL,
	[Ngay] [date] NULL,
	[IDNV] [int] NULL,
 CONSTRAINT [PK_KyLuat] PRIMARY KEY CLUSTERED 
(
	[IDKL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiKhenThuong]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiKhenThuong](
	[IDLoaiKT] [int] IDENTITY(1,1) NOT NULL,
	[TenKT] [nvarchar](50) NULL,
	[GiaTri] [int] NULL,
 CONSTRAINT [PK_LoaiKhenThuong] PRIMARY KEY CLUSTERED 
(
	[IDLoaiKT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiKyLuat]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiKyLuat](
	[IDLoaiKL] [int] IDENTITY(1,1) NOT NULL,
	[TenKL] [nvarchar](50) NULL,
	[GiaTri] [int] NULL,
 CONSTRAINT [PK_LoaiKyLuat] PRIMARY KEY CLUSTERED 
(
	[IDLoaiKL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[IDNV] [int] IDENTITY(1,1) NOT NULL,
	[IDPB] [int] NULL,
	[IDCV] [int] NULL,
	[TenNV] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[CMND] [int] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[HinhAnh] [varchar](50) NULL,
	[TinhTrang] [bit] NULL,
	[NgaySinh] [date] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[IDPB] [int] IDENTITY(1,1) NOT NULL,
	[TenPB] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[IDPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: Thu 10 6 2021 7:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[IDNV] [int] NOT NULL,
	[Pass] [varchar](50) NULL,
	[Type] [bit] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChamCong] ([Ngay], [IDNV], [TrangThai]) VALUES (CAST(N'2021-06-05' AS Date), 2, 1)
INSERT [dbo].[ChamCong] ([Ngay], [IDNV], [TrangThai]) VALUES (CAST(N'2021-06-05' AS Date), 3, 1)
INSERT [dbo].[ChamCong] ([Ngay], [IDNV], [TrangThai]) VALUES (CAST(N'2021-06-05' AS Date), 1018, 1)
INSERT [dbo].[ChamCong] ([Ngay], [IDNV], [TrangThai]) VALUES (CAST(N'2021-06-08' AS Date), 3, 1)
INSERT [dbo].[ChamCong] ([Ngay], [IDNV], [TrangThai]) VALUES (CAST(N'2021-06-09' AS Date), 3, 1)
INSERT [dbo].[ChamCong] ([Ngay], [IDNV], [TrangThai]) VALUES (CAST(N'2021-06-10' AS Date), 3, 1)
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([IDCV], [TenCV], [HeSo]) VALUES (1, N'Trưởng phòng', 2)
INSERT [dbo].[ChucVu] ([IDCV], [TenCV], [HeSo]) VALUES (2, N'Phó phòng', 1.5)
INSERT [dbo].[ChucVu] ([IDCV], [TenCV], [HeSo]) VALUES (3, N'Nhân viên', 1)
INSERT [dbo].[ChucVu] ([IDCV], [TenCV], [HeSo]) VALUES (4, N'Thư ký', 1.5)
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (1, 10530000, CAST(N'2014-04-29' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (2, 13479053, CAST(N'2001-08-19' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (3, 29560870, CAST(N'2011-08-06' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (4, 28859860, CAST(N'2017-09-07' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (5, 27245021, CAST(N'2004-11-05' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (6, 30676816, CAST(N'2017-08-16' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (7, 15909248, CAST(N'2013-05-21' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (8, 71587072, CAST(N'2007-08-26' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (9, 90127496, CAST(N'2004-06-05' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (10, 72579757, CAST(N'2004-05-22' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (1016, 12000000, CAST(N'2021-05-31' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (1017, 10500000, CAST(N'2021-05-31' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (1018, 15000000, CAST(N'2021-06-02' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (1019, 7000000, CAST(N'2021-06-02' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (1020, 50000000, CAST(N'2020-07-20' AS Date))
INSERT [dbo].[HopDongLaoDong] ([IDNV], [LuongCB], [NgayKy]) VALUES (1021, 20000000, CAST(N'2021-06-10' AS Date))
GO
SET IDENTITY_INSERT [dbo].[KhenThuong] ON 

INSERT [dbo].[KhenThuong] ([IDKT], [IDLoaiKT], [Ngay], [IDNV]) VALUES (1, 3, CAST(N'2021-05-31' AS Date), 3)
INSERT [dbo].[KhenThuong] ([IDKT], [IDLoaiKT], [Ngay], [IDNV]) VALUES (2, 4, CAST(N'2021-04-30' AS Date), 3)
SET IDENTITY_INSERT [dbo].[KhenThuong] OFF
GO
SET IDENTITY_INSERT [dbo].[KyLuat] ON 

INSERT [dbo].[KyLuat] ([IDKL], [IDLoaiKL], [Ngay], [IDNV]) VALUES (1, 2, CAST(N'2021-04-05' AS Date), 3)
INSERT [dbo].[KyLuat] ([IDKL], [IDLoaiKL], [Ngay], [IDNV]) VALUES (2, 2, CAST(N'2021-06-05' AS Date), 3)
INSERT [dbo].[KyLuat] ([IDKL], [IDLoaiKL], [Ngay], [IDNV]) VALUES (3, 2, CAST(N'2021-06-05' AS Date), 1018)
INSERT [dbo].[KyLuat] ([IDKL], [IDLoaiKL], [Ngay], [IDNV]) VALUES (4, 2, CAST(N'2021-06-08' AS Date), 3)
INSERT [dbo].[KyLuat] ([IDKL], [IDLoaiKL], [Ngay], [IDNV]) VALUES (5, 2, CAST(N'2021-05-01' AS Date), 3)
INSERT [dbo].[KyLuat] ([IDKL], [IDLoaiKL], [Ngay], [IDNV]) VALUES (6, 2, CAST(N'2021-05-02' AS Date), 3)
INSERT [dbo].[KyLuat] ([IDKL], [IDLoaiKL], [Ngay], [IDNV]) VALUES (7, 2, CAST(N'2021-05-11' AS Date), 3)
INSERT [dbo].[KyLuat] ([IDKL], [IDLoaiKL], [Ngay], [IDNV]) VALUES (8, 2, CAST(N'2021-06-10' AS Date), 3)
SET IDENTITY_INSERT [dbo].[KyLuat] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiKhenThuong] ON 

INSERT [dbo].[LoaiKhenThuong] ([IDLoaiKT], [TenKT], [GiaTri]) VALUES (1, N'Không đi trễ', 200000)
INSERT [dbo].[LoaiKhenThuong] ([IDLoaiKT], [TenKT], [GiaTri]) VALUES (3, N'Thành tích công việc tốt', 200000)
INSERT [dbo].[LoaiKhenThuong] ([IDLoaiKT], [TenKT], [GiaTri]) VALUES (4, N'Không nghỉ không phép', 150000)
SET IDENTITY_INSERT [dbo].[LoaiKhenThuong] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiKyLuat] ON 

INSERT [dbo].[LoaiKyLuat] ([IDLoaiKL], [TenKL], [GiaTri]) VALUES (1, N'Nghỉ không phép', 200000)
INSERT [dbo].[LoaiKyLuat] ([IDLoaiKL], [TenKL], [GiaTri]) VALUES (2, N'Đi trễ', 100000)
INSERT [dbo].[LoaiKyLuat] ([IDLoaiKL], [TenKL], [GiaTri]) VALUES (4, N'Tác phong không đúng quy định', 100000)
INSERT [dbo].[LoaiKyLuat] ([IDLoaiKL], [TenKL], [GiaTri]) VALUES (5, N'Không hoàn thành nhiệm vụ được giao', 200000)
INSERT [dbo].[LoaiKyLuat] ([IDLoaiKL], [TenKL], [GiaTri]) VALUES (6, N'Làm việc riêng', 50000)
SET IDENTITY_INSERT [dbo].[LoaiKyLuat] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (1, 2, 3, N'Coretta Chinge', 0, 736531664, N'22243 Dakota Court', N'968-517-4369', N'cchinge0@is.gd', N'f99a2f6005b12c7fd41908cb3492955a.jpg', 1, CAST(N'1992-12-16' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (2, 5, 1, N'Grantham Ferroli', 1, 891411297, N'10369 Namekagon Junction', N'1324328896', N'gferroli1@msn.com', N'e18a9fa6e67578b1df86ca9edb316d62.jpg', 1, CAST(N'1994-08-12' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (3, 1, 2, N'Henriette Sparkwell', 0, 612262111, N'5260 Aberg Junction', N'162-267-8055', N'hsparkwell2@cnet.com', N'ca57bf142e3c085fdaef4ee675fc2083.jpg', 1, CAST(N'1994-03-19' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (4, 1, 1, N'Em Smidmor', 0, 529794805, N'94 Lighthouse Bay Junction', N'895-747-6030', N'esmidmor3@ucsd.edu', N'c7815eb742cbde2da88d6d32d2785ac0.jpg', 1, CAST(N'1996-03-04' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (5, 5, 2, N'Reed Garber', 0, 306237330, N'8161 Northview Street', N'933-258-9439', N'rgarber4@ameblo.jp', N'c43e1ab6893185a70c1abc17e6769768.jpg', 1, CAST(N'2002-11-10' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (6, 2, 1, N'Devina Slowgrove', 1, 244152191, N'5012 Evergreen Pass', N'352-433-0740', N'dslowgrove5@hp.com', N'beef40f03850c11e1312ab57d8f4bb7b.jpg', 1, CAST(N'2001-10-19' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (7, 3, 3, N'King Weond', 0, 242451177, N'7 Bayside Avenue', N'976-132-8788', N'kweond6@fc2.com', N'Anhavatardoi51-800x800.jpg', 1, CAST(N'2001-07-21' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (8, 4, 1, N'Dianna Gorce', 1, 224711464, N'172 Spenser Terrace', N'334-415-9073', N'dgorce7@livejournal.com', N'f99a2f6005b12c7fd41908cb3492955a.jpg', 1, CAST(N'1990-07-24' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (9, 4, 3, N'Riva Parlour', 1, 109852128, N'46 Dryden Alley', N'409-311-9626', N'rparlour8@blinklist.com', N'0407845aa40be7ad8a3a8a44d97123aa.jpg', 1, CAST(N'1991-04-16' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (10, 1, 1, N'Aldridge Steinson', 0, 317280477, N'18 Morning Alley', N'793-825-1822', N'asteinson9@imdb.com', N'0411a8468765b0832f8672003af93d67.jpg', 1, CAST(N'1987-08-26' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (1016, 5, 3, N'Long Cong Đuôi', 1, 231857643, N'hùng vương TPHCM', N'0976831723', N'congduoi@.com', N'fb42303f0554c463ed89ed9dc34c624e.jpg', 1, CAST(N'2000-03-29' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (1017, 3, 3, N'Long Tre', 1, 546372839, N'an dương vương TPHCM', N'0976831799', N'tre@.com', N'cbc42228979904813baca7d69bdd5868.jpg', 1, CAST(N'1999-03-02' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (1018, 5, 3, N'Cong Đuôi', 1, 534267189, N'nguyễn chi phương TPHCM', N'097683178', N'duoi@.com', N'2f60c15f65c687684b3df9aafcae54b1.jpg', 1, CAST(N'1999-07-02' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (1019, 3, 3, N'Ngọc', 0, 765483928, N'chi phương TPHCM', N'0976831098', N'ngoc@.com', N'e353523d1a8ad11e523fc2590d9734d9.jpg', 1, CAST(N'1997-10-02' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (1020, 2, 3, N'Trí', 1, 564763648, N'đâu đó', N'5368765389', N'tri@.com', N'Staff_09.png', NULL, CAST(N'1997-09-12' AS Date))
INSERT [dbo].[NhanVien] ([IDNV], [IDPB], [IDCV], [TenNV], [GioiTinh], [CMND], [DiaChi], [DienThoai], [Email], [HinhAnh], [TinhTrang], [NgaySinh]) VALUES (1021, 3, 3, N'Trí Trịnh', 1, 123456789, N'122/17', N'123456789', N'st.huflit@gmail.com', N'Staff_10.png', 1, CAST(N'2000-07-20' AS Date))
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhongBan] ON 

INSERT [dbo].[PhongBan] ([IDPB], [TenPB]) VALUES (1, N'Marketing')
INSERT [dbo].[PhongBan] ([IDPB], [TenPB]) VALUES (2, N'Nhân sự')
INSERT [dbo].[PhongBan] ([IDPB], [TenPB]) VALUES (3, N'IT')
INSERT [dbo].[PhongBan] ([IDPB], [TenPB]) VALUES (4, N'Design')
INSERT [dbo].[PhongBan] ([IDPB], [TenPB]) VALUES (5, N'Kế toán')
SET IDENTITY_INSERT [dbo].[PhongBan] OFF
GO
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (1, N'tri', 1)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (2, N'2', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (3, N'3', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (4, N'4', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (5, N'5', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (6, N'6', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (7, N'7', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (8, N'8', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (9, N'9', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (10, N'10', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (1018, N'NV1018', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (1019, N'NV1019', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (1020, N'NV1020', 0)
INSERT [dbo].[TaiKhoan] ([IDNV], [Pass], [Type]) VALUES (1021, N'NV1021', NULL)
GO
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD  CONSTRAINT [FK_ChamCong_NhanVien] FOREIGN KEY([IDNV])
REFERENCES [dbo].[NhanVien] ([IDNV])
GO
ALTER TABLE [dbo].[ChamCong] CHECK CONSTRAINT [FK_ChamCong_NhanVien]
GO
ALTER TABLE [dbo].[HopDongLaoDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDongLaoDong_NhanVien] FOREIGN KEY([IDNV])
REFERENCES [dbo].[NhanVien] ([IDNV])
GO
ALTER TABLE [dbo].[HopDongLaoDong] CHECK CONSTRAINT [FK_HopDongLaoDong_NhanVien]
GO
ALTER TABLE [dbo].[KhenThuong]  WITH CHECK ADD  CONSTRAINT [FK_KhenThuong_LoaiKhenThuong] FOREIGN KEY([IDLoaiKT])
REFERENCES [dbo].[LoaiKhenThuong] ([IDLoaiKT])
GO
ALTER TABLE [dbo].[KhenThuong] CHECK CONSTRAINT [FK_KhenThuong_LoaiKhenThuong]
GO
ALTER TABLE [dbo].[KhenThuong]  WITH CHECK ADD  CONSTRAINT [FK_KhenThuong_NhanVien] FOREIGN KEY([IDNV])
REFERENCES [dbo].[NhanVien] ([IDNV])
GO
ALTER TABLE [dbo].[KhenThuong] CHECK CONSTRAINT [FK_KhenThuong_NhanVien]
GO
ALTER TABLE [dbo].[KyLuat]  WITH CHECK ADD  CONSTRAINT [FK_KyLuat_LoaiKyLuat] FOREIGN KEY([IDLoaiKL])
REFERENCES [dbo].[LoaiKyLuat] ([IDLoaiKL])
GO
ALTER TABLE [dbo].[KyLuat] CHECK CONSTRAINT [FK_KyLuat_LoaiKyLuat]
GO
ALTER TABLE [dbo].[KyLuat]  WITH CHECK ADD  CONSTRAINT [FK_KyLuat_NhanVien] FOREIGN KEY([IDNV])
REFERENCES [dbo].[NhanVien] ([IDNV])
GO
ALTER TABLE [dbo].[KyLuat] CHECK CONSTRAINT [FK_KyLuat_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([IDCV])
REFERENCES [dbo].[ChucVu] ([IDCV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhongBan] FOREIGN KEY([IDPB])
REFERENCES [dbo].[PhongBan] ([IDPB])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhongBan]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([IDNV])
REFERENCES [dbo].[NhanVien] ([IDNV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
