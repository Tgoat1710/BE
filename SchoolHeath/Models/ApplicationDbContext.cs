using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolHeath.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<HealthCheckup> HealthCheckups { get; set; }

    public virtual DbSet<HealthRecord> HealthRecords { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<MedicalEvent> MedicalEvents { get; set; }

    public virtual DbSet<MedicationRequest> MedicationRequests { get; set; }

    public virtual DbSet<MedicineInventory> MedicineInventories { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<SchoolNurse> SchoolNurses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<UserNotification> UserNotifications { get; set; }

    public virtual DbSet<VaccinationConsent> VaccinationConsents { get; set; }

    public virtual DbSet<VaccinationRecord> VaccinationRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SchoolHealthDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__46A222CD1FB9B110");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "UQ__Account__F3DBC572E2E40CDF").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<HealthCheckup>(entity =>
        {
            entity.HasKey(e => e.CheckupId).HasName("PK__HealthCh__C4A1A420E8A16C52");

            entity.ToTable("HealthCheckup");

            entity.Property(e => e.CheckupId).HasColumnName("checkup_id");
            entity.Property(e => e.BloodPressure)
                .HasMaxLength(20)
                .HasColumnName("blood_pressure");
            entity.Property(e => e.CheckupDate).HasColumnName("checkup_date");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.NurseId).HasColumnName("nurse_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.Vision)
                .HasMaxLength(50)
                .HasColumnName("vision");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Nurse).WithMany(p => p.HealthCheckups)
                .HasForeignKey(d => d.NurseId)
                .HasConstraintName("FK__HealthChe__nurse__52593CB8");

            entity.HasOne(d => d.Student).WithMany(p => p.HealthCheckups)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HealthChe__stude__5165187F");
        });

        modelBuilder.Entity<HealthRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__HealthRe__BFCFB4DDECB3EBF6");

            entity.ToTable("HealthRecord");

            entity.HasIndex(e => e.StudentId, "UQ__HealthRe__2A33069BA89E76A6").IsUnique();

            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.Allergies).HasColumnName("allergies");
            entity.Property(e => e.ChronicDiseases).HasColumnName("chronic_diseases");
            entity.Property(e => e.MedicalHistory).HasColumnName("medical_history");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VisionStatus)
                .HasMaxLength(50)
                .HasColumnName("vision_status");

            entity.HasOne(d => d.Student).WithOne(p => p.HealthRecord)
                .HasForeignKey<HealthRecord>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HealthRec__stude__04E4BC85");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__Manager__5A6073FC2DEF89C3");

            entity.ToTable("Manager");

            entity.HasIndex(e => e.AccountId, "UQ__Manager__46A222CC4A8BE7DA").IsUnique();

            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.HasOne(d => d.Account).WithOne(p => p.Manager)
                .HasForeignKey<Manager>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Manager__account__412EB0B6");
        });

        modelBuilder.Entity<MedicalEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__MedicalE__2370F727A4731A13");

            entity.ToTable("MedicalEvent");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventType)
                .HasMaxLength(100)
                .HasColumnName("event_type");
            entity.Property(e => e.HandledBy).HasColumnName("handled_by");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Outcome).HasColumnName("outcome");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.HandledByNavigation).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.HandledBy)
                .HasConstraintName("FK__MedicalEv__handl__6754599E");

            entity.HasOne(d => d.Student).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MedicalEv__stude__66603565");
        });

        modelBuilder.Entity<MedicationRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Medicati__18D3B90F27AC9CFD");

            entity.ToTable("MedicationRequest");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.Dosage)
                .HasMaxLength(100)
                .HasColumnName("dosage");
            entity.Property(e => e.Duration)
                .HasMaxLength(100)
                .HasColumnName("duration");
            entity.Property(e => e.Frequency)
                .HasMaxLength(100)
                .HasColumnName("frequency");
            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestedBy).HasColumnName("requested_by");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Medicine).WithMany(p => p.MedicationRequests)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicatio__medic__628FA481");

            entity.HasOne(d => d.RequestedByNavigation).WithMany(p => p.MedicationRequests)
                .HasForeignKey(d => d.RequestedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicatio__reque__6383C8BA");

            entity.HasOne(d => d.Student).WithMany(p => p.MedicationRequests)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicatio__stude__619B8048");
        });

        modelBuilder.Entity<MedicineInventory>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("PK__Medicine__E7148EBBDF6A8772");

            entity.ToTable("MedicineInventory");

            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NurseId).HasColumnName("nurse_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Nurse).WithMany(p => p.MedicineInventories)
                .HasForeignKey(d => d.NurseId)
                .HasConstraintName("FK__MedicineI__nurse__5CD6CB2B");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__Parent__F2A608194B1C9FF0");

            entity.ToTable("Parent");

            entity.HasIndex(e => e.Cccd, "UQ__Parent__37D42BFA7507EDB0").IsUnique();

            entity.HasIndex(e => e.AccountId, "UQ__Parent__46A222CC005B578D").IsUnique();

            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("cccd");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.HasOne(d => d.Account).WithOne(p => p.Parent)
                .HasForeignKey<Parent>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Parent__account___3D5E1FD2");
        });

        modelBuilder.Entity<SchoolNurse>(entity =>
        {
            entity.HasKey(e => e.NurseId).HasName("PK__SchoolNu__9BADE4996CBF50B1");

            entity.ToTable("SchoolNurse");

            entity.HasIndex(e => e.AccountId, "UQ__SchoolNu__46A222CC01462613").IsUnique();

            entity.Property(e => e.NurseId).HasColumnName("nurse_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.HasOne(d => d.Account).WithOne(p => p.SchoolNurse)
                .HasForeignKey<SchoolNurse>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SchoolNur__accou__44FF419A");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__2A33069AE690E7F8");

            entity.ToTable("Student");

            entity.HasIndex(e => e.StudentCode, "UQ__Student__6DF33C4527BA2FF7").IsUnique();

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.BloodType)
                .HasMaxLength(5)
                .HasColumnName("blood_type");
            entity.Property(e => e.Class)
                .HasMaxLength(20)
                .HasColumnName("class");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ParentCccd)
                .HasMaxLength(20)
                .HasColumnName("parent_cccd");
            entity.Property(e => e.School)
                .HasMaxLength(100)
                .HasColumnName("school");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("active")
                .HasColumnName("status");
            entity.Property(e => e.StudentCode)
                .HasMaxLength(20)
                .HasColumnName("student_code");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.ParentCccdNavigation).WithMany(p => p.Students)
                .HasPrincipalKey(p => p.Cccd)
                .HasForeignKey(d => d.ParentCccd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__parent___4AB81AF0");
        });

        modelBuilder.Entity<UserNotification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__UserNoti__E059842F1A17C6FE");

            entity.ToTable("UserNotification");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");

            entity.HasOne(d => d.Recipient).WithMany(p => p.UserNotifications)
                .HasForeignKey(d => d.RecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserNotif__recip__6C190EBB");
        });

        modelBuilder.Entity<VaccinationConsent>(entity =>
        {
            entity.HasKey(e => e.ConsentId).HasName("PK__Vaccinat__E6C2B678FB5ACF69");

            entity.ToTable("VaccinationConsent");

            entity.Property(e => e.ConsentId).HasColumnName("consent_id");
            entity.Property(e => e.ConsentDate).HasColumnName("consent_date");
            entity.Property(e => e.ConsentStatus).HasColumnName("consent_status");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.ParentCccd)
                .HasMaxLength(20)
                .HasColumnName("parent_cccd");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.VaccineName)
                .HasMaxLength(100)
                .HasColumnName("vaccine_name");

            entity.HasOne(d => d.ParentCccdNavigation).WithMany(p => p.VaccinationConsents)
                .HasPrincipalKey(p => p.Cccd)
                .HasForeignKey(d => d.ParentCccd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vaccinati__paren__59FA5E80");

            entity.HasOne(d => d.Student).WithMany(p => p.VaccinationConsents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vaccinati__stude__59063A47");
        });

        modelBuilder.Entity<VaccinationRecord>(entity =>
        {
            entity.HasKey(e => e.VaccinationId).HasName("PK__Vaccinat__E588AFE79BCEAE2F");

            entity.ToTable("VaccinationRecord");

            entity.Property(e => e.VaccinationId).HasColumnName("vaccination_id");
            entity.Property(e => e.AdministeredBy).HasColumnName("administered_by");
            entity.Property(e => e.DateOfVaccination).HasColumnName("date_of_vaccination");
            entity.Property(e => e.FollowUpReminder).HasColumnName("follow_up_reminder");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.VaccineName)
                .HasMaxLength(100)
                .HasColumnName("vaccine_name");

            entity.HasOne(d => d.AdministeredByNavigation).WithMany(p => p.VaccinationRecords)
                .HasForeignKey(d => d.AdministeredBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vaccinati__admin__5629CD9C");

            entity.HasOne(d => d.Student).WithMany(p => p.VaccinationRecords)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vaccinati__stude__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
