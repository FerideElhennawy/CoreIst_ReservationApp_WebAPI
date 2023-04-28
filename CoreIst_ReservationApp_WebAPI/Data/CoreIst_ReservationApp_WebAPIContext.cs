using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreIst_ReservationApp_WebAPI.Models;

namespace CoreIst_ReservationApp_WebAPI.Data
{
    public class CoreIst_ReservationApp_WebAPIContext : DbContext
    {
        public CoreIst_ReservationApp_WebAPIContext (DbContextOptions<CoreIst_ReservationApp_WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CoreIst_ReservationApp_WebAPI.Models.Facility> Facility { get; set; } = default!;

        public DbSet<CoreIst_ReservationApp_WebAPI.Models.Instrument>? Instrument { get; set; }
    }
}
