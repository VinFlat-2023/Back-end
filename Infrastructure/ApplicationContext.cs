using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; } = null!;
    public virtual DbSet<Area> Areas { get; set; } = null!;
    public virtual DbSet<Building> Buildings { get; set; } = null!;
    public virtual DbSet<Contract> Contracts { get; set; } = null!;
    public virtual DbSet<ContractHistory> ContractHistories { get; set; } = null!;
    public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
    public virtual DbSet<FeedbackType> FeedbackTypes { get; set; } = null!;
    public virtual DbSet<Flat> Flats { get; set; } = null!;
    public virtual DbSet<FlatType> FlatTypes { get; set; } = null!;
    public virtual DbSet<Invoice> Invoices { get; set; } = null!;
    public virtual DbSet<Major> Majors { get; set; } = null!;
    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
    public virtual DbSet<InvoiceType> InvoiceTypes { get; set; } = null!;
    public virtual DbSet<Renter> Renters { get; set; } = null!;
    public virtual DbSet<Request> Requests { get; set; } = null!;
    public virtual DbSet<RequestType> RequestTypes { get; set; } = null!;
    public virtual DbSet<Role> Roles { get; set; } = null!;
    public virtual DbSet<ServiceEntity> Services { get; set; } = null!;
    public virtual DbSet<ServiceType> ServiceTypes { get; set; } = null!;
    public virtual DbSet<University> University { get; set; } = null!;
    public virtual DbSet<Wallet> Wallets { get; set; } = null!;
    public virtual DbSet<WalletType> WalletTypes { get; set; } = null!;

    public virtual DbSet<Transaction> Transactions { get; set; } = null!;
    public virtual DbSet<UserDevice> UserDevices { get; set; } = null!;

    public virtual DbSet<DatabaseException> DatabaseExceptions { get; set; } = null!;
    public virtual DbSet<Notification> Notifications { get; set; } = null!;

    public virtual DbSet<NotificationType> NotificationTypes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }

        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("Notification");

            entity.Property(e => e.ActionStatusColor).HasDefaultValueSql("((1))");

            entity.Property(e => e.NotificationId).ValueGeneratedOnAdd();

            entity.Property(e => e.Time).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.NotificationType)
                .WithMany()
                .HasForeignKey(d => d.NotificationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Notif__10216507");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.ToTable("NotificationType");

            entity.Property(e => e.NotificationTypeName).HasMaxLength(20);

            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasIndex(e => e.Username)
                .IsUnique();
            entity.HasIndex(e => e.Email)
                .IsUnique();
        });

        modelBuilder.Entity<Account>().HasData(
            new Account
            {
                AccountId = 1,
                Username = "superadmin",
                Password = "superadmin",
                Email = "superadmin@mail",
                Phone = "0123543125",
                Status = true,
                RoleId = 1
            },
            new Account
            {
                AccountId = 2,
                Username = "admin",
                Password = "admin",
                Email = "admin@mail",
                Phone = "0123543532",
                Status = true,
                RoleId = 2
            },
            new Account
            {
                AccountId = 3,
                Username = "supervisor",
                Password = "supervisor",
                Email = "supervisor@mail",
                Phone = "0123543554",
                Status = true,
                RoleId = 3
            },
            new Account
            {
                AccountId = 4,
                Username = "employee1",
                Password = "employee1",
                Email = "employee1@mail",
                Phone = "0123543235",
                Status = true,
                RoleId = 4
            },
            new Account
            {
                AccountId = 5,
                Username = "employee2",
                Password = "employee2",
                Email = "employee2@mail",
                Phone = "0123123235",
                Status = true,
                RoleId = 4
            }
        );

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Status = true,
                RoleId = 1,
                RoleName = "SuperAdmin"
            },
            new Role
            {
                Status = true,
                RoleId = 2,
                RoleName = "Admin"
            },
            new Role
            {
                Status = true,
                RoleId = 3,
                RoleName = "Supervisor"
            },
            new Role
            {
                Status = true,
                RoleId = 4,
                RoleName = "Employee"
            }
        );

        modelBuilder.Entity<Renter>(entity =>
        {
            entity.HasIndex(e => e.Username)
                .IsUnique();
            entity.HasIndex(e => e.Email)
                .IsUnique();
        });

        modelBuilder.Entity<Renter>().HasData(
            new Renter
            {
                RenterId = 1,
                Username = "renter1",
                Email = "renter1@mail",
                Password = "renter1",
                Phone = "0123543125",
                FullName = "Nguyen Van A",
                BirthDate = DateTime.UtcNow,
                Status = true,
                CitizenNumber = "3214324523",
                Address = "HCM",
                Gender = "Male",
                DeviceToken = "12321fdsg45adsa"
            },
            new Renter
            {
                RenterId = 2,
                Username = "renter2",
                Email = "renter2@mail",
                Password = "renter2",
                Phone = "0123543125",
                FullName = "Nguyen Van B",
                BirthDate = DateTime.UtcNow,
                Status = true,
                CitizenNumber = "3214324523",
                Address = "Hue",
                Gender = "Male",
                DeviceToken = "dsavvf"
            },
            new Renter
            {
                RenterId = 3,
                Username = "renter3",
                Email = "renter3@mail",
                Password = "renter3",
                Phone = "0123543125",
                FullName = "Nguyen Van C",
                BirthDate = DateTime.UtcNow,
                Status = true,
                CitizenNumber = "3214324523",
                Address = "DN",
                Gender = "Female",
                DeviceToken = "123221ad145ad423sa",
                MajorId = 2,
                UniversityId = 1
            }, new Renter
            {
                RenterId = 4,
                Username = "renter4",
                Email = "renter4@mail",
                Password = "renter4",
                Phone = "0123543125",
                FullName = "Nguyen Van D",
                BirthDate = DateTime.UtcNow,
                Status = true,
                CitizenNumber = "3214324523",
                Address = "HN",
                Gender = "Female",
                DeviceToken = "ewasdv12344",
                MajorId = 1,
                UniversityId = 1
            }
        );

        modelBuilder.Entity<University>().HasData(
            new University
            {
                UniversityId = 1,
                UniversityName = "HCM University of Technology",
                Address = "HCM",
                Status = "Active",
                Description = "HCM University of Technology"
            },
            new University
            {
                UniversityId = 2,
                UniversityName = "HCM University of Science",
                Address = "HCM",
                Status = "Active",
                Description = "HCM University of Science"
            },
            new University
            {
                UniversityId = 3,
                UniversityName = "HCM University of Pedagogy",
                Address = "HCM",
                Status = "Active",
                Description = "HCM University of Pedagogy"
            },
            new University
            {
                UniversityId = 4,
                UniversityName = "HCM University of Physical",
                Address = "HCM",
                Status = "Active",
                Description = "HCM University of Physical"
            },
            new University
            {
                UniversityId = 5,
                UniversityName = "HCM University of Math",
                Address = "HCM",
                Status = "Active",
                Description = "HCM University of Math"
            },
            new University
            {
                UniversityId = 6,
                UniversityName = "HCM University of History",
                Address = "HCM",
                Status = "Active",
                Description = "HCM University of History"
            }
        );

        modelBuilder.Entity<Major>().HasData(
            new Major
            {
                MajorId = 1,
                Name = "Computer Science",
                UniversityId = 1
            },
            new Major
            {
                MajorId = 2,
                Name = "Information Technology",
                UniversityId = 1
            },
            new Major
            {
                MajorId = 3,
                Name = "Software Engineering",
                UniversityId = 2
            },
            new Major
            {
                MajorId = 4,
                Name = "Information Technology",
                UniversityId = 2
            }, new Major
            {
                MajorId = 5,
                Name = "Information Technology",
                UniversityId = 3
            }
        );

        modelBuilder.Entity<Area>().HasData(
            new Area
            {
                AreaId = 1,
                Name = "HCM",
                Location = "HCM",
                Status = true
            },
            new Area
            {
                AreaId = 2,
                Name = "HN",
                Location = "HN",
                Status = true
            },
            new Area
            {
                AreaId = 3,
                Name = "DN",
                Location = "DN",
                Status = true
            },
            new Area
            {
                AreaId = 4,
                Name = "Hue",
                Location = "Hue",
                Status = true
            },
            new Area
            {
                AreaId = 5,
                Name = "Thanh Hoa",
                Location = "TH",
                Status = true
            },
            new Area
            {
                AreaId = 6,
                Name = "Hai Phong",
                Location = "HP",
                Status = true
            },
            new Area
            {
                AreaId = 7,
                Name = "Dong Nai",
                Location = "DN",
                Status = true
            },
            new Area
            {
                AreaId = 8,
                Name = "Hoa Lac",
                Location = "HN",
                Status = true
            }
        );

        modelBuilder.Entity<Building>().HasData(
            new Building
            {
                BuildingId = 1,
                BuildingName = "Building 1a",
                Description = "Building 1a",
                TotalFloor = 10,
                TotalRooms = 20,
                Status = true,
                CoordinateX = 231,
                CoordinateY = 324,
                AreaId = 1
            },
            new Building
            {
                BuildingId = 2,
                BuildingName = "Building 1b",
                Description = "Building 1b",
                TotalFloor = 10,
                TotalRooms = 20,
                Status = true,
                CoordinateX = 21233,
                CoordinateY = 334,
                AreaId = 1
            },
            new Building
            {
                BuildingId = 3,
                BuildingName = "Building 1c",
                Description = "Building 1c",
                TotalFloor = 10,
                TotalRooms = 20,
                Status = true,
                CoordinateX = 423,
                CoordinateY = 3214,
                AreaId = 2
            },
            new Building
            {
                BuildingId = 4,
                BuildingName = "Building 1d",
                Description = "Building 1d",
                TotalFloor = 10,
                TotalRooms = 20,
                Status = true,
                CoordinateX = 2323,
                CoordinateY = 314,
                AreaId = 2
            },
            new Building
            {
                BuildingId = 5,
                BuildingName = "Building 1e",
                Description = "Building 1e",
                TotalFloor = 10,
                TotalRooms = 20,
                Status = true,
                CoordinateX = 23431,
                CoordinateY = 3245,
                AreaId = 3
            },
            new Building
            {
                BuildingId = 6,
                BuildingName = "Building 1f",
                Description = "Building 1f",
                TotalFloor = 10,
                TotalRooms = 20,
                Status = true,
                CoordinateX = 21233,
                CoordinateY = 334,
                AreaId = 3
            },
            new Building
            {
                BuildingId = 7,
                BuildingName = "Building 1g",
                Description = "Building 1g",
                TotalFloor = 10,
                TotalRooms = 20,
                Status = true,
                CoordinateX = 423,
                CoordinateY = 3214,
                AreaId = 4
            },
            new Building
            {
                BuildingId = 8,
                BuildingName = "Building 1h",
                Description = "Building 1h",
                TotalFloor = 10,
                TotalRooms = 20,
                Status = true,
                CoordinateX = 2323,
                CoordinateY = 31454,
                AreaId = 4
            }
        );

        modelBuilder.Entity<FlatType>().HasData(
            new FlatType
            {
                FlatTypeId = 1,
                Capacity = 10,
                Status = "Active"
            },
            new FlatType
            {
                FlatTypeId = 2,
                Capacity = 2,
                Status = "Active"
            },
            new FlatType
            {
                FlatTypeId = 3,
                Capacity = 4,
                Status = "Active"
            },
            new FlatType
            {
                FlatTypeId = 4,
                Capacity = 5,
                Status = "Active"
            },
            new FlatType
            {
                FlatTypeId = 5,
                Capacity = 6,
                Status = "NonActive"
            }
        );

        modelBuilder.Entity<Flat>().HasData(
            new Flat
            {
                FlatId = 1,
                Name = "Flat 1",
                Description = "Flat 1",
                Status = "Active",
                WaterMeter = 0,
                ElectricityMeter = 0,
                FlatTypeId = 1,
                BuildingId = 1
            },
            new Flat
            {
                FlatId = 2,
                Name = "Flat 2",
                Description = "Flat 2",
                Status = "Active",
                WaterMeter = 0,
                ElectricityMeter = 0,
                FlatTypeId = 3,
                BuildingId = 3
            },
            new Flat
            {
                FlatId = 3,
                Name = "Flat 3",
                Description = "Flat 3",
                Status = "Active",
                WaterMeter = 0,
                ElectricityMeter = 0,
                FlatTypeId = 2,
                BuildingId = 2
            },
            new Flat
            {
                FlatId = 4,
                Name = "Flat 4",
                Description = "Flat 4",
                Status = "NonActive",
                WaterMeter = 0,
                ElectricityMeter = 0,
                FlatTypeId = 5,
                BuildingId = 2
            }
        );

        modelBuilder.Entity<RequestType>().HasData(
            new RequestType
            {
                RequestTypeId = 1,
                Name = "Repair",
                Description = "Repair",
                Status = true
            },
            new RequestType
            {
                RequestTypeId = 2,
                Name = "Maintenance",
                Description = "Maintenance",
                Status = true
            },
            new RequestType
            {
                RequestTypeId = 3,
                Name = "Other",
                Description = "Other",
                Status = true
            },
            new RequestType
            {
                RequestTypeId = 4,
                Name = "Complaint",
                Description = "Complaint",
                Status = true
            }
        );

        modelBuilder.Entity<ServiceType>().HasData(
            new ServiceType
            {
                ServiceTypeId = 1,
                Name = "Water Supply",
                Status = "Active"
            },
            new ServiceType
            {
                ServiceTypeId = 2,
                Name = "Gas Supply",
                Status = "Active"
            },
            new ServiceType
            {
                ServiceTypeId = 3,
                Name = "Electricity Supply",
                Status = "Active"
            },
            new ServiceType
            {
                ServiceTypeId = 4,
                Name = "Other",
                Status = "Active"
            }
        );

        modelBuilder.Entity<FeedbackType>().HasData(
            new FeedbackType
            {
                FeedbackTypeId = 1,
                Name = "Complaint"
            },
            new FeedbackType
            {
                FeedbackTypeId = 2,
                Name = "Suggestion"
            },
            new FeedbackType
            {
                FeedbackTypeId = 3,
                Name = "Other"
            }
        );


        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.ToTable("Wallet");

            entity.Property(e => e.WalletId)
                .HasColumnName("WalletID")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.WalletTypeId).HasColumnName("WalletTypeID");
        });

        modelBuilder.Entity<WalletType>(entity =>
        {
            entity.ToTable("WalletType");

            entity.Property(e => e.WalletTypeId).HasColumnName("WalletTypeID");

            entity.Property(e => e.WalletTypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<UserDevice>(entity =>
        {
            entity.ToTable("UserDevice");

            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    private void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
    }
}