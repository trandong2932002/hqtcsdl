create database QUANLYLUONGNV

go
use QUANLYLUONGNV

go
create table CHINHANH(
	MaCN char(5)primary key,
	DiaChi nvarchar(50),
	SoDT char(10) constraint dt_vanphong check (SoDT like'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' and len(SoDT)=10)
)

go 
create table PHONGBAN(
	MaPB char(5) primary key,
	MaCN char(5) references CHINHANH(MaCN),
	TenPB nvarchar(20)
)

go
create table CONGVIEC(
	MaCV char(5) primary key,
	TenCV nvarchar(20),
	MoTaCV nvarchar(50)
)

create table NHANVIEN(--Khoi tao cac bang lien quan bang trigger
	MaNV char(10) primary key,
	MaPB char(5) references PHONGBAN(MaPB),
	MaCV char(5) references CONGVIEC(MaCV),
	TenNV nvarchar(50),
	GioiTinh nvarchar(5) constraint gioitinh check(GioiTinh in(N'Nam',N'Nữ')),
	SoDT char(10) constraint dt_nhanvien check (SoDT like'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' and len(SoDT)=10),
	LoaiLaoDong nvarchar(20) constraint ld check(LoaiLaoDong in ('ToanThoiGian','BanThoiGian')),
	TienTheoDonVi int constraint tien_luong check (TienTheoDonvi>=0 and TienTheoDonVi%1000=0)
)


go
create table CHAMCONG(
	MaNV char(10) references NHANVIEN(MaNV),
	ThoiGianLamDonVi int,
	TangCa int, 
	NgayChamCong date,
	primary key(MaNV,NgayChamCong)
)

go


go
create table TINHLUONG(
	MaNV char(10) references NHANVIEN(MaNV),
	TongLuong int,
	ThoiGianThang date,
	primary key(MaNV,ThoiGianThang)
)

-------TRIGGER-------
--Nhap Nhan Vien--
/*
go
create trigger trgg_new_NHANVIEN
on NHANVIEN after insert
as
begin
	insert into CHAMCONG(MaNV,ThoiGianLamDonVi,TangCa,TongLuong)values((select MaNV from inserted),0,0,0)
	insert into PHUCAP(MaNV,SoTien,LyDo)values((select MaNV from inserted),0,N'Nhan vien moi')
	insert into TINHLUONG(MaNV,TongLuong,TongPhuCap,ThucNhan)values((select MaNV from inserted),0,0,0)
end
*/
--Thay Doi Cham Cong--
/*
go 
create trigger trgg_chg_CHAMCONG
on CHAMCONG after update
as
declare @donvi int,
		@loai nvarchar(20),
		@manv char(10)
select @donvi = ThoiGianLamDonVi from inserted
select @loai = LoaiLaoDong from LOAILUONG where MaNV=(@manv)
if (@donvi>30 and @loai=N'ToanThoiGian')
begin
	update CHAMCONG set ThoiGianLamDonVi = 30 where MaNV = (@manv)
end

if(@donvi>12 and @loai=N'BanThoiGian')
begin
	update CHAMCONG set ThoiGianLamDonVi = 12 where MaNV = (@manv)
end
begin
	update CHAMCONG set TongLuong = ThoiGianLamDonVi*(select TienMoiDonVi from LOAILUONG) where MaNV=@manv
end

--Cap Nhat Tinh Luong khi thay doi cac gia tri--
go
create trigger trigg_chg_CHAMCONG_to_TINHLUONG 
on CHAMCONG after update
as
declare @manv char(10)
select @manv = MaNV from inserted
begin
	update TINHLUONG set TongLuong = (select TongLuong from CHAMCONG where MaNV=@manv),TongPhuCap=(select sum(SoTien) from PHUCAP where MaNV=@manv)
	where MaNV=@manv
end

--
go
create trigger trgg_chg_TINHLUONG
on TINHLUONG after update
as
declare @manv char(10)
select @manv = MaNV from inserted
begin
	update TINHLUONG set ThucNhan=TongLuong+TongPhuCap 
	where MaNV=@manv
end

*/

--trigger thong bao

--

/*
create function f_TinhLuong()
returns table 
as
begin
	declare @LoaiLaoDong nvarchar(20),@TienTheoDonvi int,@ThoiGianLamDonvi int, @TangCa int,@Heso float
	select @LoaiLaoDong=LoaiLaoDong,@TienTheoDonvi=TienTheoDonvi from NHANVIEN;
	select @ThoiGianLamDonvi=ThoiGianLamDonvi,@TangCa=TangCa from CHAMCONG;
	
*/


--Thong ke
go
select NHANVIEN.MaNV,NHANVIEN.TienTheoDonVi,LoaiLaoDong,ThoiGianLamDonVi,TangCa from
NHANVIEN join
(select MaNV,sum(ThoiGianLamDonVi)as ThoiGianLamDonVi,sum(TangCa)as TangCa from CHAMCONG  where MONTH(NgayChamCong)=5 and YEAR(NgayChamCong)=2022group by(MaNV) )as T1
on NHANVIEN.MaNV=T1.MaNV

go
create function f_ThongKe(@ngay date)
returns table
as
return(select NHANVIEN.MaNV,NHANVIEN.TienTheoDonVi,LoaiLaoDong,ThoiGianLamDonVi,TangCa from
NHANVIEN join
(select MaNV,sum(ThoiGianLamDonVi)as ThoiGianLamDonVi,sum(TangCa)as TangCa from CHAMCONG  where MONTH(NgayChamCong)=MONTH(@ngay) and YEAR(NgayChamCong)=YEAR(@ngay) group by(MaNV) )as T1
on NHANVIEN.MaNV=T1.MaNV)



--Nhap, sua

---Nhap
go
create proc sp_addChiNhanh @MaCN char(5), @DiaChi nvarchar(50),@SoDT char(10)
as
INSERT into CHINHANH values(@MaCN,@DiaChi,@SoDT)

go
create proc sp_addPhongBan @MaPB char(5),@MaCN char(5),@TenPB nvarchar(20)
as
INSERT into PHONGBAN values(@MaPB,@MaCN,@TenPB)

go
create proc sp_addCongViec @MaCV char(5),@TenCV nvarchar(20),@MoTaCV nvarchar(50)
as
INSERT into CONGVIEC values(@MaCV,@TenCV,@MoTaCV)

go
create proc sp_addNhanVien @MaNV nvarchar(10),@MaPB nvarchar(5),@MaCV nvarchar(5),@TenNV nvarchar(50),@GioiTinh nvarchar(5),@SoDT char(10),@LoaiLaoDong nvarchar(20),@LuongDonVi int
as
INSERT into NHANVIEN values(@MaNV,@MaPB,@MaCV,@TenNV,@GioiTinh,@SoDT,@LoaiLaoDong,@LuongDonVi)

go
create proc sp_ChamCong @MaNV char(10), @ThoiGian int, @TangCa int
as
INSERT into CHAMCONG values(@MaNV,@ThoiGian,@TangCa,GETDATE())


---Sua
go
create proc sp_updateChiNhanh @MaCN char(5), @DiaChi nvarchar(50),@SoDT char(10)
as
UPDATE CHINHANH set DiaChi=@DiaChi,SoDT=@SoDT where MaCN=@MaCN

go
create proc sp_updatePhongBan @MaPB char(5),@MaCN char(5),@TenPB nvarchar(20)
as
UPDATE PHONGBAN set TenPB=@TenPB,MaCN=@MaCN where MaPB=@MaPB

go
create proc sp_updateCongViec @MaCV char(5),@TenCV nvarchar(20),@MoTaCV nvarchar(50)
as
UPDATE CONGVIEC set TenCV=@TenCV,MoTaCV=@MoTaCV where MaCV=@MaCV

go
create proc sp_updateNhanVien @MaNV nvarchar(10),@MaPB nvarchar(5),@MaCV nvarchar(5),@TenNV nvarchar(50),@GioiTinh nvarchar(5),@SoDT char(10),@LoaiLaoDong nvarchar(20),@LuongDonVi int
as
UPDATE NHANVIEN set MaCV=@MaCV,MaPB=@MaPB,TenNV=@TenNV,GioiTinh=@GioiTinh,SoDT=@SoDT,LoaiLaoDong=@LoaiLaoDong,TienTheoDonVi=@LuongDonVi where MaNV=@MaNV

--Tinh Luong Thang
select NHANVIEN.MaNV,NHANVIEN.TienTheoDonVi,LoaiLaoDong,ThoiGianLamDonVi,TangCa,
TienLuong = case LoaiLaoDong
when 'ToanThoiGian' then TienTheoDonVi * (ThoiGianLamDonVi * 1 + TangCa * 1.5)
when 'BanThoiGian' then TienTheoDonVi * 0.75 * (ThoiGianLamDonVi * 1 + TangCa * 1.5)
end
from
NHANVIEN join
(select MaNV,sum(ThoiGianLamDonVi)as ThoiGianLamDonVi,sum(TangCa)as TangCa from CHAMCONG  where MONTH(NgayChamCong)=1 and YEAR(NgayChamCong)=2000 group by(MaNV) )as T1
on NHANVIEN.MaNV=T1.MaNV
