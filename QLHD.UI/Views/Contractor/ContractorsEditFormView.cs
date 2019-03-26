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

namespace QLHD.UI.Views.Contractor
{
    [ViewType("ContractorView")]
    public partial class ContractorsEditFormView : UserControl
    {
        public ContractorsEditFormView()
        {
            InitializeComponent();
            var fluent = mvvmContext1.OfType<ContractorViewModel>();
            fluent.SetObjectDataSourceBinding(
                contractorBindingSource, x => x.Entity, x => x.Update());
        }

    }
}
