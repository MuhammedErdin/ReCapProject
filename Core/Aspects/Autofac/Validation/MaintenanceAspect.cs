using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class MaintenanceAspect : MethodInterception
    {
        private readonly DayOfWeek _maintenanceDay;

        public MaintenanceAspect(DayOfWeek maintenanceDay)
        {
            _maintenanceDay = maintenanceDay;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            if (IsMaintenanceTime())
            {
                throw new Exception("Sistem Bakımda!");
            }
        }

        private bool IsMaintenanceTime()
        {
            return DateTime.Now.DayOfWeek == _maintenanceDay;
        }
    }
}
