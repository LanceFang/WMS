﻿using System;
using Abp.Extensions;
using Abp.Runtime.Validation;
using Abp.Timing;
using BM.WMS.Dto;

namespace BM.WMS.Auditing.Dto
{
    public class GetAuditLogsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string UserName { get; set; }

        public string ServiceName { get; set; }

        public string MethodName { get; set; }

        public string BrowserInfo { get; set; }

        public bool? HasException { get; set; }

        public int? MinExecutionDuration { get; set; }

        public int? MaxExecutionDuration { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = $"{sort} {order}" ?? "ExecutionTime DESC";// 
            }

            if (Sorting.IndexOf("UserName", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                Sorting = "User." + Sorting;
            }
            else
            {
                //Abp.Logging.LogHelper.Logger.Debug("11111111111");
                Sorting = "AuditLog." + Sorting;
            }

            if (StartDate == DateTime.MinValue)
            {
                StartDate = Clock.Now;
            }

            StartDate = StartDate.Date;

            if (EndDate == DateTime.MinValue)
            {
                EndDate = Clock.Now;
            }

            EndDate = EndDate.AddDays(1).Date;
        }
    }
}