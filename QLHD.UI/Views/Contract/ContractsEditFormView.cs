﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM.UI;
using QLHD.UI.ViewModels;

namespace QLHD.UI.Views.Contract
{
    [ViewType("ContractView")]
    public partial class ContractsEditFormView : UserControl
    {
        public ContractsEditFormView()
        {
            InitializeComponent();
            var fluent = mvvmContext1.OfType<ContractViewModel>();
            fluent.SetObjectDataSourceBinding(
                contractBindingSource, x => x.Entity, x => x.Update());
        }
    }
}