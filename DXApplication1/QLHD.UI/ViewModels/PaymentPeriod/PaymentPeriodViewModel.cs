﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using QLHD.UI.QLHDDbContextDataModel;
using QLHD.UI.Common;
using QLHD.Model.Models;

namespace QLHD.UI.ViewModels {

    /// <summary>
    /// Represents the single PaymentPeriod object view model.
    /// </summary>
    public partial class PaymentPeriodViewModel : SingleObjectViewModel<PaymentPeriod, int, IQLHDDbContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of PaymentPeriodViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static PaymentPeriodViewModel Create(IUnitOfWorkFactory<IQLHDDbContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new PaymentPeriodViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the PaymentPeriodViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the PaymentPeriodViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected PaymentPeriodViewModel(IUnitOfWorkFactory<IQLHDDbContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.PaymentPeriods, x => x.Name) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Contracts for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Contract> LookUpContracts {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (PaymentPeriodViewModel x) => x.LookUpContracts,
                    getRepositoryFunc: x => x.Contracts);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of PaymentTypes for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<PaymentType> LookUpPaymentTypes {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (PaymentPeriodViewModel x) => x.LookUpPaymentTypes,
                    getRepositoryFunc: x => x.PaymentTypes);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Invoices for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Invoice> LookUpInvoices {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (PaymentPeriodViewModel x) => x.LookUpInvoices,
                    getRepositoryFunc: x => x.Invoices);
            }
        }


        /// <summary>
        /// The view model for the PaymentPeriodInvoices detail collection.
        /// </summary>
        public CollectionViewModelBase<Invoice, Invoice, int, IQLHDDbContextUnitOfWork> PaymentPeriodInvoicesDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (PaymentPeriodViewModel x) => x.PaymentPeriodInvoicesDetails,
                    getRepositoryFunc: x => x.Invoices,
                    foreignKeyExpression: x => x.PaymentPeriodId,
                    navigationExpression: x => x.PaymentPeriod);
            }
        }
    }
}
