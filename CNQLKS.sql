CREATE DATABASE QL_KSan
USE QL_KSan
GO 
CREATE TABLE QUYEN
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TENQUYEN NVARCHAR(40) UNIQUE
)
create table NHANSU
(
	MaNV varchar (10) not null  ,
	TenNV nvarchar(20) , 
	NgaySinh date,
	DiaChi nvarchar(20) , 
	GT nvarchar(10),
	SDT char(10) ,  
	USERNAME VARCHAR(20),
	PASS VARCHAR(20),
	QUYEN INT,
	constraint PK_NS primary key (MaNV),
	Constraint FK_NS_Quyen foreign key (QUYEN) references QUYEN(ID)
)
create table KhachHang
(
	MaKH varchar (10) not null  ,
	TenKhach nvarchar(20) , 
	DiaChi nvarchar(20) , 
	SDT char(10) , 
	email char(25) 
	constraint PK_KH primary key (MaKH)
)
create table Phong 
(
	MaPhong varchar(10) not null , 
	TenPhong nvarchar(20) , 
	TrangThai nvarchar(10) default N'Trống' , 
	DonGia float ,
	constraint FK_Phong primary key (MaPhong)
) 
create table DatPhong 
(
	MaDatPhong varchar(10) not null , 
	MaPhong varchar(10) , 
	NgayDat  Date ,
	NgayNhan Date  , 
	NgayTra Date   ,
	ThanhTien float,
	Constraint PK_DatPhong primary key (MaDatPhong)  , 
	Constraint FK_DP_Phong foreign key (MaPhong) references Phong(MaPhong) 
	
)
create table DichVu 
(
	MaDichVu varchar(10) not null , 
	TenDichVu nvarchar(20) , 
	GiaDichVu float 
	constraint PK_DV primary key (MaDichVu) 
)

create table DatDichVu
(
	MaDichVu varchar(10) not null, 
	MaDatPhong varchar(10) not null,
	SoLuong int  , 
	ThanhTien float,
	constraint PK_DDV primary key (MaDichVu,MaDatPhong), 
	constraint FK_DDV_DV foreign key (MaDichVu) references DichVu(MaDichVu),
	constraint FK_DDV_DP foreign key (MaDatPhong) references DatPhong(MaDatPhong)

)
Create table HoaDon 
(
	MaHD varchar(10) not null , 
	MaDatPhong varchar(10),
	MAKH VARCHAR(10),
	MANV VARCHAR(10),
	TongTien float , 
	Giamgia float,
	TienCoc float,
	CongNo float,
	NgayLap Date , 
	Trangthai nvarchar(30) Default N'Chưa thanh toán'
	constraint PK_HD primary key (MaHD) , 
	constraint FK_HD_DP foreign key (MaDatPhong) references DatPhong(MaDatPhong),
	Constraint FK_HD_KH foreign key (MaKH) references KhachHang(MaKH),
	Constraint FK_HD_NV foreign key (MaNV) references NHANSU(MaNV) 
)
Insert into Quyen(TENQUYEN) values(N'Quản trị viên')
Insert into Quyen(TENQUYEN) values(N'Lễ tân')
Insert into Quyen(TENQUYEN) values(N'Quản lý')

Insert into NHANSU values('QTV',N'Quản trị viên 1','02/02/2003',N'TP.HCM',N'Nam','0331546785','admin','1',1)
Insert into NHANSU values('QL01',N'Quản lý 1','08/21/2003',N'TP.HCM',N'Nam','0331546787','QL01','1',3)
Insert into NHANSU values('NV01',N'Nhân viên 1','12/08/2003',N'TP.HCM',N'Nữ','0331546782','NV01','1',2)

Insert into Phong(MaPhong,TenPhong,TrangThai) values('PH01',N'Phòng 1',350000)
Insert into Phong(MaPhong,TenPhong,TrangThai) values('PH02',N'Phòng 2',250000)
Insert into Phong(MaPhong,TenPhong,TrangThai) values('PH03',N'Phòng 3',300000)

Insert into DichVu values('DV01',N'Máy lạnh',50000);
Insert into DichVu values('DV02',N'Sử dụng hồ bơi',150000);
Insert into DichVu values('DV03',N'Massage thư giản',250000);

insert into DatPhong(MaDatPhong,MaPhong,NgayDat,NgayNhan,NgayTra) values('DP01','PH01','11/11/2023','11/12/2023','11/13/2023')
insert into DatPhong(MaDatPhong,MaPhong,NgayDat,NgayNhan,NgayTra) values('DP02','PH02','11/14/2023','11/15/2023','11/16/2023')
insert into DatPhong(MaDatPhong,MaPhong,NgayDat,NgayNhan,NgayTra) values('DP03','PH03','11/15/2023','11/18/2023','11/19/2023')

insert into KhachHang values('KH01',N'Hồ Trọng An',N'Vũng Tàu','0908751234','trongan@gmail.com')
insert into KhachHang values('KH02',N'Nguyễn Ngọc Anhs',N'Đồng Nai','0934178523','ngocanh@gmail.com')
insert into KhachHang values('KH03',N'HTrần Anh Khôi',N'TP.HCM','090102872','anhkhoi@gmail.com')

insert into DatDichVu(MaDichVu,MaDatPhong,SoLuong) values('DV01','DP01',2)
insert into DatDichVu(MaDichVu,MaDatPhong,SoLuong) values('DV02','DP02',4)
insert into DatDichVu(MaDichVu,MaDatPhong,SoLuong) values('DV03','DP03',1)

insert into HoaDon(MaHD,MaDatPhong,MAKH,MANV,Giamgia,TienCoc,NgayLap) VALUES('HD01','DP01','KH01','NV01',20000,100000,'12/06/2023')
insert into HoaDon(MaHD,MaDatPhong,MAKH,MANV,Giamgia,TienCoc,NgayLap) VALUES('HD02','DP02','KH02','NV01',20000,100000,'12/06/2023')
insert into HoaDon(MaHD,MaDatPhong,MAKH,MANV,Giamgia,TienCoc,NgayLap) VALUES('HD03','DP03','KH03','NV01',20000,100000,'12/06/2023')

GO
-------------Trigger------------------

---1.Trigger tự động cập nhật trạng thái hóa đơn khi Công nợ = 0

CREATE TRIGGER trg_CNTrangThaiHD ON HOADON
FOR INSERT,Update AS BEGIN
	UPDATE HoaDon
	SET Trangthai = N'Đã thanh toán'
	FROM inserted
	WHERE inserted.MaHD = HoaDon.MaHD AND HoaDon.CongNo = 0
END

----2.Trigger tự động cập nhật khi trạng thái phòng = 'Trống' khi trạng thái của hóa đơn = 'Đã thanh toán'

CREATE TRIGGER trg_CNPhongKhiCheckOut ON HoaDon
for Insert,Update
AS BEGIN
	UPDATE Phong
	SET TrangThai = N'Trống'
	FROM inserted
	join DatPhong DP ON DP.MaDatPhong = inserted.MaDatPhong
	WHERE DP.MaDatPhong = inserted.MaDatPhong AND DP.MaPhong = Phong.MaPhong AND inserted.Trangthai = N'Đã thanh toán'
END

--3.Trigger tự động cập nhật trạng thái phòng khi có người thuê

CREATE TRIGGER trg_CNPhongKhiDatPhong ON DatPhong
for Insert,Update
AS BEGIN
	UPDATE Phong
	SET TrangThai = N'Đang thuê'
	FROM inserted
	WHERE inserted.MaPhong = Phong.MaPhong
END

--4.Cập nhật thành tiền hóa đơn
CREATE TRIGGER tgr_CapNhatCongNo ON HoaDon
for INSERT AS BEGIN
	UPDATE HoaDon
	SET CongNo = (SELECT TongTien FROM inserted WHERE MaDatPhong = HoaDon.MaDatPhong) - (SELECT Giamgia FROM inserted WHERE MaDatPhong = HoaDon.MaDatPhong) - (SELECT TienCoc FROM inserted WHERE MaDatPhong = HoaDon.MaDatPhong)
	FROM inserted
	JOIN HoaDon ON HoaDon.MaDatPhong = inserted.MaDatPhong
END
go
--5.Cập thật thành tiền trong đặt phòng
CREATE TRIGGER tgr_CapNhatCNTHANHTIENDP ON DatPhong
for INSERT AS BEGIN
	UPDATE DatPhong
	SET ThanhTien = (select DonGia from Phong where Phong.MaPhong = inserted.MaPhong) 
	FROM inserted
	JOIN DatPhong ON DatPhong.MaDatPhong = inserted.MaDatPhong
END

-------------------------------------------------------------------------------------------------------------------------------------------



----QL NHANVIEN

---1.Proc lấy danh sách nhân viên khi truyền vào mã nhân viên(QL_NhanVien)

CREATE PROC dbo.LayDSNVTheoMa @manv varchar(10)
AS BEGIN
	SELECT  MANV,TENNV,NgaySinh,DiaChi,GT,SDT,USERNAME,PASS,TENQUYEN 
	from NHANSU,QUYEN 
	WHERE NHANSU.QUYEN = QUYEN.ID AND NHANSU.MaNV = @manv
END


---2.Lấy danh sách nhân viên(QL_NhanVien)
CREATE PROC dbo.LayDSNV
AS BEGIN
	SELECT  MANV,TENNV,NgaySinh,DiaChi,GT,SDT,USERNAME,PASS,TENQUYEN 
	from NHANSU,QUYEN 
	WHERE NHANSU.QUYEN = QUYEN.ID
END




---QL KHACH HANG


---1.Proc lấy danh sách hóa đơn của khách hàng khi truyền mà mã khách hàng(QL_KhachHang)

CREATE PROC dbo.LayDSHDCuaKH @makh varchar(10)
AS BEGIN
	SELECT HD.*
	from HoaDon HD
	JOIN KhachHang KH ON HD.MAKH = KH.MaKH
	WHERE HD.MAKH = @makh
END


----2.Lấy danh sách khách hàng(QL_KhachHang)
CREATE PROC dbo.LayDSKH
AS BEGIN
	SELECT  MAKH,TenKhach,SDT,DiaChi,email
	from KhachHang 
END

---3.Lấy danh sách KH theo mã(QL_KhachHang)
CREATE PROC dbo.LayDSKHTheoMa @makh varchar(10)
AS BEGIN
	SELECT  KH.* 
	from KhachHang KH 
	WHERE KH.MaKH = @makh
END
--==================================================================================================================


--QUANLY PHONG DV


--1.Lấy danh sách phòng(QL_PhongDV)
CREATE PROC dbo.LayDSPH
AS BEGIN
	SELECT  MaPhong,TenPhong,DonGia,TrangThai
	from Phong 
END
---2.Lấy danh sách phòng theo mã(QL_PhongDV)
CREATE PROC dbo.LayDSPHTheoMa @maph varchar(10)
AS BEGIN
	SELECT  MaPhong,TenPhong,DonGia,TrangThai
	from Phong 
	WHERE Phong.MaPhong = @maph
END
--3.Lấy danh sách dịch vụ(QL_PhongDV)
CREATE PROC dbo.LayDSDV
AS BEGIN
	SELECT  MaDichVu,TenDichVu,GiaDichVu
	from DichVu
END
--4.Lấy danh sách đặt phòng(QL_PhongDV)
CREATE PROC dbo.LayDSDP
AS BEGIN
	SELECT  DP.*
	from DatPhong DP
END
--5.Lấy danh sách dịch vụ theo mã(QL_PhongDV)
CREATE PROC dbo.LayDSDVTheoMa @madv varchar(10)
AS BEGIN
	SELECT  MaDichVu,TenDichVu,GiaDichVu
	from DichVu
	WHERE DichVu.MaDichVu = @madv
END

---QUANLY BAO CAO




---1.Lấy danh sách hóa đơn(QL_BaoCao)
CREATE PROC dbo.LayDSHDBC
AS BEGIN
	SELECT  MaHD,HD.MaDatPhong,DP.MaPhong,KH.MaKH,HD.TongTien,HD.NgayLap,NV.TenNV
	from HoaDon HD
	join DatPhong DP ON DP.MaDatPhong = HD.MaDatPhong 
	JOIN PHONG P ON DP.MaDatPhong = HD.MaDatPhong AND DP.MaPhong = P.MaPhong
	JOIN KhachHang KH ON KH.MaKH= HD.MAKH
	JOIN NHANSU NV ON NV.MaNV = HD.MANV
END

---2.PROC Lấy danh sách hóa đơn dịch vụ(QL_BaoCao)
CREATE PROC dbo.LayDSHDDVBC
AS BEGIN
	SELECT DDV.MaDatPhong,HD.MaHD,DDV.MaDichVu,DDV.SoLuong,DDV.ThanhTien,hd.NgayLap
	from DatDichVu DDV
	join DatPhong DP ON DP.MaDatPhong = DDV.MaDatPhong
	join HoaDon HD ON DP.MaDatPhong = HD.MaDatPhong AND DP.MaDatPhong = DDV.MaDatPhong
	
END
---3.Proc Đếm số lượng phòng đã được thuê(QL_BaoCao)
CREATE PROC dbo.DemSLPhongDuocThue
AS BEGIN
	SELECT Count(P.MaPhong) AS 'SL'
	from Phong P,DatPhong DP,HoaDon HD
	WHERE (P.MaPhong = DP.MaPhong AND HD.MaDatPhong = DP.MaDatPhong)
	GROUP BY P.MaPhong
	HAVING COUNT(P.MaPhong) > 0
	
END
---4.Proc Đếm số lượng khách đã thuê(QL_BaoCao)

CREATE PROC dbo.DemSLKH
AS BEGIN
	SELECT Count(KH.MaKH) AS 'SL'
	from KhachHang KH,HoaDon HD
	WHERE (KH.MaKH = HD.MAKH)
	GROUP BY KH.MaKH
	HAVING COUNT(KH.MaKH) > 0
	
END



---QUANLY NGHIEPVU


---1.Lấy danh sách hóa đơn(QL_HoaDon)
CREATE PROC dbo.LayDSHD
AS BEGIN
	SELECT  MaHD,P.TenPhong,KH.MaKH,TongTien,HD.Trangthai
	from HoaDon HD
	join DatPhong DP ON DP.MaDatPhong = HD.MaDatPhong 
	JOIN PHONG P ON DP.MaDatPhong = HD.MaDatPhong AND DP.MaPhong = P.MaPhong
	JOIN KhachHang KH ON KH.MaKH= HD.MAKH
END
---2.Proc Lấy danh sách hóa đơn(QL_CheckOut)
CREATE PROC dbo.LayDSHDCheckOut
AS BEGIN
	SELECT  MaHD,HD.MaDatPhong,DP.MaPhong,KH.MaKH,HD.TongTien,HD.NgayLap,KH.TenKhach,HD.Giamgia,NV.MaNV
	from HoaDon HD
	join DatPhong DP ON DP.MaDatPhong = HD.MaDatPhong 
	JOIN PHONG P ON DP.MaDatPhong = HD.MaDatPhong AND DP.MaPhong = P.MaPhong
	JOIN KhachHang KH ON KH.MaKH= HD.MAKH
	JOIN NHANSU NV ON NV.MaNV = HD.MaNV
	WHERE HD.Trangthai = N'Chưa thanh toán'
END


---3.Proc lấy danh sách dịch vụ theo của hóa đơn khi truyền vào mã hóa đơn(CheckOut)

CREATE PROC dbo.LayDSDVCheckOut @mahd varchar(10)
AS BEGIN
	SELECT  DDV.MaDichVu,DV.TenDichVu,DDV.SoLuong,DV.GiaDichVu,DDV.ThanhTien
	from DatDichVu DDV
	join DichVu DV ON DV.MaDichVu = DDV.MaDichVu
	JOIN DatPhong DP ON DP.MaDatPhong = DDV.MaDatPhong
	JOIN HoaDon HD ON HD.MaDatPhong = DP.MaDatPhong AND DP.MaDatPhong = DDV.MaDatPhong
	WHERE HD.MaHD = @mahd
END
---4.Function lấy danh sách hóa đơn chưa thanh toán(CheckOut)

CREATE FUNCTION fu_LayDSHDChuaThanhToan()
returns @ds table (
				MAHD VARCHAR(10),
				MADP VARCHAR(10),
				MP VARCHAR(10),
				MAKH VARCHAR(10),
				TT FLOAT,
				NL DATE,
				TENKH NVARCHAR(100),
				GG FLOAT,
				MANV VARCHAR(10)

)
AS BEGIN
	INSERT INTO @ds
	SELECT  MaHD,HD.MaDatPhong,DP.MaPhong,KH.MaKH,HD.TongTien,HD.NgayLap,KH.TenKhach,HD.Giamgia,NV.MaNV
	from HoaDon HD
	join DatPhong DP ON DP.MaDatPhong = HD.MaDatPhong 
	JOIN PHONG P ON DP.MaDatPhong = HD.MaDatPhong AND DP.MaPhong = P.MaPhong
	JOIN KhachHang KH ON KH.MaKH= HD.MAKH
	JOIN NHANSU NV ON NV.MaNV = HD.MaNV
	WHERE HD.Trangthai = N'Chưa thanh toán'
	RETURN
END

---5.Function tra cứu hóa đơn chưa thanh toán theo mã hóa đơn(có ứng dụng CheckOut)

CREATE FUNCTION fu_SearchDSHD(@mahd varchar(10))
returns @ds table (
				MAHD VARCHAR(10),
				MADP VARCHAR(10),
				MP VARCHAR(10),
				MAKH VARCHAR(10),
				TT FLOAT,
				NL DATE,
				TENKH NVARCHAR(100),
				GG FLOAT,
				MANV VARCHAR(10)

)
AS BEGIN
	INSERT INTO @ds
	SELECT  MaHD,HD.MaDatPhong,DP.MaPhong,KH.MaKH,HD.TongTien,HD.NgayLap,KH.TenKhach,HD.Giamgia,NV.MaNV
	from HoaDon HD
	join DatPhong DP ON DP.MaDatPhong = HD.MaDatPhong 
	JOIN PHONG P ON DP.MaDatPhong = HD.MaDatPhong AND DP.MaPhong = P.MaPhong
	JOIN KhachHang KH ON KH.MaKH= HD.MAKH
	JOIN NHANSU NV ON NV.MaNV = HD.MaNV
	WHERE HD.Trangthai = N'Chưa thanh toán' and HD.MaHD = @mahd
	RETURN
END
