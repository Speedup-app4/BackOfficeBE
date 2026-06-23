using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackOffice.Utils
{
    public class RequestMetric
    {
        public string? Path { get; set; }
        public string? Method { get; set; }
        public long DurationMs { get; set; }
        public double CpuUsedMs { get; set; }
        public long RamUsedKB { get; set; }
        public DateTime Time { get; set; }
    }

    public class RequestMetricsService(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        private static readonly ConcurrentQueue<RequestMetric> _recentRequests = new();

        public async Task Invoke(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            var process = Process.GetCurrentProcess();
            long ramBefore = process.WorkingSet64;
            TimeSpan cpuBefore = process.TotalProcessorTime;

            await _next(context);

            sw.Stop();
            long ramAfter = process.WorkingSet64;
            TimeSpan cpuAfter = process.TotalProcessorTime;

            var metric = new RequestMetric
            {
                Path = context.Request.Path,
                Method = context.Request.Method,
                DurationMs = sw.ElapsedMilliseconds,
                RamUsedKB = (ramAfter - ramBefore) / 1024,
                CpuUsedMs = (cpuAfter - cpuBefore).TotalMilliseconds,
                Time = DateTime.UtcNow,
            };

            //* Giới hạn tối đa 100 request gần nhất
            _recentRequests.Enqueue(metric);
            while (_recentRequests.Count > 100)
            {
                _recentRequests.TryDequeue(out _);
            }

            context.Items["RequestMetric"] = metric; //* optional: lưu để controller khác dùng
        }

        public static IEnumerable<RequestMetric> GetRecentRequests() => _recentRequests.Reverse();
    }
}
