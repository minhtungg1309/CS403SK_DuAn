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
    [System.ComponentModel.DisplayName("Phiếu thu")]
    [ImageName("thu")]
    [DefaultProperty("SoCT")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Phieuthu : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Phieuthu(Session session)
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
        private Khachhang _khach;
        [XafDisplayName("Thu của")]
        [Association("khach-thu")]
        public Khachhang khach
        {
            get { return _khach; }
            set { SetPropertyValue<Khachhang>(nameof(khach), ref _khach, value); }
        }
        private Nhanvien _Ketoan;
        [XafDisplayName("Kế toán")]
        [Association("kt-thu")]
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
        private decimal _Sotien;
        [XafDisplayName("Số Tiền")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal Sotien
        {
            get { return _Sotien; }
            set { SetPropertyValue<decimal>(nameof(Sotien), ref _Sotien, value); }
        }
        private string _Ghichu;
        [XafDisplayName("Số CT"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }
    }
}