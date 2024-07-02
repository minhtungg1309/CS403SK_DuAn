using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.XtraRichEdit.Model;
using System;
using System.ComponentModel;
using System.Linq;

namespace CS403SK_DuAn.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("Khach")]
    [System.ComponentModel.DisplayName("Khách hàng")]
    [DefaultProperty("TenKh")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Khachhang : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Khachhang(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private NhomKhach _Nhom;
        [XafDisplayName("Nhóm")]
        [Association]
        public NhomKhach Nhom
        {
            get { return _Nhom; }
            set { SetPropertyValue<NhomKhach>(nameof(Nhom), ref _Nhom, value); }
        }
        private string _TenKh;
        [XafDisplayName("Tên Khách hàng"), Size(255)]
        public string TenKh
        {
            get { return _TenKh; }
            set { SetPropertyValue<string>(nameof(TenKh), ref _TenKh, value); }
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
        [DevExpress.Xpo.Aggregated, Association("khach-chi")]
        [XafDisplayName("Phiếu chi")]
        public XPCollection<Phieuchi> Phieuchis
        {
            get { return GetCollection<Phieuchi>(nameof(Phieuchis)); }
        }
        [DevExpress.Xpo.Aggregated, Association("khach-thu")]
        [XafDisplayName("Phiếu thu")]
        public XPCollection<Phieuthu> Phieuthus
        {
            get { return GetCollection<Phieuthu>(nameof(Phieuthus)); }
        }
        [DevExpress.Xpo.Aggregated, Association("khach-nhap")]
        [XafDisplayName("Phiếu nhập")]
        public XPCollection<Phieunhap> Phieunhaps
        {
            get { return GetCollection<Phieunhap>(nameof(Phieunhaps)); }
        }

        [DevExpress.Xpo.Aggregated, Association("khach-xuat")]
        [XafDisplayName("Phiếu xuất")]
        public XPCollection<Phieuxuat> Phieuxuats
        {
            get { return GetCollection<Phieuxuat>(nameof(Phieuxuats)); }
        }

    }
}

