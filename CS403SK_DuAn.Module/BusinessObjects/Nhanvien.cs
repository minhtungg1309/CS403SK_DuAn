using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace CS403SK_DuAn.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("nhanvien")]
    [System.ComponentModel.DisplayName("Nhân viên")]
    [DefaultProperty("Hoten")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Nhanvien : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Nhanvien(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string _Taikhoan;
        [XafDisplayName("Tài Khoản"), Size(12)]
        public string Taikhoan
        {
            get { return _Taikhoan; }
            set { SetPropertyValue<string>(nameof(Taikhoan), ref _Taikhoan, value); }
        }


        private string _Hoten;
        [XafDisplayName("Tên Khách hàng"), Size(255)]
        public string Hoten
        {
            get { return _Hoten; }
            set { SetPropertyValue<string>(nameof(Hoten), ref _Hoten, value); }
        }
        private string _Diachi;
        [XafDisplayName("Địa chỉ"), Size(255)]
        public string Diachi
        {
            get { return _Diachi; }
            set { SetPropertyValue<string>(nameof(Diachi), ref _Diachi, value); }
        }
        private string _DienThoai;
        [XafDisplayName("Điện thoại"), Size(50)]
        public string DienThoai
        {
            get { return _DienThoai; }
            set { SetPropertyValue<string>(nameof(DienThoai), ref _DienThoai, value); }
        }
        private string _Email;
        [XafDisplayName("Email"), Size(255)]
        public string Email
        {
            get { return _Email; }
            set { SetPropertyValue<string>(nameof(Email), ref _Email, value); }
        }
        private string _Ghichu;
        [XafDisplayName("Ghi chú"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }
        [DevExpress.Xpo.Aggregated, Association("kt-chi")]
        [XafDisplayName("Phiếu chi")]
        public XPCollection<Phieuchi> Phieuchis
        {
            get { return GetCollection<Phieuchi>(nameof(Phieuchis)); }
        }
        [DevExpress.Xpo.Aggregated, Association("kt-thu")]
        [XafDisplayName("Phiếu thu")]
        public XPCollection<Phieuthu> Phieuthus
        {
            get { return GetCollection<Phieuthu>(nameof(Phieuthus)); }
        }
        [DevExpress.Xpo.Aggregated, Association("kt-nhap")]
        [XafDisplayName("Phiếu nhập")]
        public XPCollection<Phieunhap> Phieunhaps
        {
            get { return GetCollection<Phieunhap>(nameof(Phieunhaps)); }
        }
        [DevExpress.Xpo.Aggregated, Association("kt-xuat")]
        [XafDisplayName("Phiếu xuất")]
        public XPCollection<Phieuxuat> Phieuxuats
        {
            get { return GetCollection<Phieuxuat>(nameof(Phieuxuats)); }
        }

    }
}