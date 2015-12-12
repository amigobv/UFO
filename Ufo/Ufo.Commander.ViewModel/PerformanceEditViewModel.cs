using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.ViewModel
{
    public class PerformanceEditViewModel: ViewModelBase
    {
        private PerformanceViewModel performanceVm;

        public PerformanceEditViewModel(IManager manager)
        {
            performanceVm = new PerformanceViewModel(manager);
        }

        public PerformanceEditViewModel(Performance performance, IManager manager)
        {
            performanceVm = new PerformanceViewModel(performance, manager);
        }

        public PerformanceViewModel Performance
        {
            get { return performanceVm; }
            set
            {
                if (performanceVm != value)
                {
                    performanceVm = value;
                    RaisePropertyChangedEvent(nameof(Performance));
                }
            }
        }

    }
}
