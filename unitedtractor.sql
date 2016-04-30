# Host: localhost  (Version: 5.5.36)
# Date: 2016-03-03 08:12:30
# Generator: MySQL-Front 5.3  (Build 4.4)

/*!40101 SET NAMES utf8 */;

#
# Source for table "hargasewa"
#

DROP TABLE IF EXISTS `hargasewa`;
CREATE TABLE `hargasewa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `Harga` double NOT NULL DEFAULT '0',
  `Aktif` enum('true','false') NOT NULL DEFAULT 'true',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "hargasewa"
#


#
# Source for table "history"
#

DROP TABLE IF EXISTS `history`;
CREATE TABLE `history` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Tanggal` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `Keterangan` tinytext NOT NULL,
  `PetugasID` int(11) NOT NULL DEFAULT '0',
  `PetugasName` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "history"
#


#
# Source for table "karyawan"
#

DROP TABLE IF EXISTS `karyawan`;
CREATE TABLE `karyawan` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NIK` varchar(20) NOT NULL DEFAULT '',
  `Nama` varchar(255) NOT NULL DEFAULT '',
  `Jabatan` varchar(255) NOT NULL DEFAULT '',
  `Alamat` tinytext NOT NULL,
  `Email` varchar(50) NOT NULL DEFAULT '',
  `Hp` varchar(20) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

#
# Data for table "karyawan"
#

INSERT INTO `karyawan` VALUES (2,'03404303430430','Yoseph Kungkung','Direktur','ini alamat','Ocph@gmail.com','0812334'),(3,'0003','Ajenk','Staf','asdadwasdasdwasdasd','ajenksj@yahoo.com','08111'),(9,'012312','Darman','Driver','Jln. Apa Khabar','asdasd@asdas.coasd','081345'),(10,'03404303430430','Yoseph Kungkung','Direktur','ini alamat','Ocph@gmail.com','0812334');

#
# Source for table "kategori"
#

DROP TABLE IF EXISTS `kategori`;
CREATE TABLE `kategori` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(15) NOT NULL DEFAULT '',
  `Nama` varchar(255) NOT NULL DEFAULT '',
  `Keterangan` tinytext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

#
# Data for table "kategori"
#

INSERT INTO `kategori` VALUES (1,'PKS','Perkakas','Ini Keterangan'),(2,'PJP','Penjepit','tolls Penjepit');

#
# Source for table "permintaan"
#

DROP TABLE IF EXISTS `permintaan`;
CREATE TABLE `permintaan` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(10) NOT NULL DEFAULT '',
  `KaryawanId` int(11) NOT NULL DEFAULT '0',
  `TglPengajuan` date NOT NULL DEFAULT '0000-00-00',
  PRIMARY KEY (`Id`),
  KEY `KaryawanId` (`KaryawanId`),
  CONSTRAINT `Permintaan_Karyawan` FOREIGN KEY (`KaryawanId`) REFERENCES `karyawan` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

#
# Data for table "permintaan"
#

INSERT INTO `permintaan` VALUES (19,'MNT-00002',2,'2016-02-23');

#
# Source for table "peminjaman"
#

DROP TABLE IF EXISTS `peminjaman`;
CREATE TABLE `peminjaman` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(10) NOT NULL DEFAULT '',
  `PermintaanId` int(11) NOT NULL DEFAULT '0',
  `TglMulai` date NOT NULL DEFAULT '0000-00-00',
  `TglKembali` date NOT NULL DEFAULT '0000-00-00',
  `KirimSuratPengambilan` enum('true','false') NOT NULL DEFAULT 'false',
  PRIMARY KEY (`Id`),
  KEY `PeminjamanDenganPermintaan` (`PermintaanId`),
  CONSTRAINT `PeminjamanDenganPermintaan` FOREIGN KEY (`PermintaanId`) REFERENCES `permintaan` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

#
# Data for table "peminjaman"
#

INSERT INTO `peminjaman` VALUES (14,'PNJ-00001',19,'2016-02-23','2016-02-26','false');

#
# Source for table "setting"
#

DROP TABLE IF EXISTS `setting`;
CREATE TABLE `setting` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DendaPerHari` double NOT NULL DEFAULT '0',
  `MaxPinjam` int(11) NOT NULL DEFAULT '0',
  `Actived` enum('true','false') NOT NULL DEFAULT 'false',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

#
# Data for table "setting"
#

INSERT INTO `setting` VALUES (1,15000,3,'true');

#
# Source for table "tolls"
#

DROP TABLE IF EXISTS `tolls`;
CREATE TABLE `tolls` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(10) NOT NULL DEFAULT '',
  `KategoriId` int(11) NOT NULL DEFAULT '0',
  `Nama` varchar(255) NOT NULL DEFAULT '',
  `Gambar` blob,
  `Keterangan` tinytext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `KategoryId` (`KategoriId`),
  CONSTRAINT `KategoryId` FOREIGN KEY (`KategoriId`) REFERENCES `kategori` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

#
# Data for table "tolls"
#

INSERT INTO `tolls` VALUES (1,'PKS-0001',1,'Kunci Rodal',X'','Ini Adalah Alat buka Roda'),(2,'PSK-0002',1,'Kunci Shok',X'','Serbaguna');

#
# Source for table "stock"
#

DROP TABLE IF EXISTS `stock`;
CREATE TABLE `stock` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `Jumlah` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `stockdengantolls` (`TollsId`),
  CONSTRAINT `stockdengantolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

#
# Data for table "stock"
#

INSERT INTO `stock` VALUES (3,1,7),(4,2,0);

#
# Source for table "permintaan_details"
#

DROP TABLE IF EXISTS `permintaan_details`;
CREATE TABLE `permintaan_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PermintaanID` int(11) NOT NULL DEFAULT '0',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `StatusTolls` enum('Ada','Terpakai','Tidak') NOT NULL DEFAULT 'Ada',
  PRIMARY KEY (`Id`),
  KEY `PermintaanID` (`PermintaanID`),
  KEY `TollsId` (`TollsId`),
  CONSTRAINT `DetailsDenganPermintaan` FOREIGN KEY (`PermintaanID`) REFERENCES `permintaan` (`Id`),
  CONSTRAINT `PermintaanDetailsDenganTolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

#
# Data for table "permintaan_details"
#

INSERT INTO `permintaan_details` VALUES (29,19,1,'Ada'),(30,19,2,'Ada');

#
# Source for table "peminjaman_details"
#

DROP TABLE IF EXISTS `peminjaman_details`;
CREATE TABLE `peminjaman_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PeminjamanId` int(11) NOT NULL DEFAULT '0',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `TelahKembali` enum('true','false') NOT NULL DEFAULT 'false',
  PRIMARY KEY (`Id`),
  KEY `PeminjamanId` (`PeminjamanId`),
  KEY `TollsId` (`TollsId`),
  CONSTRAINT `DetailsDenganPeminjaman` FOREIGN KEY (`PeminjamanId`) REFERENCES `peminjaman` (`Id`),
  CONSTRAINT `DetailsDenganTolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

#
# Data for table "peminjaman_details"
#

INSERT INTO `peminjaman_details` VALUES (23,14,1,'true'),(24,14,2,'true');

#
# Source for table "tollsdetails"
#

DROP TABLE IF EXISTS `tollsdetails`;
CREATE TABLE `tollsdetails` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `TransaksiId` int(11) NOT NULL DEFAULT '0',
  `NomorSeri` varchar(15) NOT NULL DEFAULT '',
  `HargaBeli` double NOT NULL DEFAULT '0',
  `Kondisi` int(3) NOT NULL DEFAULT '100',
  `BisaDipakai` enum('true','false') NOT NULL DEFAULT 'true',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

#
# Data for table "tollsdetails"
#

INSERT INTO `tollsdetails` VALUES (10,2,14,'PSK-00020001',100000,100,'true'),(11,2,14,'PSK-00020002',100000,100,'true'),(12,2,14,'PSK-00020003',100000,100,'true'),(13,1,15,'PKS-00010001',50000,100,'true'),(14,1,15,'PKS-00010002',50000,100,'true'),(15,1,15,'PKS-00010003',50000,100,'true'),(16,1,15,'PKS-00010004',50000,100,'true'),(17,1,15,'PKS-00010005',50000,100,'true'),(18,1,16,'PKS-00010006',500000,100,'true'),(19,1,16,'PKS-00010007',500000,100,'true');

#
# Source for table "transaksi_stock"
#

DROP TABLE IF EXISTS `transaksi_stock`;
CREATE TABLE `transaksi_stock` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Tanggal` date NOT NULL DEFAULT '0000-00-00',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `Jumlah` int(11) NOT NULL DEFAULT '0',
  `HargaBeli` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `TollsId` (`TollsId`),
  CONSTRAINT `transaksistockdengantolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

#
# Data for table "transaksi_stock"
#

INSERT INTO `transaksi_stock` VALUES (14,'2016-02-29',2,3,100000),(15,'2016-02-29',1,5,50000),(16,'2016-02-29',1,2,500000);

#
# Source for table "users"
#

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(100) NOT NULL DEFAULT '',
  `PasswordHash` tinytext NOT NULL,
  `AccessLevel` enum('Administrator','Keuangan','Gudang','User') NOT NULL DEFAULT 'Administrator',
  `Activate` enum('true','false') NOT NULL DEFAULT 'false',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

#
# Data for table "users"
#

INSERT INTO `users` VALUES (3,'admin','admin','Administrator','true'),(4,'gudang','gudang','Gudang','true');

#
# Source for table "pengembalian"
#

DROP TABLE IF EXISTS `pengembalian`;
CREATE TABLE `pengembalian` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `peminjamanid` int(11) NOT NULL DEFAULT '0',
  `TglKembali` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `PetugasId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `peminjamanid` (`peminjamanid`),
  KEY `PetugasId` (`PetugasId`),
  CONSTRAINT `PengembalianDenganPeminjaman` FOREIGN KEY (`peminjamanid`) REFERENCES `peminjaman` (`Id`),
  CONSTRAINT `pengembaliandenganpetugas` FOREIGN KEY (`PetugasId`) REFERENCES `users` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

#
# Data for table "pengembalian"
#

INSERT INTO `pengembalian` VALUES (8,14,'2016-02-23 01:51:27',3);

#
# Source for table "pengembalian_details"
#

DROP TABLE IF EXISTS `pengembalian_details`;
CREATE TABLE `pengembalian_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PengembalianId` int(11) NOT NULL DEFAULT '0',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `KeadaanTolls` enum('Baik','Hilang','Rusak') NOT NULL DEFAULT 'Baik',
  `Keterangan` tinytext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `PengembalianId` (`PengembalianId`),
  KEY `TollsId` (`TollsId`),
  CONSTRAINT `DetailDenganPengembalian` FOREIGN KEY (`PengembalianId`) REFERENCES `pengembalian` (`Id`),
  CONSTRAINT `PengembalianDetailsDenganTolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

#
# Data for table "pengembalian_details"
#

INSERT INTO `pengembalian_details` VALUES (23,8,1,'Baik',''),(24,8,2,'Rusak','');

#
# Source for table "pelanggaran"
#

DROP TABLE IF EXISTS `pelanggaran`;
CREATE TABLE `pelanggaran` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(10) NOT NULL DEFAULT '',
  `PeminjamanId` int(11) NOT NULL DEFAULT '0',
  `PengembalianId` int(11) DEFAULT NULL,
  `PetugasId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `PeminjamanId` (`PeminjamanId`),
  KEY `PengembalianId` (`PengembalianId`),
  KEY `PetugasId` (`PetugasId`),
  CONSTRAINT `pelanganggarandenganpengembalian` FOREIGN KEY (`PeminjamanId`) REFERENCES `pengembalian` (`Id`),
  CONSTRAINT `pelangarandenganpeminjaman` FOREIGN KEY (`PeminjamanId`) REFERENCES `peminjaman` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "pelanggaran"
#


#
# Source for table "pelanggaran_details"
#

DROP TABLE IF EXISTS `pelanggaran_details`;
CREATE TABLE `pelanggaran_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `pelanggaranId` int(11) NOT NULL DEFAULT '0',
  `JenisPelanggaran` enum('Menghilangkan','Merusakkan') NOT NULL DEFAULT 'Merusakkan',
  PRIMARY KEY (`Id`),
  KEY `pelanggaranId` (`pelanggaranId`),
  CONSTRAINT `DetailsDenganPelanggaran` FOREIGN KEY (`pelanggaranId`) REFERENCES `pelanggaran` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "pelanggaran_details"
#


#
# Source for table "denda"
#

DROP TABLE IF EXISTS `denda`;
CREATE TABLE `denda` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(255) NOT NULL DEFAULT '',
  `KaryawanId` int(11) NOT NULL DEFAULT '0',
  `PelanggaranId` int(11) NOT NULL DEFAULT '0',
  `Tanggal` date NOT NULL DEFAULT '0000-00-00',
  `Selesai` enum('true','false') NOT NULL DEFAULT 'false',
  `Petugas⁯Id` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `KaryawanId` (`KaryawanId`),
  KEY `PelanggaranId` (`PelanggaranId`),
  KEY `Petugas⁯Id` (`Petugas⁯Id`),
  CONSTRAINT `dendadengankaryawan` FOREIGN KEY (`KaryawanId`) REFERENCES `karyawan` (`Id`),
  CONSTRAINT `dendadenganpelanggaran` FOREIGN KEY (`KaryawanId`) REFERENCES `pelanggaran` (`Id`),
  CONSTRAINT `DendaDenganPetugas` FOREIGN KEY (`Petugas⁯Id`) REFERENCES `users` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "denda"
#


#
# Source for table "denda_details"
#

DROP TABLE IF EXISTS `denda_details`;
CREATE TABLE `denda_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DendaId` int(11) NOT NULL DEFAULT '0',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `Nilai` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `TollsId` (`TollsId`),
  KEY `detailsdengandenda` (`DendaId`),
  CONSTRAINT `detailsdengandenda` FOREIGN KEY (`DendaId`) REFERENCES `denda` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "denda_details"
#

