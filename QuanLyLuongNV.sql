﻿create database QUANLYLUONGNV

go
use QUANLYLUONGNV

go
create table CHINHANH(
	MaCN char(5)primary key,
	DiaChi nvarchar(100),
	SoDT char(10) constraint dt_vanphong check (SoDT like'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' and len(SoDT)=10)
)

go 
create table PHONGBAN(
	MaPB char(5) primary key,
	MaCN char(5) references CHINHANH(MaCN)on delete set null on update cascade,
	TenPB nvarchar(50)
)

go
create table CONGVIEC(
	MaCV char(5) primary key,
	TenCV nvarchar(50),
	MoTaCV nvarchar(200)
)

create table NHANVIEN(--Khoi tao cac bang lien quan bang trigger
	MaNV char(6) primary key,
	MaPB char(5) references PHONGBAN(MaPB) on delete set null on update cascade,
	MaCV char(5) references CONGVIEC(MaCV) on delete set null on update cascade,
	TenNV nvarchar(50),
	GioiTinh nvarchar(5) constraint gioitinh check(GioiTinh in(N'Nam',N'Nữ')),
	SoDT char(10) constraint dt_nhanvien check (SoDT like'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' and len(SoDT)=10),
	LoaiLaoDong nvarchar(20) constraint ld check(LoaiLaoDong in ('ToanThoiGian','BanThoiGian')),
	TienTheoDonVi int constraint tien_luong check (TienTheoDonvi>=0 and TienTheoDonVi%1000=0)
)


go
create table CHAMCONG(
	MaNV char(6) references NHANVIEN(MaNV)on update cascade,
	ThoiGianLamDonVi int,
	TangCa int, 
	NgayChamCong date,
	primary key(MaNV,NgayChamCong)
)


go
create table TINHLUONG(
	MaNV char(6) references NHANVIEN(MaNV)on update cascade,
	TongLuong int,
	ThoiGianThang date,
	primary key(MaNV,ThoiGianThang)
)


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
create proc sp_addChiNhanh @MaCN char(5), @DiaChi nvarchar(100),@SoDT char(10)
as
begin tran
	if(@MaCN is null or @MaCN = ' ')
	begin
		raiserror('Chua nhap ma chi nhanh',16,1)
		rollback
		return
	end
	if exists (select 1 from CHINHANH where MaCN = @MaCN)
	begin
		raiserror('Ma Chi nhanh da ton tai',16,1)
		rollback
		return
	end
	if(@DiaChi is null or @DiaChi = ' ')
	begin
		raiserror('Dia chi khong the bo trong',16,1)
		rollback
		return
	end
	INSERT into CHINHANH values(@MaCN,@DiaChi,@SoDT)
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

go
create proc sp_addPhongBan @MaPB char(5),@MaCN char(5),@TenPB nvarchar(50)
as
begin tran
	if(@MaPB is null or @MaPB = ' ')
	begin
		raiserror('Chua nhap ma phong ban',16,1)
		rollback
		return
	end
	if exists (select 1 from PHONGBAN where MaPB = @MaPB)
	begin
		raiserror('Ma Phong ban da ton tai',16,1)
		rollback
		return
	end
	if(@MaCN is null or @MaCN = ' ')
	begin
		raiserror('De nghi nhap ma chi nhanh',16,1)
		rollback
		return
	end
	if not exists (select 1 from CHINHANH where MaCN = @MaCN)
	begin
		raiserror('Chi nhanh khong ton tai',16,1)
		rollback
		return
	end
	if(@TenPB is null or @TenPB = ' ')
	begin
		raiserror('De nghi nhap ten phong ban',16,1)
		rollback
		return
	end
	INSERT into PHONGBAN values(@MaPB,@MaCN,@TenPB)
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran
	

go
create proc sp_addCongViec @MaCV char(5),@TenCV nvarchar(50),@MoTaCV nvarchar(200)
as
begin tran
	if(@MaCV is null or @MaCV = ' ')
	begin
		raiserror('Chua nhap ma cong viec',16,1)
		rollback
		return
	end
	if exists (select 1 from CONGVIEC where MaCV = @MaCV)
	begin
		raiserror('Ma Cong viec da ton tai',16,1)
		rollback
		return
	end
	if(@TenCV is null or @TenCV = ' ')
	begin
		raiserror('Khong de trong Ten cong viec',16,1)
		rollback
		return
	end
	if(@MoTaCV is null or @MoTaCV = ' ')
	begin
		raiserror('Hay nhap mo ta cong viec',16,1)
		rollback
		return
	end
	INSERT into CONGVIEC values(@MaCV,@TenCV,@MoTaCV)
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

go
create proc sp_addNhanVien @MaNV nvarchar(6),@MaPB nvarchar(5),@MaCV nvarchar(5),@TenNV nvarchar(50),@GioiTinh nvarchar(5),@SoDT char(10),@LoaiLaoDong nvarchar(20),@LuongDonVi int
as
begin tran
	if exists (select 1 from NHANVIEN where MaNV = @MaNV)
	begin
		raiserror('Ma Nhan vien da ton tai',16,1)
		rollback
		return
	end
	if(@MaNV is null or @MaNV=' ')
	begin
		raiserror('Chua nhap ma nhan vien',16,1)
		rollback
		return
	end
	if(@MaPB is null or @MaPB = ' ')
	begin
		raiserror('Hay chon phong ban',16,1)
		rollback
		return
	end
	if not exists (select 1 from PHONGBAN where MaPB = @MaPB)
	begin
		raiserror('Phong ban khong ton tai',16,1)
		rollback
		return
	end
	if(@MaCV is null or @MaCV = ' ')
	begin
		raiserror('Hay chon cong viec',16,1)
		rollback
		return
	end
	if not exists (select 1 from CONGVIEC where MaCV=@MaCV)
	begin
		raiserror('Cong viec khong ton tai',16,1)
		rollback
		return
	end
	if(@TenNV is null or @TenNV = ' ')
	begin
		raiserror('Hay nhap ten',16,1)
		rollback
		return
	end
	if(@LuongDonVi is null or @LuongDonVi<0)
	begin
		raiserror('Hay nhap luong dung',16,1)
		rollback
		return
	end
	if(@GioiTinh!=N'Nam' and @GioiTinh!=N'Nữ')
	begin
		raiserror('Hay nhap dung gioi tinh',16,1)
		rollback
		return
	end
	if(@LoaiLaoDong is null or @LoaiLaoDong='')
	begin
		raiserror('Chon loai lao dong',16,1)
		rollback
		return
	end
	if(@SoDT is null or @SoDT = ' ' or len(@SoDT)!=10)
	begin
		raiserror('Hay nhap so dien thoai dung',16,1)
		rollback
		return
	end
	INSERT into NHANVIEN values(@MaNV,@MaPB,@MaCV,@TenNV,@GioiTinh,@SoDT,@LoaiLaoDong,@LuongDonVi)
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

go
create proc sp_ChamCong @MaNV char(6), @ThoiGian int, @TangCa int
as
begin tran
	if not exists (select 1 from NHANVIEN where MaNV = @MaNV)
	begin
		raiserror('Nhan vien khong ton tai',16,1)
		rollback
		return
	end
	if(@ThoiGian is null or @ThoiGian < 0 or @ThoiGian>16)
	begin
		raiserror('De nghi nhap thoi gian chinh xac',16,1)
		rollback
		return
	end
	if(@TangCa is null or @TangCa<=-1 or @TangCa>8)
	begin
		raiserror('De nghi nhap thoi gian tang ca chinh xac',16,1)
		rollback
		return
	end
	if exists (select 1 from CHAMCONG where MaNV = @MaNV and NgayChamCong=convert(date,GETDATE()))
	begin
		if((select TangCa from CHAMCONG where MaNV = @MaNV and NgayChamCong=convert(date,GETDATE()))=0 and @TangCa != 0)
		begin
			delete from CHAMCONG where MaNV = @MaNV and NgayChamCong=convert(date,GETDATE())
		end
		else
		begin
			raiserror('Da thuc hien cham cong truoc do',16,1)
			rollback
			return
		end
	end
	INSERT into CHAMCONG values(@MaNV,@ThoiGian,@TangCa,GETDATE())
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran



---Sua
go
create proc sp_updateChiNhanh @MaCN char(5), @DiaChi nvarchar(50),@SoDT char(10)
as
begin tran
	if(@MaCN is null or @MaCN = ' ')
	begin 
		raiserror('Hay chon chi nhanh',16,1)
		rollback
		return
	end
	if not exists (select 1 from CHINHANH where MaCN=@MaCN)
	begin
		raiserror('Chi nhanh khong ton tai',16,1)
		rollback
		return
	end
	if(@DiaChi is null or @DiaChi = ' ')
	begin
		raiserror('Dia chi khong the bo trong',16,1)
		rollback
		return
	end
	if(@SoDT is null or @SoDT = ' ' or len(@SoDT)!=10)
	begin
		raiserror('Hay nhap so dien thoai dung',16,1)
		rollback
		return
	end
	UPDATE CHINHANH set DiaChi=@DiaChi,SoDT=@SoDT where MaCN=@MaCN
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

go
create proc sp_updatePhongBan @MaPB char(5),@MaCN char(5),@TenPB nvarchar(20)
as
begin tran
	if(@MaPB is null or @MaPB = ' ')
	begin
		raiserror('Hay chon phong ban',16,1)
		rollback
		return
	end
	if not exists (select 1 from PHONGBAN where MaPB=@MaPB)
	begin
		raiserror('Phong ban khong ton tai',16,1)
		rollback
		return
	end
	if(@MaCN is null or @MaCN = ' ')
	begin
		raiserror('De nghi nhap ma chi nhanh',16,1)
		rollback
		return
	end
	if(@TenPB is null or @TenPB = ' ')
	begin
		raiserror('De nghi nhap ten phong ban',16,1)
		rollback
		return
	end
	UPDATE PHONGBAN set TenPB=@TenPB,MaCN=@MaCN where MaPB=@MaPB
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

go
create proc sp_updateCongViec @MaCV char(5),@TenCV nvarchar(20),@MoTaCV nvarchar(50)
as
begin tran
	if(@MaCV is null or @MaCV = ' ')
	begin
		raiserror('Hay chon cong viec',16,1)
		rollback
		return
	end
	if not exists (select 1 from CONGVIEC where MaCV=@MaCV)
	begin
		raiserror('Cong viec khong ton tai',16,1)
		rollback
		return
	end
	if(@TenCV is null or @TenCV = ' ')
	begin
		raiserror('Khong de trong Ten cong viec',16,1)
		rollback
		return
	end
	if(@MoTaCV is null or @MoTaCV = ' ')
	begin
		raiserror('Hay nhap mo ta cong viec',16,1)
		rollback
		return
	end
	UPDATE CONGVIEC set TenCV=@TenCV,MoTaCV=@MoTaCV where MaCV=@MaCV
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

go
create proc sp_updateNhanVien @MaNV nvarchar(6),@MaPB nvarchar(5),@MaCV nvarchar(5),@TenNV nvarchar(50),@GioiTinh nvarchar(5),@SoDT char(10),@LoaiLaoDong nvarchar(20),@LuongDonVi int
as
begin tran
	if(@MaNV is null or @MaNV = ' ')
	begin
		raiserror('Hay nhap ma nhan vien',16,1)
		rollback
		return
	end
	if not exists (select 1 from NHANVIEN where MaNV=@MaNV)
	begin
		raiserror('Nhan vien khong ton tai',16,1)
		rollback
		return
	end
	if(@MaPB is null or @MaPB = ' ')
	begin
		raiserror('Hay chon phong ban',16,1)
		rollback
		return
	end
	if(@MaCV is null or @MaCV = ' ')
	begin
		raiserror('Hay chon cong viec',16,1)
		rollback
		return
	end
	if(@TenNV is null or @TenNV = ' ')
	begin
		raiserror('Hay nhap ten',16,1)
		rollback
		return
	end
	if(@GioiTinh!=N'Nam' and @GioiTinh!=N'Nữ')
	begin
		raiserror('Hay nhap dung gioi tinh',16,1)
		rollback
		return
	end
	if(@LoaiLaoDong is null or @LoaiLaoDong='')
	begin
		raiserror('Chon loai lao dong',16,1)
		rollback
		return
	end
	if(@SoDT is null or @SoDT = ' ' or len(@SoDT)!=10)
	begin
		raiserror('Hay nhap so dien thoai dung',16,1)
		rollback
		return
	end
	if(@LuongDonVi is null or @LuongDonVi<0 or @LuongDonVi%1000 !=0)
	begin
		raiserror('Hay nhap luong chinh xac',16,1)
		rollback
		return
	end
	UPDATE NHANVIEN set MaCV=@MaCV,MaPB=@MaPB,TenNV=@TenNV,GioiTinh=@GioiTinh,SoDT=@SoDT,LoaiLaoDong=@LoaiLaoDong,TienTheoDonVi=@LuongDonVi where MaNV=@MaNV
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

--Xoa
go
create proc sp_delChiNhanh @MaCN char(5)
as
begin tran
	if(@MaCN is null or @MaCN = ' ')
	begin
		raiserror('Hay chon chi nhanh',16,1)
		rollback
		return
	end
	if not exists (select 1 from CHINHANH where MaCN=@MaCN)
	begin
		raiserror('Chi nhanh khong ton tai',16,1)
		rollback
		return
	end
	DELETE from CHINHANH where MaCN = @MaCN 
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

go 
create proc sp_delPhongBan @MaPB char(5)
as
begin tran
	if(@MaPB is null or @MaPB = ' ')
	begin
		raiserror('Hay chon phong ban',16,1)
		rollback
		return
	end
	if not exists (select 1 from PHONGBAN where MaPB=@MaPB)
	begin
		raiserror('Phong ban khong ton tai',16,1)
		rollback
		return
	end
	DELETE from PHONGBAN where MaPB = @MaPB
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

go
create proc sp_delCongViec @MaCV char(5)
as
begin tran
	if(@MaCV is null or @MaCV = ' ')
	begin
		raiserror('Hay chon cong viec',16,1)
		rollback
		return
	end
	if not exists (select 1 from CONGVIEC where MaCV=@MaCV)
	begin
		raiserror('Cong viec khong ton tai',16,1)
		rollback
		return
	end
	DELETE from CONGVIEC where MaCV = @MaCV
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran

go
create proc sp_delNhanVien @MaNV char(6)
as 
begin tran
	if(@MaNV is null or @MaNV = ' ')
	begin
		raiserror('Hay chon nhan vien',16,1)
		rollback
		return
	end
	if not exists (select 1 from NHANVIEN where MaNV=@MaNV)
	begin
		raiserror('Nhan vien khong ton tai',16,1)
		rollback
		return
	end
	DELETE from NHANVIEN where MaNV=@MaNV
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran
--Tinh Luong Thang

go
create function f_TinhLuong(@NgayTinhLuong date)
returns table
as
return
(
select NHANVIEN.MaNV,NHANVIEN.TienTheoDonVi,LoaiLaoDong,ThoiGianLamDonVi,TangCa,
TienLuong = case LoaiLaoDong
when 'ToanThoiGian' then TienTheoDonVi * (ThoiGianLamDonVi * 1 + TangCa * 1.5)
when 'BanThoiGian' then TienTheoDonVi * 0.75 * (ThoiGianLamDonVi * 1 + TangCa * 1.5)
end
from
NHANVIEN join
(select MaNV,sum(ThoiGianLamDonVi)as ThoiGianLamDonVi,sum(TangCa)as TangCa from CHAMCONG  where MONTH(NgayChamCong)=MONTH(@NgayTinhLuong) and YEAR(NgayChamCong)=YEAR(@NgayTinhLuong) group by(MaNV) )as T1
on NHANVIEN.MaNV=T1.MaNV
)


--Nhap bang tinh luong
go
create proc sp_TinhLuong @NgayTinhluong date
as
begin tran
	delete from TINHLUONG where month(ThoiGianThang) = month(@NgayTinhluong) and year(ThoiGianThang)=year(@NgayTinhLuong)
	insert into TINHLUONG(MaNV,TongLuong,ThoiGianThang) select MaNV,TienLuong,@NgayTinhluong from f_TinhLuong(@NgayTinhluong)
	if(@@ERROR<>0)
	begin
		raiserror('Error',16,1)
		rollback
		return
	end
commit tran
 




--Trigger
go
create trigger trg_ChamCongTinhLuong
on CHAMCONG after insert
as 
declare @date date = getdate() 
begin
	exec sp_TinhLuong @date
end

go 
create trigger trg_TangCa
on CHAMCONG after insert
as
declare @TangCa int = (select TangCa from inserted),
		@ThoiGian int = (select ThoiGianLamDonVi from inserted)
begin
	if(@ThoiGian < 8 and @TangCa >0)
	begin
		rollback transaction
		raiserror('Chua lam du gio de tang ca',16,1)
	end
end
--Table
go
create proc getDataChiNhanh 
as
	select *from CHINHANH order by MaCN
	return;

go
create proc getDataPhongBan
as	
	select *from PHONGBAN order by MaPB

go
create proc getDataCongViec
as
	select *from CONGVIEC order by MaCV


go
create proc getDataNhanVien
as
	select distinct *from NHANVIEN A 



go
create proc getDataChamCong @NgayChamCong date
as
	select A.MaNV, MaPB,MaCV, TenNV, ISNULL(ThoiGianLamDonVi,0)as ThoiGianLamDonVi,ISNULL(TangCa,0)as TangCa from NHANVIEN A left join
	(select MaNV, ThoiGianLamDonVi, TangCa from CHAMCONG where NgayChamCong = @NgayChamCong)B on A.MaNV=B.MaNV

go
create proc getDataTinhLuong @NgayChamCong date
as
	select *from f_TinhLuong(@NgayChamCong)



--Tao User 
--Admin:admin
go
create login Admin with password = 'admin', default_database=[QUANLYLUONGNV], check_expiration=off,check_policy=off
go
create user Admin for login Admin

--Manager:manager
go
create login Manager with password = 'manager', default_database=[QUANLYLUONGNV], check_expiration=off,check_policy=off
go
create user Manager for login Manager


go
alter role db_owner add member Admin

go
create role employee_manage

go
grant select on CHINHANH to employee_manage 
go
grant select on PHONGBAN to employee_manage 
go
grant select on CONGVIEC to employee_manage 
go
grant select,update,insert,delete on NHANVIEN to employee_manage
go
grant select,update,insert,delete on CHAMCONG to employee_manage 
go
grant select,update,insert,delete on TINHLUONG to employee_manage 
go
grant execute on sp_ChamCong to employee_manage
go
grant execute on sp_TinhLuong to employee_manage
go
grant select on f_TinhLuong to employee_manage
go
grant execute on getDataChiNhanh to employee_manage
go
grant execute on getDataPhongBan to employee_manage
go
grant execute on getDataCongViec to employee_manage
go
grant execute on getDataNhanVien to employee_manage
go
grant execute on getDataChamCong to employee_manage
go
grant execute on getDataTinhLuong to employee_manage
go
alter role employee_manage add member Manager

--exec getDataChamCong '2022-10-1'

--select *from f_TinhLuong('2022/6/1')

/*
go 
select * from 
(
(
(	select *from NHANVIEN)T1 
	inner join (select MaCV,TenCV from CONGVIEC)T2 on T1.MaCV = T2.MaCV 
	inner join (select MaPB,TenPB from PHONGBAN)T3 on T1.MaPB = T3.MaPB))
*/

/*
exec sp_ChamCong 'NV0000',8,8

select * from CHAMCONG
exec sp_TinhLuong '2022-1-1' -- (select convert(date,GETDATE()))
select *from TINHLUONG
*/
/*

select *from f_TinhLuong('2020-2-2')
select *from f_ThongKe('2020-2-2')
sp(add,update,del)+transaction+Login+user
*/
/*
Thêm: 
exec sp_addChiNhanh @MaCN, @DiaChinh, @SoDT
exec sp_addPhongBan @MaPB, @MaPB, @TenPB
sp_addCongViec @MaCV, @TenCV, @MoTaCV
sp_addNhanVien @MaNV, @MaPB, @MaCV, @TenNV, @GioiTinh, @SoDT, @LoaiLaoDong, @LuongDonVi

Sửa:
sp_updateChiNhanh @MaCN, @DiaChi, @SoDT
sp_updatePhongBan @MaPB, @MaPB, @TenPB
sp_updateCongViec @MaCV, @TenCV, @MoTaCV
sp_updateNhanVien @MaNV, @MaPB, @MaCV, @TenNV, @GioiTinh, @SoDT, @LoaiLaoDong, @LuongDonVi

Xóa:
sp_delChiNhanh @MaCN
sp_delPhongBan @MaPB
sp_delCongViec @MACV
sp_delNhanVien @MaNV

Chức năng:
sp_ChamCong @date
sp_TinhLuong @date

Bảng:
f_TinhLuong @date
f_ThongKe @date

connetionString = @"Data Source=.;Initial Catalog=QUANLYLUONGNV;User ID=username;Password=pass";
*/

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
/*
go
select NHANVIEN.MaNV,NHANVIEN.TienTheoDonVi,LoaiLaoDong,ThoiGianLamDonVi,TangCa from
NHANVIEN join
(select MaNV,sum(ThoiGianLamDonVi)as ThoiGianLamDonVi,sum(TangCa)as TangCa from CHAMCONG  where MONTH(NgayChamCong)=5 and YEAR(NgayChamCong)=2022group by(MaNV) )as T1
on NHANVIEN.MaNV=T1.MaNV
*/

