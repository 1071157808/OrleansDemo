﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrleansDemo.API.ViewModels
{
    public class DeviceViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DeviceType { get; set; }
        public bool Enabled { get; set; }
        public bool RunOnStartup { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public IEnumerable<ReadingViewModel> Readings { get; set; } = new List<ReadingViewModel>();
    }

    public class ReadingViewModel
    {
        public Guid Id { get; set; }
        public int ReadingTypeId { get; set; }
        public string ReadyingType { get; set; }
        public string ReadingUom { get; set; }
        public string ReadingDataType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}