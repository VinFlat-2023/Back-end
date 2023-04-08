using System.Globalization;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<Area> Areas { get; set; } = null!;
    public virtual DbSet<Building> Buildings { get; set; } = null!;
    public virtual DbSet<Contract> Contracts { get; set; } = null!;
    public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
    public virtual DbSet<FeedbackType> FeedbackTypes { get; set; } = null!;
    public virtual DbSet<Flat> Flats { get; set; } = null!;
    public virtual DbSet<FlatType> FlatTypes { get; set; } = null!;
    public virtual DbSet<Invoice> Invoices { get; set; } = null!;
    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
    public virtual DbSet<InvoiceType> InvoiceTypes { get; set; } = null!;
    public virtual DbSet<Renter> Renters { get; set; } = null!;
    public virtual DbSet<Ticket> Tickets { get; set; } = null!;
    public virtual DbSet<TicketType> TicketTypes { get; set; } = null!;
    public virtual DbSet<Role> Roles { get; set; } = null!;
    public virtual DbSet<ServiceEntity> Services { get; set; } = null!;
    public virtual DbSet<ServiceType> ServiceTypes { get; set; } = null!;
    public virtual DbSet<Wallet> Wallets { get; set; } = null!;
    public virtual DbSet<WalletType> WalletTypes { get; set; } = null!;
    public virtual DbSet<Transaction> Transactions { get; set; } = null!;
    public virtual DbSet<UserDevice> UserDevices { get; set; } = null!;
    public virtual DbSet<Notification> Notifications { get; set; } = null!;
    public virtual DbSet<NotificationType> NotificationTypes { get; set; } = null!;
    public virtual DbSet<Room> Rooms { get; set; } = null!;
    public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;

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

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.Username)
                .IsUnique();
            entity.HasIndex(e => e.Email)
                .IsUnique();
        });


        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                FullName = "supervisor 31",
                Username = "sup1",
                Password = "123",
                Email = "sup13@mail",
                Phone = "0123543423125",
                Status = true,
                RoleId = 2,
                Address = "Sup1 address"
            },
            new Employee
            {
                EmployeeId = 2,
                Username = "supervisor 24",
                FullName = "sup2",
                Password = "123",
                Email = "sup21@mail",
                Phone = "012354353432",
                Status = true,
                RoleId = 2,
                Address = "Sup2 address"
            },
            new Employee
            {
                EmployeeId = 3,
                Username = "supervisor",
                FullName = "sup3",
                Password = "supervisor",
                Email = "supervisor32@mail",
                Phone = "012354433554",
                Status = true,
                RoleId = 2,
                Address = "Sup3 address"
            },
            new Employee
            {
                EmployeeId = 4,
                Username = "supervisor 4",
                FullName = "sup4",
                Password = "123",
                Email = "employee211@mail",
                Phone = "012323543235",
                Status = true,
                RoleId = 2,
                Address = "Sup4 address"
            },
            new Employee
            {
                EmployeeId = 5,
                Username = "supervisor 5",
                FullName = "sup5",
                Password = "123",
                Email = "employee233@mail",
                Phone = "043123123235",
                Status = true,
                RoleId = 2,
                Address = "Sup5 address"
            },
            new Employee
            {
                EmployeeId = 6,
                Username = "supervisor 6",
                FullName = "sup6",
                Password = "123",
                Email = "employee232@mail",
                Phone = "012312323235",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 7,
                Username = "admin",
                FullName = "Admin account",
                Password = "admin",
                Email = "admin12@mail",
                Phone = "012343123235",
                Status = true,
                RoleId = 1,
                Address = "Admin address"
            }
        );

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Status = true,
                RoleId = 1,
                RoleName = "Admin"
            },
            new Role
            {
                Status = true,
                RoleId = 2,
                RoleName = "Supervisor"
            },
            new Role
            {
                Status = true,
                RoleId = 3,
                RoleName = "Technician"
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
                Email = "renter1@mail.com",
                Password = "renter1",
                Phone = "0123543125",
                FullName = "Nguyen Van A",
                BirthDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
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
                BirthDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
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
                BirthDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                Status = true,
                CitizenNumber = "3214324523",
                Address = "DN",
                Gender = "Female",
                DeviceToken = "123221ad145ad423sa"
            }, new Renter
            {
                RenterId = 4,
                Username = "renter4",
                Email = "renter4@mail.com",
                Password = "renter4",
                Phone = "0123543125",
                FullName = "Nguyen Van D",
                BirthDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                Status = true,
                CitizenNumber = "3214324523",
                Address = "HN",
                Gender = "Female",
                DeviceToken = "ewasdv12344"
            }, new Renter
            {
                RenterId = 5,
                Username = "minhkhoi10a3",
                Email = "trankhaimnhkhoi10a3@mail.com",
                Password = "123456789",
                Phone = "0123543125",
                FullName = "Tran Minh Khoi",
                BirthDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                Status = true,
                CitizenNumber = "3214324523",
                Address = "HCM",
                Gender = "Male",
                DeviceToken = "ewasdv12344"
            }, new Renter
            {
                RenterId = 6,
                Username = "minhkhoi",
                Email = "trankhaimnhkhoi@mail.com",
                Password = "123456789",
                Phone = "0123543125",
                FullName = "Tran Minh Khoi",
                BirthDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                Status = true,
                CitizenNumber = "3214324523",
                Address = "HCM",
                Gender = "Male",
                DeviceToken = "ewasdv12344"
            }, new Renter
            {
                RenterId = 7,
                Username = "minhkhoitkm",
                Email = "khoitkmse150850@fpt",
                Password = "123456789",
                Phone = "0123543125",
                FullName = "Tran Minh Khoi",
                BirthDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                Status = true,
                CitizenNumber = "3214324523",
                Address = "HCM",
                Gender = "Male",
                DeviceToken = "ewasdv12344"
            }
        );

        modelBuilder.Entity<Area>().HasData(
            new Area
            {
                AreaId = 1,
                Name = "Quận 1",
                Location = "HCM",
                Status = true,
                ImageUrl =
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/PANO0002-Pano.jpg/1200px-PANO0002-Pano.jpg"
            },
            new Area
            {
                AreaId = 2,
                Name = "Quận 2",
                Location = "HCM",
                Status = true,
                ImageUrl =
                    "https://i1-vnexpress.vnecdn.net/2022/11/17/Ve-may-bay-di-sai-gon-600x399-4356-2813-1668672299.jpg?w=0&h=0&q=100&dpr=2&fit=crop&s=8All1Mq-so56XkVbZXvdFA"
            },
            new Area
            {
                AreaId = 3,
                Name = "Quận 3",
                Location = "HCM",
                Status = true,
                ImageUrl =
                    "https://images.pexels.com/photos/11742806/pexels-photo-11742806.jpeg?cs=srgb&dl=pexels-th%E1%BB%8Bnh-la-11742806.jpg&fm=jpg"
            },
            new Area
            {
                AreaId = 4,
                Name = "Quận 9",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 5,
                Name = "Quận Phú Nhuận",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 6,
                Name = "Quận 7",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 7,
                Name = "Quận 8",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 8,
                Name = "Quận 1",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
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
                EmployeeId = 1,
                ImageUrl = "https://vinflat.blob.core.windows.net/building-image/6716250e-8169-446d-a54e-37094c30ae70thumbnail-202303031027054744.jpg",
                BuildingAddress = "Quận 9",
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
                EmployeeId = 2,
                ImageUrl = "https://vinflat.blob.core.windows.net/building-image/be39f244-45d1-48cc-94dc-7e1b138caa3athumbnail-202302251636284394.jpg",
                BuildingAddress = "Quận 9",
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
                EmployeeId = 3,
                ImageUrl = "https://vinflat.blob.core.windows.net/building-image/8a8ea225-ea25-422c-a20d-299c7ed42456thumbnail-202302041627581789.jpg",
                BuildingAddress = "Quận 2",
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
                EmployeeId = 4,
                ImageUrl = "https://vinflat.blob.core.windows.net/building-image/69d0767f-ff29-49dc-88fc-c3bc87cba986thumbnail-202212291740189478.jpg",
                BuildingAddress = "Quận 3",
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
                AreaId = 2,
                EmployeeId = 5,
                ImageUrl = "https://vinflat.blob.core.windows.net/building-image/a3f9897c-800e-4d5e-92b7-e388eefdf64bthumbnail-202212151636139810.jpg",
                BuildingAddress = "Quận 4",
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
                EmployeeId = 6,
                ImageUrl = "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 7",
                BuildingPhoneNumber = "012323123"
            }
        );

        modelBuilder.Entity<FlatType>().HasData(
            new FlatType
            {
                FlatTypeId = 1,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 10,
                Status = true,
                BuildingId = 5
            },
            new FlatType
            {
                FlatTypeId = 2,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 2,
                Status = true,
                BuildingId = 5
            },
            new FlatType
            {
                FlatTypeId = 3,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 4,
                Status = true,
                BuildingId = 5
            },
            new FlatType
            {
                FlatTypeId = 4,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 5,
                Status = true,
                BuildingId = 5
            },
            new FlatType
            {
                FlatTypeId = 5,
                FlatTypeName = "AAAAAAAA",
                RoomCapacity = 6,
                Status = true,
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
                BuildingId = 1
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
                BuildingId = 3
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
                AvailableRoom = 0
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
                BuildingId = 2
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
                CreateDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                Status = "Active",
                SolveDate = null,
                TicketTypeId = 1,
                EmployeeId = 2,
                ContractId = 3
            },
            new Ticket
            {
                TicketId = 2,
                Description = "Sự cố 2",
                CreateDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                Status = "Processing",
                SolveDate = null,
                TicketTypeId = 2,
                EmployeeId = 2,
                ContractId = 3
            },
            new Ticket
            {
                TicketId = 3,
                Description = "Sự cố 3",
                CreateDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                Status = "Completed",
                SolveDate = null,
                TicketTypeId = 3,
                EmployeeId = 2,
                ContractId = 3
            },
            new Ticket
            {
                TicketId = 4,
                Description = "Sự cố 4",
                CreateDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                Status = "Active",
                SolveDate = null,
                TicketTypeId = 1,
                EmployeeId = 2,
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
                CreatedTime = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                RenterId = 1,
                EmployeeId = 2,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 2,
                Name = "Hoá đơn điện tử cho renter 2",
                Amount = 0,
                Status = true,
                Detail = "Detail for invoice 2",
                CreatedTime = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                RenterId = 2,
                EmployeeId = 3,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 3,
                Name = "Hoá đơn điện tử cho renter 3",
                Amount = 0,
                Status = false,
                Detail = "Detail for invoice 3",
                CreatedTime = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                RenterId = 3,
                EmployeeId = 4,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 4,
                Name = "Hoá đơn điện tử cho renter 3 (2)",
                Amount = 0,
                Status = false,
                Detail = "Detail for invoice 3 (2)",
                CreatedTime = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                RenterId = 3,
                EmployeeId = 2,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 5,
                Name = "Hoá đơn điện tử cho renter 3 (3)",
                Amount = 0,
                Status = false,
                Detail = "Detail for invoice 3 (3)",
                CreatedTime = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                RenterId = 3,
                EmployeeId = 2,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 6,
                Name = "Hoá đơn điện tử cho renter 3 (4)",
                Amount = 0,
                Status = true,
                Detail = "Detail for invoice 3 (4)",
                CreatedTime = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                RenterId = 3,
                EmployeeId = 2,
                InvoiceTypeId = 1
            },
            new Invoice
            {
                InvoiceId = 7,
                Name = "Hoá đơn điện tử cho renter 3 (5)",
                Amount = 0,
                Status = true,
                Detail = "Detail for invoice 3 (5)",
                CreatedTime = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    "dd/MM/yyyy HH:mm:ss", null),
                RenterId = 3,
                EmployeeId = 2,
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
                    DateSigned = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(30),
                    StartDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(25),
                    EndDate = null,
                    LastUpdated = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null),
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
                    DateSigned = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(29),
                    StartDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null),
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
                    DateSigned = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(29),
                    StartDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null),
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
                    DateSigned = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(29),
                    StartDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null),
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
                    DateSigned = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(29),
                    StartDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null),
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
                    DateSigned = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(29),
                    StartDate = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null) - TimeSpan.FromDays(27),
                    EndDate = null,
                    LastUpdated = DateTime.ParseExact(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                        "dd/MM/yyyy HH:mm:ss", null),
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