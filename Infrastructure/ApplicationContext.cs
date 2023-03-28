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
    public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
    public virtual DbSet<FeedbackType> FeedbackTypes { get; set; } = null!;
    public virtual DbSet<Flat> Flats { get; set; } = null!;
    public virtual DbSet<FlatType> FlatTypes { get; set; } = null!;
    public virtual DbSet<Invoice> Invoices { get; set; } = null!;
    public virtual DbSet<Major> Majors { get; set; } = null!;
    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
    public virtual DbSet<InvoiceType> InvoiceTypes { get; set; } = null!;
    public virtual DbSet<Renter> Renters { get; set; } = null!;
    public virtual DbSet<Ticket> Tickets { get; set; } = null!;
    public virtual DbSet<TicketType> TicketTypes { get; set; } = null!;
    public virtual DbSet<Role> Roles { get; set; } = null!;
    public virtual DbSet<ServiceEntity> Services { get; set; } = null!;
    public virtual DbSet<ServiceType> ServiceTypes { get; set; } = null!;
    public virtual DbSet<University> University { get; set; } = null!;
    public virtual DbSet<Wallet> Wallets { get; set; } = null!;
    public virtual DbSet<WalletType> WalletTypes { get; set; } = null!;
    public virtual DbSet<Transaction> Transactions { get; set; } = null!;
    public virtual DbSet<UserDevice> UserDevices { get; set; } = null!;
    public virtual DbSet<Notification> Notifications { get; set; } = null!;
    public virtual DbSet<NotificationType> NotificationTypes { get; set; } = null!;
    public virtual DbSet<Room> Rooms { get; set; } = null!;
    public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
    public virtual DbSet<AttributeForNumeric> AttributeForNumerics { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }

        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contract>()
            .ToTable("Contracts",
                b => b.IsTemporal());

        modelBuilder.Entity<Invoice>()
            .ToTable("Invoices",
                b => b.IsTemporal());

        modelBuilder.Entity<Contract>()
            .HasMany(c => c.Tickets);

        modelBuilder.Entity<Ticket>()
            .HasOne(x => x.Contract)
            .WithMany(x => x.Tickets)
            .OnDelete(DeleteBehavior.NoAction);

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

        modelBuilder.Entity<AttributeForNumeric>().HasData(
            new AttributeForNumeric
            {
                AttributeForNumericId = 1,
                WaterAttribute = "1",
                ElectricityAttribute = "1.1"
            },
            new AttributeForNumeric
            {
                AttributeForNumericId = 2,
                WaterAttribute = "1",
                ElectricityAttribute = "0.9"
            },
            new AttributeForNumeric
            {
                AttributeForNumericId = 3,
                WaterAttribute = "1",
                ElectricityAttribute = "1.2"
            },
            new AttributeForNumeric
            {
                AttributeForNumericId = 4,
                WaterAttribute = "0.9",
                ElectricityAttribute = "1.4"
            }
        );


        modelBuilder.Entity<Account>().HasData(
            new Account
            {
                AccountId = 1,
                FullName = "Super admin account",
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
                FullName = "Admin account",
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
                FullName = "Supervisor account",
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
                FullName = "Employee account 1",
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
                FullName = "Employee account 2",
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
            entity.HasIndex(e => e.MajorId)
                .IsUnique(false);
        });

        modelBuilder.Entity<Renter>().HasData(
            new Renter
            {
                RenterId = 1,
                Username = "renter1",
                Email = "renter1@mail.com",
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
                Email = "renter2@mail.com",
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
                Email = "renter3@mail.com",
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
                Email = "renter4@mail.com",
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
            }, new Renter
            {
                RenterId = 5,
                Username = "minhkhoi10a3",
                Email = "trankhaimnhkhoi10a3@mail.com",
                Password = "123456789",
                Phone = "0123543125",
                FullName = "Tran Minh Khoi",
                BirthDate = DateTime.UtcNow,
                Status = true,
                CitizenNumber = "3214324523",
                Address = "HCM",
                Gender = "Male",
                DeviceToken = "ewasdv12344",
                MajorId = 1,
                UniversityId = 1
            }, new Renter
            {
                RenterId = 6,
                Username = "minhkhoi",
                Email = "trankhaimnhkhoi@mail.com",
                Password = "123456789",
                Phone = "0123543125",
                FullName = "Tran Minh Khoi",
                BirthDate = DateTime.UtcNow,
                Status = true,
                CitizenNumber = "3214324523",
                Address = "HCM",
                Gender = "Male",
                DeviceToken = "ewasdv12344",
                MajorId = 1,
                UniversityId = 1
            }, new Renter
            {
                RenterId = 7,
                Username = "minhkhoitkm",
                Email = "khoitkmse150850@fpt",
                Password = "123456789",
                Phone = "0123543125",
                FullName = "Tran Minh Khoi",
                BirthDate = DateTime.UtcNow,
                Status = true,
                CitizenNumber = "3214324523",
                Address = "HCM",
                Gender = "Male",
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
                Status = true,
                CoordinateX = 231,
                CoordinateY = 324,
                AreaId = 1,
                AccountId = 5,
                ImageUrl = "",
                BuildingPhoneNumber = "012323123"
            },
            new Building
            {
                BuildingId = 2,
                BuildingName = "Building 1b",
                Description = "Building 1b",
                Status = true,
                CoordinateX = 21233,
                CoordinateY = 334,
                AreaId = 1,
                AccountId = 2,
                ImageUrl = "",
                BuildingPhoneNumber = "012323123"
            },
            new Building
            {
                BuildingId = 3,
                BuildingName = "Building 1c",
                Description = "Building 1c",
                Status = true,
                CoordinateX = 423,
                CoordinateY = 3214,
                AreaId = 2,
                AccountId = 2,
                ImageUrl = "",
                BuildingPhoneNumber = "012323123"
            },
            new Building
            {
                BuildingId = 4,
                BuildingName = "Building 1d",
                Description = "Building 1d",
                Status = true,
                CoordinateX = 2323,
                CoordinateY = 314,
                AreaId = 2,
                AccountId = 4,
                ImageUrl = "",
                BuildingPhoneNumber = "012323123"
            },
            new Building
            {
                BuildingId = 5,
                BuildingName = "Building 1e",
                Description = "Building 1e",
                Status = true,
                CoordinateX = 23431,
                CoordinateY = 3245,
                AreaId = 3,
                AccountId = 3,
                ImageUrl = "",
                BuildingPhoneNumber = "012323123"
            },
            new Building
            {
                BuildingId = 6,
                BuildingName = "Building 1f",
                Description = "Building 1f",
                Status = true,
                CoordinateX = 21233,
                CoordinateY = 334,
                AreaId = 3,
                AccountId = 4,
                ImageUrl = "",
                BuildingPhoneNumber = "012323123"
            }
        );

        modelBuilder.Entity<FlatType>().HasData(
            new FlatType
            {
                FlatTypeId = 1,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 10,
                Status = "Active",
                BuildingId = 5
            },
            new FlatType
            {
                FlatTypeId = 2,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 2,
                Status = "Active",
                BuildingId = 5
            },
            new FlatType
            {
                FlatTypeId = 3,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 4,
                Status = "Active",
                BuildingId = 5
            },
            new FlatType
            {
                FlatTypeId = 4,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 5,
                Status = "Active",
                BuildingId = 5
            },
            new FlatType
            {
                FlatTypeId = 5,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 6,
                Status = "Active",
                BuildingId = 5
            }
        );

        modelBuilder.Entity<Utility>().HasData(
            new Utility
            {
                UtilityId = 1,
                UtilitiesName = "Air Conditioner"
            },
            new Utility
            {
                UtilityId = 2,
                UtilitiesName = "Water Heater"
            },
            new Utility
            {
                UtilityId = 3,
                UtilitiesName = "Wifi"
            },
            new Utility
            {
                UtilityId = 4,
                UtilitiesName = "Kitchen"
            }
        );

        modelBuilder.Entity<UtilitiesFlat>().HasData(
            new UtilitiesFlat
            {
                UtilitiesFlatId = 1,
                FlatId = 1,
                UtilityId = 1
            },
            new UtilitiesFlat
            {
                UtilitiesFlatId = 2,
                FlatId = 1,
                UtilityId = 2
            }
        );

        modelBuilder.Entity<Flat>().HasData(
            new Flat
            {
                FlatId = 1,
                Name = "Flat 1",
                Description = "Flat 1",
                Status = "Active",
                WaterMeterBefore = 0,
                ElectricityMeterBefore = 0,
                WaterMeterAfter = 0,
                ElectricityMeterAfter = 0,
                FlatTypeId = 1,
                BuildingId = 1,
                AttributeForNumericId = 4
            },
            new Flat
            {
                FlatId = 2,
                Name = "Flat 2",
                Description = "Flat 2",
                Status = "Active",
                WaterMeterBefore = 0,
                ElectricityMeterBefore = 0,
                WaterMeterAfter = 0,
                ElectricityMeterAfter = 0,
                FlatTypeId = 3,
                BuildingId = 3,
                AttributeForNumericId = 3
            },
            new Flat
            {
                FlatId = 3,
                Name = "Flat 3",
                Description = "Flat 3",
                Status = "Active",
                WaterMeterBefore = 0,
                ElectricityMeterBefore = 0,
                WaterMeterAfter = 0,
                ElectricityMeterAfter = 0,
                FlatTypeId = 2,
                BuildingId = 2,
                AvailableRoom = 0,
                AttributeForNumericId = 2
            },
            new Flat
            {
                FlatId = 4,
                Name = "Flat 4",
                Description = "Flat 4",
                Status = "NonActive",
                WaterMeterBefore = 0,
                ElectricityMeterBefore = 0,
                WaterMeterAfter = 0,
                ElectricityMeterAfter = 0,
                FlatTypeId = 5,
                BuildingId = 2,
                AttributeForNumericId = 1
            }
        );

        modelBuilder.Entity<Room>().HasData(
            new Room
            {
                RoomId = 1,
                RoomName = "Room 1 for flat 1",
                AvailableSlots = 2,
                RoomTypeId = 1,
                FlatId = 1
            },
            new Room
            {
                RoomId = 2,
                RoomName = "Room 1 for flat 3",
                AvailableSlots = 1,
                RoomTypeId = 1,
                FlatId = 3
            },
            new Room
            {
                RoomId = 3,
                RoomName = "Room 2 for flat 3",
                AvailableSlots = 2,
                RoomTypeId = 2,
                FlatId = 3
            },
            new Room
            {
                RoomId = 4,
                RoomName = "Room 3 for flat 3",
                AvailableSlots = 2,
                RoomTypeId = 3,
                FlatId = 3
            }
        );

        modelBuilder.Entity<RoomType>().HasData(
            new RoomType
            {
                RoomTypeId = 1,
                RoomTypeName = "Room type id 1 : 2 slots",
                Description = "Room type id 1 : 2 slots",
                NumberOfSlots = 2,
                BuildingId = 5
            },
            new RoomType
            {
                RoomTypeId = 2,
                RoomTypeName = "Room type id 2 : 2 slots",
                Description = "Room type id 2 : 2 slots",
                NumberOfSlots = 2,
                BuildingId = 5
            },
            new RoomType
            {
                RoomTypeId = 3,
                RoomTypeName = "Room type id 3 : 2 slots",
                Description = "Room type id 3 : 2 slots",
                NumberOfSlots = 2,
                BuildingId = 5
            }
        );

        modelBuilder.Entity<TicketType>().HasData(
            new TicketType
            {
                TicketTypeId = 1,
                TicketTypeName = "Sự cố",
                Description = "Sự cố",
                Status = true
            },
            new TicketType
            {
                TicketTypeId = 2,
                TicketTypeName = "Bảo trì",
                Description = "Bảo trì",
                Status = true
            },
            new TicketType
            {
                TicketTypeId = 3,
                TicketTypeName = "Phàn nàn",
                Description = "Phàn nàn",
                Status = true
            },
            new TicketType
            {
                TicketTypeId = 4,
                TicketTypeName = "Khác",
                Description = "Khác",
                Status = true
            }
        );

        modelBuilder.Entity<Ticket>().HasData(
            new Ticket
            {
                TicketId = 1,
                Description = "Sự cố 1",
                CreateDate = DateTime.UtcNow,
                Status = "Active",
                SolveDate = null,
                TicketTypeId = 1,
                AccountId = 2,
                ContractId = 3
            },
            new Ticket
            {
                TicketId = 2,
                Description = "Sự cố 2",
                CreateDate = DateTime.UtcNow,
                Status = "Processing",
                SolveDate = null,
                TicketTypeId = 2,
                AccountId = 2,
                ContractId = 3
            },
            new Ticket
            {
                TicketId = 3,
                Description = "Sự cố 3",
                CreateDate = DateTime.UtcNow,
                Status = "Completed",
                SolveDate = null,
                TicketTypeId = 3,
                AccountId = 2,
                ContractId = 3
            },
            new Ticket
            {
                TicketId = 4,
                Description = "Sự cố 4",
                CreateDate = DateTime.UtcNow,
                Status = "Active",
                SolveDate = null,
                TicketTypeId = 1,
                AccountId = 2,
                ContractId = 3
            }
        );

        modelBuilder.Entity<ServiceType>().HasData(
            new ServiceType
            {
                ServiceTypeId = 1,
                Name = "Nước",
                Status = "Active",
                BuildingId = 3
            },
            new ServiceType
            {
                ServiceTypeId = 2,
                Name = "Gas",
                Status = "Active",
                BuildingId = 3
            },
            new ServiceType
            {
                ServiceTypeId = 3,
                Name = "Điện",
                Status = "Active",
                BuildingId = 2
            },
            new ServiceType
            {
                ServiceTypeId = 4,
                Name = "Còn lại",
                Status = "Active",
                BuildingId = 2
            }
        );


        modelBuilder.Entity<ServiceEntity>().HasData(
            new ServiceEntity
            {
                ServiceId = 1,
                Name = "Cung cấp nước 1",
                Description = "Cung cấp nước 1",
                Status = true,
                Amount = 0,
                ServiceTypeId = 1,
                BuildingId = 2
            },
            new ServiceEntity
            {
                ServiceId = 2,
                Name = "Cung cấp nước 2",
                Description = "Cung cấp nước 2 ",
                Status = true,
                Amount = 0,
                ServiceTypeId = 1,
                BuildingId = 1
            },
            new ServiceEntity
            {
                ServiceId = 3,
                Name = "Cung cấp nước 3",
                Description = "Cung cấp nước 3",
                Status = true,
                Amount = 0,
                ServiceTypeId = 3,
                BuildingId = 3
            },
            new ServiceEntity
            {
                ServiceId = 4,
                Name = "Cung cấp 4 cho toa nha 3",
                Description = "Cung cấp 4 cho toa nha 3",
                Status = true,
                Amount = 0,
                ServiceTypeId = 2,
                BuildingId = 3
            }
            ,
            new ServiceEntity
            {
                ServiceId = 5,
                Name = "Cung cấp 5 cho toa nha 3",
                Description = "Cung cấp 5 cho toa nha 3",
                Status = true,
                Amount = 0,
                ServiceTypeId = 2,
                BuildingId = 3
            }
            ,
            new ServiceEntity
            {
                ServiceId = 6,
                Name = "Cung cấp 6 cho toa nha 3",
                Description = "Cung cấp 6 cho toa nha 3",
                Status = true,
                Amount = 0,
                ServiceTypeId = 2,
                BuildingId = 3
            }
        );

        modelBuilder.Entity<FeedbackType>().HasData(
            new FeedbackType
            {
                FeedbackTypeId = 1,
                Name = "Rating"
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

        modelBuilder.Entity<InvoiceType>().HasData(
            new InvoiceType
            {
                InvoiceTypeId = 1,
                Status = true,
                InvoiceTypeName = "Thu",
                InvoiceTypeIdWildCard = 1
            },
            new InvoiceType
            {
                InvoiceTypeId = 2,
                Status = true,
                InvoiceTypeName = "Chi",
                InvoiceTypeIdWildCard = 2
            }
        );

        modelBuilder.Entity<Invoice>().HasData(
            new Invoice
            {
                InvoiceId = 1,
                Name = "Hoá đơn điện tử cho renter 1",
                Amount = 0,
                Status = true,
                Detail = "Detail for invoice 1",
                CreatedTime = DateTime.UtcNow,
                RenterId = 1,
                AccountId = 2,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 2,
                Name = "Hoá đơn điện tử cho renter 2",
                Amount = 0,
                Status = true,
                Detail = "Detail for invoice 2",
                CreatedTime = DateTime.UtcNow,
                RenterId = 2,
                AccountId = 3,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 3,
                Name = "Hoá đơn điện tử cho renter 3",
                Amount = 0,
                Status = false,
                Detail = "Detail for invoice 3",
                CreatedTime = DateTime.UtcNow,
                RenterId = 3,
                AccountId = 4,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 4,
                Name = "Hoá đơn điện tử cho renter 3 (2)",
                Amount = 0,
                Status = false,
                Detail = "Detail for invoice 3 (2)",
                CreatedTime = DateTime.UtcNow,
                RenterId = 3,
                AccountId = 2,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 5,
                Name = "Hoá đơn điện tử cho renter 3 (3)",
                Amount = 0,
                Status = false,
                Detail = "Detail for invoice 3 (3)",
                CreatedTime = DateTime.UtcNow,
                RenterId = 3,
                AccountId = 2,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 6,
                Name = "Hoá đơn điện tử cho renter 3 (4)",
                Amount = 0,
                Status = true,
                Detail = "Detail for invoice 3 (4)",
                CreatedTime = DateTime.UtcNow,
                RenterId = 3,
                AccountId = 2,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 7,
                Name = "Hoá đơn điện tử cho renter 3 (5)",
                Amount = 0,
                Status = true,
                Detail = "Detail for invoice 3 (5)",
                CreatedTime = DateTime.UtcNow,
                RenterId = 3,
                AccountId = 2,
                InvoiceTypeId = 1
            }
        );

        modelBuilder.Entity<InvoiceDetail>().HasData(
            new InvoiceDetail
            {
                InvoiceDetailId = 1,
                InvoiceId = 1,
                Amount = 0,
                ServiceId = 1
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 2,
                InvoiceId = 1,
                Amount = 0,
                ServiceId = 2
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 3,
                InvoiceId = 1,
                Amount = 0
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 4,
                InvoiceId = 2,
                Amount = 0
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 5,
                InvoiceId = 4,
                Amount = 0,
                ServiceId = 4
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 6,
                InvoiceId = 4,
                Amount = 0,
                ServiceId = 4
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 7,
                InvoiceId = 5,
                Amount = 0,
                ServiceId = 4
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 8,
                InvoiceId = 5,
                Amount = 0,
                ServiceId = 5
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 9,
                InvoiceId = 5,
                Amount = 0,
                ServiceId = 5
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 10,
                InvoiceId = 6,
                Amount = 0,
                ServiceId = 6
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 11,
                InvoiceId = 6,
                Amount = 0,
                ServiceId = 5
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 12,
                InvoiceId = 6,
                Amount = 0,
                ServiceId = 6
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 13,
                InvoiceId = 7,
                Amount = 0,
                ServiceId = 3
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 14,
                InvoiceId = 7,
                Amount = 0,
                ServiceId = 3
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 15,
                InvoiceId = 7,
                Amount = 0,
                ServiceId = 4
            },
            new InvoiceDetail
            {
                InvoiceDetailId = 16,
                InvoiceId = 7,
                Amount = 0,
                ServiceId = 5
            }
        );

        modelBuilder.Entity<Contract>()
            .HasData(
                new Contract
                {
                    ContractId = 1,
                    ContractName = "Contract for renter 1",
                    DateSigned = DateTime.UtcNow - TimeSpan.FromDays(30),
                    StartDate = DateTime.UtcNow - TimeSpan.FromDays(25),
                    EndDate = null,
                    LastUpdated = DateTime.UtcNow,
                    ContractStatus = "Active",
                    PriceForRent = 1800000,
                    RenterId = 1,
                    BuildingId = 1,
                    Description = "Contract description for renter 1",
                    ImageUrl = "No image",
                    FlatId = 2,
                    RoomId = 1
                },
                new Contract
                {
                    ContractId = 2,
                    ContractName = "Contract for renter 2",
                    DateSigned = DateTime.UtcNow - TimeSpan.FromDays(29),
                    StartDate = DateTime.UtcNow - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.UtcNow,
                    ContractStatus = "Active",
                    PriceForRent = 2800000,
                    RenterId = 2,
                    BuildingId = 2,
                    Description = "Contract description for renter 2",
                    ImageUrl = "No image",
                    FlatId = 3,
                    RoomId = 1
                },
                new Contract
                {
                    ContractId = 3,
                    ContractName = "Contract for renter 3",
                    DateSigned = DateTime.UtcNow - TimeSpan.FromDays(29),
                    StartDate = DateTime.UtcNow - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.UtcNow,
                    ContractStatus = "Active",
                    PriceForRent = 2800000,
                    PriceForService = 10000,
                    PriceForWater = 1000,
                    PriceForElectricity = 120,
                    RenterId = 3,
                    BuildingId = 3,
                    Description = "Contract description for renter 3",
                    ImageUrl = "No image",
                    FlatId = 3,
                    RoomId = 2
                },
                new Contract
                {
                    ContractId = 4,
                    ContractName = "Contract for renter 3 (2)",
                    DateSigned = DateTime.UtcNow - TimeSpan.FromDays(29),
                    StartDate = DateTime.UtcNow - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.UtcNow,
                    ContractStatus = "Active",
                    PriceForRent = 2800000,
                    PriceForService = 10000,
                    PriceForWater = 1000,
                    PriceForElectricity = 120,
                    RenterId = 3,
                    BuildingId = 3,
                    Description = "Contract description for renter 3",
                    ImageUrl = "No image",
                    FlatId = 4,
                    RoomId = 1
                },
                new Contract
                {
                    ContractId = 5,
                    ContractName = "Contract for renter 3 (3)",
                    DateSigned = DateTime.UtcNow - TimeSpan.FromDays(29),
                    StartDate = DateTime.UtcNow - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.UtcNow,
                    ContractStatus = "Inactive",
                    PriceForRent = 2800000,
                    PriceForService = 10000,
                    PriceForWater = 1000,
                    PriceForElectricity = 120,
                    RenterId = 3,
                    BuildingId = 3,
                    Description = "Contract description for renter 3",
                    ImageUrl = "No image",
                    FlatId = 3,
                    RoomId = 2
                },
                new Contract
                {
                    ContractId = 6,
                    ContractName = "Contract for renter 3 (4)",
                    DateSigned = DateTime.UtcNow - TimeSpan.FromDays(29),
                    StartDate = DateTime.UtcNow - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.UtcNow,
                    ContractStatus = "Inactive",
                    PriceForRent = 2800000,
                    PriceForService = 10000,
                    PriceForWater = 1000,
                    PriceForElectricity = 120,
                    RenterId = 3,
                    BuildingId = 3,
                    Description = "Contract description for renter 3",
                    ImageUrl = "No image",
                    FlatId = 3,
                    RoomId = 2
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