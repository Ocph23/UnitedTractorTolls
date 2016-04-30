    using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedTractorLib.DTO
{

    [TableName("users")]
    public class UsersDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("Username")]
        public string Username { get; set; }

        [DbColumn("Passwordhash")]
        public string Passwordhash { get; set; }

        [DbColumn("Accesslevel")]
        public AccessLevel Accesslevel { get; set; }

        [DbColumn("Activate")]
        public bool Activate { get; set; }

        [DbColumn("Photo")]
        public byte[] Photo { get; set; }
    }

    [TableName("denda")]
    public class DendaDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("Kode")]
        public string Kode { get; set; }

        [DbColumn("Karyawanid")]
        public int Karyawanid { get; set; }

        [DbColumn("Pelanggaranid")]
        public int Pelanggaranid { get; set; }

        [DbColumn("Tanggal")]
        public DateTime Tanggal { get; set; }

        [DbColumn("Selesai")]
        public bool Selesai { get; set; }

        [DbColumn("PetugasId")]
        public int PetugasId { get; set; }
    }

    [TableName("denda_details")]
    public class DendaDetailDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("Dendaid")]
        public int Dendaid { get; set; }

        [DbColumn("Tollsid")]
        public int Tollsid { get; set; }

        [DbColumn("Nilai")]
        public double Nilai { get; set; }
    }

    [TableName("history")]
    public class HistoryDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("Tanggal")]
        public DateTime Tanggal { get; set; }

        [DbColumn("Keterangan")]
        public string Keterangan { get; set; }

        [DbColumn("Petugasid")]
        public int Petugasid { get; set; }

        [DbColumn("Petugasname")]
        public int Petugasname { get; set; }
    }

    [TableName("pelanggan")]
    public class CustomerDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("Nik")]
        public string Nik { get; set; }

        [DbColumn("Nama")]
        public string Nama { get; set; }

        [DbColumn("Jabatan")]
        public string Jabatan { get; set; }

        [DbColumn("Alamat")]
        public string Alamat { get; set; }

        [DbColumn("Email")]
        public string Email { get; set; }

        [DbColumn("Hp")]
        public string Hp { get; set; }

        [DbColumn("Photo")]
        public byte[] Photo { get; set; }
    }

    [TableName("pelanggaran")]
    public class PelanggaranDTO
    {
        [PrimaryKey("Id")]

        [DbColumn("Id")]
        public int Id { get; set; }


        [DbColumn("Kode")]
        public string Kode { get; set; }


        [DbColumn("Peminjamanid")]
        public int Peminjamanid { get; set; }


        [DbColumn("Pengembalianid")]
        public int Pengembalianid { get; set; }


        [DbColumn("Petugasid")]
        public int Petugasid { get; set; }

    }

    [TableName("pelanggaran_details")]
    public class PelanggaranDetailDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }


        [DbColumn("Pelanggaranid")]
        public int Pelanggaranid { get; set; }


        [DbColumn("Jenispelanggaran")]
        public JenisPelanggaran Jenispelanggaran { get; set; }

    }

    [TableName("peminjaman")]
    public class PeminjamanDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }


        [DbColumn("Kode")]
        public string Kode { get; set; }


        [DbColumn("Permintaanid")]
        public int Permintaanid { get; set; }


        [DbColumn("Tglmulai")]
        public DateTime Tglmulai { get; set; }


        [DbColumn("Tglkembali")]
        public DateTime Tglkembali { get; set; }


        [DbColumn("PengambilanKomplet")]
        public bool Completed { get; set; }

    }

    [TableName("peminjaman_details")]
    public class PeminjamanDetailDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("Peminjamanid")]
        public int Peminjamanid { get; set; }

        [DbColumn("Tollsid")]
        public int Tollsid { get; set; }

        [DbColumn("TollsItemId")]
        public int TollsItemId { get; set; }

        [DbColumn("TelahKembali")]
        public bool IsReturnBack { get; set; }

        [DbColumn("SewaId")]
        public int SewaId { get; set; }

      
    }

    [TableName("pengembalian")]
    public class PengembalianDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }


        [DbColumn("Peminjamanid")]
        public int Peminjamanid { get; set; }


        [DbColumn("Tglkembali")]
        public DateTime Tglkembali { get; set; }


        [DbColumn("Petugasid")]
        public int Petugasid { get; set; }

    }

    [TableName("pengembalian_details")]
    public class PengembalianDetailDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

      
        [DbColumn("Pengembalianid")]
        public int Pengembalianid { get; set; }

        [DbColumn("Tollsid")]
        public int Tollsid { get; set; }

        [DbColumn("TollsItemId")]
        public int TollsItemId { get; set; }

        [DbColumn("Keadaantolls")]
        public StatusTolls Keadaantolls { get; set; }

        [DbColumn("Keterangan")]
        public string Keterangan { get; set; }

    }

    [TableName("permintaan")]
    public class PermintaanDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }


        [DbColumn("Kode")]
        public string Kode { get; set; }


        [DbColumn("Karyawanid")]
        public int Karyawanid { get; set; }


        [DbColumn("Tglpengajuan")]
        public DateTime Tglpengajuan { get; set; }

    }

    [TableName("permintaan_details")]
    public class PermintaanDetailDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }


        [DbColumn("PermintaanID")]
        public int Permintaanid { get; set; }


        [DbColumn("Tollsid")]
        public int Tollsid { get; set; }


        [DbColumn("Statustolls")]
        public StatusStock Statustolls { get; set; }

    }

    [TableName("stock")]
    public class StockDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }


        [DbColumn("Tollsid")]
        public int Tollsid { get; set; }


        [DbColumn("Jumlah")]
        public int Jumlah { get; set; }

    }

    [TableName("setting")]
    public class SettingDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("Dendaperhari")]
        public double Dendaperhari { get; set; }

        [DbColumn("Maxpinjam")]
        public int Maxpinjam { get; set; }


         [DbColumn("Actived")]
        public bool Actived { get; internal set; }
    }

    [TableName("transaksi_stock")]
    public class TransaksiStockDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }


        [DbColumn("Tanggal")]
        public DateTime Tanggal { get; set; }


        [DbColumn("Tollsid")]
        public int Tollsid { get; set; }


        [DbColumn("Jumlah")]
        public int Jumlah { get; set; }

        [DbColumn("HargaBeli")]
        public double HargaBeli { get; set; }

    }

    [TableName("kategori")]
    public class KategoriDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("Kode")]
        public string Kode { get; set; }

        [DbColumn("Nama")]
        public string Nama { get; set; }

        [DbColumn("Keterangan")]
        public string Keterangan { get; set; }
    }

    [TableName("tolls")]
    public class TollsDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("Kode")]
        public string Kode { get; set; }

        [DbColumn("Kategoriid")]
        public int Kategoriid { get; set; }


        [DbColumn("Nama")]
        public string Nama { get; set; }


        [DbColumn("Gambar")]
        public byte[] Gambar { get; set; }


        [DbColumn("Keterangan")]
        public string Keterangan { get; set; }

    }


    [TableName("TollsDetails")]
    public class TollsDetailsDTO
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id { get; set; }

        [DbColumn("TollsId")]
        public int TollsId { get; set; }

        [DbColumn("TransaksiId")]
        public int TransaksiId { get; set; }

        [DbColumn("NomorSeri")]
        public string NomorSeri { get; set; }

        [DbColumn("HargaBeli")]
        public double HargaBeli { get; set; }

        [DbColumn("Kondisi")]
        public int Kondisi { get; set; }

        public bool CanUse { get; set; }

        [DbColumn("Status")]
        public StatusTolls Status { get; set; }

        [DbColumn("StatusDiStok")]
        public StatusStock StatusInStock { get; set; }
    }

    [TableName("hargasewa")]
    public class HargaSewaDTO:ViewModelBase
    {
        private int id;
        private int tollsId;
        private double harga;
        private double denda;
        private bool isActived;

        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        [DbColumn("TollsId")]
        public int TollsId
        {
            get
            {
                return tollsId;
            }

            set
            {
                tollsId = value;
                OnPropertyChanged("TollsId");
            }
        }

        [DbColumn("Harga")]
        public double Harga
        {
            get
            {
                return harga;
            }

            set
            {
                harga = value;
                OnPropertyChanged("Harga");
            }
        }

        [DbColumn("Denda")]
        public double Denda
        {
            get
            {
                return denda;
            }

            set
            {
                denda = value;
                OnPropertyChanged("Denda");
            }
        }

        [DbColumn("Aktif")]
        public bool IsActived
        {
            get
            {
                return isActived;
            }

            set
            {
                isActived = value;
                OnPropertyChanged("IsActived");
            }
        }
    }

}