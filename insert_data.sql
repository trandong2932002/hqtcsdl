use QUANLYLUONGNV

GO
INSERT [dbo].[CHINHANH] ([MaCN], [DiaChi], [SoDT]) VALUES (N'cn1  ', NULL, NULL)
GO
INSERT [dbo].[CHINHANH] ([MaCN], [DiaChi], [SoDT]) VALUES (N'cn2  ', NULL, NULL)
GO
INSERT [dbo].[CHINHANH] ([MaCN], [DiaChi], [SoDT]) VALUES (N'cn3  ', NULL, NULL)
GO
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV], [MoTaCV]) VALUES (N'cv1  ', NULL, NULL)
GO
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV], [MoTaCV]) VALUES (N'cv2  ', NULL, NULL)
GO
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV], [MoTaCV]) VALUES (N'cv3  ', NULL, NULL)
GO
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV], [MoTaCV]) VALUES (N'cv4  ', NULL, NULL)
GO

INSERT [dbo].[PHONGBAN] ([MaPB], [MaCN], [TenPB]) VALUES (N'pb1  ', N'cn1  ', NULL)
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [MaCN], [TenPB]) VALUES (N'pb2  ', N'cn2  ', NULL)
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [MaCN], [TenPB]) VALUES (N'pb3  ', N'cn3  ', NULL)
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [MaCN], [TenPB]) VALUES (N'pb4  ', N'cn3  ', NULL)
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [MaCN], [TenPB]) VALUES (N'pb5  ', N'cn2  ', NULL)
GO
INSERT [dbo].[PHONGBAN] ([MaPB], [MaCN], [TenPB]) VALUES (N'pb6  ', N'cn1  ', NULL)
GO

INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV], [MoTaCV]) VALUES (N'cv1  ', NULL, NULL)
GO
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV], [MoTaCV]) VALUES (N'cv2  ', NULL, NULL)
GO
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV], [MoTaCV]) VALUES (N'cv3  ', NULL, NULL)
GO
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV], [MoTaCV]) VALUES (N'cv4  ', NULL, NULL)
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [MaPB], [MaCV], [TenNV], [GioiTinh], [SoDT], [LoaiLaoDong], [TienTheoDonVi]) VALUES (N'1         ', N'pb1  ', N'cv1  ', NULL, NULL, NULL, N'ToanThoiGian', 1000)
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [MaPB], [MaCV], [TenNV], [GioiTinh], [SoDT], [LoaiLaoDong], [TienTheoDonVi]) VALUES (N'2         ', N'pb3  ', N'cv4  ', NULL, NULL, NULL, N'BanThoiGian', 2000)
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [MaPB], [MaCV], [TenNV], [GioiTinh], [SoDT], [LoaiLaoDong], [TienTheoDonVi]) VALUES (N'3         ', N'pb2  ', N'cv2  ', NULL, NULL, NULL, N'ToanThoiGian', 1000)
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [MaPB], [MaCV], [TenNV], [GioiTinh], [SoDT], [LoaiLaoDong], [TienTheoDonVi]) VALUES (N'4         ', N'pb4  ', N'cv3  ', NULL, NULL, NULL, N'ToanThoiGian', 5000)
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [MaPB], [MaCV], [TenNV], [GioiTinh], [SoDT], [LoaiLaoDong], [TienTheoDonVi]) VALUES (N'5         ', N'pb1  ', N'cv1  ', NULL, NULL, NULL, N'BanThoiGian', 10000)
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'1         ', 10, 8, CAST(N'2000-01-01' AS Date))
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'1         ', 3, 0, CAST(N'2000-01-02' AS Date))
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'2         ', 4, 1, CAST(N'2000-01-01' AS Date))
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'2         ', 4, 5, CAST(N'2000-01-02' AS Date))
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'2         ', 6, 2, CAST(N'2000-01-03' AS Date))
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'2         ', 3, 6, CAST(N'2000-01-04' AS Date))
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'2         ', 3, 8, CAST(N'2000-01-05' AS Date))
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'3         ', 9, 9, CAST(N'2000-01-01' AS Date))
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'3         ', 1, 2, CAST(N'2000-01-02' AS Date))
GO
INSERT [dbo].[CHAMCONG] ([MaNV], [ThoiGianLamDonVi], [TangCa], [NgayChamCong]) VALUES (N'3         ', 8, 3, CAST(N'2000-01-03' AS Date))
