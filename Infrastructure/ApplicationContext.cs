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
                FullName = "Bình Linh",
                Username = "sup1",
                Password = "123456",
                Email = "binhlinh@mail",
                Phone = "0912345678",
                Status = true,
                RoleId = 2,
                Address = "Sup1 address"
            },
            new Employee
            {
                EmployeeId = 2,
                Username = "sup2",
                FullName = "Thoa Hy",
                Password = "123456",
                Email = "thoahy@mail",
                Phone = "0923456789",
                Status = true,
                RoleId = 2,
                Address = "Sup2 address"
            },
            new Employee
            {
                EmployeeId = 3,
                Username = "Khôi Huy",
                FullName = "sup3",
                Password = "123456",
                Email = "khoihuy@mail",
                Phone = "0812345678",
                Status = true,
                RoleId = 2,
                Address = "Sup3 address"
            },
            new Employee
            {
                EmployeeId = 4,
                Username = "sup4",
                FullName = "Nga Châu",
                Password = "123456",
                Email = "ngachau@mail",
                Phone = "0823456789",
                Status = true,
                RoleId = 2,
                Address = "Sup4 address"
            },
            new Employee
            {
                EmployeeId = 5,
                Username = "sup5",
                FullName = "Ngọc Huy",
                Password = "123456",
                Email = "ngochuy@mail",
                Phone = "0834567890",
                Status = true,
                RoleId = 2,
                Address = "Sup5 address"
            },
            new Employee
            {
                EmployeeId = 6,
                Username = "sup6",
                FullName = "Ngà Sơn",
                Password = "123",
                Email = "ngason@mail",
                Phone = "0712345678",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 7,
                Username = "admin",
                FullName = "Thư Minh",
                Password = "123456",
                Email = "thuminh@mail",
                Phone = "0723456789",
                Status = true,
                RoleId = 1,
                Address = "Admin address"
            },
            new Employee
            {
                EmployeeId = 8,
                Username = "sup7",
                FullName = "Minh Anh",
                Password = "123456",
                Email = "minhanh123@mail",
                Phone = "0723567890",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 9,
                Username = "sup8",
                FullName = "Minh Ngọc",
                Password = "123456",
                Email = "minhngon@mail",
                Phone = "0913456324",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 10,
                Username = "sup9",
                FullName = "Mạnh Khoa",
                Password = "123456",
                Email = "manhkhoa@mail",
                Phone = "0942184853",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 11,
                Username = "sup10",
                FullName = "Khang Ngọc",
                Password = "123456",
                Email = "khangngoc@mail",
                Phone = "0234328589",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 12,
                Username = "sup11",
                FullName = "Hoàng Minh",
                Password = "123456",
                Email = "hoangminh@mail",
                Phone = "0482138128",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 13,
                Username = "sup12",
                FullName = "An Khang",
                Password = "123456",
                Email = "ankhang@mail",
                Phone = "0763125422",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 14,
                Username = "sup13",
                FullName = "Trang Hoà",
                Password = "123456",
                Email = "tranghoa@mail",
                Phone = "0358438539",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 15,
                Username = "sup14",
                FullName = "Minh Tính",
                Password = "123456",
                Email = "minhtinh@mail",
                Phone = "0429215737",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 16,
                Username = "sup15",
                FullName = "Tiên Hoàng",
                Password = "123456",
                Email = "tienhoang@mail",
                Phone = "0582021245",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 17,
                Username = "sup16",
                FullName = "Thanh Hoa",
                Password = "123456",
                Email = "thanhhoa032@mail",
                Phone = "0984271626",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 18,
                Username = "sup17",
                FullName = "Ngà Sơn",
                Password = "123",
                Email = "ngason234@mail",
                Phone = "012312323235",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 19,
                Username = "sup18",
                FullName = "Hoàng Thoa",
                Password = "123",
                Email = "hoangthao@mail",
                Phone = "0932441829",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 20,
                Username = "sup19",
                FullName = "Minh Nghi",
                Password = "123456",
                Email = "minhnghi@mail",
                Phone = "0490238588",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 21,
                Username = "sup20",
                FullName = "Mạnh Hùng",
                Password = "123456",
                Email = "manhhung@mail",
                Phone = "0943573182",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 22,
                Username = "sup21",
                FullName = "Hương Tràm",
                Password = "123456",
                Email = "huongtram@mail",
                Phone = "0984372814",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 23,
                Username = "sup24",
                FullName = "Minh Hoàng",
                Password = "123456",
                Email = "minhhoang@mail",
                Phone = "0958214539",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 24,
                Username = "sup25",
                FullName = "Hoàng Thanh",
                Password = "123456",
                Email = "hoangthanh12@mail",
                Phone = "012312323235",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 25,
                Username = "sup26",
                FullName = "Anh Tú",
                Password = "123456",
                Email = "anhtu@mail",
                Phone = "0943783365",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 26,
                Username = "sup27",
                FullName = "Anh Hùng",
                Password = "123456",
                Email = "anhhung@mail",
                Phone = "0913683923",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 27,
                Username = "sup28",
                FullName = "Khánh Huy",
                Password = "123456",
                Email = "khanhhuy32@mail",
                Phone = "0942812643",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 28,
                Username = "sup29",
                FullName = "Vinh Hưng",
                Password = "123456",
                Email = "vinhhung@mail",
                Phone = "012312323235",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 29,
                Username = "sup30",
                FullName = "Khang Trung",
                Password = "123456",
                Email = "khangtrung@mail",
                Phone = "0918238483",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 30,
                Username = "sup31",
                FullName = "Trang Huyền",
                Password = "123456",
                Email = "tranghuyen123@mail",
                Phone = "0984271544",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 31,
                Username = "sup32",
                FullName = "Hà Trang",
                Password = "123456",
                Email = "hatrang4@mail",
                Phone = "0384943481",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 32,
                Username = "sup33",
                FullName = "Sơn Hà",
                Password = "123456",
                Email = "sonha3@mail",
                Phone = "0938772581",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 33,
                Username = "sup34",
                FullName = "Ngưu Sơn",
                Password = "123456",
                Email = "nguuson32@mail",
                Phone = "0485245513",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 34,
                Username = "sup35",
                FullName = "Thúy Sơn",
                Password = "123456",
                Email = "thuyson32@mail",
                Phone = "0947327121",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 35,
                Username = "sup36",
                FullName = "Thanh Hồ",
                Password = "123456",
                Email = "thanhho13@mail",
                Phone = "0942837429",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 36,
                Username = "sup37",
                FullName = "Quang Huy",
                Password = "123456",
                Email = "quanghuy29@mail",
                Phone = "0947291723",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 37,
                Username = "sup38",
                FullName = "Khánh Trâm",
                Password = "123456",
                Email = "khanhtram32@mail",
                Phone = "0938271525",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 38,
                Username = "sup39",
                FullName = "Sơn Trang",
                Password = "123456",
                Email = "sontrang12@mail",
                Phone = "0948271626",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 39,
                Username = "sup40",
                FullName = "Minh Lâm",
                Password = "123456",
                Email = "minhlam23@mail",
                Phone = "0942647123",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 40,
                Username = "sup41",
                FullName = "Hằng Sương",
                Password = "123456",
                Email = "hangsuong23@mail",
                Phone = "0928367325",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 41,
                Username = "sup42",
                FullName = "Uyên Chi",
                Password = "123456",
                Email = "uyenchi47@mail",
                Phone = "0975383282",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 42,
                Username = "sup43",
                FullName = "Lâm Toàn",
                Password = "123456",
                Email = "lamtoan12@mail",
                Phone = "0942537435",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 43,
                Username = "sup44",
                FullName = "Minh Toàn",
                Password = "123456",
                Email = "minhtoan@mail",
                Phone = "0938243827",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 44,
                Username = "sup45",
                FullName = "Nhâm Sơn",
                Password = "123456",
                Email = "nhamson@mail",
                Phone = "0837243827",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 45,
                Username = "sup46",
                FullName = "Sơn Kim",
                Password = "123456",
                Email = "sonkim432@mail",
                Phone = "0947348292",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 46,
                Username = "sup47",
                FullName = "Kim Tiền",
                Password = "123456",
                Email = "kimtien32@mail",
                Phone = "0847342789",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 47,
                Username = "sup48",
                FullName = "Tiến Kim",
                Password = "123456",
                Email = "tienkim384@mail",
                Phone = "012312323235",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 48,
                Username = "sup49",
                FullName = "Mạnh Sơn",
                Password = "123456",
                Email = "manhson292@mail",
                Phone = "0485838261",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            },
            new Employee
            {
                EmployeeId = 49,
                Username = "sup50",
                FullName = "Long Hương",
                Password = "123456",
                Email = "longhuong12@mail",
                Phone = "0749274839",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
            }, new Employee
            {
                EmployeeId = 50,
                Username = "sup51",
                FullName = "Nhân Trọng",
                Password = "123456",
                Email = "nhantrong25@mail",
                Phone = "0984028345",
                Status = true,
                RoleId = 2,
                Address = "Employee address"
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
                DeviceToken = "123221ad145ad423sa"
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
                DeviceToken = "ewasdv12344"
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
                DeviceToken = "ewasdv12344"
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
                DeviceToken = "ewasdv12344"
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
                Name = "Quận 4",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 5,
                Name = "Quận 5",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 6,
                Name = "Quận 6",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 7,
                Name = "Quận 7",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 8,
                Name = "Quận 8",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 9,
                Name = "Quận 9",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            },
            new Area
            {
                AreaId = 10,
                Name = "Quận 10",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 11,
                Name = "Quận 11",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 12,
                Name = "Quận 12",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 13,
                Name = "Quận Bình Thạnh",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 14,
                Name = "Quận Gò Vấp",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 15,
                Name = "Quận Phú Nhuận",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 16,
                Name = "Quận Tân Bình",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 17,
                Name = "Quận Tân Phú",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 18,
                Name = "Quận Bình Tân",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 19,
                Name = "Quận Nhà Bè",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 20,
                Name = "Quận Hóc Môn",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 21,
                Name = "Quận Củ Chi",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 22,
                Name = "Quận Cần Giờ",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 23,
                Name = "Quận Bình Chánh",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }, new Area
            {
                AreaId = 24,
                Name = "Quận Thủ Đức",
                Location = "HCM",
                Status = true,
                ImageUrl = ""
            }
        );

        modelBuilder.Entity<Building>().HasData(
            new Building
            {
                BuildingId = 1,
                BuildingName = "Building 1 quận 1",
                Description = "Building 1 quận 1",
                Status = true,
                CoordinateX = 231,
                CoordinateY = 324,
                AreaId = 1,
                EmployeeId = 1,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/6716250e-8169-446d-a54e-37094c30ae70thumbnail-202303031027054744.jpg",
                BuildingAddress = "Quận 1",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 2500000
            },
            new Building
            {
                BuildingId = 2,
                BuildingName = "Building 2 quận 1",
                Description = "Building 2 quận 1",
                Status = true,
                CoordinateX = 21233,
                CoordinateY = 334,
                AreaId = 1,
                EmployeeId = 2,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/be39f244-45d1-48cc-94dc-7e1b138caa3athumbnail-202302251636284394.jpg",
                BuildingAddress = "Quận 1",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 2600000
            },
            new Building
            {
                BuildingId = 3,
                BuildingName = "Building 1 quận 2",
                Description = "Building 1 quận 2",
                Status = true,
                CoordinateX = 423,
                CoordinateY = 3214,
                AreaId = 2,
                EmployeeId = 3,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/8a8ea225-ea25-422c-a20d-299c7ed42456thumbnail-202302041627581789.jpg",
                BuildingAddress = "Quận 2",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 3500000
            },
            new Building
            {
                BuildingId = 4,
                BuildingName = "Building 2 quận 2",
                Description = "Building 2 quận 2",
                Status = true,
                CoordinateX = 2323,
                CoordinateY = 314,
                AreaId = 2,
                EmployeeId = 4,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/69d0767f-ff29-49dc-88fc-c3bc87cba986thumbnail-202212291740189478.jpg",
                BuildingAddress = "Quận 2",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 4500000
            },
            new Building
            {
                BuildingId = 5,
                BuildingName = "Building 1 quận 3",
                Description = "Building 1 quận 3",
                Status = true,
                CoordinateX = 23431,
                CoordinateY = 3245,
                AreaId = 3,
                EmployeeId = 5,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a3f9897c-800e-4d5e-92b7-e388eefdf64bthumbnail-202212151636139810.jpg",
                BuildingAddress = "Quận 3",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 4600000
            },
            new Building
            {
                BuildingId = 6,
                BuildingName = "Building 2 quận 3",
                Description = "Building 2 quận 3",
                Status = true,
                CoordinateX = 21233,
                CoordinateY = 334,
                AreaId = 3,
                EmployeeId = 6,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 3",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            },
            new Building
            {
                BuildingId = 7,
                BuildingName = "Building 1 quận 4",
                Description = "Building 1 quận 4",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 4,
                EmployeeId = 8,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 4",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            },
            new Building
            {
                BuildingId = 8,
                BuildingName = "Building 2 quận 4",
                Description = "Building 2 quận 4",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 4,
                EmployeeId = 9,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 4",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            },
            new Building
            {
                BuildingId = 9,
                BuildingName = "Building 1 quận 5",
                Description = "Building 1 quận 5",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 5,
                EmployeeId = 10,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 5",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 10,
                BuildingName = "Building 2 quận 5",
                Description = "Building 2 quận 5",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 5,
                EmployeeId = 11,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 5",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 11,
                BuildingName = "Building 1 quận 6",
                Description = "Building 1 quận 6",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 6,
                EmployeeId = 12,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 6",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 12,
                BuildingName = "Building 2 quận 6",
                Description = "Building 2 quận 6",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 6,
                EmployeeId = 13,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 6",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 13,
                BuildingName = "Building 1 quận 7",
                Description = "Building 1 quận 7",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 7,
                EmployeeId = 14,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 7",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 14,
                BuildingName = "Building 2 quận 7",
                Description = "Building 2 quận 7",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 7,
                EmployeeId = 15,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 7",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 15,
                BuildingName = "Building 1 quận 8",
                Description = "Building 1 quận 8",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 8,
                EmployeeId = 16,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 8",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 16,
                BuildingName = "Building 2 quận 8",
                Description = "Building 2 quận 8",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 8,
                EmployeeId = 17,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 8",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 17,
                BuildingName = "Building 1 quận 9",
                Description = "Building 1 quận 9",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 9,
                EmployeeId = 18,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 9",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 18,
                BuildingName = "Building 2 quận 9",
                Description = "Building 2 quận 9",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 9,
                EmployeeId = 19,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 9",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 19,
                BuildingName = "Building 1 quận 10",
                Description = "Building 1 quận 10",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 10,
                EmployeeId = 20,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 9",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 20,
                BuildingName = "Building 2 quận 10",
                Description = "Building 2 quận 10",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 10,
                EmployeeId = 21,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 10",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 21,
                BuildingName = "Building 1 quận 11",
                Description = "Building 1 quận 11",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 11,
                EmployeeId = 22,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 10",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 22,
                BuildingName = "Building 2 quận 11",
                Description = "Building 2 quận 11",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 11,
                EmployeeId = 23,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 11",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 23,
                BuildingName = "Building 1 quận 12",
                Description = "Building 1 quận 12",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 12,
                EmployeeId = 24,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 12",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 24,
                BuildingName = "Building 2 quận 12",
                Description = "Building 2 quận 12",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 12,
                EmployeeId = 25,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 12",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 25,
                BuildingName = "Building 1 quận Bình Thạnh",
                Description = "Building 1 quận Bình Thạnh",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 13,
                EmployeeId = 26,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Bình Thạnh",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 26,
                BuildingName = "Building 2 quận Bình Thanh",
                Description = "Building 2 quận Bình Thanh",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 13,
                EmployeeId = 27,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Bình Thanh",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 27,
                BuildingName = "Building 1 quận Gò Vấp",
                Description = "Building 1 quận Gò Vấp",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 14,
                EmployeeId = 28,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 3",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 28,
                BuildingName = "Building 1 quận Gò Vấp",
                Description = "Building 1 quận Gò Vấp",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 14,
                EmployeeId = 29,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 3",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 29,
                BuildingName = "Building 1 quận Phú Nhuận",
                Description = "Building 1 quận Phú Nhuận",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 15,
                EmployeeId = 30,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Phú Nhuận",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 30,
                BuildingName = "Building 2 quận Phú Nhuận",
                Description = "Building 2 quận Phú Nhuận",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 15,
                EmployeeId = 31,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Phú Nhuận",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 31,
                BuildingName = "Building 1 quận Tân Bình",
                Description = "Building 1 quận Tân Bình",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 16,
                EmployeeId = 32,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Tân Bình",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            ,
            new Building
            {
                BuildingId = 32,
                BuildingName = "Building 2 quận Tân Bình",
                Description = "Building 2 quận Tân Bình",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 16,
                EmployeeId = 33,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Tân Bình",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 33,
                BuildingName = "Building 1 quận Tân Phú",
                Description = "Building 1 quận Tân Phú",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 17,
                EmployeeId = 34,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Tân Phú",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            },
            new Building
            {
                BuildingId = 34,
                BuildingName = "Building 2 quận Tân Phú",
                Description = "Building 2 quận Tân Phú",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 17,
                EmployeeId = 35,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Tân Phú",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 35,
                BuildingName = "Building 1 quận Bình Tân",
                Description = "Building 1 quận Bình Tân",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 18,
                EmployeeId = 36,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Bình Tân",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 36,
                BuildingName = "Building 2 quận Bình Tân",
                Description = "Building 2 quận Bình Tân",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 18,
                EmployeeId = 37,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Bình Tân",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 37,
                BuildingName = "Building 1 quận Nhà Bè",
                Description = "Building 1 quận Nhà Bè",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 19,
                EmployeeId = 38,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận 3",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 38,
                BuildingName = "Building 2 quận Nhà Bè",
                Description = "Building 2 quận Nhà Bè",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 19,
                EmployeeId = 39,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Nhà Bè",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 39,
                BuildingName = "Building 1 quận Hóc Môn",
                Description = "Building 1 quận Hóc Môn",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 20,
                EmployeeId = 40,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Hóc Môn",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 40,
                BuildingName = "Building 2 quận Hóc Môn",
                Description = "Building 2 quận Hóc Môn",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 20,
                EmployeeId = 41,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Hóc Môn",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 41,
                BuildingName = "Building 1 quận Củ Chi",
                Description = "Building 1 quận Củ Chi",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 21,
                EmployeeId = 42,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Củ Chi",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 42,
                BuildingName = "Building 2 quận Củ Chi",
                Description = "Building 2 quận Củ Chi",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 21,
                EmployeeId = 43,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Củ Chi",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 43,
                BuildingName = "Building 1 quận Cần Giờ",
                Description = "Building 1 quận Cần Giờ",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 22,
                EmployeeId = 44,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Cần Giờ",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }
            , new Building
            {
                BuildingId = 44,
                BuildingName = "Building 2 quận Cần Giờ",
                Description = "Building 2 quận Cần Giờ",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 22,
                EmployeeId = 45,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Cần Giờ",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            },
            new Building
            {
                BuildingId = 45,
                BuildingName = "Building 1 quận Bình Chánh",
                Description = "Building 1 quận Bình Chánh",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 23,
                EmployeeId = 46,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Bình Chánh",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }, new Building
            {
                BuildingId = 46,
                BuildingName = "Building 2 quận Bình Chánh",
                Description = "Building 2 quận Bình Chánh",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 23,
                EmployeeId = 47,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Bình Chánh",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            },
            new Building
            {
                BuildingId = 47,
                BuildingName = "Building 1 quận Thủ Đức",
                Description = "Building 1 quận Thủ Đức",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 24,
                EmployeeId = 46,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Thủ Đức",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
            }, new Building
            {
                BuildingId = 48,
                BuildingName = "Building 2 quận Thủ Đức",
                Description = "Building 2 quận Thủ Đức",
                Status = true,
                CoordinateX = 212333,
                CoordinateY = 3344,
                AreaId = 24,
                EmployeeId = 47,
                ImageUrl =
                    "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg",
                BuildingAddress = "Quận Thủ Đức",
                BuildingPhoneNumber = "012323123",
                AveragePrice = 5300000
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
                CreateDate = DateTime.UtcNow,
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
                CreateDate = DateTime.UtcNow,
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
                CreateDate = DateTime.UtcNow,
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
                CreateDate = DateTime.UtcNow,
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
                CreatedTime = DateTime.UtcNow,
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
                CreatedTime = DateTime.UtcNow,
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
                CreatedTime = DateTime.UtcNow,
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
                CreatedTime = DateTime.UtcNow,
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
                CreatedTime = DateTime.UtcNow,
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
                CreatedTime = DateTime.UtcNow,
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
                CreatedTime = DateTime.UtcNow,
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