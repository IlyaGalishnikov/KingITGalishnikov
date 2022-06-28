﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KingITGalishnikov
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class KingITGalishnikovEntities : DbContext
    {
        private static KingITGalishnikovEntities _context;
        public static KingITGalishnikovEntities GetContext()
        {
            if (_context == null)
                _context = new KingITGalishnikovEntities();

            return _context;
        }
        public KingITGalishnikovEntities()
            : base("name=KingITGalishnikovEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Arenda> Arenda { get; set; }
        public virtual DbSet<Arendatory> Arendatory { get; set; }
        public virtual DbSet<Pavilioni> Pavilioni { get; set; }
        public virtual DbSet<Sotrudniki> Sotrudniki { get; set; }
        public virtual DbSet<TC> TC { get; set; }
    
        public virtual int RentOrBooked(Nullable<bool> status_action, string number_Pavilion, Nullable<long> number_SC, Nullable<System.DateTime> start_date, Nullable<System.DateTime> end_date, Nullable<long> iD_tenant, Nullable<long> iD_employee)
        {
            var status_actionParameter = status_action.HasValue ?
                new ObjectParameter("status_action", status_action) :
                new ObjectParameter("status_action", typeof(bool));
    
            var number_PavilionParameter = number_Pavilion != null ?
                new ObjectParameter("Number_Pavilion", number_Pavilion) :
                new ObjectParameter("Number_Pavilion", typeof(string));
    
            var number_SCParameter = number_SC.HasValue ?
                new ObjectParameter("Number_SC", number_SC) :
                new ObjectParameter("Number_SC", typeof(long));
    
            var start_dateParameter = start_date.HasValue ?
                new ObjectParameter("start_date", start_date) :
                new ObjectParameter("start_date", typeof(System.DateTime));
    
            var end_dateParameter = end_date.HasValue ?
                new ObjectParameter("end_date", end_date) :
                new ObjectParameter("end_date", typeof(System.DateTime));
    
            var iD_tenantParameter = iD_tenant.HasValue ?
                new ObjectParameter("ID_tenant", iD_tenant) :
                new ObjectParameter("ID_tenant", typeof(long));
    
            var iD_employeeParameter = iD_employee.HasValue ?
                new ObjectParameter("ID_employee", iD_employee) :
                new ObjectParameter("ID_employee", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RentOrBooked", status_actionParameter, number_PavilionParameter, number_SCParameter, start_dateParameter, end_dateParameter, iD_tenantParameter, iD_employeeParameter);
        }
    
        public virtual int ThreeYears()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ThreeYears");
        }
    }
}
