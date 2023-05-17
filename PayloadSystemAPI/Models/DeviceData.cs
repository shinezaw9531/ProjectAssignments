using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PayloadSystemAPI.Models
{
    public class DeviceData
    {
        [Key]
        public int Id { get; set; }
        public string? DeviceId { get; set; }
        public string? DeviceType { get; set; }
        public string? DeviceName { get; set; }
        public string? GroupId { get; set; }
        public string? DataType { get; set; }
        public Data? Data { get; set; }
        public long Timestamp { get; set; }
    }

    [Owned]
    public class Data
    {
        [Column("FullPowerMode")]
        public bool? FullPowerMode { get; set; } = null;
        [Column("ActivePowerControl")]
        public bool? ActivePowerControl { get; set; } = null;
        [Column("FirmwareVersion")]
        public int? FirmwareVersion { get; set; } = null;
        [Column("Temperature")]
        public int? Temperature { get; set; } = null;
        [Column("Humidity")]
        public int? Humidity { get; set; } = null;
        [Column("Version")]
        public int? Version { get; set; } = null;
        [Column("MessageType")]
        public string? MessageType { get; set; } = null;
        [Column("Occupancy")]
        public bool? Occupancy { get; set; } = null;
        [Column("StateChanged")]
        public int? StateChanged { get; set; } = null;

    }
    public class UpdateDeviceData
    {
        public string? DeviceId { get; set; }
        public string? DeviceType { get; set; }
        public string? DeviceName { get; set; }
        public string? GroupId { get; set; }
        public string? DataType { get; set; }
        public Data? Data { get; set; }
        public long Timestamp { get; set; }
    }
}
