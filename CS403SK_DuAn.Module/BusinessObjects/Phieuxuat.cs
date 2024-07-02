using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace CS403SK_DuAn.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Phiếu xuất")]
    [ImageName("xuat")]
    [DefaultProperty("SoCT")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Phieuxuat : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Phieuxuat(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                NgayCT = DateTime.Now;
            }
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            Tinhtong();
        }
        private Khachhang _khach;
        [XafDisplayName("Nhà cung cấp")]
        [Association("khach-xuat")]
        public Khachhang khach
        {
            get { return _khach; }
            set { SetPropertyValue<Khachhang>(nameof(khach), ref _khach, value); }
        }
        private Nhanvien _Ketoan;
        [XafDisplayName("Kế toán")]
        [Association("kt-xuat")]
        public Nhanvien Ketoan
        {
            get { return _Ketoan; }
            set { SetPropertyValue<Nhanvien>(nameof(Ketoan), ref _Ketoan, value); }
        }

        private string _SoCT;
        [XafDisplayName("Số CT"), Size(20), RuleUniqueValue]
        public string SoCT
        {
            get { return _SoCT; }
            set { SetPropertyValue<string>(nameof(SoCT), ref _SoCT, value); }
        }
        private DateTime _NgayCT;
        [XafDisplayName("Ngày CT")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]

        public DateTime NgayCT
        {
            get { return _NgayCT; }
            set { SetPropertyValue<DateTime>(nameof(NgayCT), ref _NgayCT, value); }
        }
        private string _SoHD;
        [XafDisplayName("Số HĐ"), Size(20)]
        public string SoHD
        {
            get { return _SoHD; }
            set { SetPropertyValue<string>(nameof(SoHD), ref _SoHD, value); }
        }
        private DateTime _NgayHD;
        [XafDisplayName("Ngày HĐ")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]
        public DateTime NgayHD
        {
            get { return _NgayHD; }
            set { SetPropertyValue<DateTime>(nameof(NgayHD), ref _NgayHD, value); }
        }
        private string _Ghichu;
        [XafDisplayName("Ghi Chú"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }
        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Hàng Nhập")]
        public XPCollection<Dongxuat> Dongxuats
        {
            get { return GetCollection<Dongxuat>(nameof(Dongxuats)); }
        }
        private decimal _Tongtien;
        [XafDisplayName("Tổng tiền"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal Tongtien
        {
            get { return _Tongtien; }
            set { SetPropertyValue<decimal>(nameof(Tongtien), ref _Tongtien, value); }
        }
        public void Tinhtong()
        {
            decimal tong = 0;
            foreach (Dongxuat dong in Dongxuats)
            {
                tong += dong.Thanhtien;
            }
            Tongtien = tong;
        }
    }
}