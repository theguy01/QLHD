﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLHD.UI.ViewModels;
using DevExpress.XtraGrid.Views.Base;

namespace QLHD.UI.Views.Contractor
{
    [DevExpress.Utils.MVVM.UI.ViewType("ContractorCollectionView")]
    public partial class ContractorsView : UserControl
    {
        public ContractorsView()
        {
            InitializeComponent();
            var fluent = mvvmContext1.OfType<ContractorCollectionViewModel>();
            fluent.SetBinding(gridView1, gView => gView.LoadingPanelVisible, x => x.IsLoading);
            fluent.SetBinding(gridControl1, gControl => gControl.DataSource, x => x.Entities);
            fluent.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView1, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity, args => args.Row as QLHD.Model.Models.Contractor,
                (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
        }
    }
}
