using System;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.ViewModels
{
    public class ServiceStatusLogViewModel
    {
        public ServiceStatusLogViewModel()
        {
        }
        
        public Int32? ServiceStatusLogID { get; set; }
        
        public Int32? ServiceID { get; set; }
        
        public String Target { get; set; }
        
        public String ActionName { get; set; }
        
        public Boolean? Success { get; set; }
        
        public String Message { get; set; }
        
        public String StackTrace { get; set; }
        
        public DateTime? Date { get; set; }
    }
    
    public static class ServiceStatusLogViewModelMapper
    {
        public static ServiceStatusLog ToEntity(this ServiceStatusLogViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceStatusLogViewModel, ServiceStatusLog>(viewModel);
        }
        
        public static ServiceStatusLogViewModel ToViewModel(this ServiceStatusLog entity)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceStatusLog, ServiceStatusLogViewModel>(entity);
        }
    }
}
