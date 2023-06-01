using ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;


namespace Infrastructure.Data;

public class PatientDbContext : DbContext
{
    public PatientDbContext(DbContextOptions<PatientDbContext> options) : base (options) 
    {
        
    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<MedicalRecord>(MedicalRecordConfiguration);
    }

    private void MedicalRecordConfiguration(EntityTypeBuilder<MedicalRecord> builder)
    {
        builder.HasOne(mr => mr.Patient)
            .WithMany(p => p.MedicalRecords)
            .HasForeignKey(mr => mr.PatientId);
    }
}