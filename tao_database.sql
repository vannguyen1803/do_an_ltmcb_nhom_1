create database dbltm;
use dbltm;

create table NguoiDung(
	MaND int not null primary key,
	Username varchar(50),
	Pass varchar(100),
	HoTen nvarchar(100),
	email varchar(100),
	NgayTao datetime,
	TrangThai bit
);

create table ThoiGianBieu (
	MaTGB int primary key,
	MaND int,
	TenTGB nvarchar(100),
	KieuLich nvarchar(20),
	NgayBD date,
	NgayKT date
);
--Khoa ngoai thoi gian bieu
alter table ThoiGianBieu add foreign key(MaND) references NguoiDung(MaND);

create table ChiTiet_TGB(
	MaCT int not null,
	MaTGB int,
	MonHoc nvarchar(100),
	NoiDung nvarchar(200),
	GioBD time,
	GioKT time,
	GhiChu nvarchar (200),
	constraint pk_ct primary key (MaCT, MaTGB)
);

create table MucTieu(
	MaMT int primary key,
	MaND int,
	TenMT nvarchar(100),
	Loai nvarchar(20),
	MoTa nvarchar(200),
	NgayBD date,
	NgayKT date,
	TrangThai nvarchar(20)
);
alter table MucTieu add foreign key(MaND) references NguoiDung(MaND);

create table NhacNho(
	MaNN int primary key,
	MaND int,
	NoiDung nvarchar(200),
	ThoiGianNN datetime,
	TrangThai bit
)
alter table NhacNho add foreign key (MaND) references NguoiDung(MaND);

create table NhatKyHoc(
	MaNK int primary key,
	MaND int,
	NgayGhi date,
	NoiDung nvarchar(MAX),
	DanhGia nvarchar(100),
	TienBo nvarchar(200)
);
alter table NhatKyHoc add foreign key (MaND) references NguoiDung(MaND);

create table Pomodoro (
	MaPomodoro int primary key,
	MaND int,
	NgayThucHien date,
	SoPhien int,
	TongThoiGian int
)
alter table Pomodoro add foreign key (MaND) references NguoiDung(MaND);

create table GioHoc(
	MaGH int primary key,
	MaND int,
	Ngay date,
	TongGioHoc int
)
alter table GioHoc add foreign key (MaND) references NguoiDung(MaND);

create table LichSu_DangNhap(
	MaLS int primary key,
	MaND int,
	ThoiGianDangNhap datetime,
	ThoiGianDangXuat datetime default NULL,
	DiaChiIP varchar(50),
	ThietBi nvarchar(20)
)
alter table LichSu_DangNhap add foreign key (MaND) references NguoiDung(MaND);
