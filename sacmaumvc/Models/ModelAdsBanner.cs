using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace sacmaumvc.Models
{
    public class ModelAdsBanner
    {
        public virtual ObjectResult<usp_AdsBanner_SelectOne_Result> usp_AdsBanner_SelectAll(Nullable<int> startRowIndex, Nullable<int> endRowIndex, Nullable<int> adsCategoryID, string companyName, string website, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, Nullable<bool> isAvailable, Nullable<bool> priority, Nullable<bool> sortByPriority)
        {
            var startRowIndexParameter = startRowIndex.HasValue ?
                new ObjectParameter("StartRowIndex", startRowIndex) :
                new ObjectParameter("StartRowIndex", typeof(int));

            var endRowIndexParameter = endRowIndex.HasValue ?
                new ObjectParameter("EndRowIndex", endRowIndex) :
                new ObjectParameter("EndRowIndex", typeof(int));

            var adsCategoryIDParameter = adsCategoryID.HasValue ?
                new ObjectParameter("AdsCategoryID", adsCategoryID) :
                new ObjectParameter("AdsCategoryID", typeof(int));

            var companyNameParameter = companyName != null ?
                new ObjectParameter("CompanyName", companyName) :
                new ObjectParameter("CompanyName", typeof(string));

            var websiteParameter = website != null ?
                new ObjectParameter("Website", website) :
                new ObjectParameter("Website", typeof(string));

            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));

            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));

            var isAvailableParameter = isAvailable.HasValue ?
                new ObjectParameter("IsAvailable", isAvailable) :
                new ObjectParameter("IsAvailable", typeof(bool));

            var priorityParameter = priority.HasValue ?
                new ObjectParameter("Priority", priority) :
                new ObjectParameter("Priority", typeof(bool));

            var sortByPriorityParameter = sortByPriority.HasValue ?
                new ObjectParameter("SortByPriority", sortByPriority) :
                new ObjectParameter("SortByPriority", typeof(bool));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_AdsBanner_SelectOne_Result>("usp_AdsBanner_SelectAll", startRowIndexParameter, endRowIndexParameter, adsCategoryIDParameter, companyNameParameter, websiteParameter, fromDateParameter, toDateParameter, isAvailableParameter, priorityParameter, sortByPriorityParameter);
        }
    }
}