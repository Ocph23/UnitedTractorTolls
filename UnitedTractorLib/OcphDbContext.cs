using DAL.DContext;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedTractorLib.DTO;

namespace UnitedTractorLib
{
    public class OcphDbContext : IDbContext, IDisposable
    {
        private string connectionString = "Server=localhost;database=unitedtractor;UID=root;password=;CharSet=utf8;Persist Security Info=True";
        private IDbConnection _Connection = null;

        public OcphDbContext()
        {

        }

        public IRepository<DendaDTO> Dendas { get { return new Repository<DendaDTO>(this); } }
        public IRepository<DendaDetailDTO> DendaDetails { get { return new Repository<DendaDetailDTO>(this); } }
        public IRepository<HistoryDTO> Histories { get { return new Repository<HistoryDTO>(this); } }
        public IRepository<PelanggaranDTO> Pelanggarans { get { return new Repository<PelanggaranDTO>(this); } }
        public IRepository<PelanggaranDetailDTO> PelanggaranDetails { get { return new Repository<PelanggaranDetailDTO>(this); } }
        public IRepository<PeminjamanDTO> Peminjamans { get { return new Repository<PeminjamanDTO>(this); } }
        public IRepository<PeminjamanDetailDTO> PeminjamanDetails { get { return new Repository<PeminjamanDetailDTO>(this); } }
        public IRepository<PengembalianDTO> Pengembalians { get { return new Repository<PengembalianDTO>(this); } }
        public IRepository<PengembalianDetailDTO> PengembalianDetails{ get { return new Repository<PengembalianDetailDTO>(this); } }
        public IRepository<PermintaanDTO> Permintaans { get { return new Repository<PermintaanDTO>(this); } }
        public IRepository<PermintaanDetailDTO> PermintaanDetails { get { return new Repository<PermintaanDetailDTO>(this); } }
        public IRepository<StockDTO> Stocks { get { return new Repository<StockDTO>(this); } }
        public IRepository<SettingDTO> Settings { get { return new Repository<SettingDTO>(this); } }
        public IRepository<TransaksiStockDTO> TransaksiStocks { get { return new Repository<TransaksiStockDTO>(this); } }
        public IRepository<KategoriDTO> Kategories { get { return new Repository<KategoriDTO>(this); } }
        public IRepository<TollsDTO> Tolles { get { return new Repository<TollsDTO>(this); } }
        public IRepository<CustomerDTO> Customers { get { return new Repository<CustomerDTO>(this); } }
        public IRepository<UsersDTO> Users { get { return new Repository<UsersDTO>(this); } }
        public IRepository<TollsDetailsDTO> TollsDetails { get { return new Repository<TollsDetailsDTO>(this); } }
        public IRepository<HargaSewaDTO> HargaSewas { get { return new Repository<HargaSewaDTO>(this); } }
             




        public IDbConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new MySqlDbContext(this.connectionString);
                    return _Connection;
                }
                else
                {
                    return _Connection;
                }
            }
        }

        public void Dispose()
        {
            if (_Connection != null)
            {
                if (this.Connection.State != ConnectionState.Closed)
                {
                    this.Connection.Close();
                }
            }
        }

    }
}
