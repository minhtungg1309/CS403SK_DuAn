﻿using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace CS403SK_DuAn.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Hàng Hóa")]
    [ImageName("product")]
    [DefaultProperty("TenSP")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Sanpham : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Sanpham(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private NhomSP _Nhom;
        [Association]
        [XafDisplayName("Nhóm")]
        public NhomSP Nhom
        {
            get { return _Nhom; }
            set { SetPropertyValue<NhomSP>(nameof(Nhom), ref _Nhom, value); }
        }
        private string _Masp;
        [XafDisplayName("Mã"), Size(20)]
        [RuleRequiredField("Yeucau MaSP", DefaultContexts.Save, "Phải có Mã sản phẩm")]
        [RuleUniqueValue, Indexed(Unique = true)]
        public string Masp
        {
            get { return _Masp; }
            set { SetPropertyValue<string>(nameof(Masp), ref _Masp, value); }
        }
        private string _Mavach;
        [XafDisplayName("Mã vạch"), Size(20)]
        public string Mavach
        {
            get { return _Mavach; }
            set { SetPropertyValue<string>(nameof(Mavach), ref _Mavach, value); }
        }
        private string _TenSP;
        [XafDisplayName("Tên Hàng"), Size(255)]
        public string TenSP
        {
            get { return _TenSP; }
            set { SetPropertyValue<string>(nameof(TenSP), ref _TenSP, value); }
        }
        private string _Dvt;
        [XafDisplayName("Đvt"), Size(10)]
        public string Dvt
        {
            get { return _Dvt; }
            set { SetPropertyValue<string>(nameof(Dvt), ref _Dvt, value); }
        }
        private double _Vat;
        [XafDisplayName("Vat")]
        public double Vat
        {
            get { return _Vat; }
            set { SetPropertyValue<double>(nameof(Vat), ref _Vat, value); }
        }
        private decimal _Giaban;
        [XafDisplayName("Giá bán")]
        public decimal Giaban
        {
            get { return _Giaban; }
            set { SetPropertyValue<decimal>(nameof(Giaban), ref _Giaban, value); }
        }
        private double _Soton;
        [XafDisplayName("Số lượng tồn"), ModelDefault("AllowEdit", "false")]
        public double Soton
        {
            get { return _Soton; }
            set { SetPropertyValue<double>(nameof(Soton), ref _Soton, value); }
        }
        private decimal _Giatriton;
        [XafDisplayName("Giá trị tồn"), ModelDefault("AllowEdit", "false")]
        public decimal Giatriton
        {
            get { return _Giatriton; }
            set { SetPropertyValue<decimal>(nameof(Giatriton), ref _Giatriton, value); }
        }
        private string _Ghichu;
        [XafDisplayName("Ghi chú"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }
        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName(" Nhập")]
        public XPCollection<Dongnhap> Dongnhaps
        {
            get { return GetCollection<Dongnhap>(nameof(Dongnhaps)); }
        }
        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName(" xuat")]
        public XPCollection<Dongxuat> Dongxuats
        {
            get { return GetCollection<Dongxuat>(nameof(Dongxuats)); }
        }
    }
}

