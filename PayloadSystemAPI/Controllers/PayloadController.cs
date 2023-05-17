using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayloadSystemAPI.Data;
using PayloadSystemAPI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaymentSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayloadController : ControllerBase
    {
        private readonly PayloadAPIDbContext _context;

        public PayloadController(PayloadAPIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceData>>> GetAllDeviceData()
        {
            try
            {
                var deviceData = await _context.DeviceData.ToListAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                var serializedDevices = JsonSerializer.Serialize(deviceData, options);

                return Content(serializedDevices, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceDataById(int id)
        {
            try
            {
                var deviceData = await _context.DeviceData.FindAsync(id);
                if (deviceData == null)
                {
                    return NotFound();
                }
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                var serializedDevices = JsonSerializer.Serialize(deviceData, options);

                return Content(serializedDevices, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<DeviceData>> CreateDeviceData(DeviceData createDeviceDataDto)
        {
            try
            {
                _context.DeviceData.Add(createDeviceDataDto);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetDeviceDataById), new { id = createDeviceDataDto.Id }, createDeviceDataDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException}");

                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeviceData(int id)
        {
            try
            {
                // Find the device data entity by ID
                var deviceData = await _context.DeviceData.FindAsync(id);

                if (deviceData == null)
                {
                    return NotFound();
                }

                // Remove the device data entity from the DbContext
                _context.DeviceData.Remove(deviceData);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DeviceData>> UpdateDeviceData(int id, UpdateDeviceData updateDeviceDataDto)
        {
            try
            {
                var deviceData = await _context.DeviceData.FindAsync(id);

                if (deviceData == null)
                {
                    return NotFound();
                }

                // Update the device data entity with the new values
                deviceData.DeviceId = updateDeviceDataDto.DeviceId;
                deviceData.DeviceType = updateDeviceDataDto.DeviceType;
                deviceData.DeviceName = updateDeviceDataDto.DeviceName;
                deviceData.GroupId = updateDeviceDataDto.GroupId;
                deviceData.DataType = updateDeviceDataDto.DataType;
                deviceData.Data.FullPowerMode = updateDeviceDataDto.Data.FullPowerMode;
                deviceData.Data.ActivePowerControl = updateDeviceDataDto.Data.ActivePowerControl;
                deviceData.Data.FirmwareVersion = updateDeviceDataDto.Data.FirmwareVersion;
                deviceData.Data.Temperature = updateDeviceDataDto.Data.Temperature;
                deviceData.Data.Humidity = updateDeviceDataDto.Data.Humidity;
                deviceData.Data.Version = updateDeviceDataDto.Data.Version;
                deviceData.Data.MessageType = updateDeviceDataDto.Data.MessageType;
                deviceData.Data.Occupancy = updateDeviceDataDto.Data.Occupancy;
                deviceData.Data.StateChanged = updateDeviceDataDto.Data.StateChanged;

                await _context.SaveChangesAsync();

                return Ok(deviceData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}
