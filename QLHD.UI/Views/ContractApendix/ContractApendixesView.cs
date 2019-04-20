﻿using DevExpress.Utils.MVVM.UI;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using QLHD.UI.ViewModels;
using QLHD.UI.Views.Commons;
using System;
using System.Collections.Generic;

namespace QLHD.UI.Views.ContractApendix
{
    [ViewType("ContractApendixCollectionView")]
    public partial class ContractApendixesView : DevExpress.XtraEditors.XtraUserControl
    {
        public ContractApendixesView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
            CustomizeGridView();
        }
        void CustomizeGridView()
        {
            GridView gv = (GridView)gridControl1.MainView;
            GridControlConfig.SetColumnsHide(gv, new List<string> { "ContractId" });
            gv.Columns["Contract"].GroupIndex = 0;
            //gv.BestFitColumns();
        }
        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<ContractApendixCollectionViewModel>();
            fluent.SetBinding(gridView1, gView => gView.LoadingPanelVisible, x => x.IsLoading);
            fluent.SetBinding(gridControl1, gControl => gControl.DataSource, x => x.Entities);
            fluent.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView1, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity, args => args.Row as QLHD.Model.Models.ContractApendix,
                (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
        }

        private void gridControl1_DataSourceChanged(object sender, EventArgs e)
        {
            GridControl gc = (GridControl)sender;
            GridView gv = (GridView)gc.MainView;
            gv.BestFitColumns();
        }
    }
}